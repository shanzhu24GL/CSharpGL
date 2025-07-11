﻿using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL {
    /// <summary>
    /// Provides a <see cref="Texture"/> object.
    /// </summary>
    public interface ITextureSource {
        /// <summary>
        /// The provided texture object.
        /// </summary>
        Texture BindingTexture { get; }
    }

    /// <summary>
    /// Provides a <see cref="Texture"/> object generated from specified bitmap file.
    /// </summary>
    public class BitmapTextureSource : ITextureSource {
        private readonly Texture texture;
        /// <summary>
        /// Provides a <see cref="Texture"/> object generated from specified bitmap file.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="pixelBytes">bytes per pixel</param>
        /// <param name="scan0"></param>
        public BitmapTextureSource(int width, int height, int pixelBytes, IntPtr scan0/*string filename*/) {
            //var bmp = new System.Drawing.Bitmap(filename);
            //bmp.RotateFlip(System.Drawing.RotateFlipType.Rotate180FlipX);
            var bmp = new GLBitmap(width, height, pixelBytes, scan0);
            var storage = new TexImageBitmap(bmp);
            texture = new Texture(storage);
            texture.builtInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_CLAMP_TO_EDGE));
            texture.builtInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_CLAMP_TO_EDGE));
            texture.builtInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureWrapR, (int)GL.GL_CLAMP_TO_EDGE));
            texture.builtInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_LINEAR));
            texture.builtInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_LINEAR));

            texture.Initialize();
            bmp.Dispose();
        }

        #region ITextureSource 成员

        /// <summary>
        /// 
        /// </summary>
        public Texture BindingTexture { get { return texture; } }

        #endregion
    }
}
