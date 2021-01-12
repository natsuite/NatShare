/* 
*   NatShare
*   Copyright (c) 2021 Yusuf Olokoba.
*/

namespace NatSuite.Sharing {

    using UnityEngine;
    using System.Threading.Tasks;

    /// <summary>
    /// A payload for social sharing.
    /// </summary>
    public interface ISharePayload {
        
        /// <summary>
        /// Add text to the payload.
        /// </summary>
        /// <param name="text">Plain text to add.</param>
        void AddText (string text);

        /// <summary>
        /// Add an image to the payload from a pixel buffer.
        /// The pixel buffer MUST have an RGBA8888 pixel layout.
        /// </summary>
        /// <param name="pixelBuffer">Pixel buffer containing image to add.</param>
        /// <param name="width">Image width.</param>
        /// <param name="height">Image height.</param>
        void AddImage<T> (T[] pixelBuffer, int width, int height) where T : unmanaged;

        /// <summary>
        /// Add an image to the payload.
        /// </summary>
        /// <param name="image">Image to add.</param>
        void AddImage (Texture2D image);

        /// <summary>
        /// Add a media file to the payload.
        /// </summary>
        /// <param name="path">Path to media file to add.</param>
        void AddMedia (string path);

        /// <summary>
        /// Commit the payload and return the success value.
        /// </summary>
        /// <returns>Whether the sharing action was successfully completed.</returns>
        Task<bool> Commit ();
    }
}