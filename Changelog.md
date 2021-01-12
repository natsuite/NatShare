## NatShare 1.2.4
+ Added `ISharePayload.AddImage` overload which takes in a raw pixel buffer.
+ Fixed sharing not working on iOS 14.
+ Fixed `SavePayload` with album name crashing on Android Q+.
+ Fixed `DllNotFoundException` when using any sharing payloads in the Unity Editor.
+ Removed method chaining support from all payloads. Use multiple invocations instead.
+ NatShare now requires Android API level 24+.

## NatShare 1.2.3
+ Moved documentation [online](http://docs.natsuite.io/natshare).
+ Fixed compiler errors when building with IL2CPP backend on Android.
+ Fixed "No apps can perform this action" error when sharing text on Android.
+ Reduced time taken when adding images to payloads.
+ NatShare now requires iOS 11+.

## NatShare 1.2.2
+ Updated top-level namespace to `NatSuite.Sharing` for parity with other NatSuite API's.
+ Updated `ISharePayload` methods to support chaining, making code easier and more declarative.
+ Implemented `async` pattern for sharing callback using `ISharePayload.Commit` method, further simplifying sharing code.
+ Added boolean return type for `ISharePayload.Commit` showing whether the sharing operation was successfully completed.
+ Fixed UI constraints error when sharing on iPad with iOS 13.
+ Deprecated `ISharePayload.Dispose` method.

## NatShare 1.2.1
+ Fixed `SavePayload.AddMedia` not working properly on Android.
+ Fixed `SavePayload` failing to save the first time the user is asked for permissions on iOS.

## NatShare 1.2.0
+ Migrated to an object-oriented approach, where sharing payloads are created then committed. See README for more details.
+ Added support for printing on iOS with `PrintPayload`.
+ Added support for sharing multiple items at once.
+ Upgraded API to .NET 4.
+ NatShare now requires Android API level 22+.

## NatShare 1.1f3
+ Added support for saving to an album in the camera roll.
+ Added `copy` parameter to `SaveToCameraRoll`. When `false`, the media file will be moved to the camera roll instead of being copied.
+ Deprecated `message` parameter in `Share*` functions.
+ Refactored all `Share*` functions to overloads of one `NatShare.Share` function.

## NatShare 1.1f2
+ Added callbacks to the `NatShare.Share...` functions. You can use these to know when the user has completed the sharing activity.
+ Added better error logging on iOS.
+ Changed `NatShare.GetThumbnail` to return the thumbnail texture instead of take a callback.
+ Deprecated the WebGL backend since most functions were not supported.

## NatShare 1.1f1
+ Added `ShareText` function for sharing plain text.
+ Added `ShareMedia` function for sharing media files like videos, images, and so on.
+ Refactored `Share` function to `ShareImage`.
+ Correctly set duration of video file being saved to camera roll on Android.
+ Fix creation date on saved video being incorrect on Android.
+ Fix sharing not being available for Instagram and Twitter on iOS.
+ Fix videos not being copied to the top level of the device gallery on Android.

## NatShare 1.0f3
+ Images being shared or saved will not appear in a "NatShare" album.
+ Added null checking in all functions to prevent crashing.
+ Fixed hard crash when thumbnail cannot be retreived on iOS.

## NatShare 1.0f2
+ Added ability to share images and videos with message.
+ Fixed tearing and skew in generated thumbnails on iOS.

## NatShare 1.0f1
+ First release.