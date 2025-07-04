﻿namespace CSharpGL {
    public partial class GL {

        //  Constants
        /// <summary>
        ///
        /// </summary>
        internal const uint GL_INVALID_FRAMEBUFFER_OPERATION = 0x0506;

        /// <summary>
        ///
        /// </summary>
        internal const uint GL_MAX_RENDERBUFFER_SIZE = 0x84E8;

        /// <summary>
        ///
        /// </summary>
        internal const uint GL_FRAMEBUFFER_BINDING = 0x8CA6;

        /// <summary>
        ///
        /// </summary>
        internal const uint GL_RENDERBUFFER_BINDING = 0x8CA7;

        /// <summary>
        ///
        /// </summary>
        internal const uint GL_READ_FRAMEBUFFER = 0x8CA8;

        /// <summary>
        ///
        /// </summary>
        internal const uint GL_DRAW_FRAMEBUFFER = 0x8CA9;

        /// <summary>
        ///
        /// </summary>
        internal const uint GL_FRAMEBUFFER_ATTACHMENT_OBJECT_TYPE = 0x8CD0;

        /// <summary>
        ///
        /// </summary>
        internal const uint GL_FRAMEBUFFER_ATTACHMENT_OBJECT_NAME = 0x8CD1;

        /// <summary>
        ///
        /// </summary>
        internal const uint GL_FRAMEBUFFER_ATTACHMENT_TEXTURE_LEVEL = 0x8CD2;

        /// <summary>
        ///
        /// </summary>
        internal const uint GL_FRAMEBUFFER_ATTACHMENT_TEXTURE_CUBE_MAP_FACE = 0x8CD3;

        /// <summary>
        ///
        /// </summary>
        internal const uint GL_FRAMEBUFFER_ATTACHMENT_TEXTURE_3D_ZOFFSET = 0x8CD4;

        /// <summary>
        ///
        /// </summary>
        internal const uint GL_FRAMEBUFFER_COMPLETE = 0x8CD5;

        /// <summary>
        ///
        /// </summary>
        internal const uint GL_FRAMEBUFFER_UNDEFINED = 0x8219;

        /// <summary>
        ///
        /// </summary>
        internal const uint GL_FRAMEBUFFER_INCOMPLETE_ATTACHMENT = 0x8CD6;

        /// <summary>
        ///
        /// </summary>
        internal const uint GL_FRAMEBUFFER_INCOMPLETE_MISSING_ATTACHMENT = 0x8CD7;

        /// <summary>
        ///
        /// </summary>
        internal const uint GL_FRAMEBUFFER_INCOMPLETE_MULTISAMPLE = 0x8D56;

        /// <summary>
        ///
        /// </summary>
        internal const uint GL_FRAMEBUFFER_INCOMPLETE_DIMENSIONS = 0x8CD9;

        /// <summary>
        ///
        /// </summary>
        internal const uint GL_FRAMEBUFFER_INCOMPLETE_FORMATS_EXT = 0x8CDA;

        /// <summary>
        ///
        /// </summary>
        internal const uint GL_FRAMEBUFFER_INCOMPLETE_DRAW_BUFFER = 0x8CDB;

        /// <summary>
        ///
        /// </summary>
        internal const uint GL_FRAMEBUFFER_INCOMPLETE_READ_BUFFER = 0x8CDC;

        /// <summary>
        ///
        /// </summary>
        internal const uint GL_FRAMEBUFFER_UNSUPPORTED = 0x8CDD;

        /// <summary>
        ///
        /// </summary>
        internal const uint GL_MAX_COLOR_ATTACHMENTS = 0x8CDF;

        /// <summary>
        ///
        /// </summary>
        internal const uint GL_MAX_FRAMEBUFFER_WIDTH = 0x9315;

        /// <summary>
        ///
        /// </summary>
        internal const uint GL_MAX_FRAMEBUFFER_HEIGHT = 0x9316;

        /// <summary>
        ///
        /// </summary>
        internal const uint GL_MAX_FRAMEBUFFER_LAYERS = 0x9317;

        /// <summary>
        ///
        /// </summary>
        internal const uint GL_MAX_FRAMEBUFFER_SAMPLES = 0x9318;

        /// <summary>
        ///
        /// </summary>
        internal const uint GL_COLOR_ATTACHMENT0 = 0x8CE0;

        /// <summary>
        ///
        /// </summary>
        internal const uint GL_COLOR_ATTACHMENT1 = 0x8CE1;

        /// <summary>
        ///
        /// </summary>
        internal const uint GL_COLOR_ATTACHMENT2 = 0x8CE2;

        /// <summary>
        ///
        /// </summary>
        internal const uint GL_COLOR_ATTACHMENT3 = 0x8CE3;

        /// <summary>
        ///
        /// </summary>
        internal const uint GL_COLOR_ATTACHMENT4 = 0x8CE4;

        /// <summary>
        ///
        /// </summary>
        internal const uint GL_COLOR_ATTACHMENT5 = 0x8CE5;

        /// <summary>
        ///
        /// </summary>
        internal const uint GL_COLOR_ATTACHMENT6 = 0x8CE6;

        /// <summary>
        ///
        /// </summary>
        internal const uint GL_COLOR_ATTACHMENT7 = 0x8CE7;

        /// <summary>
        ///
        /// </summary>
        internal const uint GL_COLOR_ATTACHMENT8 = 0x8CE8;

        /// <summary>
        ///
        /// </summary>
        internal const uint GL_COLOR_ATTACHMENT9 = 0x8CE9;

        /// <summary>
        ///
        /// </summary>
        internal const uint GL_COLOR_ATTACHMENT10 = 0x8CEA;

        /// <summary>
        ///
        /// </summary>
        internal const uint GL_COLOR_ATTACHMENT11 = 0x8CEB;

        /// <summary>
        ///
        /// </summary>
        internal const uint GL_COLOR_ATTACHMENT12 = 0x8CEC;

        /// <summary>
        ///
        /// </summary>
        internal const uint GL_COLOR_ATTACHMENT13 = 0x8CED;

        /// <summary>
        ///
        /// </summary>
        internal const uint GL_COLOR_ATTACHMENT14 = 0x8CEE;

        /// <summary>
        ///
        /// </summary>
        internal const uint GL_COLOR_ATTACHMENT15 = 0x8CEF;

        /// <summary>
        ///
        /// </summary>
        internal const uint GL_DEPTH_ATTACHMENT = 0x8D00;

        /// <summary>
        ///
        /// </summary>
        internal const uint GL_STENCIL_ATTACHMENT = 0x8D20;

        /// <summary>
        ///
        /// </summary>
        internal const uint GL_DEPTH_STENCIL_ATTACHMENT = 0x821A;

        /// <summary>
        ///
        /// </summary>
        internal const uint GL_FRAMEBUFFER = 0x8D40;

        /// <summary>
        ///
        /// </summary>
        internal const uint GL_RENDERBUFFER = 0x8D41;

        /// <summary>
        ///
        /// </summary>
        internal const uint GL_RENDERBUFFER_WIDTH = 0x8D42;

        /// <summary>
        ///
        /// </summary>
        internal const uint GL_RENDERBUFFER_HEIGHT = 0x8D43;

        /// <summary>
        ///
        /// </summary>
        internal const uint GL_RENDERBUFFER_INTERNAL_FORMAT = 0x8D44;

        /// <summary>
        ///
        /// </summary>
        internal const uint GL_STENCIL_INDEX1 = 0x8D46;

        /// <summary>
        ///
        /// </summary>
        internal const uint GL_STENCIL_INDEX4 = 0x8D47;

        /// <summary>
        ///
        /// </summary>
        internal const uint GL_STENCIL_INDEX8 = 0x8D48;

        /// <summary>
        ///
        /// </summary>
        internal const uint GL_STENCIL_INDEX16 = 0x8D49;

        /// <summary>
        ///
        /// </summary>
        internal const uint GL_RENDERBUFFER_RED_SIZE = 0x8D50;

        /// <summary>
        ///
        /// </summary>
        internal const uint GL_RENDERBUFFER_GREEN_SIZE = 0x8D51;

        /// <summary>
        ///
        /// </summary>
        internal const uint GL_RENDERBUFFER_BLUE_SIZE = 0x8D52;

        /// <summary>
        ///
        /// </summary>
        internal const uint GL_RENDERBUFFER_ALPHA_SIZE = 0x8D53;

        /// <summary>
        ///
        /// </summary>
        internal const uint GL_RENDERBUFFER_DEPTH_SIZE = 0x8D54;

        /// <summary>
        ///
        /// </summary>
        internal const uint GL_RENDERBUFFER_STENCIL_SIZE = 0x8D55;

        /// <summary>
        ///
        /// </summary>
        internal const uint GL_FRAMEBUFFER_DEFAULT_WIDTH = 0x9310;

        /// <summary>
        ///
        /// </summary>
        internal const uint GL_FRAMEBUFFER_DEFAULT_HEIGHT = 0x9311;

        /// <summary>
        ///
        /// </summary>
        internal const uint GL_FRAMEBUFFER_DEFAULT_LAYERS = 0x9312;

        /// <summary>
        ///
        /// </summary>
        internal const uint GL_FRAMEBUFFER_DEFAULT_SAMPLES = 0x9313;

        /// <summary>
        ///
        /// </summary>
        internal const uint GL_FRAMEBUFFER_DEFAULT_FIXED_SAMPLES_LOCATIONS = 0x9314;

        //#region GL_EXT_framebuffer_multisample

        ////  Constants
        ///// <summary>
        /////
        ///// </summary>
        //internal const uint GL_RENDERBUFFER_SAMPLES = 0x8CAB;
        ///// <summary>
        /////
        ///// </summary>
        //internal const uint GL_FRAMEBUFFER_INCOMPLETE_MULTISAMPLE = 0x8D56;
        ///// <summary>
        /////
        ///// </summary>
        //internal const uint GL_MAX_SAMPLES = 0x8D57;

        //#endregion
    }
}