﻿using System;
using System.Collections.Generic;

namespace CSharpGL {
    partial class Framebuffer {
        public enum Target : GLuint {
            /// <summary>
            /// used to draw(write only) something.
            /// </summary>
            DrawFramebuffer = GL.GL_DRAW_FRAMEBUFFER,

            /// <summary>
            /// used to read from(read only).
            /// </summary>
            ReadFramebuffer = GL.GL_READ_FRAMEBUFFER,

            /// <summary>
            /// both read/write.
            /// </summary>
            Framebuffer = GL.GL_FRAMEBUFFER,
        }
    }
}
