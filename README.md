# NatShare API
NatShare is a lightweight, easy-to-use native sharing API for Unity Engine. NatShare supports sharing text, images (using a `Texture2D`) and media files (using a `string` path). Currently, you can save media to the camera roll and open the native sharing UI:

## Native Sharing
To share an image, you can use the `SharePayload`:
```csharp
Texture2D image = ...;
var payload = new SharePayload()
payload.AddImage(image);
payload.Commit();
```

You can share multiple items at once:
```csharp
new SharePayload()
    .AddText("Happy Birthday!")
    .AddImage(image)
    .AddMedia("/path/to/some/media/file.mp4")
    .Commit();
```

The `ISharePayload.Commit` function returns a task which when completed, returns a `bool` indicating whether the sharing operation was successful:
```csharp
async void ShareVideo () {
    var success = await new SharePayload().AddMedia("/path/to/some/media/file.mp4").Commit();
    Debug.Log($"Successfully shared items: {success}");
}    
```

## Saving to the Camera Roll
You can save images or media files to the camera roll with the `SavePayload`:
```csharp
// Save a texture and a media file to the camera roll
Texture2D image = ...;
var payload = new SavePayload();
payload.AddImage(image);
payload.AddMedia("/path/to/some/media/file.gif");
payload.Commit();
```

___

## iOS Instructions
After building an Xcode project from Unity, add the following keys to the `Info.plist` file with a good description:
- `NSPhotoLibraryUsageDescription`
- `NSPhotoLibraryAddUsageDescription`

## Requirements
- Unity 2018.3+
- Android API level 22+
- iOS 9+

## Quick Tips
- To discuss, report an issue, or request a feature, visit [Unity forums](https://forum.unity.com/threads/natshare-free-sharing-api.527074/) or [GitHub](https://github.com/olokobayusuf/NatShare-API)
- Contact me at [olokobayusuf@gmail.com](mailto:olokobayusuf@gmail.com)

Thank you very much!