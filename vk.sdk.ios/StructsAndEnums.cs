using System;
using System.Runtime.InteropServices;
using CoreAnimation;
using CoreFoundation;
using CoreGraphics;
using CoreText;
using CoreVideo;
using Foundation;
using IOSurface;
using ImageIO;
using Metal;
using ObjCRuntime;
using OpenGLES;
using Security;
using UIKit;

namespace VKontakte
{
    [Native]
    public enum VKAuthorizationOptions : ulong
    {
        UnlimitedToken = 1 << 0,
        DisableSafariController = 1 << 1
    }

    [Native]
    public enum VKAuthorizationState : ulong
    {
        Unknown,
        Initialized,
        Pending,
        External,
        SafariInApp,
        Webview,
        Authorized,
        Error
    }
}

namespace VKontakte.Core
{
    public enum VKOperationState
    {
        Paused = -1,
        Ready = 1,
        Executing = 2,
        Finished = 3
    }
}

namespace VKontakte.API.Methods
{
    [Native]
    public enum VKProgressType : long
    {
        Upload,
        Download
    }
}

namespace VKontakte.Image
{
    public enum VKImageType : uint
    {
        Jpg,
        Png
    }
}

namespace VKontakte.Views
{
    [Native]
    public enum VKShareDialogControllerResult : long
    {
        Cancelled,
        Done
    }

    [Native]
    public enum VKAuthorizationType : ulong
    {
        WebView,
        Safari,
        App
    }
}
