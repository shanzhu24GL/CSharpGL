﻿using System;

namespace CSharpGL {
    public partial class ModernRenderUnit {
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose() {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        } // end sub

        /// <summary>
        /// Destruct instance of the class.
        /// </summary>
        ~ModernRenderUnit() {
            this.Dispose(false);
        }

        /// <summary>
        /// Backing field to track whether Dispose has been called.
        /// </summary>
        private bool disposedValue = false;

        /// <summary>
        /// Dispose managed and unmanaged resources of this instance.
        /// </summary>
        /// <param name="disposing">If disposing equals true, managed and unmanaged resources can be disposed. If disposing equals false, only unmanaged resources can be disposed. </param>
        private void Dispose(bool disposing) {
            if (this.disposedValue == false) {
                if (disposing) {
                    // Dispose managed resources.
                } // end if

                // Dispose unmanaged resources.
                var methods = this.Methods;
                if (methods != null) {
                    foreach (var item in methods) {
                        if (item != null) {
                            item.Dispose();
                        }
                    }
                }
            } // end if

            this.disposedValue = true;
        } // end sub

    }
}