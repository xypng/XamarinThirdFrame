using System;
using System.Runtime.InteropServices;
using Foundation;
using ObjCRuntime;

namespace YYKit.iOS
{
	[Native]
	public enum YYTextAttributeType : nint
	{
		None = 0,
		UIKit = 1 << 0,
		CoreText = 1 << 1,
		YYText = 1 << 2
	}

	static class CFunctions
	{
		// extern YYTextAttributeType YYTextAttributeGetType (NSString * _Nonnull attributeName);
		[DllImport ("__Internal")]
		[Verify (PlatformInvoke)]
		static extern YYTextAttributeType YYTextAttributeGetType (NSString attributeName);
	}

	[Native]
	public enum YYTextLineStyle : nint
	{
		None = 0,
		Single = 1,
		Thick = 2,
		Double = 9,
		PatternSolid = 0,
		PatternDot = 256,
		PatternDash = 512,
		PatternDashDot = 768,
		PatternDashDotDot = 1024,
		PatternCircleDot = 2304
	}

	[Native]
	public enum YYTextVerticalAlignment : nint
	{
		Top = 0,
		Center = 1,
		Bottom = 2
	}

	[Native]
	public enum YYTextDirection : nuint
	{
		None = 0,
		Top = 1 << 0,
		Right = 1 << 1,
		Bottom = 1 << 2,
		Left = 1 << 3
	}

	[Native]
	public enum YYTextTruncationType : nuint
	{
		None = 0,
		Start = 1,
		End = 2,
		Middle = 3
	}

	[Native]
	public enum YYWebImageOptions : nuint
	{
		ShowNetworkActivity = 1 << 0,
		Progressive = 1 << 1,
		ProgressiveBlur = 1 << 2,
		UseNSURLCache = 1 << 3,
		AllowInvalidSSLCertificates = 1 << 4,
		AllowBackgroundTask = 1 << 5,
		HandleCookies = 1 << 6,
		RefreshImageCache = 1 << 7,
		IgnoreDiskCache = 1 << 8,
		IgnorePlaceHolder = 1 << 9,
		IgnoreImageDecoding = 1 << 10,
		IgnoreAnimatedImage = 1 << 11,
		SetImageWithFadeAnimation = 1 << 12,
		AvoidSetImage = 1 << 13,
		IgnoreFailedURL = 1 << 14
	}

	[Native]
	public enum YYWebImageFromType : nuint
	{
		None = 0,
		MemoryCacheFast,
		MemoryCache,
		DiskCache,
		Remote
	}

	[Native]
	public enum YYWebImageStage : nint
	{
		Progress = -1,
		Cancelled = 0,
		Finished = 1
	}
}
