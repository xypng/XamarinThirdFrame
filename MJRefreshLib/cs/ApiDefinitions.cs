using System;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace MJRefresh
{
	// typedef void (^BeginRefreshingBlock)(MJRefreshBaseView *);
	delegate void BeginRefreshingBlock (MJRefreshBaseView arg0);

	// typedef void (^EndRefreshingBlock)(MJRefreshBaseView *);
	delegate void EndRefreshingBlock (MJRefreshBaseView arg0);

	// typedef void (^RefreshStateChangeBlock)(MJRefreshBaseView *, MJRefreshState);
	delegate void RefreshStateChangeBlock (MJRefreshBaseView arg0, MJRefreshState arg1);

	// @protocol MJRefreshBaseViewDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface MJRefreshBaseViewDelegate
	{
		// @optional -(void)refreshViewBeginRefreshing:(MJRefreshBaseView *)refreshView;
		[Export ("refreshViewBeginRefreshing:")]
		void RefreshViewBeginRefreshing (MJRefreshBaseView refreshView);

		// @optional -(void)refreshViewEndRefreshing:(MJRefreshBaseView *)refreshView;
		[Export ("refreshViewEndRefreshing:")]
		void RefreshViewEndRefreshing (MJRefreshBaseView refreshView);

		// @optional -(void)refreshView:(MJRefreshBaseView *)refreshView stateChange:(MJRefreshState)state;
		[Export ("refreshView:stateChange:")]
		void RefreshView (MJRefreshBaseView refreshView, MJRefreshState state);
	}

	// @interface MJRefreshBaseView : UIView
	[BaseType (typeof(UIView))]
	interface MJRefreshBaseView
	{
		// -(instancetype)initWithScrollView:(UIScrollView *)scrollView;
		[Export ("initWithScrollView:")]
		IntPtr Constructor (UIScrollView scrollView);

		// @property (nonatomic, weak) UIScrollView * scrollView;
		[Export ("scrollView", ArgumentSemantic.Weak)]
		UIScrollView ScrollView { get; set; }

		// @property (readonly, nonatomic, weak) UILabel * lastUpdateTimeLabel;
		[Export ("lastUpdateTimeLabel", ArgumentSemantic.Weak)]
		UILabel LastUpdateTimeLabel { get; }

		// @property (readonly, nonatomic, weak) UILabel * statusLabel;
		[Export ("statusLabel", ArgumentSemantic.Weak)]
		UILabel StatusLabel { get; }

		// @property (readonly, nonatomic, weak) UIImageView * arrowImage;
		[Export ("arrowImage", ArgumentSemantic.Weak)]
		UIImageView ArrowImage { get; }

		// @property (readonly, nonatomic, weak) UIActivityIndicatorView * activityView;
		[Export ("activityView", ArgumentSemantic.Weak)]
		UIActivityIndicatorView ActivityView { get; }

		// @property (copy, nonatomic) BeginRefreshingBlock beginRefreshingBlock;
		[Export ("beginRefreshingBlock", ArgumentSemantic.Copy)]
		BeginRefreshingBlock BeginRefreshingBlock { get; set; }

		// @property (copy, nonatomic) RefreshStateChangeBlock refreshStateChangeBlock;
		[Export ("refreshStateChangeBlock", ArgumentSemantic.Copy)]
		RefreshStateChangeBlock RefreshStateChangeBlock { get; set; }

		// @property (copy, nonatomic) EndRefreshingBlock endStateChangeBlock;
		[Export ("endStateChangeBlock", ArgumentSemantic.Copy)]
		EndRefreshingBlock EndStateChangeBlock { get; set; }

		[Wrap ("WeakDelegate")]
		MJRefreshBaseViewDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<MJRefreshBaseViewDelegate> delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (readonly, getter = isRefreshing, nonatomic) BOOL refreshing;
		[Export ("refreshing")]
		bool Refreshing { [Bind ("isRefreshing")] get; }

		// -(void)beginRefreshing;
		[Export ("beginRefreshing")]
		void BeginRefreshing ();

		// -(void)endRefreshing;
		[Export ("endRefreshing")]
		void EndRefreshing ();

		// -(void)free;
		[Export ("free")]
		void Free ();

		// -(void)setState:(MJRefreshState)state;
		[Export ("setState:")]
		void SetState (MJRefreshState state);

		// -(int)totalDataCountInScrollView;
		[Export ("totalDataCountInScrollView")]
		[Verify (MethodToProperty)]
		int TotalDataCountInScrollView { get; }
	}

	// @interface MJRefreshFooterView : MJRefreshBaseView
	[BaseType (typeof(MJRefreshBaseView))]
	interface MJRefreshFooterView
	{
		// +(instancetype)footer;
		[Static]
		[Export ("footer")]
		MJRefreshFooterView Footer ();
	}

	// @interface MJRefreshHeaderView : MJRefreshBaseView
	[BaseType (typeof(MJRefreshBaseView))]
	interface MJRefreshHeaderView
	{
		// +(instancetype)header;
		[Static]
		[Export ("header")]
		MJRefreshHeaderView Header ();
	}

	[Static]
	[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern const CGFloat MJRefreshViewHeight;
		[Field ("MJRefreshViewHeight", "__Internal")]
		nfloat MJRefreshViewHeight { get; }

		// extern const CGFloat MJRefreshAnimationDuration;
		[Field ("MJRefreshAnimationDuration", "__Internal")]
		nfloat MJRefreshAnimationDuration { get; }

		// extern NSString *const MJRefreshBundleName;
		[Field ("MJRefreshBundleName", "__Internal")]
		NSString MJRefreshBundleName { get; }

		// extern NSString *const MJRefreshFooterPullToRefresh;
		[Field ("MJRefreshFooterPullToRefresh", "__Internal")]
		NSString MJRefreshFooterPullToRefresh { get; }

		// extern NSString *const MJRefreshFooterReleaseToRefresh;
		[Field ("MJRefreshFooterReleaseToRefresh", "__Internal")]
		NSString MJRefreshFooterReleaseToRefresh { get; }

		// extern NSString *const MJRefreshFooterRefreshing;
		[Field ("MJRefreshFooterRefreshing", "__Internal")]
		NSString MJRefreshFooterRefreshing { get; }

		// extern NSString *const MJRefreshHeaderPullToRefresh;
		[Field ("MJRefreshHeaderPullToRefresh", "__Internal")]
		NSString MJRefreshHeaderPullToRefresh { get; }

		// extern NSString *const MJRefreshHeaderReleaseToRefresh;
		[Field ("MJRefreshHeaderReleaseToRefresh", "__Internal")]
		NSString MJRefreshHeaderReleaseToRefresh { get; }

		// extern NSString *const MJRefreshHeaderRefreshing;
		[Field ("MJRefreshHeaderRefreshing", "__Internal")]
		NSString MJRefreshHeaderRefreshing { get; }

		// extern NSString *const MJRefreshHeaderTimeKey;
		[Field ("MJRefreshHeaderTimeKey", "__Internal")]
		NSString MJRefreshHeaderTimeKey { get; }

		// extern NSString *const MJRefreshContentOffset;
		[Field ("MJRefreshContentOffset", "__Internal")]
		NSString MJRefreshContentOffset { get; }

		// extern NSString *const MJRefreshContentSize;
		[Field ("MJRefreshContentSize", "__Internal")]
		NSString MJRefreshContentSize { get; }
	}
}
