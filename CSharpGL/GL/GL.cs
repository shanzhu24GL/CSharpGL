using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL {
    /// <summary>
    /// collection of openGL function pointers.
    /// <para>each operating system should has its own openGL implementation(ie. an class that implements this <see cref="GL"/> class).</para>
    /// <para><see cref="GLRenderContext"/> objects with the same initial parameters share function pointers in <see cref="GL"/>.</para>
    /// </summary>
    public unsafe partial class GL {

        internal static GL? current;
        /// <summary>
        /// openGL function pointers that bind to current <see cref="GLRenderContext"/>
        /// </summary>
        public static GL? Current => current;

        ///// <summary>
        ///// the function that gets openGL function with specified <paramref name="funcName"/>
        ///// </summary>
        //public readonly Func<string, IntPtr> GetProcAddress;

        ///// <summary>
        ///// get current opengl context.
        ///// </summary>
        ///// <returns></returns>
        //public abstract IntPtr GetCurrentContext();
    }
}
