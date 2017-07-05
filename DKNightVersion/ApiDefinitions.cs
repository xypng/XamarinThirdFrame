using System;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace DKNightversion
{
	// typedef NSInteger (^DKNSIntegerPicker)(DKThemeVersion *);
	delegate nint DKNSIntegerPicker (string arg0);

	// @interface DKNSInteger : NSObject
	[BaseType (typeof(NSObject))]
	interface DKNSInteger
	{
		// +(DKNSIntegerPicker)DKNSIntegerPickerWithints:(NSArray<NSNumber *> *)ints;
		[Static]
		[Export ("DKNSIntegerPickerWithints:")]
		DKNSIntegerPicker DKNSIntegerPickerWithints (NSNumber[] ints);
	}

	// @interface Night (UIActivityIndicatorView)
	[Category]
	[BaseType (typeof(UIActivityIndicatorView))]
	interface UIActivityIndicatorView_Night
	{
		// @property (nonatomic, setter = dk_setActivityIndicatorViewStyle:) DKNSIntegerPicker dk_activityIndicatorViewStyle;
		[Export ("dk_activityIndicatorViewStyle", ArgumentSemantic.Assign)]
		DKNSIntegerPicker Dk_activityIndicatorViewStyle { get; [Bind ("dk_setActivityIndicatorViewStyle:")] set; }
	}
}
