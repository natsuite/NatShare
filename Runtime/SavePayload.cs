/* 
*   NatShare
*   Copyright (c) 2021 Yusuf Olokoba.
*/

namespace NatSuite.Sharing {

    using System;
    using Internal;

    /// <summary>
    /// Payload for saving to the camera roll.
    /// </summary>
    public sealed class SavePayload : NativePayload {

        #region --Client API--
        /// <summary>
        /// Create a save payload.
        /// </summary>
        /// <param name="album">Optional. Album name in which contents should be saved.</param>
        public SavePayload (string album = default) : base(Supported ? Bridge.CreateSavePayload(album) : IntPtr.Zero) { }

        /// <summary>
        /// Nop. No concept as saving text to the camera roll.
        /// </summary>
        public override void AddText (string text) => base.AddText(text);
        #endregion
    }
}