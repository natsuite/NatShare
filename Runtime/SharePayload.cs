/* 
*   NatShare
*   Copyright (c) 2021 Yusuf Olokoba.
*/

namespace NatSuite.Sharing {

    using System;
    using Internal;

    /// <summary>
    /// Payload for sharing to available social services.
    /// </summary>
    public sealed class SharePayload : NativePayload {

        #region --Client API--
        /// <summary>
        /// Create a share payload.
        /// </summary>
        public SharePayload () : base(Supported ? Bridge.CreateSharePayload() : IntPtr.Zero) { }
        #endregion
    }
}