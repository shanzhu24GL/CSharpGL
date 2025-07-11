﻿using System;
using System.ComponentModel;
using System.Drawing.Design;

namespace CSharpGL {
    /// <summary>
    /// VAO是用来管理VBO的。可以进一步减少DrawCall。
    /// <para>VAO is used to reduce draw-call.</para>
    /// </summary>

    public sealed unsafe class VertexArrayObject : IDisposable {
        //internal static readonly GLDelegates.void_int_uintN glGenVertexArrays;
        //internal static readonly GLDelegates.void_uint glBindVertexArray;
        //internal static readonly GLDelegates.void_int_uintN glDeleteVertexArrays;
        //static VertexArrayObject() {
        //    glGenVertexArrays = gl.glGetDelegateFor("glGenVertexArrays", GLDelegates.typeof_void_int_uintN) as GLDelegates.void_int_uintN;
        //    glBindVertexArray = gl.glGetDelegateFor("glBindVertexArray", GLDelegates.typeof_void_uint) as GLDelegates.void_uint;
        //    glDeleteVertexArrays = gl.glGetDelegateFor("glDeleteVertexArrays", GLDelegates.typeof_void_int_uintN) as GLDelegates.void_int_uintN;

        //}

        /// <summary>
        /// vertex attribute buffers('in vec3 position;' in shader etc.)
        /// </summary>
        public IReadOnlyList<VertexShaderAttribute> VertexAttributes { get; private set; }

        /// <summary>
        /// The draw command.
        /// The one and only one index buffer used to indexing vertex attribute buffers.
        /// </summary>
        public IDrawCommand DrawCommand { get; private set; }

        private uint id;

        /// <summary>
        /// 此VAO的ID，由OpenGL给出。
        /// <para>Id generated by glGenVertexArrays().</para>
        /// </summary>
        public uint Id { get { return id; } }

        /// <summary>
        /// VAO是用来管理VBO的。可以进一步减少DrawCall。
        /// <para>VAO is used to reduce draw-call.</para>
        /// </summary>
        /// <param name="drawCommand">index buffer pointer that used to invoke draw command.</param>
        /// <param name="shaderProgram">shader program that <paramref name="vertexAttributes"/> bind to.</param>
        /// <param name="vertexAttributes">给出此VAO要管理的所有VBO。<para>All VBOs that are managed by this VAO.</para></param>
        public VertexArrayObject(IDrawCommand drawCommand, GLProgram shaderProgram, IReadOnlyList<VertexShaderAttribute> vertexAttributes) {
            if (drawCommand == null) {
                throw new ArgumentNullException("drawCommand");
            }
            // Zero vertex attribute is allowed in GLSL.
            //if (vertexAttributeBuffers == null || vertexAttributeBuffers.Length == 0)
            //{
            //    throw new ArgumentNullException("vertexAttributeBuffers");
            //}

            this.DrawCommand = drawCommand;
            this.VertexAttributes = vertexAttributes;

            var gl = GL.current; if (gl == null) { return; }
            uint id;
            gl.glGenVertexArrays(1, &id); this.id = id;

            gl.glBindVertexArray(this.Id); // this vertex array object will record all stand-by actions.

            foreach (var item in vertexAttributes) {
                VertexBuffer buffer = item.buffer;
                buffer.Standby(shaderProgram, item.inVar);
            }

            gl.glBindVertexArray(0); // this vertex array object has recorded all stand-by actions.
        }

        internal void Bind() {
            var gl = GL.current; if (gl == null) { return; }
            gl.glBindVertexArray(this.Id);
        }

        internal void Unbind() {
            var gl = GL.current; if (gl == null) { return; }
            gl.glBindVertexArray(0);
        }

        /// <summary>
        /// 执行一次渲染的过程。
        /// <para>Execute rendering command.</para>
        /// </summary>
        /// <param name="drawCmds">render by temporary index buffers</param>
        public void Draw(params IDrawCommand[] drawCmds) {
            this.Bind();

            if (drawCmds != null && drawCmds.Length > 0) {
                foreach (var cmd in drawCmds) {
                    cmd.Draw();
                }
            }
            else {
                this.DrawCommand.Draw();
            }

            this.Unbind();
        }

        /// <summary>
        ///
        /// </summary>
        public override string ToString() {
            return string.Format("VAO Id: {0}", this.Id);
        }

        /// <summary>
        ///
        /// </summary>
        public void Dispose() {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        ///
        /// </summary>
        ~VertexArrayObject() {
            this.Dispose(false);
        }

        private bool disposedValue;

        private void Dispose(bool disposing) {
            if (this.disposedValue == false) {
                if (disposing) {
                    // Dispose managed resources.
                }

                // Dispose unmanaged resources.

                //IntPtr ptr = gl.glGetCurrentContext(); //Win32.wglGetCurrentContext();
                //if (ptr != IntPtr.Zero) {
                //var glDeleteVertexArrays = gl.glGetDelegateFor("glDeleteVertexArrays", GLDelegates.typeof_void_int_uintN) as GLDelegates.void_int_uintN;
                var gl = GL.current; if (gl != null) {
                    var id = this.id;
                    gl.glDeleteVertexArrays(1, &id);
                }
                this.id = 0;
                // NOTE: This indicates that all references to these VertexShaderAttribute objects should be disposed.
                var vertexAttributeBuffers = this.VertexAttributes;
                if (vertexAttributeBuffers != null) {
                    foreach (var item in vertexAttributeBuffers) {
                        item.buffer.Dispose();
                    }
                }
                if (this.DrawCommand is IDisposable disposable) { disposable.Dispose(); }
                //}
            }

            this.disposedValue = true;
        }
    }
}