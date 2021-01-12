/* 
*   NatShare
*   Copyright (c) 2021 Yusuf Olokoba.
*/

namespace NatSuite.Sharing.Internal {

    using AOT;
    using UnityEngine;
    using System;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Threading.Tasks;

    public abstract class NativePayload : ISharePayload {

        #region --Client API--
        /// <summary>
        /// Does the current platform support this payload?
        /// </summary>
        public static bool Supported => new [] { RuntimePlatform.IPhonePlayer, RuntimePlatform.Android }.Contains(Application.platform);

        /// <summary>
        /// Add text to the payload.
        /// </summary>
        /// <param name="text">Plain text to add.</param>
        public virtual void AddText (string text) {
            // Check
            if (payload == IntPtr.Zero)
                return;
            // Add
            payload.AddText(text);
        }

        /// <summary>
        /// Add an image to the payload from a pixel buffer.
        /// The pixel buffer MUST have an RGBA8888 pixel layout.
        /// </summary>
        /// <param name="pixelBuffer">Pixel buffer containing image to add.</param>
        /// <param name="width">Image width.</param>
        /// <param name="height">Image height.</param>
        public virtual void AddImage<T> (T[] pixelBuffer, int width, int height) where T : unmanaged {
            // Check
            if (payload == IntPtr.Zero)
                return;
            // Compress
            var handle = GCHandle.Alloc(pixelBuffer, GCHandleType.Pinned);
            var frameBuffer = new Texture2D(width, height, TextureFormat.RGBA32, false);
            frameBuffer.LoadRawTextureData(handle.AddrOfPinnedObject(), width * height * 4);
            handle.Free();
            // Add
            AddImage(frameBuffer);
            Texture2D.Destroy(frameBuffer);
        }

        /// <summary>
        /// Add an image to the payload.
        /// Note that the image MUST be readable.
        /// </summary>
        /// <param name="image">Image to add.</param>
        public virtual void AddImage (Texture2D image) {
            // Check
            if (payload == IntPtr.Zero)
                return;
            if (!image.isReadable) {
                Debug.LogError("NatShare Error: Cannot add non-readable texture to payload");
                return;
            }
            // Add
            var jpegData = ImageConversion.EncodeToJPG(image); // Faster than PNG #85
            payload.AddImage(jpegData, jpegData.Length);
        }

        /// <summary>
        /// Add a media file to the payload.
        /// </summary>
        /// <param name="path">Path to media file to add.</param>
        public virtual void AddMedia (string uri) {
            // Check
            if (payload == IntPtr.Zero)
                return;
            // Add
            payload.AddMedia(uri);
        }

        /// <summary>
        /// Commit the payload.
        /// </summary>
        /// <returns>Whether the sharing action was successfully completed.</returns>
        public virtual Task<bool> Commit () {
            // Check
            if (payload == IntPtr.Zero)
                return Task.FromResult(false);
            // Commit
            var commitTask = new TaskCompletionSource<bool>();
            var handle = GCHandle.Alloc(commitTask, GCHandleType.Normal);
            payload.Commit(OnCompletion, (IntPtr)handle);
            return commitTask.Task;
        }
        #endregion


        #region --Operations--

        private readonly IntPtr payload;

        protected NativePayload (IntPtr payload) => this.payload = payload;

        [MonoPInvokeCallback(typeof(Bridge.CompletionHandler))]
        private static void OnCompletion (IntPtr context, bool success) {
            var handle = (GCHandle)context;
            var commitTask = handle.Target as TaskCompletionSource<bool>;
            handle.Free();
            commitTask?.SetResult(success);
        }
        #endregion
    }
}