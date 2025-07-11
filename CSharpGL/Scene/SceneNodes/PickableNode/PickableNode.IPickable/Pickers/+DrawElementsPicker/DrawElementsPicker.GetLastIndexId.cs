﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpGL {
    // check http://www.cnblogs.com/bitzhuwei/p/CSharpGL-18-Picking-of-OneIndexBuffer.html
    partial class DrawElementsPicker {
        /// <summary>
        /// 在所有可能的图元（singleNodeVertexId匹配）中，
        /// 逐个测试，找到最接近摄像机的那个图元，
        /// 返回此图元的最后一个索引在<see cref="IndexBuffer"/>中的索引（位置）。
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="primitiveInfoList"></param>
        /// <returns></returns>
        private RecognizedPrimitiveInfo? FindThePickedOne(
            PickingEventArgs arg,
            List<RecognizedPrimitiveInfo> primitiveInfoList, uint baseId) {
            if (primitiveInfoList == null || primitiveInfoList.Count == 0) { return null; }
#if DEBUG
            SameLengths(primitiveInfoList);
#endif
            if (primitiveInfoList[0].VertexIds.Length == 1)// picking a point.
            {
                return primitiveInfoList[0];
            }

            int target = 0;
#if DEBUG
            NoPrimitiveRestartIndex(primitiveInfoList);
#endif
            DrawMode singlePrimitiveMode = this.DrawCommand.Mode.ToSinglePrimitiveMode();
            for (int current = 1; current < primitiveInfoList.Count; current++) {
                DrawElementsCmd twoPrimitivesIndexBuffer;
                uint leftLastIndex, rightLastIndex;
                AssembleIndexBuffer(
                    primitiveInfoList[target], primitiveInfoList[current], singlePrimitiveMode,
                    out twoPrimitivesIndexBuffer, out leftLastIndex, out rightLastIndex);

                this.Node.Render4InnerPicking(arg, twoPrimitivesIndexBuffer);
                uint stageVertexId = ColorCodedPicking.ReadStageVertexId(arg.X, arg.Y);
                uint pickedIndex = stageVertexId - baseId;
                if (pickedIndex == rightLastIndex) {
                    target = current;
                }
                else if (pickedIndex == leftLastIndex)// 保留上一次的候选图元
                {
                    //target = target;
                    /* nothing to do */
                }
                else if (stageVertexId == uint.MaxValue)// 两个候选图元都没有被拾取到
                { /* nothing to do */ }
                else { throw new Exception("This should not happen!"); }
            }

            return primitiveInfoList[target];
        }

        private void SameLengths(List<RecognizedPrimitiveInfo> primitiveInfoList) {
            int length = primitiveInfoList[0].VertexIds.Length;
            for (int i = 0; i < primitiveInfoList.Count; i++) {
                if (primitiveInfoList[i].VertexIds.Length != length) {
                    throw new Exception("This should not happen!");
                }
            }
        }

        private void NoPrimitiveRestartIndex(List<RecognizedPrimitiveInfo> primitiveInfoList) {
            uint pri = this.DrawCommand.primitiveRestartIndex;
            if (pri == byte.MaxValue || pri == ushort.MaxValue || pri == uint.MaxValue) {
                foreach (RecognizedPrimitiveInfo info in primitiveInfoList) {
                    foreach (uint vertexId in info.VertexIds) {
                        if (vertexId == pri) {
                            throw new Exception(string.Format(
                                "Picking algorithm got PrimitiveRestartIndex([{0}]) as the index of vertex!", pri));
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 将共享点前移，然后重新渲染、拾取
        /// </summary>
        /// <param name="recognizedPrimitiveIndex0"></param>
        /// <param name="recognizedPrimitiveIndex1"></param>
        /// <param name="singlePrimitiveMode"></param>
        /// <param name="cmd"></param>
        /// <param name="lastIndex0"></param>
        /// <param name="lastIndex1"></param>
        private void AssembleIndexBuffer(
            RecognizedPrimitiveInfo recognizedPrimitiveIndex0,
            RecognizedPrimitiveInfo recognizedPrimitiveIndex1,
            DrawMode singlePrimitiveMode,
            out DrawElementsCmd cmd,
            out uint lastIndex0, out uint lastIndex1) {
            List<uint> indexArray = ArrangeIndexes(
                recognizedPrimitiveIndex0, recognizedPrimitiveIndex1,
                out lastIndex0, out lastIndex1);
            if (indexArray.Count !=
                recognizedPrimitiveIndex0.VertexIds.Length
                + 1
                + recognizedPrimitiveIndex1.VertexIds.Length) { throw new Exception(string.Format("index array[{0}] not same length with [recognized primitive1 index length{1}] + [1] + recognized primitive2 index length[{2}]", indexArray.Count, recognizedPrimitiveIndex0.VertexIds.Length, recognizedPrimitiveIndex1.VertexIds.Length)); }

            IndexBuffer buffer = indexArray.ToArray().GenIndexBuffer(IndexBuffer.ElementType.UInt, GLBuffer.Usage.StaticDraw);
            cmd = new DrawElementsCmd(buffer, singlePrimitiveMode, uint.MaxValue);// uint.MaxValue in glPrimitiveRestartIndex();

            //oneIndexBuffer = Buffer.Create(IndexElementType.UInt,
            //    recognizedPrimitiveIndex0.VertexIds.Length
            //    + 1
            //    + recognizedPrimitiveIndex1.VertexIds.Length,
            //    singlePrimitiveMode, GLBuffer.BufferUsage.StaticDraw);
            //unsafe
            //{
            //    var array = (uint*)oneIndexBuffer.MapBuffer(MapBufferAccess.WriteOnly);
            //    for (int i = 0; i < indexArray.Count; i++)
            //    {
            //        array[i] = indexArray[i];
            //    }
            //    oneIndexBuffer.UnmapBuffer();
            //}
        }

        /// <summary>
        /// 将共享点前移，构成2个图元组成的新的小小的索引。
        /// </summary>
        /// <param name="recognizedPrimitiveIndex0"></param>
        /// <param name="recognizedPrimitiveIndex1"></param>
        /// <param name="lastIndex0"></param>
        /// <param name="lastIndex1"></param>
        /// <returns></returns>
        private List<uint> ArrangeIndexes(
            RecognizedPrimitiveInfo recognizedPrimitiveIndex0,
            RecognizedPrimitiveInfo recognizedPrimitiveIndex1,
            out uint lastIndex0, out uint lastIndex1) {
            var sameIndexList = new List<uint>();
            var array0 = new List<uint>(recognizedPrimitiveIndex0.VertexIds);
            var array1 = new List<uint>(recognizedPrimitiveIndex1.VertexIds);
            array0.Sort(); array1.Sort();
            int p0 = 0, p1 = 0;
            while (p0 < array0.Count && p1 < array1.Count) {
                if (array0[p0] < array1[p1]) { p0++; }
                else if (array0[p0] > array1[p1]) { p1++; }
                else {
                    sameIndexList.Add(array0[p0]);
                    array0.RemoveAt(p0);
                    array1.RemoveAt(p1);
                }
            }

            if (array0.Count == 0 && array1.Count == 0) { throw new Exception("Two primitives are totally the same!"); }

            if (array0.Count > 0) { lastIndex0 = array0.Last(); }
            else {
                if (sameIndexList.Count == 0) { throw new Exception("array0 is totally empty!"); }

                lastIndex0 = sameIndexList.Last();
            }

            if (array1.Count > 0) { lastIndex1 = array1.Last(); }
            else {
                if (sameIndexList.Count == 0) { throw new Exception("array1 is totally empty!"); }

                lastIndex1 = sameIndexList.Last();
            }

            if (lastIndex0 == lastIndex1) { throw new Exception(); }

            var result = new List<uint>();
            result.AddRange(sameIndexList);
            result.AddRange(array0);
            result.Add(uint.MaxValue);// primitive restart index
            result.AddRange(sameIndexList);
            result.AddRange(array1);

            return result;
        }
    }
}
