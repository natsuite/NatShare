/* 
*   NatShare
*   Copyright (c) 2021 Yusuf Olokoba.
*/

namespace NatSuite.Sharing.Internal {

    using System;
    using System.Runtime.InteropServices;

    public static class Bridge {

        private const string Assembly =
        #if UNITY_IOS && !UNITY_EDITOR
        @"__Internal";
        #else
        @"NatShare";
        #endif

        public delegate void CompletionHandler (IntPtr context, bool success);

        [DllImport(Assembly, EntryPoint = @"NSCreateSharePayload")]
        public static extern IntPtr CreateSharePayload ();
        [DllImport(Assembly, EntryPoint = @"NSCreateSavePayload")]
        public static extern IntPtr CreateSavePayload (string album);
        [DllImport(Assembly, EntryPoint = @"NSCreatePrintPayload")]
        public static extern IntPtr CreatePrintPayload (bool color, bool landscape);
        [DllImport(Assembly, EntryPoint = @"NSAddText")]
        public static extern void AddText (this IntPtr payload, string text);
        [DllImport(Assembly, EntryPoint = @"NSAddImage")]
        public static extern void AddImage (this IntPtr payload, byte[] jpegData, int dataSize);
        [DllImport(Assembly, EntryPoint = @"NSAddMedia")]
        public static extern void AddMedia (this IntPtr payload, string uri);
        [DllImport(Assembly, EntryPoint = @"NSCommit")]
        public static extern void Commit (this IntPtr payload, CompletionHandler completionHandler, IntPtr context);
    }
}