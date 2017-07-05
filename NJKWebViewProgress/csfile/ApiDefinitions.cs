using Foundation;
using ObjCRuntime;
using UIKit;

namespace WebViewProgress.iOS
{
	[Static]
	[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern const float NJKInitialProgressValue;
		[Field ("NJKInitialProgressValue", "__Internal")]
		float NJKInitialProgressValue { get; }

		// extern const float NJKInteractiveProgressValue;
		[Field ("NJKInteractiveProgressValue", "__Internal")]
		float NJKInteractiveProgressValue { get; }

		// extern const float NJKFinalProgressValue;
		[Field ("NJKFinalProgressValue", "__Internal")]
		float NJKFinalProgressValue { get; }
	}

	// typedef void (^NJKWebViewProgressBlock)(float);
	delegate void NJKWebViewProgressBlock (float arg0);

	// @interface NJKWebViewProgress : NSObject <UIWebViewDelegate>
	[BaseType (typeof(NSObject))]
	interface NJKWebViewProgress : IUIWebViewDelegate
	{
		[Wrap ("WeakProgressDelegate")]
		NJKWebViewProgressDelegate ProgressDelegate { get; set; }

		// @property (nonatomic, unsafe_unretained) id<NJKWebViewProgressDelegate> progressDelegate;
		[NullAllowed, Export ("progressDelegate", ArgumentSemantic.Assign)]
		NSObject WeakProgressDelegate { get; set; }

		[Wrap ("WeakWebViewProxyDelegate")]
		UIWebViewDelegate WebViewProxyDelegate { get; set; }

		// @property (nonatomic, unsafe_unretained) id<UIWebViewDelegate> webViewProxyDelegate;
		[NullAllowed, Export ("webViewProxyDelegate", ArgumentSemantic.Assign)]
		NSObject WeakWebViewProxyDelegate { get; set; }

		// @property (copy, nonatomic) NJKWebViewProgressBlock progressBlock;
		[Export ("progressBlock", ArgumentSemantic.Copy)]
		NJKWebViewProgressBlock ProgressBlock { get; set; }

		// @property (readonly, nonatomic) float progress;
		[Export ("progress")]
		float Progress { get; }

		// -(void)reset;
		[Export ("reset")]
		void Reset ();
	}

	// @protocol NJKWebViewProgressDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface NJKWebViewProgressDelegate
	{
		// @required -(void)webViewProgress:(NJKWebViewProgress *)webViewProgress updateProgress:(float)progress;
		[Abstract]
		[Export ("webViewProgress:updateProgress:")]
		void UpdateProgress (NJKWebViewProgress webViewProgress, float progress);
	}

	// @interface NJKWebViewProgressView : UIView
	[BaseType (typeof(UIView))]
	interface NJKWebViewProgressView
	{
		// @property (nonatomic) float progress;
		[Export ("progress")]
		float Progress { get; set; }

		// @property (nonatomic) UIView * progressBarView;
		[Export ("progressBarView", ArgumentSemantic.Assign)]
		UIView ProgressBarView { get; set; }

		// @property (nonatomic) NSTimeInterval barAnimationDuration;
		[Export ("barAnimationDuration")]
		double BarAnimationDuration { get; set; }

		// @property (nonatomic) NSTimeInterval fadeAnimationDuration;
		[Export ("fadeAnimationDuration")]
		double FadeAnimationDuration { get; set; }

		// @property (nonatomic) NSTimeInterval fadeOutDelay;
		[Export ("fadeOutDelay")]
		double FadeOutDelay { get; set; }

		// -(void)setProgress:(float)progress animated:(BOOL)animated;
		[Export ("setProgress:animated:")]
		void SetProgress (float progress, bool animated);
	}
}
