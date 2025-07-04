using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;

namespace CSharpGL {
    /// <summary>
    /// Set up 2D texture's content with a <see cref="Bitmap"/> object.
    /// </summary>
    public unsafe class TexImageBitmap : TexStorageBase {
        ///// <summary>
        ///// 
        ///// </summary>
        public readonly GLBitmap bitmap;
        /// <summary>
        /// 
        /// </summary>
        public readonly int width;
        /// <summary>
        /// 
        /// </summary>
        public readonly int height;

        /// <summary>
        /// Set up 2D texture's content with a <see cref="Bitmap"/> object.
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="internalFormat"></param>
        /// <param name="mipmapLevelCount"></param>
        /// <param name="border"></param>
        public TexImageBitmap(GLBitmap bitmap, uint internalFormat = GL.GL_RGBA, int mipmapLevelCount = 1, bool border = false)
            : base(TextureTarget.Texture2D, internalFormat, mipmapLevelCount, border) {
            ArgumentNullException.ThrowIfNull(bitmap);

            this.bitmap = bitmap;
            this.width = bitmap.width;
            this.height = bitmap.height;
        }

        /// <summary>
        /// Set up 2D texture's content with a <see cref="Bitmap"/> object.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="internalFormat"></param>
        /// <param name="mipmapLevelCount"></param>
        /// <param name="border"></param>
        public TexImageBitmap(int width, int height, uint internalFormat = GL.GL_RGBA, int mipmapLevelCount = 1, bool border = false)
            : base(TextureTarget.Texture2D, internalFormat, mipmapLevelCount, border) {
            this.width = width;
            this.height = height;
            if (!GLBitmap.internalFormat2Bytes.TryGetValue(internalFormat, out var bytes)) { throw new NotImplementedException(); }
            this.bitmap = new GLBitmap(width, height, bytes);
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Apply() {
            var gl = GL.current; if (gl == null) { return; }
            var bitmap = this.bitmap;
            if (bitmap == null) {
                for (int level = 0; level < mipmapLevelCount; level++) {
                    gl.glTexImage2D((uint)this.target, level, (int)this.internalFormat, this.width, this.height, this.border ? 1 : 0, GL.GL_BGRA, GL.GL_UNSIGNED_BYTE, IntPtr.Zero);
                }
            }
            else {
                {
                    const int level = 0;
                    //BitmapData data = bitmap.LockBits(new Rectangle(0, 0, this.width, this.height), System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                    //IntPtr pixels = data.Scan0;
                    //var pixels = this.bitmap.Lock();
                    gl.glTexImage2D((uint)this.target, level, (int)this.internalFormat, this.width, this.height, this.border ? 1 : 0, GL.GL_BGRA, GL.GL_UNSIGNED_BYTE, this.bitmap.scan0 /*pixels*/);
                    //bitmap.UnlockBits(data);
                    //this.bitmap.Unlock();
                }
                var bmp = bitmap;
                for (int level = 1; level < mipmapLevelCount; level++) {
                    //bmp = (Bitmap)bmp.GetThumbnailImage(bmp.Width / 2, bmp.Height / 2, new Image.GetThumbnailImageAbort(ThumbnailCallback), IntPtr.Zero);
                    //BitmapData data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                    //IntPtr pixels = data.Scan0;
                    var bmp2 = bmp.ZoomOut(0.5f, 0.5f);
                    gl.glTexImage2D((uint)this.target, level, (GLint)this.internalFormat, bmp2.width, bmp2.height, this.border ? 1 : 0, GL.GL_BGRA, GL.GL_UNSIGNED_BYTE, bmp2.scan0);
                    //bmp.UnlockBits(data);
                    //bmp.Dispose();
                    if (bmp != bitmap) { bmp.Dispose(); }
                    bmp = bmp2;
                }
            }
        }

        private bool ThumbnailCallback() {
            return false;
        }
    }
}
