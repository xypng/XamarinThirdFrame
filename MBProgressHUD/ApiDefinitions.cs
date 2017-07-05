using System;
using CoreFoundation;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace MBProgressHUB.iOS
{
	[Static]
	[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern const CGFloat MBProgressMaxOffset;
		[Field ("MBProgressMaxOffset", "__Internal")]
		nfloat MBProgressMaxOffset { get; }
	}

	// typedef void (^MBProgressHUDCompletionBlock)();
	delegate void MBProgressHUDCompletionBlock ();

	// @interface MBProgressHUD : UIView
	[BaseType (typeof(UIView))]
	interface MBProgressHUD
	{
		// +(instancetype _Nonnull)showHUDAddedTo:(UIView * _Nonnull)view animated:(BOOL)animated;
		[Static]
		[Export ("showHUDAddedTo:animated:")]
		MBProgressHUD ShowHUDAddedTo (UIView view, bool animated);

		// +(BOOL)hideHUDForView:(UIView * _Nonnull)view animated:(BOOL)animated;
		[Static]
		[Export ("hideHUDForView:animated:")]
		bool HideHUDForView (UIView view, bool animated);

		// +(MBProgressHUD * _Nullable)HUDForView:(UIView * _Nonnull)view;
		[Static]
		[Export ("HUDForView:")]
		[return: NullAllowed]
		MBProgressHUD HUDForView (UIView view);

		// -(instancetype _Nonnull)initWithView:(UIView * _Nonnull)view;
		[Export ("initWithView:")]
		IntPtr Constructor (UIView view);

		// -(void)showAnimated:(BOOL)animated;
		[Export ("showAnimated:")]
		void ShowAnimated (bool animated);

		// -(void)hideAnimated:(BOOL)animated;
		[Export ("hideAnimated:")]
		void HideAnimated (bool animated);

		// -(void)hideAnimated:(BOOL)animated afterDelay:(NSTimeInterval)delay;
		[Export ("hideAnimated:afterDelay:")]
		void HideAnimated (bool animated, double delay);

		[Wrap ("WeakDelegate")]
		[NullAllowed]
		MBProgressHUDDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<MBProgressHUDDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (copy) MBProgressHUDCompletionBlock _Nullable completionBlock;
		[NullAllowed, Export ("completionBlock", ArgumentSemantic.Copy)]
		MBProgressHUDCompletionBlock CompletionBlock { get; set; }

		// @property (assign, nonatomic) NSTimeInterval graceTime;
		[Export ("graceTime")]
		double GraceTime { get; set; }

		// @property (assign, nonatomic) NSTimeInterval minShowTime;
		[Export ("minShowTime")]
		double MinShowTime { get; set; }

		// @property (assign, nonatomic) BOOL removeFromSuperViewOnHide;
		[Export ("removeFromSuperViewOnHide")]
		bool RemoveFromSuperViewOnHide { get; set; }

		// @property (assign, nonatomic) MBProgressHUDMode mode;
		[Export ("mode", ArgumentSemantic.Assign)]
		MBProgressHUDMode Mode { get; set; }

		// @property (nonatomic, strong) UIColor * _Nullable contentColor __attribute__((annotate("ui_appearance_selector")));
		[NullAllowed, Export ("contentColor", ArgumentSemantic.Strong)]
		UIColor ContentColor { get; set; }

		// @property (assign, nonatomic) MBProgressHUDAnimation animationType __attribute__((annotate("ui_appearance_selector")));
		[Export ("animationType", ArgumentSemantic.Assign)]
		MBProgressHUDAnimation AnimationType { get; set; }

		// @property (assign, nonatomic) CGPoint offset __attribute__((annotate("ui_appearance_selector")));
		[Export ("offset", ArgumentSemantic.Assign)]
		CGPoint Offset { get; set; }

		// @property (assign, nonatomic) CGFloat margin __attribute__((annotate("ui_appearance_selector")));
		[Export ("margin")]
		nfloat Margin { get; set; }

		// @property (assign, nonatomic) CGSize minSize __attribute__((annotate("ui_appearance_selector")));
		[Export ("minSize", ArgumentSemantic.Assign)]
		CGSize MinSize { get; set; }

		// @property (getter = isSquare, assign, nonatomic) BOOL square __attribute__((annotate("ui_appearance_selector")));
		[Export ("square")]
		bool Square { [Bind ("isSquare")] get; set; }

		// @property (getter = areDefaultMotionEffectsEnabled, assign, nonatomic) BOOL defaultMotionEffectsEnabled __attribute__((annotate("ui_appearance_selector")));
		[Export ("defaultMotionEffectsEnabled")]
		bool DefaultMotionEffectsEnabled { [Bind ("areDefaultMotionEffectsEnabled")] get; set; }

		// @property (assign, nonatomic) float progress;
		[Export ("progress")]
		float Progress { get; set; }

		// @property (nonatomic, strong) NSProgress * _Nullable progressObject;
		[NullAllowed, Export ("progressObject", ArgumentSemantic.Strong)]
		NSProgress ProgressObject { get; set; }

		// @property (readonly, nonatomic, strong) MBBackgroundView * _Nonnull bezelView;
		[Export ("bezelView", ArgumentSemantic.Strong)]
		MBBackgroundView BezelView { get; }

		// @property (readonly, nonatomic, strong) MBBackgroundView * _Nonnull backgroundView;
		[Export ("backgroundView", ArgumentSemantic.Strong)]
		MBBackgroundView BackgroundView { get; }

		// @property (nonatomic, strong) UIView * _Nullable customView;
		[NullAllowed, Export ("customView", ArgumentSemantic.Strong)]
		UIView CustomView { get; set; }

		// @property (readonly, nonatomic, strong) UILabel * _Nonnull label;
		[Export ("label", ArgumentSemantic.Strong)]
		UILabel Label { get; }

		// @property (readonly, nonatomic, strong) UILabel * _Nonnull detailsLabel;
		[Export ("detailsLabel", ArgumentSemantic.Strong)]
		UILabel DetailsLabel { get; }

		// @property (readonly, nonatomic, strong) UIButton * _Nonnull button;
		[Export ("button", ArgumentSemantic.Strong)]
		UIButton Button { get; }
	}

	// @protocol MBProgressHUDDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface MBProgressHUDDelegate
	{
		// @optional -(void)hudWasHidden:(MBProgressHUD * _Nonnull)hud;
		[Export ("hudWasHidden:")]
		void HudWasHidden (MBProgressHUD hud);
	}

	// @interface MBRoundProgressView : UIView
	[BaseType (typeof(UIView))]
	interface MBRoundProgressView
	{
		// @property (assign, nonatomic) float progress;
		[Export ("progress")]
		float Progress { get; set; }

		// @property (nonatomic, strong) UIColor * _Nonnull progressTintColor;
		[Export ("progressTintColor", ArgumentSemantic.Strong)]
		UIColor ProgressTintColor { get; set; }

		// @property (nonatomic, strong) UIColor * _Nonnull backgroundTintColor;
		[Export ("backgroundTintColor", ArgumentSemantic.Strong)]
		UIColor BackgroundTintColor { get; set; }

		// @property (getter = isAnnular, assign, nonatomic) BOOL annular;
		[Export ("annular")]
		bool Annular { [Bind ("isAnnular")] get; set; }
	}

	// @interface MBBarProgressView : UIView
	[BaseType (typeof(UIView))]
	interface MBBarProgressView
	{
		// @property (assign, nonatomic) float progress;
		[Export ("progress")]
		float Progress { get; set; }

		// @property (nonatomic, strong) UIColor * _Nonnull lineColor;
		[Export ("lineColor", ArgumentSemantic.Strong)]
		UIColor LineColor { get; set; }

		// @property (nonatomic, strong) UIColor * _Nonnull progressRemainingColor;
		[Export ("progressRemainingColor", ArgumentSemantic.Strong)]
		UIColor ProgressRemainingColor { get; set; }

		// @property (nonatomic, strong) UIColor * _Nonnull progressColor;
		[Export ("progressColor", ArgumentSemantic.Strong)]
		UIColor ProgressColor { get; set; }
	}

	// @interface MBBackgroundView : UIView
	[BaseType (typeof(UIView))]
	interface MBBackgroundView
	{
		// @property (nonatomic) MBProgressHUDBackgroundStyle style;
		[Export ("style", ArgumentSemantic.Assign)]
		MBProgressHUDBackgroundStyle Style { get; set; }

		// @property (nonatomic, strong) UIColor * _Nonnull color;
		[Export ("color", ArgumentSemantic.Strong)]
		UIColor Color { get; set; }
	}

	// @interface Other (MBProgressHUD)
	[Category]
	[BaseType (typeof(MBProgressHUD))]
	interface MBProgressHUD_Other
	{
		// +(NSArray * _Nonnull)allHUDsForView:(UIView * _Nonnull)view __attribute__((deprecated("Store references when using more than one HUD per view.")));
		[Static]
		[Export ("allHUDsForView:")]
		[Verify (StronglyTypedNSArray)]
		NSObject[] AllHUDsForView (UIView view);

		// +(NSUInteger)hideAllHUDsForView:(UIView * _Nonnull)view animated:(BOOL)animated __attribute__((deprecated("Store references when using more than one HUD per view.")));
		[Static]
		[Export ("hideAllHUDsForView:animated:")]
		nuint HideAllHUDsForView (UIView view, bool animated);

		// -(id _Nonnull)initWithWindow:(UIWindow * _Nonnull)window __attribute__((deprecated("Use initWithView: instead.")));
		[Export ("initWithWindow:")]
		IntPtr Constructor (UIWindow window);

		// -(void)show:(BOOL)animated __attribute__((deprecated("Use showAnimated: instead.")));
		[Export ("show:")]
		void Show (bool animated);

		// -(void)hide:(BOOL)animated __attribute__((deprecated("Use hideAnimated: instead.")));
		[Export ("hide:")]
		void Hide (bool animated);

		// -(void)hide:(BOOL)animated afterDelay:(NSTimeInterval)delay __attribute__((deprecated("Use hideAnimated:afterDelay: instead.")));
		[Export ("hide:afterDelay:")]
		void Hide (bool animated, double delay);

		// -(void)showWhileExecuting:(SEL _Nonnull)method onTarget:(id _Nonnull)target withObject:(id _Nonnull)object animated:(BOOL)animated __attribute__((deprecated("Use GCD directly.")));
		[Export ("showWhileExecuting:onTarget:withObject:animated:")]
		void ShowWhileExecuting (Selector method, NSObject target, NSObject @object, bool animated);

		// -(void)showAnimated:(BOOL)animated whileExecutingBlock:(dispatch_block_t _Nonnull)block __attribute__((deprecated("Use GCD directly.")));
		[Export ("showAnimated:whileExecutingBlock:")]
		void ShowAnimated (bool animated, dispatch_block_t block);

		// -(void)showAnimated:(BOOL)animated whileExecutingBlock:(dispatch_block_t _Nonnull)block completionBlock:(MBProgressHUDCompletionBlock _Nullable)completion __attribute__((deprecated("Use GCD directly.")));
		[Export ("showAnimated:whileExecutingBlock:completionBlock:")]
		void ShowAnimated (bool animated, dispatch_block_t block, [NullAllowed] MBProgressHUDCompletionBlock completion);

		// -(void)showAnimated:(BOOL)animated whileExecutingBlock:(dispatch_block_t _Nonnull)block onQueue:(dispatch_queue_t _Nonnull)queue __attribute__((deprecated("Use GCD directly.")));
		[Export ("showAnimated:whileExecutingBlock:onQueue:")]
		void ShowAnimated (bool animated, dispatch_block_t block, DispatchQueue queue);

		// -(void)showAnimated:(BOOL)animated whileExecutingBlock:(dispatch_block_t _Nonnull)block onQueue:(dispatch_queue_t _Nonnull)queue completionBlock:(MBProgressHUDCompletionBlock _Nullable)completion __attribute__((deprecated("Use GCD directly.")));
		[Export ("showAnimated:whileExecutingBlock:onQueue:completionBlock:")]
		void ShowAnimated (bool animated, dispatch_block_t block, DispatchQueue queue, [NullAllowed] MBProgressHUDCompletionBlock completion);

		// @property (assign) BOOL taskInProgress __attribute__((deprecated("No longer needed.")));
		[Export ("taskInProgress")]
		bool TaskInProgress { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull labelText __attribute__((deprecated("Use label.text instead.")));
		[Export ("labelText")]
		string LabelText { get; set; }

		// @property (nonatomic, strong) UIFont * _Nonnull labelFont __attribute__((deprecated("Use label.font instead.")));
		[Export ("labelFont", ArgumentSemantic.Strong)]
		UIFont LabelFont { get; set; }

		// @property (nonatomic, strong) UIColor * _Nonnull labelColor __attribute__((deprecated("Use label.textColor instead.")));
		[Export ("labelColor", ArgumentSemantic.Strong)]
		UIColor LabelColor { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull detailsLabelText __attribute__((deprecated("Use detailsLabel.text instead.")));
		[Export ("detailsLabelText")]
		string DetailsLabelText { get; set; }

		// @property (nonatomic, strong) UIFont * _Nonnull detailsLabelFont __attribute__((deprecated("Use detailsLabel.font instead.")));
		[Export ("detailsLabelFont", ArgumentSemantic.Strong)]
		UIFont DetailsLabelFont { get; set; }

		// @property (nonatomic, strong) UIColor * _Nonnull detailsLabelColor __attribute__((deprecated("Use detailsLabel.textColor instead.")));
		[Export ("detailsLabelColor", ArgumentSemantic.Strong)]
		UIColor DetailsLabelColor { get; set; }

		// @property (assign, nonatomic) CGFloat opacity __attribute__((deprecated("Customize bezelView properties instead.")));
		[Export ("opacity")]
		nfloat Opacity { get; set; }

		// @property (nonatomic, strong) UIColor * _Nonnull color __attribute__((deprecated("Customize the bezelView color instead.")));
		[Export ("color", ArgumentSemantic.Strong)]
		UIColor Color { get; set; }

		// @property (assign, nonatomic) CGFloat xOffset __attribute__((deprecated("Set offset.x instead.")));
		[Export ("xOffset")]
		nfloat XOffset { get; set; }

		// @property (assign, nonatomic) CGFloat yOffset __attribute__((deprecated("Set offset.y instead.")));
		[Export ("yOffset")]
		nfloat YOffset { get; set; }

		// @property (assign, nonatomic) CGFloat cornerRadius __attribute__((deprecated("Set bezelView.layer.cornerRadius instead.")));
		[Export ("cornerRadius")]
		nfloat CornerRadius { get; set; }

		// @property (assign, nonatomic) BOOL dimBackground __attribute__((deprecated("Customize HUD background properties instead.")));
		[Export ("dimBackground")]
		bool DimBackground { get; set; }

		// @property (nonatomic, strong) UIColor * _Nonnull activityIndicatorColor __attribute__((deprecated("Use UIAppearance to customize UIActivityIndicatorView. E.g.: [UIActivityIndicatorView appearanceWhenContainedIn:[MBProgressHUD class], nil].color = [UIColor redColor];")));
		[Export ("activityIndicatorColor", ArgumentSemantic.Strong)]
		UIColor ActivityIndicatorColor { get; set; }

		// @property (readonly, assign, atomic) CGSize size __attribute__((deprecated("Get the bezelView.frame.size instead.")));
		[Export ("size", ArgumentSemantic.Assign)]
		CGSize Size { get; }
	}
}
