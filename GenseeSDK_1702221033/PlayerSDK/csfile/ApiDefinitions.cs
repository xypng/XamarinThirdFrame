using System;
using AVFoundation;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using PlayerSDK;
using UIKit;

namespace GenseePlayer.ios
{
	// @interface GSPUserInfo : NSObject
	[BaseType (typeof(NSObject))]
	interface GSPUserInfo
	{
		// @property (assign, nonatomic) long long userID;
		[Export ("userID")]
		long UserID { get; set; }

		// @property (nonatomic, strong) NSString * userName;
		[Export ("userName", ArgumentSemantic.Strong)]
		string UserName { get; set; }

		// @property (assign, nonatomic) unsigned int chatID;
		[Export ("chatID")]
		uint ChatID { get; set; }

		// @property (assign, nonatomic) unsigned int role;
		[Export ("role")]
		uint Role { get; set; }
	}

	// @interface GSPChatMessage : NSObject
	[BaseType (typeof(NSObject))]
	interface GSPChatMessage
	{
		// @property (copy, nonatomic) NSString * text;
		[Export ("text")]
		string Text { get; set; }

		// @property (copy, nonatomic) NSString * richText;
		[Export ("richText")]
		string RichText { get; set; }

		// @property (copy, nonatomic) NSString * senderName;
		[Export ("senderName")]
		string SenderName { get; set; }

		// @property (assign, nonatomic) long long senderUserID;
		[Export ("senderUserID")]
		long SenderUserID { get; set; }

		// @property (assign, nonatomic) unsigned int senderChatID;
		[Export ("senderChatID")]
		uint SenderChatID { get; set; }

		// @property (assign, nonatomic) long long receiveTime;
		[Export ("receiveTime")]
		long ReceiveTime { get; set; }

		// @property (assign, nonatomic) GSPChatType chatType;
		[Export ("chatType", ArgumentSemantic.Assign)]
		GSPChatType ChatType { get; set; }

		// @property (assign, nonatomic) long long targetUserID;
		[Export ("targetUserID")]
		long TargetUserID { get; set; }

		// @property (copy, nonatomic) NSString * targetUserName;
		[Export ("targetUserName")]
		string TargetUserName { get; set; }

		// @property (assign, nonatomic) NSUInteger role;
		[Export ("role")]
		nuint Role { get; set; }
	}

	// @interface GSPChatView : UIView
	[BaseType (typeof(UIView))]
	interface GSPChatView
	{
		// -(id)initWithFrame:(CGRect)frame;
		[Export ("initWithFrame:")]
		IntPtr Constructor (CGRect frame);

		// @property (nonatomic, strong) GSPUserInfo * chatTargetUser;
		[Export ("chatTargetUser", ArgumentSemantic.Strong)]
		GSPUserInfo ChatTargetUser { get; set; }

		// -(void)receiveMessage:(GSPChatMessage *)chatMessage;
		[Export ("receiveMessage:")]
		void ReceiveMessage (GSPChatMessage chatMessage);

		// -(BOOL)sendMessage:(NSString *)content;
		[Export ("sendMessage:")]
		bool SendMessage (string content);

		// @property (assign, nonatomic) BOOL isChatEnabled;
		[Export ("isChatEnabled")]
		bool IsChatEnabled { get; set; }

		// @property (nonatomic, weak) GSPChatInputToolView * inputToolView;
		[Export ("inputToolView", ArgumentSemantic.Weak)]
		GSPChatInputToolView InputToolView { get; set; }

		// @property (nonatomic, weak) GSPPlayerManager * playerManager;
		[Export ("playerManager", ArgumentSemantic.Weak)]
		GSPPlayerManager PlayerManager { get; set; }
	}

	// @interface GSPJoinParam : NSObject
	[BaseType (typeof(NSObject))]
	interface GSPJoinParam
	{
		// @property (copy, nonatomic) NSString * domain;
		[Export ("domain")]
		string Domain { get; set; }

		// @property (assign, nonatomic) GSPServiceType serviceType;
		[Export ("serviceType", ArgumentSemantic.Assign)]
		GSPServiceType ServiceType { get; set; }

		// @property (copy, nonatomic) NSString * webcastID;
		[Export ("webcastID")]
		string WebcastID { get; set; }

		// @property (copy, nonatomic) NSString * roomNumber;
		[Export ("roomNumber")]
		string RoomNumber { get; set; }

		// @property (copy, nonatomic) NSString * nickName;
		[Export ("nickName")]
		string NickName { get; set; }

		// @property (copy, nonatomic) NSString * watchPassword;
		[Export ("watchPassword")]
		string WatchPassword { get; set; }

		// @property (copy, nonatomic) NSString * loginName;
		[Export ("loginName")]
		string LoginName { get; set; }

		// @property (copy, nonatomic) NSString * loginPassword;
		[Export ("loginPassword")]
		string LoginPassword { get; set; }

		// @property (assign, nonatomic) long long customUserID;
		[Export ("customUserID")]
		long CustomUserID { get; set; }

		// @property (assign, nonatomic) BOOL needsValidateCustomUserID;
		[Export ("needsValidateCustomUserID")]
		bool NeedsValidateCustomUserID { get; set; }

		// @property (copy, nonatomic) NSString * thirdToken;
		[Export ("thirdToken")]
		string ThirdToken { get; set; }

		// @property (assign, nonatomic) BOOL oldVersion;
		[Export ("oldVersion")]
		bool OldVersion { get; set; }
	}

	// @interface GSPDocument : NSObject
	[BaseType (typeof(NSObject))]
	interface GSPDocument
	{
		// @property (assign, nonatomic) unsigned int docID;
		[Export ("docID")]
		uint DocID { get; set; }

		// @property (nonatomic, strong) NSMutableDictionary * pages;
		[Export ("pages", ArgumentSemantic.Strong)]
		NSMutableDictionary Pages { get; set; }

		// @property (assign, nonatomic) int currentPageIndex;
		[Export ("currentPageIndex")]
		int CurrentPageIndex { get; set; }

		// @property (assign, nonatomic) BOOL savedOnServer;
		[Export ("savedOnServer")]
		bool SavedOnServer { get; set; }

		// @property (assign, nonatomic) NSString * docName;
		[Export ("docName")]
		string DocName { get; set; }

		// @property (assign, nonatomic) long long ownerID;
		[Export ("ownerID")]
		long OwnerID { get; set; }
	}

	// @interface GSPDocPage : NSObject
	[BaseType (typeof(NSObject))]
	interface GSPDocPage
	{
		// @property (assign, nonatomic) unsigned int pageID;
		[Export ("pageID")]
		uint PageID { get; set; }

		// @property (nonatomic, strong) NSData * pageData;
		[Export ("pageData", ArgumentSemantic.Strong)]
		NSData PageData { get; set; }

		// @property (assign, nonatomic) short pageWidth;
		[Export ("pageWidth")]
		short PageWidth { get; set; }

		// @property (assign, nonatomic) short pageHeight;
		[Export ("pageHeight")]
		short PageHeight { get; set; }

		// @property (nonatomic, strong) NSMutableDictionary * annos;
		[Export ("annos", ArgumentSemantic.Strong)]
		NSMutableDictionary Annos { get; set; }
	}

	// @interface GSPAnnoBase : NSObject
	[BaseType (typeof(NSObject))]
	interface GSPAnnoBase
	{
		// @property (assign, nonatomic) GSPDocumentAnnoType type;
		[Export ("type", ArgumentSemantic.Assign)]
		GSPDocumentAnnoType Type { get; set; }

		// @property (assign, nonatomic) long long annoID;
		[Export ("annoID")]
		long AnnoID { get; set; }

		// @property (assign, nonatomic) unsigned int pageID;
		[Export ("pageID")]
		uint PageID { get; set; }

		// @property (assign, nonatomic) unsigned int docID;
		[Export ("docID")]
		uint DocID { get; set; }
	}

	// @interface GSPAnnoCircle : GSPAnnoBase
	[BaseType (typeof(GSPAnnoBase))]
	interface GSPAnnoCircle
	{
		// @property (assign, nonatomic) Byte lineSize;
		[Export ("lineSize")]
		byte LineSize { get; set; }

		// @property (nonatomic, strong) UIColor * lineColor;
		[Export ("lineColor", ArgumentSemantic.Strong)]
		UIColor LineColor { get; set; }

		// @property (assign, nonatomic) CGRect rect;
		[Export ("rect", ArgumentSemantic.Assign)]
		CGRect Rect { get; set; }
	}

	// @interface GSPAnnoFreePen : GSPAnnoBase
	[BaseType (typeof(GSPAnnoBase))]
	interface GSPAnnoFreePen
	{
		// @property (nonatomic, strong) NSMutableArray * points;
		[Export ("points", ArgumentSemantic.Strong)]
		NSMutableArray Points { get; set; }

		// @property (assign, nonatomic) Byte lineSize;
		[Export ("lineSize")]
		byte LineSize { get; set; }

		// @property (nonatomic, strong) UIColor * lineColor;
		[Export ("lineColor", ArgumentSemantic.Strong)]
		UIColor LineColor { get; set; }
	}

	// @interface GSPAnnoFreePenEx : GSPAnnoFreePen
	[BaseType (typeof(GSPAnnoFreePen))]
	interface GSPAnnoFreePenEx
	{
		// @property (assign, nonatomic) Byte stepType;
		[Export ("stepType")]
		byte StepType { get; set; }
	}

	// @interface GSPAnnoLine : GSPAnnoBase
	[BaseType (typeof(GSPAnnoBase))]
	interface GSPAnnoLine
	{
		// @property (assign, nonatomic) Byte lineSize;
		[Export ("lineSize")]
		byte LineSize { get; set; }

		// @property (nonatomic, strong) UIColor * lineColor;
		[Export ("lineColor", ArgumentSemantic.Strong)]
		UIColor LineColor { get; set; }

		// @property (assign, nonatomic) CGPoint startPoint;
		[Export ("startPoint", ArgumentSemantic.Assign)]
		CGPoint StartPoint { get; set; }

		// @property (assign, nonatomic) CGPoint endPoint;
		[Export ("endPoint", ArgumentSemantic.Assign)]
		CGPoint EndPoint { get; set; }
	}

	// @interface GSPAnnoLineEx : GSPAnnoLine
	[BaseType (typeof(GSPAnnoLine))]
	interface GSPAnnoLineEx
	{
		// @property (assign, nonatomic) Byte lineType;
		[Export ("lineType")]
		byte LineType { get; set; }
	}

	// @interface GSPAnnoPoint : GSPAnnoBase
	[BaseType (typeof(GSPAnnoBase))]
	interface GSPAnnoPoint
	{
		// @property (assign, nonatomic) CGPoint point;
		[Export ("point", ArgumentSemantic.Assign)]
		CGPoint Point { get; set; }
	}

	// @interface GSPAnnoPointEx : GSPAnnoPoint
	[BaseType (typeof(GSPAnnoPoint))]
	interface GSPAnnoPointEx
	{
		// @property (assign, nonatomic) Byte pointType;
		[Export ("pointType")]
		byte PointType { get; set; }
	}

	// @interface GSPAnnoRect : GSPAnnoBase
	[BaseType (typeof(GSPAnnoBase))]
	interface GSPAnnoRect
	{
		// @property (assign, nonatomic) Byte lineSize;
		[Export ("lineSize")]
		byte LineSize { get; set; }

		// @property (nonatomic, strong) UIColor * lineColor;
		[Export ("lineColor", ArgumentSemantic.Strong)]
		UIColor LineColor { get; set; }

		// @property (assign, nonatomic) CGRect rect;
		[Export ("rect", ArgumentSemantic.Assign)]
		CGRect Rect { get; set; }
	}

	// @interface GSPAnnoText : GSPAnnoBase
	[BaseType (typeof(GSPAnnoBase))]
	interface GSPAnnoText
	{
		// @property (nonatomic, strong) UIColor * textColor;
		[Export ("textColor", ArgumentSemantic.Strong)]
		UIColor TextColor { get; set; }

		// @property (assign, nonatomic) Byte fontSize;
		[Export ("fontSize")]
		byte FontSize { get; set; }

		// @property (nonatomic, strong) NSString * text;
		[Export ("text", ArgumentSemantic.Strong)]
		string Text { get; set; }

		// @property (assign, nonatomic) CGPoint point;
		[Export ("point", ArgumentSemantic.Assign)]
		CGPoint Point { get; set; }
	}

	// @interface GSPAnnoCleaner : GSPAnnoBase
	[BaseType (typeof(GSPAnnoBase))]
	interface GSPAnnoCleaner
	{
		// @property (assign, nonatomic) long long removedAnnoID;
		[Export ("removedAnnoID")]
		long RemovedAnnoID { get; set; }
	}

	// @protocol GSPDocViewDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface GSPDocViewDelegate
	{
		// @optional -(void)docViewPOpenFinishSuccess:(GSPDocPage *)page docID:(unsigned int)docID;
		[Export ("docViewPOpenFinishSuccess:docID:")]
		void DocID (GSPDocPage page, uint docID);
	}

	// @interface GSPDocView : UIScrollView
	[BaseType (typeof(UIScrollView))]
	interface GSPDocView
	{
		// @property (assign, nonatomic) BOOL zoomEnabled;
		[Export ("zoomEnabled")]
		bool ZoomEnabled { get; set; }

		// @property (assign, nonatomic) BOOL isVectorScale;
		[Export ("isVectorScale")]
		bool IsVectorScale { get; set; }

		// -(id)initWithFrame:(CGRect)frame;
		[Export ("initWithFrame:")]
		IntPtr Constructor (CGRect frame);

		[Wrap ("WeakPdocDelegate")]
		GSPDocViewDelegate PdocDelegate { get; set; }

		// @property (nonatomic, weak) id<GSPDocViewDelegate> pdocDelegate;
		[NullAllowed, Export ("pdocDelegate", ArgumentSemantic.Weak)]
		NSObject WeakPdocDelegate { get; set; }

		// @property (assign, nonatomic) GSPDocShowType gSDocModeType;
		[Export ("gSDocModeType", ArgumentSemantic.Assign)]
		GSPDocShowType GSDocModeType { get; set; }

		// -(void)setGlkBackgroundColor:(int)red green:(int)green blue:(int)blue;
		[Export ("setGlkBackgroundColor:green:blue:")]
		void SetGlkBackgroundColor (int red, int green, int blue);

		// -(void)drawPage:(NSData *)data with:(unsigned int)width height:(unsigned int)height;
		[Export ("drawPage:with:height:")]
		void DrawPage (NSData data, uint width, uint height);

		// -(void)drawPage:(NSData *)data with:(unsigned int)width height:(unsigned int)height strFullName:(NSString *)strFullName strSlideInfo:(NSString *)strSlideInfo;
		[Export ("drawPage:with:height:strFullName:strSlideInfo:")]
		void DrawPage (NSData data, uint width, uint height, string strFullName, string strSlideInfo);

		// -(void)drawAnno:(NSString *)xmlString;
		[Export ("drawAnno:")]
		void DrawAnno (string xmlString);

		// -(void)switchDoc:(BOOL)isEnd;
		[Export ("switchDoc:")]
		void SwitchDoc (bool isEnd);

		// -(void)goToAnimationStep:(int)step;
		[Export ("goToAnimationStep:")]
		void GoToAnimationStep (int step);
	}

	// @interface GSPVideoView : UIView
	[BaseType (typeof(UIView))]
	interface GSPVideoView
	{
		// -(instancetype)initWithFrame:(CGRect)frame;
		[Export ("initWithFrame:")]
		IntPtr Constructor (CGRect frame);

		// -(instancetype)initWithFrameNoIcon:(CGRect)frame;
		[Export ("initWithFrameNoIcon:")]
		IntPtr Constructor (CGRect frame);

		// @property (retain, nonatomic) AVSampleBufferDisplayLayer * videoLayer;
		[Export ("videoLayer", ArgumentSemantic.Retain)]
		AVSampleBufferDisplayLayer VideoLayer { get; set; }

		// @property (nonatomic, strong) id filterView;
		[Export ("filterView", ArgumentSemantic.Strong)]
		NSObject FilterView { get; set; }

		// -(void)videoStart;
		[Export ("videoStart")]
		void VideoStart ();

		// -(void)videoEnd;
		[Export ("videoEnd")]
		void VideoEnd ();

		// -(void)renderVideo:(const unsigned char *)data width:(unsigned int)width height:(unsigned int)height size:(unsigned int)size isAs:(BOOL)isAs;
		[Export ("renderVideo:width:height:size:isAs:")]
		unsafe void RenderVideo (byte* data, uint width, uint height, uint size, bool isAs);

		// -(void)renderAsVideoByImage:(UIImage *)imageFrame;
		[Export ("renderAsVideoByImage:")]
		void RenderAsVideoByImage (UIImage imageFrame);
	}

	// @interface GSPInvestigationView : UIView
	[BaseType (typeof(UIView))]
	interface GSPInvestigationView
	{
		// -(id)initWithFrame:(CGRect)frame;
		[Export ("initWithFrame:")]
		IntPtr Constructor (CGRect frame);

		// @property (readonly, assign, nonatomic) BOOL hasForceInvestigation;
		[Export ("hasForceInvestigation")]
		bool HasForceInvestigation { get; }

		// -(void)receiveVote:(NSArray *)array;
		[Export ("receiveVote:")]
		[Verify (StronglyTypedNSArray)]
		void ReceiveVote (NSObject[] array);

		// @property (nonatomic, weak) GSPPlayerManager * playerManager;
		[Export ("playerManager", ArgumentSemantic.Weak)]
		GSPPlayerManager PlayerManager { get; set; }
	}

	// @interface GSPInvestigationOption : NSObject
	[BaseType (typeof(NSObject))]
	interface GSPInvestigationOption
	{
		// @property (nonatomic, strong) NSString * ID;
		[Export ("ID", ArgumentSemantic.Strong)]
		string ID { get; set; }

		// @property (nonatomic, strong) NSString * content;
		[Export ("content", ArgumentSemantic.Strong)]
		string Content { get; set; }

		// @property (assign, nonatomic) BOOL isCorrectItem;
		[Export ("isCorrectItem")]
		bool IsCorrectItem { get; set; }

		// @property (assign, nonatomic) BOOL isSelected;
		[Export ("isSelected")]
		bool IsSelected { get; set; }

		// @property (assign, nonatomic) NSUInteger totalSumOfUsers;
		[Export ("totalSumOfUsers")]
		nuint TotalSumOfUsers { get; set; }

		// @property (assign, nonatomic) NSArray * users;
		[Export ("users", ArgumentSemantic.Assign)]
		[Verify (StronglyTypedNSArray)]
		NSObject[] Users { get; set; }
	}

	// @interface GSPInvestigationQuestion : NSObject
	[BaseType (typeof(NSObject))]
	interface GSPInvestigationQuestion
	{
		// @property (nonatomic, strong) NSString * ID;
		[Export ("ID", ArgumentSemantic.Strong)]
		string ID { get; set; }

		// @property (nonatomic, strong) NSString * content;
		[Export ("content", ArgumentSemantic.Strong)]
		string Content { get; set; }

		// @property (nonatomic, strong) NSString * essayAnswer;
		[Export ("essayAnswer", ArgumentSemantic.Strong)]
		string EssayAnswer { get; set; }

		// @property (assign, nonatomic) GSPInvestigationQuestionType questionType;
		[Export ("questionType", ArgumentSemantic.Assign)]
		GSPInvestigationQuestionType QuestionType { get; set; }

		// @property (nonatomic, strong) NSArray * options;
		[Export ("options", ArgumentSemantic.Strong)]
		[Verify (StronglyTypedNSArray)]
		NSObject[] Options { get; set; }

		// @property (assign, nonatomic) NSUInteger totalSumOfUsers;
		[Export ("totalSumOfUsers")]
		nuint TotalSumOfUsers { get; set; }

		// @property (nonatomic, strong) NSArray * users;
		[Export ("users", ArgumentSemantic.Strong)]
		[Verify (StronglyTypedNSArray)]
		NSObject[] Users { get; set; }

		// @property (assign, nonatomic) NSUInteger score;
		[Export ("score")]
		nuint Score { get; set; }
	}

	// @interface GSPInvestigation : NSObject
	[BaseType (typeof(NSObject))]
	interface GSPInvestigation
	{
		// @property (nonatomic, strong) NSString * siteID;
		[Export ("siteID", ArgumentSemantic.Strong)]
		string SiteID { get; set; }

		// @property (nonatomic, strong) NSString * configID;
		[Export ("configID", ArgumentSemantic.Strong)]
		string ConfigID { get; set; }

		// @property (nonatomic, strong) NSString * userID;
		[Export ("userID", ArgumentSemantic.Strong)]
		string UserID { get; set; }

		// @property (nonatomic, strong) NSString * live;
		[Export ("live", ArgumentSemantic.Strong)]
		string Live { get; set; }

		// @property (nonatomic, strong) NSString * ver;
		[Export ("ver", ArgumentSemantic.Strong)]
		string Ver { get; set; }

		// @property (assign, nonatomic) BOOL isCard;
		[Export ("isCard")]
		bool IsCard { get; set; }

		// @property (nonatomic, strong) NSString * ID;
		[Export ("ID", ArgumentSemantic.Strong)]
		string ID { get; set; }

		// @property (assign, nonatomic) long long ownerID;
		[Export ("ownerID")]
		long OwnerID { get; set; }

		// @property (nonatomic, strong) NSString * theme;
		[Export ("theme", ArgumentSemantic.Strong)]
		string Theme { get; set; }

		// @property (assign, nonatomic) BOOL isForce;
		[Export ("isForce")]
		bool IsForce { get; set; }

		// @property (assign, nonatomic) BOOL isPublished;
		[Export ("isPublished")]
		bool IsPublished { get; set; }

		// @property (assign, nonatomic) BOOL isResultPublished;
		[Export ("isResultPublished")]
		bool IsResultPublished { get; set; }

		// @property (assign, nonatomic) BOOL hasTerminated;
		[Export ("hasTerminated")]
		bool HasTerminated { get; set; }

		// @property (nonatomic, strong) NSArray * users;
		[Export ("users", ArgumentSemantic.Strong)]
		[Verify (StronglyTypedNSArray)]
		NSObject[] Users { get; set; }

		// @property (nonatomic, strong) NSArray * questions;
		[Export ("questions", ArgumentSemantic.Strong)]
		[Verify (StronglyTypedNSArray)]
		NSObject[] Questions { get; set; }
	}

	// @interface GSPInvestigationMyAnswer : NSObject
	[BaseType (typeof(NSObject))]
	interface GSPInvestigationMyAnswer
	{
		// @property (nonatomic, strong) NSString * questionID;
		[Export ("questionID", ArgumentSemantic.Strong)]
		string QuestionID { get; set; }

		// @property (nonatomic, strong) NSString * optionID;
		[Export ("optionID", ArgumentSemantic.Strong)]
		string OptionID { get; set; }

		// @property (nonatomic, strong) NSString * essayAnswer;
		[Export ("essayAnswer", ArgumentSemantic.Strong)]
		string EssayAnswer { get; set; }
	}

	// @protocol GSPPlayerManagerDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface GSPPlayerManagerDelegate
	{
		// @optional -(void)playerManager:(GSPPlayerManager *)playerManager didReceiveSelfJoinResult:(GSPJoinResult)joinResult __attribute__((deprecated("建议使用playerManager:didReceiveSelfJoinResult:currentIDC:")));
		[Export ("playerManager:didReceiveSelfJoinResult:")]
		void PlayerManager (GSPPlayerManager playerManager, GSPJoinResult joinResult);

		// @optional -(void)playerManager:(GSPPlayerManager *)playerManager didReceiveSelfJoinResult:(GSPJoinResult)joinResult currentIDC:(NSString *)idcKey;
		[Export ("playerManager:didReceiveSelfJoinResult:currentIDC:")]
		void PlayerManager (GSPPlayerManager playerManager, GSPJoinResult joinResult, string idcKey);

		// @optional -(void)playerManager:(GSPPlayerManager *)playerManager didReceiveSubjectInfo:(NSString *)subject;
		[Export ("playerManager:didReceiveSubjectInfo:")]
		void PlayerManager (GSPPlayerManager playerManager, string subject);

		// @optional -(void)playerManagerWillReconnect:(GSPPlayerManager *)playerManager;
		[Export ("playerManagerWillReconnect:")]
		void PlayerManagerWillReconnect (GSPPlayerManager playerManager);

		// @optional -(void)playerManagerWillBuffer:(GSPPlayerManager *)playerManager isBuffering:(BOOL)isBuffering;
		[Export ("playerManagerWillBuffer:isBuffering:")]
		void PlayerManagerWillBuffer (GSPPlayerManager playerManager, bool isBuffering);

		// @optional -(void)playerManager:(GSPPlayerManager *)playerManager didSelfLeaveFor:(GSPLeaveReason)reason;
		[Export ("playerManager:didSelfLeaveFor:")]
		void PlayerManager (GSPPlayerManager playerManager, GSPLeaveReason reason);

		// @optional -(void)playerManager:(GSPPlayerManager *)playerManager didUserJoin:(GSPUserInfo *)userInfo;
		[Export ("playerManager:didUserJoin:")]
		void PlayerManager (GSPPlayerManager playerManager, GSPUserInfo userInfo);

		// @optional -(void)playerManager:(GSPPlayerManager *)playerManager didUserLeave:(GSPUserInfo *)userInfo;
		[Export ("playerManager:didUserLeave:")]
		void PlayerManager (GSPPlayerManager playerManager, GSPUserInfo userInfo);

		// @optional -(void)playerManager:(GSPPlayerManager *)playerManager didUserStatusChange:(GSPUserInfo *)userInfo;
		[Export ("playerManager:didUserStatusChange:")]
		void PlayerManager (GSPPlayerManager playerManager, GSPUserInfo userInfo);

		// @optional -(void)playerManager:(GSPPlayerManager *)playerManager didReceiveAudioData:(const unsigned char *)data length:(unsigned int)length level:(unsigned int)level;
		[Export ("playerManager:didReceiveAudioData:length:level:")]
		unsafe void PlayerManager (GSPPlayerManager playerManager, byte* data, uint length, uint level);

		// @optional -(void)playerManagerDidVideoBegin:(GSPPlayerManager *)playerManager;
		[Export ("playerManagerDidVideoBegin:")]
		void PlayerManagerDidVideoBegin (GSPPlayerManager playerManager);

		// @optional -(void)playerManagerDidVideoEnd:(GSPPlayerManager *)playerManager;
		[Export ("playerManagerDidVideoEnd:")]
		void PlayerManagerDidVideoEnd (GSPPlayerManager playerManager);

		// @optional -(void)playerManagerDidDocumentClose:(GSPPlayerManager *)playerManager;
		[Export ("playerManagerDidDocumentClose:")]
		void PlayerManagerDidDocumentClose (GSPPlayerManager playerManager);

		// @optional -(void)playerManagerDidDocumentSwitch:(GSPPlayerManager *)playerManager;
		[Export ("playerManagerDidDocumentSwitch:")]
		void PlayerManagerDidDocumentSwitch (GSPPlayerManager playerManager);

		// @optional -(void)playerManager:(GSPPlayerManager *)playerManager didSetChatEnable:(BOOL)bEnable;
		[Export ("playerManager:didSetChatEnable:")]
		void PlayerManager (GSPPlayerManager playerManager, bool bEnable);

		// @optional -(void)playerManager:(GSPPlayerManager *)playerManager didSetQaEnable:(BOOL)bEnable;
		[Export ("playerManager:didSetQaEnable:")]
		void PlayerManager (GSPPlayerManager playerManager, bool bEnable);

		// @optional -(void)playerManager:(GSPPlayerManager *)playerManager isSelfMute:(BOOL)bMute;
		[Export ("playerManager:isSelfMute:")]
		void PlayerManager (GSPPlayerManager playerManager, bool bMute);

		// @optional -(void)playerManager:(GSPPlayerManager *)playerManager isPaused:(BOOL)isPaused;
		[Export ("playerManager:isPaused:")]
		void PlayerManager (GSPPlayerManager playerManager, bool isPaused);

		// @optional -(void)playerManager:(GSPPlayerManager *)playerManager didReceiveChatMessage:(GSPChatMessage *)message;
		[Export ("playerManager:didReceiveChatMessage:")]
		void PlayerManager (GSPPlayerManager playerManager, GSPChatMessage message);

		// @optional -(void)playerManager:(GSPPlayerManager *)playerManager didReceiveQaData:(NSArray *)qaDatas;
		[Export ("playerManager:didReceiveQaData:")]
		[Verify (StronglyTypedNSArray)]
		void PlayerManager (GSPPlayerManager playerManager, NSObject[] qaDatas);

		// @optional -(void)playerManager:(GSPPlayerManager *)playerManager didReceiveInvestigation:(NSArray *)investigations;
		[Export ("playerManager:didReceiveInvestigation:")]
		[Verify (StronglyTypedNSArray)]
		void PlayerManager (GSPPlayerManager playerManager, NSObject[] investigations);

		// @optional -(void)playerManager:(GSPPlayerManager *)playerManager didReceiveBroadcastMessage:(NSString *)msg senderID:(long long)senderID;
		[Export ("playerManager:didReceiveBroadcastMessage:senderID:")]
		void PlayerManager (GSPPlayerManager playerManager, string msg, long senderID);

		// @optional -(void)playerManager:(GSPPlayerManager *)playerManager onlineNum:(NSUInteger)num;
		[Export ("playerManager:onlineNum:")]
		void PlayerManager (GSPPlayerManager playerManager, nuint num);

		// @optional -(void)playerManager:(GSPPlayerManager *)playerManager didReceiveMediaInvitation:(GSPMediaInvitationType)type action:(BOOL)on;
		[Export ("playerManager:didReceiveMediaInvitation:action:")]
		void PlayerManager (GSPPlayerManager playerManager, GSPMediaInvitationType type, bool on);

		// @optional -(void)playerManager:(GSPPlayerManager *)playerManager didReceiveMediaModuleFocus:(GSModuleFocusType)focus;
		[Export ("playerManager:didReceiveMediaModuleFocus:")]
		void PlayerManager (GSPPlayerManager playerManager, GSModuleFocusType focus);

		// @optional -(void)playerManager:(GSPPlayerManager *)playerManager didReceiveMediaScreenStatus:(BOOL)bIsOpen;
		[Export ("playerManager:didReceiveMediaScreenStatus:")]
		void PlayerManager (GSPPlayerManager playerManager, bool bIsOpen);

		// @optional -(void)playerManager:(GSPPlayerManager *)playerManager didReceiveLiveText:(NSString *)liveText language:(NSString *)language;
		[Export ("playerManager:didReceiveLiveText:language:")]
		void PlayerManager (GSPPlayerManager playerManager, string liveText, string language);

		// @optional -(void)playerManager:(GSPPlayerManager *)playerManager didReceiveRollCall:(NSUInteger)seconds;
		[Export ("playerManager:didReceiveRollCall:")]
		void PlayerManager (GSPPlayerManager playerManager, nuint seconds);

		// @optional -(void)playerManager:(GSPPlayerManager *)playerManager didReceiveLottryInfo:(NSString *)names type:(GSLottryType)type;
		[Export ("playerManager:didReceiveLottryInfo:type:")]
		void PlayerManager (GSPPlayerManager playerManager, string names, GSLottryType type);

		// @optional -(void)playerManager:(GSPPlayerManager *)playerManager didReceiveVideoData:(const unsigned char *)data height:(int)height width:(int)width;
		[Export ("playerManager:didReceiveVideoData:height:width:")]
		unsafe void PlayerManager (GSPPlayerManager playerManager, byte* data, int height, int width);
	}

	// @interface GSPPlayerManager : NSObject
	[BaseType (typeof(NSObject))]
	interface GSPPlayerManager
	{
		// +(instancetype)sharedManager;
		[Static]
		[Export ("sharedManager")]
		GSPPlayerManager SharedManager ();

		// -(BOOL)joinWithParam:(GSPJoinParam *)joinParam;
		[Export ("joinWithParam:")]
		bool JoinWithParam (GSPJoinParam joinParam);

		// -(BOOL)leave;
		[Export ("leave")]
		[Verify (MethodToProperty)]
		bool Leave { get; }

		// -(void)invalidate;
		[Export ("invalidate")]
		void Invalidate ();

		// -(NSArray *)getIDCArray;
		[Export ("getIDCArray")]
		[Verify (MethodToProperty), Verify (StronglyTypedNSArray)]
		NSObject[] IDCArray { get; }

		// -(BOOL)setCurrentIDC:(NSString *)idcKey;
		[Export ("setCurrentIDC:")]
		bool SetCurrentIDC (string idcKey);

		// -(BOOL)enableAudio:(BOOL)enabled;
		[Export ("enableAudio:")]
		bool EnableAudio (bool enabled);

		// -(BOOL)enableVideo:(BOOL)enabled;
		[Export ("enableVideo:")]
		bool EnableVideo (bool enabled);

		// -(void)resetAudioHelper;
		[Export ("resetAudioHelper")]
		void ResetAudioHelper ();

		// -(void)playAudio:(const unsigned char *)data length:(unsigned int)length;
		[Export ("playAudio:length:")]
		unsafe void PlayAudio (byte* data, uint length);

		// -(void)setLogLevel:(GSPLogLevel)level;
		[Export ("setLogLevel:")]
		void SetLogLevel (GSPLogLevel level);

		// +(void)redirectLogToFile;
		[Static]
		[Export ("redirectLogToFile")]
		void RedirectLogToFile ();

		// -(void)uploadLog;
		[Export ("uploadLog")]
		void UploadLog ();

		// -(BOOL)chatWithAll:(GSPChatMessage *)message;
		[Export ("chatWithAll:")]
		bool ChatWithAll (GSPChatMessage message);

		// -(BOOL)chatWithUser:(unsigned int)chatID message:(GSPChatMessage *)message;
		[Export ("chatWithUser:message:")]
		bool ChatWithUser (uint chatID, GSPChatMessage message);

		// -(BOOL)askQuestion:(NSString *)quesID content:(NSString *)content;
		[Export ("askQuestion:content:")]
		bool AskQuestion (string quesID, string content);

		// -(BOOL)submitInvestigation:(GSPInvestigation *)inves;
		[Export ("submitInvestigation:")]
		bool SubmitInvestigation (GSPInvestigation inves);

		// -(void)activateMicrophone:(BOOL)active;
		[Export ("activateMicrophone:")]
		void ActivateMicrophone (bool active);

		// -(void)acceptMediaInvitation:(BOOL)accept type:(GSPMediaInvitationType)type;
		[Export ("acceptMediaInvitation:type:")]
		void AcceptMediaInvitation (bool accept, GSPMediaInvitationType type);

		// -(void)activateCamera:(BOOL)active;
		[Export ("activateCamera:")]
		void ActivateCamera (bool active);

		// -(void)rotateCamera;
		[Export ("rotateCamera")]
		void RotateCamera ();

		// -(void)setCameraOrientation:(BOOL)landscape;
		[Export ("setCameraOrientation:")]
		void SetCameraOrientation (bool landscape);

		// -(BOOL)handup:(BOOL)isUp;
		[Export ("handup:")]
		bool Handup (bool isUp);

		// -(BOOL)replyRollCall:(BOOL)reply;
		[Export ("replyRollCall:")]
		bool ReplyRollCall (bool reply);

		// -(BOOL)switchRate:(GSRate)rate;
		[Export ("switchRate:")]
		bool SwitchRate (GSRate rate);

		// -(void)reconnect;
		[Export ("reconnect")]
		void Reconnect ();

		// -(void)enableBackgroundMode;
		[Export ("enableBackgroundMode")]
		void EnableBackgroundMode ();

		[Wrap ("WeakDelegate")]
		GSPPlayerManagerDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<GSPPlayerManagerDelegate> delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (nonatomic, weak) GSPDocView * docView;
		[Export ("docView", ArgumentSemantic.Weak)]
		GSPDocView DocView { get; set; }

		// @property (nonatomic, weak) GSPChatView * chatView;
		[Export ("chatView", ArgumentSemantic.Weak)]
		GSPChatView ChatView { get; set; }

		// @property (nonatomic, weak) GSPQaView * qaView;
		[Export ("qaView", ArgumentSemantic.Weak)]
		GSPQaView QaView { get; set; }

		// @property (nonatomic, weak) GSPVideoView * videoView;
		[Export ("videoView", ArgumentSemantic.Weak)]
		GSPVideoView VideoView { get; set; }

		// @property (nonatomic, weak) GSPInvestigationView * investigationView;
		[Export ("investigationView", ArgumentSemantic.Weak)]
		GSPInvestigationView InvestigationView { get; set; }

		// @property (nonatomic, strong) GSPUserInfo * selfUserInfo;
		[Export ("selfUserInfo", ArgumentSemantic.Strong)]
		GSPUserInfo SelfUserInfo { get; set; }

		// @property (assign, nonatomic) int audioQueueLength;
		[Export ("audioQueueLength")]
		int AudioQueueLength { get; set; }

		// @property (nonatomic, weak) GSPVideoView * previewVideoView;
		[Export ("previewVideoView", ArgumentSemantic.Weak)]
		GSPVideoView PreviewVideoView { get; set; }

		// @property (assign, nonatomic) BOOL beautifyFace;
		[Export ("beautifyFace")]
		bool BeautifyFace { get; set; }

		// @property (assign, nonatomic) GSPVideoCrop videoPublishCrop;
		[Export ("videoPublishCrop", ArgumentSemantic.Assign)]
		GSPVideoCrop VideoPublishCrop { get; set; }

		// @property (assign, nonatomic) BOOL httpAPIEnabled;
		[Export ("httpAPIEnabled")]
		bool HttpAPIEnabled { get; set; }
	}

	// @interface GSPQaData : NSObject
	[BaseType (typeof(NSObject))]
	interface GSPQaData
	{
		// @property (nonatomic, strong) NSString * questionID;
		[Export ("questionID", ArgumentSemantic.Strong)]
		string QuestionID { get; set; }

		// @property (nonatomic, strong) NSString * answerID;
		[Export ("answerID", ArgumentSemantic.Strong)]
		string AnswerID { get; set; }

		// @property (nonatomic, strong) NSString * content;
		[Export ("content", ArgumentSemantic.Strong)]
		string Content { get; set; }

		// @property (nonatomic, strong) NSString * ownerName;
		[Export ("ownerName", ArgumentSemantic.Strong)]
		string OwnerName { get; set; }

		// @property (assign, nonatomic) long long time;
		[Export ("time")]
		long Time { get; set; }

		// @property (assign, nonatomic) BOOL isQuestion;
		[Export ("isQuestion")]
		bool IsQuestion { get; set; }

		// @property (assign, nonatomic) long long ownnerID;
		[Export ("ownnerID")]
		long OwnnerID { get; set; }

		// @property (assign, nonatomic) BOOL isCanceled;
		[Export ("isCanceled")]
		bool IsCanceled { get; set; }

		// @property (assign, nonatomic) long long receiveFlag;
		[Export ("receiveFlag")]
		long ReceiveFlag { get; set; }
	}

	// @interface GSPQaView : UIView
	[BaseType (typeof(UIView))]
	interface GSPQaView
	{
		// -(id)initWithFrame:(CGRect)frame;
		[Export ("initWithFrame:")]
		IntPtr Constructor (CGRect frame);

		// -(void)receiveQuestion:(NSArray *)qaArray;
		[Export ("receiveQuestion:")]
		[Verify (StronglyTypedNSArray)]
		void ReceiveQuestion (NSObject[] qaArray);

		// -(BOOL)sendQuestion:(NSString *)question;
		[Export ("sendQuestion:")]
		bool SendQuestion (string question);

		// @property (assign, nonatomic) BOOL isQaEnabled;
		[Export ("isQaEnabled")]
		bool IsQaEnabled { get; set; }

		// @property (nonatomic, weak) GSPPlayerManager * playerManager;
		[Export ("playerManager", ArgumentSemantic.Weak)]
		GSPPlayerManager PlayerManager { get; set; }

		// @property (nonatomic, weak) GSPChatInputToolView * inputToolView;
		[Export ("inputToolView", ArgumentSemantic.Weak)]
		GSPChatInputToolView InputToolView { get; set; }

		// -(void)clearAllQaData;
		[Export ("clearAllQaData")]
		void ClearAllQaData ();
	}

	// @interface GSPChatInputToolView : UIView
	[BaseType (typeof(UIView))]
	interface GSPChatInputToolView
	{
		// -(id)initWithViewController:(UIViewController *)viewController combinedChatView:(GSPChatView *)chatView combinedQaView:(GSPQaView *)qaView isChatMode:(BOOL)flag;
		[Export ("initWithViewController:combinedChatView:combinedQaView:isChatMode:")]
		IntPtr Constructor (UIViewController viewController, GSPChatView chatView, GSPQaView qaView, bool flag);

		// @property (nonatomic, strong) UITextView * inputTextView;
		[Export ("inputTextView", ArgumentSemantic.Strong)]
		UITextView InputTextView { get; set; }

		// -(void)setUserList:(NSMutableArray *)array;
		[Export ("setUserList:")]
		void SetUserList (NSMutableArray array);

		// -(void)hideUserListView;
		[Export ("hideUserListView")]
		void HideUserListView ();
	}

	// @protocol GSPDiagnosisInfoDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface GSPDiagnosisInfoDelegate
	{
		// @optional -(void)upLoadResult:(GSPDiagnosisType)type;
		[Export ("upLoadResult:")]
		void UpLoadResult (GSPDiagnosisType type);
	}

	// typedef void (^upLoadResultBlock)(BOOL);
	delegate void upLoadResultBlock (bool arg0);

	// typedef void (^upLoadResultWithErrorDescriptionBlock)(BOOL, NSString *);
	delegate void upLoadResultWithErrorDescriptionBlock (bool arg0, string arg1);

	// @interface GSPDiagnosisInfo : NSObject <NSURLSessionDelegate>
	[BaseType (typeof(NSObject))]
	interface GSPDiagnosisInfo : INSUrlSessionDelegate
	{
		[Wrap ("WeakDiagnosisInfoDelegate")]
		GSPDiagnosisInfoDelegate DiagnosisInfoDelegate { get; set; }

		// @property (nonatomic, weak) id<GSPDiagnosisInfoDelegate> DiagnosisInfoDelegate;
		[NullAllowed, Export ("DiagnosisInfoDelegate", ArgumentSemantic.Weak)]
		NSObject WeakDiagnosisInfoDelegate { get; set; }

		// @property (copy, nonatomic) NSString * userName;
		[Export ("userName")]
		string UserName { get; set; }

		// @property (copy, nonatomic) NSString * userId;
		[Export ("userId")]
		string UserId { get; set; }

		// @property (copy, nonatomic) NSString * userRole;
		[Export ("userRole")]
		string UserRole { get; set; }

		// @property (copy, nonatomic) NSString * confId;
		[Export ("confId")]
		string ConfId { get; set; }

		// @property (copy, nonatomic) NSString * confName;
		[Export ("confName")]
		string ConfName { get; set; }

		// @property (copy, nonatomic) NSString * confSiteId;
		[Export ("confSiteId")]
		string ConfSiteId { get; set; }

		// @property (copy, nonatomic) NSString * confSiteName;
		[Export ("confSiteName")]
		string ConfSiteName { get; set; }

		// @property (copy, nonatomic) NSString * currentDate;
		[Export ("currentDate")]
		string CurrentDate { get; set; }

		// @property (nonatomic, strong) NSString * uploadfile;
		[Export ("uploadfile", ArgumentSemantic.Strong)]
		string Uploadfile { get; set; }

		// @property (nonatomic, strong) NSString * uploadUrl;
		[Export ("uploadUrl", ArgumentSemantic.Strong)]
		string UploadUrl { get; set; }

		// @property (nonatomic, strong) NSString * appLogFilePath;
		[Export ("appLogFilePath", ArgumentSemantic.Strong)]
		string AppLogFilePath { get; set; }

		// @property (copy, nonatomic) upLoadResultWithErrorDescriptionBlock upLoadResult;
		[Export ("upLoadResult", ArgumentSemantic.Copy)]
		upLoadResultWithErrorDescriptionBlock UpLoadResult { get; set; }

		// +(GSPDiagnosisInfo *)shareInstance;
		[Static]
		[Export ("shareInstance")]
		[Verify (MethodToProperty)]
		GSPDiagnosisInfo ShareInstance { get; }

		// -(void)uploadDiagnosisInfo;
		[Export ("uploadDiagnosisInfo")]
		void UploadDiagnosisInfo ();

		// -(void)ReportDiagonse;
		[Export ("ReportDiagonse")]
		void ReportDiagonse ();

		// -(void)ReportDiagonseEx;
		[Export ("ReportDiagonseEx")]
		void ReportDiagonseEx ();

		// -(void)redirectNSlogToDocumentFolder;
		[Export ("redirectNSlogToDocumentFolder")]
		void RedirectNSlogToDocumentFolder ();

		// -(void)activeGetLog;
		[Export ("activeGetLog")]
		void ActiveGetLog ();
	}

	// @interface GSVodDocument : NSObject
	[BaseType (typeof(NSObject))]
	interface GSVodDocument
	{
		// @property (assign, nonatomic) unsigned int docID;
		[Export ("docID")]
		uint DocID { get; set; }

		// @property (nonatomic, strong) NSMutableDictionary * pages;
		[Export ("pages", ArgumentSemantic.Strong)]
		NSMutableDictionary Pages { get; set; }

		// @property (assign, nonatomic) int currentPageIndex;
		[Export ("currentPageIndex")]
		int CurrentPageIndex { get; set; }

		// @property (assign, nonatomic) BOOL savedOnServer;
		[Export ("savedOnServer")]
		bool SavedOnServer { get; set; }

		// @property (assign, nonatomic) NSString * docName;
		[Export ("docName")]
		string DocName { get; set; }

		// @property (assign, nonatomic) long long ownerID;
		[Export ("ownerID")]
		long OwnerID { get; set; }
	}

	// @interface GSVodDocPage : NSObject
	[BaseType (typeof(NSObject))]
	interface GSVodDocPage
	{
		// @property (assign, nonatomic) unsigned int pageID;
		[Export ("pageID")]
		uint PageID { get; set; }

		// @property (nonatomic, strong) NSData * pageData;
		[Export ("pageData", ArgumentSemantic.Strong)]
		NSData PageData { get; set; }

		// @property (assign, nonatomic) short pageWidth;
		[Export ("pageWidth")]
		short PageWidth { get; set; }

		// @property (assign, nonatomic) short pageHeight;
		[Export ("pageHeight")]
		short PageHeight { get; set; }

		// @property (nonatomic, strong) NSMutableDictionary * annos;
		[Export ("annos", ArgumentSemantic.Strong)]
		NSMutableDictionary Annos { get; set; }
	}

	// @interface GSVodAnnoBase : NSObject
	[BaseType (typeof(NSObject))]
	interface GSVodAnnoBase
	{
		// @property (assign, nonatomic) GSVodDocumentAnnoType type;
		[Export ("type", ArgumentSemantic.Assign)]
		GSVodDocumentAnnoType Type { get; set; }

		// @property (assign, nonatomic) long long annoID;
		[Export ("annoID")]
		long AnnoID { get; set; }

		// @property (assign, nonatomic) unsigned int pageID;
		[Export ("pageID")]
		uint PageID { get; set; }

		// @property (assign, nonatomic) unsigned int docID;
		[Export ("docID")]
		uint DocID { get; set; }
	}

	// @interface GSVodAnnoCircle : GSVodAnnoBase
	[BaseType (typeof(GSVodAnnoBase))]
	interface GSVodAnnoCircle
	{
		// @property (assign, nonatomic) Byte lineSize;
		[Export ("lineSize")]
		byte LineSize { get; set; }

		// @property (nonatomic, strong) UIColor * lineColor;
		[Export ("lineColor", ArgumentSemantic.Strong)]
		UIColor LineColor { get; set; }

		// @property (assign, nonatomic) CGRect rect;
		[Export ("rect", ArgumentSemantic.Assign)]
		CGRect Rect { get; set; }
	}

	// @interface GSVodAnnoFreePen : GSVodAnnoBase
	[BaseType (typeof(GSVodAnnoBase))]
	interface GSVodAnnoFreePen
	{
		// @property (nonatomic, strong) NSMutableArray * points;
		[Export ("points", ArgumentSemantic.Strong)]
		NSMutableArray Points { get; set; }

		// @property (assign, nonatomic) Byte lineSize;
		[Export ("lineSize")]
		byte LineSize { get; set; }

		// @property (nonatomic, strong) UIColor * lineColor;
		[Export ("lineColor", ArgumentSemantic.Strong)]
		UIColor LineColor { get; set; }
	}

	// @interface GSVodAnnoFreePenEx : GSVodAnnoFreePen
	[BaseType (typeof(GSVodAnnoFreePen))]
	interface GSVodAnnoFreePenEx
	{
		// @property (assign, nonatomic) Byte stepType;
		[Export ("stepType")]
		byte StepType { get; set; }
	}

	// @interface GSVodAnnoLine : GSVodAnnoBase
	[BaseType (typeof(GSVodAnnoBase))]
	interface GSVodAnnoLine
	{
		// @property (assign, nonatomic) Byte lineSize;
		[Export ("lineSize")]
		byte LineSize { get; set; }

		// @property (nonatomic, strong) UIColor * lineColor;
		[Export ("lineColor", ArgumentSemantic.Strong)]
		UIColor LineColor { get; set; }

		// @property (assign, nonatomic) CGPoint startPoint;
		[Export ("startPoint", ArgumentSemantic.Assign)]
		CGPoint StartPoint { get; set; }

		// @property (assign, nonatomic) CGPoint endPoint;
		[Export ("endPoint", ArgumentSemantic.Assign)]
		CGPoint EndPoint { get; set; }
	}

	// @interface GSVodAnnoLineEx : GSVodAnnoLine
	[BaseType (typeof(GSVodAnnoLine))]
	interface GSVodAnnoLineEx
	{
		// @property (assign, nonatomic) Byte lineType;
		[Export ("lineType")]
		byte LineType { get; set; }
	}

	// @interface GSVodAnnoPoint : GSVodAnnoBase
	[BaseType (typeof(GSVodAnnoBase))]
	interface GSVodAnnoPoint
	{
		// @property (assign, nonatomic) CGPoint point;
		[Export ("point", ArgumentSemantic.Assign)]
		CGPoint Point { get; set; }
	}

	// @interface GSVodAnnoPointEx : GSVodAnnoPoint
	[BaseType (typeof(GSVodAnnoPoint))]
	interface GSVodAnnoPointEx
	{
		// @property (assign, nonatomic) Byte pointType;
		[Export ("pointType")]
		byte PointType { get; set; }
	}

	// @interface GSVodAnnoRect : GSVodAnnoBase
	[BaseType (typeof(GSVodAnnoBase))]
	interface GSVodAnnoRect
	{
		// @property (assign, nonatomic) Byte lineSize;
		[Export ("lineSize")]
		byte LineSize { get; set; }

		// @property (nonatomic, strong) UIColor * lineColor;
		[Export ("lineColor", ArgumentSemantic.Strong)]
		UIColor LineColor { get; set; }

		// @property (assign, nonatomic) CGRect rect;
		[Export ("rect", ArgumentSemantic.Assign)]
		CGRect Rect { get; set; }
	}

	// @interface GSVodAnnoText : GSVodAnnoBase
	[BaseType (typeof(GSVodAnnoBase))]
	interface GSVodAnnoText
	{
		// @property (nonatomic, strong) UIColor * textColor;
		[Export ("textColor", ArgumentSemantic.Strong)]
		UIColor TextColor { get; set; }

		// @property (assign, nonatomic) Byte fontSize;
		[Export ("fontSize")]
		byte FontSize { get; set; }

		// @property (nonatomic, strong) NSString * text;
		[Export ("text", ArgumentSemantic.Strong)]
		string Text { get; set; }

		// @property (assign, nonatomic) CGPoint point;
		[Export ("point", ArgumentSemantic.Assign)]
		CGPoint Point { get; set; }
	}

	// @interface GSVodAnnoCleaner : GSVodAnnoBase
	[BaseType (typeof(GSVodAnnoBase))]
	interface GSVodAnnoCleaner
	{
		// @property (assign, nonatomic) long long removedAnnoID;
		[Export ("removedAnnoID")]
		long RemovedAnnoID { get; set; }
	}

	// @interface GSVodDocPageLabelView : UIView
	[BaseType (typeof(UIView))]
	interface GSVodDocPageLabelView
	{
		// @property (nonatomic, strong) UIImage * cacheImage;
		[Export ("cacheImage", ArgumentSemantic.Strong)]
		UIImage CacheImage { get; set; }

		// @property (assign, nonatomic) CGFloat scale;
		[Export ("scale")]
		nfloat Scale { get; set; }

		// @property (nonatomic, strong) GSVodAnnoBase * anno;
		[Export ("anno", ArgumentSemantic.Strong)]
		GSVodAnnoBase Anno { get; set; }

		// @property (assign, nonatomic) CGFloat offX;
		[Export ("offX")]
		nfloat OffX { get; set; }

		// @property (assign, nonatomic) CGFloat offY;
		[Export ("offY")]
		nfloat OffY { get; set; }

		// @property (nonatomic, strong) GSVodDocPage * docPage;
		[Export ("docPage", ArgumentSemantic.Strong)]
		GSVodDocPage DocPage { get; set; }

		// @property (assign, nonatomic) BOOL needDrawFreePenEx;
		[Export ("needDrawFreePenEx")]
		bool NeedDrawFreePenEx { get; set; }

		// @property (assign, nonatomic) BOOL isDrawingSingleAnno;
		[Export ("isDrawingSingleAnno")]
		bool IsDrawingSingleAnno { get; set; }

		// @property (assign, nonatomic) CGFloat scaleX;
		[Export ("scaleX")]
		nfloat ScaleX { get; set; }

		// @property (assign, nonatomic) CGFloat scaleY;
		[Export ("scaleY")]
		nfloat ScaleY { get; set; }

		// -(void)drawPage:(GSVodDocPage *)page;
		[Export ("drawPage:")]
		void DrawPage (GSVodDocPage page);

		// -(void)drawSomeSpecialAnnos:(GSVodAnnoBase *)anno;
		[Export ("drawSomeSpecialAnnos:")]
		void DrawSomeSpecialAnnos (GSVodAnnoBase anno);

		// -(void)clearLabelViewRes;
		[Export ("clearLabelViewRes")]
		void ClearLabelViewRes ();
	}

	// @protocol GSVodDocSwfViewDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface GSVodDocSwfViewDelegate
	{
		// @optional -(void)docVodOpenFinishSuccess:(GSVodDocPage *)page;
		[Export ("docVodOpenFinishSuccess:")]
		void DocVodOpenFinishSuccess (GSVodDocPage page);
	}

	// @interface GSVodDocSwfView : UIView
	[BaseType (typeof(UIView))]
	interface GSVodDocSwfView
	{
		// -(void)drawPage:(unsigned int)dwTimeStamp data:(const unsigned char *)data dwLen:(unsigned int)dwLen dwPageW:(unsigned int)dwPageW dwPageH:(unsigned int)dwPageH strAnimations:(NSString *)strAnimations;
		[Export ("drawPage:data:dwLen:dwPageW:dwPageH:strAnimations:")]
		unsafe void DrawPage (uint dwTimeStamp, byte* data, uint dwLen, uint dwPageW, uint dwPageH, string strAnimations);

		// -(void)vodGoToAnimationStep:(int)step;
		[Export ("vodGoToAnimationStep:")]
		void VodGoToAnimationStep (int step);

		// -(void)vodDrawAnnos:(NSArray *)annos;
		[Export ("vodDrawAnnos:")]
		[Verify (StronglyTypedNSArray)]
		void VodDrawAnnos (NSObject[] annos);

		// -(void)setGlkBackColor:(int)red green:(int)green blue:(int)blue;
		[Export ("setGlkBackColor:green:blue:")]
		void SetGlkBackColor (int red, int green, int blue);

		// @property (nonatomic, strong) GSVodDocPageLabelView * annoLabelView;
		[Export ("annoLabelView", ArgumentSemantic.Strong)]
		GSVodDocPageLabelView AnnoLabelView { get; set; }

		// @property (assign, nonatomic) GSVodDocShowType docModeType;
		[Export ("docModeType", ArgumentSemantic.Assign)]
		GSVodDocShowType DocModeType { get; set; }

		// -(void)clearVodLastPageAndAnno;
		[Export ("clearVodLastPageAndAnno")]
		void ClearVodLastPageAndAnno ();

		[Wrap ("WeakVodDelegate")]
		GSVodDocSwfViewDelegate VodDelegate { get; set; }

		// @property (nonatomic, weak) id<GSVodDocSwfViewDelegate> vodDelegate;
		[NullAllowed, Export ("vodDelegate", ArgumentSemantic.Weak)]
		NSObject WeakVodDelegate { get; set; }
	}

	// @protocol GSVodDocViewDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface GSVodDocViewDelegate
	{
		// @optional -(void)docVodViewOpenFinishSuccess:(GSVodDocPage *)page;
		[Export ("docVodViewOpenFinishSuccess:")]
		void DocVodViewOpenFinishSuccess (GSVodDocPage page);
	}

	// @interface GSVodDocView : UIScrollView
	[BaseType (typeof(UIScrollView))]
	interface GSVodDocView
	{
		// @property (assign, nonatomic) BOOL zoomEnabled;
		[Export ("zoomEnabled")]
		bool ZoomEnabled { get; set; }

		// @property (assign, nonatomic) BOOL isVectorScale;
		[Export ("isVectorScale")]
		bool IsVectorScale { get; set; }

		[Wrap ("WeakVodDocDelegate")]
		GSVodDocViewDelegate VodDocDelegate { get; set; }

		// @property (nonatomic, weak) id<GSVodDocViewDelegate> vodDocDelegate;
		[NullAllowed, Export ("vodDocDelegate", ArgumentSemantic.Weak)]
		NSObject WeakVodDocDelegate { get; set; }

		// -(id)initWithFrame:(CGRect)frame;
		[Export ("initWithFrame:")]
		IntPtr Constructor (CGRect frame);

		// @property (nonatomic, strong) GSVodDocSwfView * vodDocSwfView;
		[Export ("vodDocSwfView", ArgumentSemantic.Strong)]
		GSVodDocSwfView VodDocSwfView { get; set; }

		// -(void)drawPage:(unsigned int)dwTimeStamp data:(const unsigned char *)data dwLen:(unsigned int)dwLen dwPageW:(unsigned int)dwPageW dwPageH:(unsigned int)dwPageH strAnimations:(NSString *)strAnimations;
		[Export ("drawPage:data:dwLen:dwPageW:dwPageH:strAnimations:")]
		unsafe void DrawPage (uint dwTimeStamp, byte* data, uint dwLen, uint dwPageW, uint dwPageH, string strAnimations);

		// -(void)vodGoToAnimationStep:(int)step;
		[Export ("vodGoToAnimationStep:")]
		void VodGoToAnimationStep (int step);

		// -(void)vodDrawAnnos:(NSArray *)annos;
		[Export ("vodDrawAnnos:")]
		[Verify (StronglyTypedNSArray)]
		void VodDrawAnnos (NSObject[] annos);

		// -(void)setGlkBackgroundColor:(int)red green:(int)green blue:(int)blue;
		[Export ("setGlkBackgroundColor:green:blue:")]
		void SetGlkBackgroundColor (int red, int green, int blue);

		// @property (assign, nonatomic) GSVodDocShowType gSDocModeType;
		[Export ("gSDocModeType", ArgumentSemantic.Assign)]
		GSVodDocShowType GSDocModeType { get; set; }
	}

	// @interface VodParam : NSObject
	[BaseType (typeof(NSObject))]
	interface VodParam
	{
		// @property (copy, nonatomic) NSString * domain;
		[Export ("domain")]
		string Domain { get; set; }

		// @property (copy, nonatomic) NSString * vodID;
		[Export ("vodID")]
		string VodID { get; set; }

		// @property (copy, nonatomic) NSString * number;
		[Export ("number")]
		string Number { get; set; }

		// @property (copy, nonatomic) NSString * vodPassword;
		[Export ("vodPassword")]
		string VodPassword { get; set; }

		// @property (copy, nonatomic) NSString * nickName;
		[Export ("nickName")]
		string NickName { get; set; }

		// @property (copy, nonatomic) NSString * loginName;
		[Export ("loginName")]
		string LoginName { get; set; }

		// @property (copy, nonatomic) NSString * loginPassword;
		[Export ("loginPassword")]
		string LoginPassword { get; set; }

		// @property (assign, nonatomic) BOOL oldVersion;
		[Export ("oldVersion")]
		bool OldVersion { get; set; }

		// @property (copy, nonatomic) NSString * thirdToken;
		[Export ("thirdToken")]
		string ThirdToken { get; set; }

		// @property (assign, nonatomic) long long customUserID;
		[Export ("customUserID")]
		long CustomUserID { get; set; }

		// @property (assign, nonatomic) BOOL isBox;
		[Export ("isBox")]
		bool IsBox { get; set; }

		// @property (assign, nonatomic) int downFlag;
		[Export ("downFlag")]
		int DownFlag { get; set; }

		// @property (copy, nonatomic) NSString * serviceType;
		[Export ("serviceType")]
		string ServiceType { get; set; }
	}

	// @interface VodDownLoader : NSObject
	[BaseType (typeof(NSObject))]
	interface VodDownLoader
	{
		[Wrap ("WeakDelegate")]
		VodDownLoadDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<VodDownLoadDelegate> delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (nonatomic, strong) NSString * mCurrentDownloadId;
		[Export ("mCurrentDownloadId", ArgumentSemantic.Strong)]
		string MCurrentDownloadId { get; set; }

		// @property (assign, nonatomic) BOOL vodTimeFlag;
		[Export ("vodTimeFlag")]
		bool VodTimeFlag { get; set; }

		// @property (assign, nonatomic) BOOL httpAPIEnabled;
		[Export ("httpAPIEnabled")]
		bool HttpAPIEnabled { get; set; }

		// -(id)initWithDelegate:(id<VodDownLoadDelegate>)delegate;
		[Export ("initWithDelegate:")]
		IntPtr Constructor (VodDownLoadDelegate @delegate);

		// -(void)download:(downItem *)vodItem chatPost:(BOOL)chatPost;
		[Export ("download:chatPost:")]
		void Download (downItem vodItem, bool chatPost);

		// -(void)start:(NSString *)downloadID chatPost:(BOOL)chatPost;
		[Export ("start:chatPost:")]
		void Start (string downloadID, bool chatPost);

		// -(BOOL)delete:(NSString *)downloadID;
		[Export ("delete:")]
		bool Delete (string downloadID);

		// -(void)stop:(NSString *)downloadID;
		[Export ("stop:")]
		void Stop (string downloadID);

		// -(void)addItem:(NSString *)domain number:(NSString *)number loginName:(NSString *)loginName nickName:(NSString *)nickName vodPassword:(NSString *)vodPassword loginPassword:(NSString *)loginPassword downFlag:(int)downFlag serType:(NSString *)serType isBox:(BOOL)isBox oldVersion:(BOOL)oldVersion kToken:(NSString *)token customUserID:(long long)customUserID;
		[Export ("addItem:number:loginName:nickName:vodPassword:loginPassword:downFlag:serType:isBox:oldVersion:kToken:customUserID:")]
		void AddItem (string domain, string number, string loginName, string nickName, string vodPassword, string loginPassword, int downFlag, string serType, bool isBox, bool oldVersion, string token, long customUserID);

		// -(void)addItem:(NSString *)domain number:(NSString *)number loginName:(NSString *)loginName vodPassword:(NSString *)vodPassword loginPassword:(NSString *)loginPassword downFlag:(int)downFlag serType:(NSString *)serType oldVersion:(BOOL)oldVersion kToken:(NSString *)token customUserID:(long long)customUserID;
		[Export ("addItem:number:loginName:vodPassword:loginPassword:downFlag:serType:oldVersion:kToken:customUserID:")]
		void AddItem (string domain, string number, string loginName, string vodPassword, string loginPassword, int downFlag, string serType, bool oldVersion, string token, long customUserID);

		// -(void)addItem:(NSString *)domain number:(NSString *)number loginName:(NSString *)loginName vodPassword:(NSString *)vodPassword loginPassword:(NSString *)loginPassword vodid:(NSString *)vodid downFlag:(int)downFlag serType:(NSString *)serType oldVersion:(BOOL)oldVersion kToken:(NSString *)token customUserID:(long long)customUserID;
		[Export ("addItem:number:loginName:vodPassword:loginPassword:vodid:downFlag:serType:oldVersion:kToken:customUserID:")]
		void AddItem (string domain, string number, string loginName, string vodPassword, string loginPassword, string vodid, int downFlag, string serType, bool oldVersion, string token, long customUserID);

		// -(void)addItem:(VodParam *)vodParam;
		[Export ("addItem:")]
		void AddItem (VodParam vodParam);

		// -(void)addItemToDataBase:(downItem *)item;
		[Export ("addItemToDataBase:")]
		void AddItemToDataBase (downItem item);

		// -(NSString *)vodDownloadPath:(NSString *)downloadID;
		[Export ("vodDownloadPath:")]
		string VodDownloadPath (string downloadID);

		// -(void)reconnect;
		[Export ("reconnect")]
		void Reconnect ();
	}

	// @protocol VodDownLoadDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface VodDownLoadDelegate
	{
		// @optional -(void)onDLFinish:(NSString *)downloadID;
		[Export ("onDLFinish:")]
		void OnDLFinish (string downloadID);

		// @optional -(void)onDLPosition:(NSString *)downloadID percent:(float)percent;
		[Export ("onDLPosition:percent:")]
		void OnDLPosition (string downloadID, float percent);

		// @optional -(void)onDLStart:(NSString *)downloadID;
		[Export ("onDLStart:")]
		void OnDLStart (string downloadID);

		// @optional -(void)onDLStop:(NSString *)downloadID;
		[Export ("onDLStop:")]
		void OnDLStop (string downloadID);

		// @optional -(void)onDLError:(NSString *)downloadID Status:(VodDownLoadStatus)errorCode;
		[Export ("onDLError:Status:")]
		void OnDLError (string downloadID, VodDownLoadStatus errorCode);

		// @optional -(void)onAddItemResult:(RESULT_TYPE)resultType voditem:(downItem *)item;
		[Export ("onAddItemResult:voditem:")]
		void OnAddItemResult (RESULT_TYPE resultType, downItem item);
	}

	// @interface VodGLView : UIView
	[BaseType (typeof(UIView))]
	interface VodGLView
	{
		// -(id)initWithFrame:(CGRect)frame;
		[Export ("initWithFrame:")]
		IntPtr Constructor (CGRect frame);

		// @property (nonatomic, strong) UIImageView * movieASImageView;
		[Export ("movieASImageView", ArgumentSemantic.Strong)]
		UIImageView MovieASImageView { get; set; }

		// -(void)renderAsVideoByImage:(UIImage *)imageFrame;
		[Export ("renderAsVideoByImage:")]
		void RenderAsVideoByImage (UIImage imageFrame);
	}

	// @interface VodManage : NSObject
	[BaseType (typeof(NSObject))]
	interface VodManage
	{
		// -(downItem *)findDownItem:(NSString *)downLoadId;
		[Export ("findDownItem:")]
		downItem FindDownItem (string downLoadId);

		// -(NSArray *)getListDownItem;
		[Export ("getListDownItem")]
		[Verify (MethodToProperty), Verify (StronglyTypedNSArray)]
		NSObject[] ListDownItem { get; }

		// -(NSArray *)getListOfUnDownloadedItem;
		[Export ("getListOfUnDownloadedItem")]
		[Verify (MethodToProperty), Verify (StronglyTypedNSArray)]
		NSObject[] ListOfUnDownloadedItem { get; }

		// -(NSArray *)searchAllNeedDownloadItems;
		[Export ("searchAllNeedDownloadItems")]
		[Verify (MethodToProperty), Verify (StronglyTypedNSArray)]
		NSObject[] SearchAllNeedDownloadItems { get; }

		// -(NSArray *)searchNeedDownloadAndUnFinishedItems;
		[Export ("searchNeedDownloadAndUnFinishedItems")]
		[Verify (MethodToProperty), Verify (StronglyTypedNSArray)]
		NSObject[] SearchNeedDownloadAndUnFinishedItems { get; }

		// -(NSArray *)searchUnNeedDownloadItems;
		[Export ("searchUnNeedDownloadItems")]
		[Verify (MethodToProperty), Verify (StronglyTypedNSArray)]
		NSObject[] SearchUnNeedDownloadItems { get; }

		// -(NSArray *)searchFinishedItems;
		[Export ("searchFinishedItems")]
		[Verify (MethodToProperty), Verify (StronglyTypedNSArray)]
		NSObject[] SearchFinishedItems { get; }

		// -(BOOL)updateAllItemState:(DOWNSTATE)oldState toState:(DOWNSTATE)newState;
		[Export ("updateAllItemState:toState:")]
		bool UpdateAllItemState (DOWNSTATE oldState, DOWNSTATE newState);

		// +(id)shareManage;
		[Static]
		[Export ("shareManage")]
		[Verify (MethodToProperty)]
		NSObject ShareManage { get; }

		// -(BOOL)deleteAllItem;
		[Export ("deleteAllItem")]
		[Verify (MethodToProperty)]
		bool DeleteAllItem { get; }

		// -(BOOL)updateItem:(downItem *)item;
		[Export ("updateItem:")]
		bool UpdateItem (downItem item);

		// -(BOOL)deleteItem:(NSString *)DownloadId;
		[Export ("deleteItem:")]
		bool DeleteItem (string DownloadId);
	}

	// @interface VodPlayer : NSObject
	[BaseType (typeof(NSObject))]
	interface VodPlayer
	{
		[Wrap ("WeakDelegate")]
		VodPlayDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<VodPlayDelegate> delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (nonatomic, strong) VodGLView * mVideoView;
		[Export ("mVideoView", ArgumentSemantic.Strong)]
		VodGLView MVideoView { get; set; }

		// @property (nonatomic, strong) GSVodDocView * docSwfView;
		[Export ("docSwfView", ArgumentSemantic.Strong)]
		GSVodDocView DocSwfView { get; set; }

		// @property (nonatomic, strong) UIView * vodDocShowView;
		[Export ("vodDocShowView", ArgumentSemantic.Strong)]
		UIView VodDocShowView { get; set; }

		// @property (assign, nonatomic) int docType;
		[Export ("docType")]
		int DocType { get; set; }

		// @property (nonatomic, strong) downItem * playItem;
		[Export ("playItem", ArgumentSemantic.Strong)]
		downItem PlayItem { get; set; }

		// @property (assign, nonatomic) GSVodDocShowType gSDocModeType;
		[Export ("gSDocModeType", ArgumentSemantic.Assign)]
		GSVodDocShowType GSDocModeType { get; set; }

		// -(void)reconnect;
		[Export ("reconnect")]
		void Reconnect ();

		// -(void)OfflinePlay:(BOOL)postChat;
		[Export ("OfflinePlay:")]
		void OfflinePlay (bool postChat);

		// -(void)OnlinePlay:(BOOL)postChat audioOnly:(BOOL)audioOnly;
		[Export ("OnlinePlay:audioOnly:")]
		void OnlinePlay (bool postChat, bool audioOnly);

		// -(void)SpeedPlay:(SpeedValue)value;
		[Export ("SpeedPlay:")]
		void SpeedPlay (SpeedValue value);

		// -(void)closeVideo:(BOOL)close;
		[Export ("closeVideo:")]
		void CloseVideo (bool close);

		// -(void)pause;
		[Export ("pause")]
		void Pause ();

		// -(void)resume;
		[Export ("resume")]
		void Resume ();

		// -(void)stop;
		[Export ("stop")]
		void Stop ();

		// -(int)seekTo:(int)position;
		[Export ("seekTo:")]
		int SeekTo (int position);

		// -(void)addSubViewOnVideoView:(id)subView;
		[Export ("addSubViewOnVideoView:")]
		void AddSubViewOnVideoView (NSObject subView);

		// -(void)getChatAndQalistAction;
		[Export ("getChatAndQalistAction")]
		void GetChatAndQalistAction ();

		// -(void)getChatListWithPageIndex:(int)pageIndex;
		[Export ("getChatListWithPageIndex:")]
		void GetChatListWithPageIndex (int pageIndex);

		// -(void)getQaListWithPageIndex:(int)pageIndex;
		[Export ("getQaListWithPageIndex:")]
		void GetQaListWithPageIndex (int pageIndex);

		// -(void)resetAudioPlayer;
		[Export ("resetAudioPlayer")]
		void ResetAudioPlayer ();

		// -(void)enableBackgroundMode;
		[Export ("enableBackgroundMode")]
		void EnableBackgroundMode ();
	}

	// @protocol VodPlayDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface VodPlayDelegate
	{
		// @optional -(void)onInit:(int)result haveVideo:(BOOL)haveVideo duration:(int)duration docInfos:(NSArray *)docInfos;
		[Export ("onInit:haveVideo:duration:docInfos:")]
		[Verify (StronglyTypedNSArray)]
		void OnInit (int result, bool haveVideo, int duration, NSObject[] docInfos);

		// @optional -(void)onDocInfo:(NSArray *)docInfos;
		[Export ("onDocInfo:")]
		[Verify (StronglyTypedNSArray)]
		void OnDocInfo (NSObject[] docInfos);

		// @optional -(void)onStop;
		[Export ("onStop")]
		void OnStop ();

		// @optional -(void)onPosition:(int)position;
		[Export ("onPosition:")]
		void OnPosition (int position);

		// @optional -(void)onPage:(int)position width:(unsigned int)width height:(unsigned int)height;
		[Export ("onPage:width:height:")]
		void OnPage (int position, uint width, uint height);

		// @optional -(void)onSeek:(int)position;
		[Export ("onSeek:")]
		void OnSeek (int position);

		// @optional -(void)onAudioLevel:(int)level;
		[Export ("onAudioLevel:")]
		void OnAudioLevel (int level);

		// @optional -(void)OnBuffer:(BOOL)bBeginBuffer;
		[Export ("OnBuffer:")]
		void OnBuffer (bool bBeginBuffer);

		// @optional -(void)OnChat:(NSArray *)chatArray;
		[Export ("OnChat:")]
		[Verify (StronglyTypedNSArray)]
		void OnChat (NSObject[] chatArray);

		// @optional -(void)vodRecChatList:(NSArray *)chatList more:(BOOL)more currentPageIndex:(int)pageIndex;
		[Export ("vodRecChatList:more:currentPageIndex:")]
		[Verify (StronglyTypedNSArray)]
		void VodRecChatList (NSObject[] chatList, bool more, int pageIndex);

		// @optional -(void)vodRecQaList:(NSArray *)qaList more:(BOOL)more currentPageIndex:(int)pageIndex;
		[Export ("vodRecQaList:more:currentPageIndex:")]
		[Verify (StronglyTypedNSArray)]
		void VodRecQaList (NSObject[] qaList, bool more, int pageIndex);

		// @optional -(void)onVideoStart;
		[Export ("onVideoStart")]
		void OnVideoStart ();
	}

	// @interface VodChatInfo : NSObject
	[BaseType (typeof(NSObject))]
	interface VodChatInfo
	{
		// @property (copy, nonatomic) NSString * senderName;
		[Export ("senderName")]
		string SenderName { get; set; }

		// @property (assign, nonatomic) NSUInteger senderID;
		[Export ("senderID")]
		nuint SenderID { get; set; }

		// @property (copy, nonatomic) NSString * richText;
		[Export ("richText")]
		string RichText { get; set; }

		// @property (copy, nonatomic) NSString * text;
		[Export ("text")]
		string Text { get; set; }

		// @property (assign, nonatomic) NSUInteger role;
		[Export ("role")]
		nuint Role { get; set; }

		// @property (assign, nonatomic) float timestamp;
		[Export ("timestamp")]
		float Timestamp { get; set; }
	}

	// @interface downItem : NSObject
	[BaseType (typeof(NSObject))]
	interface downItem
	{
		// @property (nonatomic, strong) NSString * strDownloadID;
		[Export ("strDownloadID", ArgumentSemantic.Strong)]
		string StrDownloadID { get; set; }

		// @property (nonatomic, strong) NSString * strURL;
		[Export ("strURL", ArgumentSemantic.Strong)]
		string StrURL { get; set; }

		// @property (assign, nonatomic) DOWNSTATE state;
		[Export ("state", ArgumentSemantic.Assign)]
		DOWNSTATE State { get; set; }

		// @property (nonatomic, strong) NSString * name;
		[Export ("name", ArgumentSemantic.Strong)]
		string Name { get; set; }

		// @property (nonatomic, strong) NSString * tid;
		[Export ("tid", ArgumentSemantic.Strong)]
		string Tid { get; set; }

		// @property (nonatomic, strong) NSString * fileSize;
		[Export ("fileSize", ArgumentSemantic.Strong)]
		string FileSize { get; set; }

		// @property (nonatomic, strong) NSString * downLoadedSize;
		[Export ("downLoadedSize", ArgumentSemantic.Strong)]
		string DownLoadedSize { get; set; }

		// @property (assign, nonatomic) LONGLONG llSiteID;
		[Export ("llSiteID")]
		long LlSiteID { get; set; }

		// @property (assign, nonatomic) LONGLONG llUserID;
		[Export ("llUserID")]
		long LlUserID { get; set; }

		// @property (nonatomic, strong) NSString * strUserName;
		[Export ("strUserName", ArgumentSemantic.Strong)]
		string StrUserName { get; set; }

		// @property (nonatomic, strong) NSString * strAlbAddress;
		[Export ("strAlbAddress", ArgumentSemantic.Strong)]
		string StrAlbAddress { get; set; }

		// @property (assign, nonatomic) int nServiceType;
		[Export ("nServiceType")]
		int NServiceType { get; set; }

		// @property (assign, nonatomic) int downFlag;
		[Export ("downFlag")]
		int DownFlag { get; set; }

		// @property (nonatomic, strong) NSString * mDomain;
		[Export ("mDomain", ArgumentSemantic.Strong)]
		string MDomain { get; set; }

		// @property (nonatomic, strong) NSString * endtime;
		[Export ("endtime", ArgumentSemantic.Strong)]
		string Endtime { get; set; }

		// @property (nonatomic, strong) NSString * starttime;
		[Export ("starttime", ArgumentSemantic.Strong)]
		string Starttime { get; set; }

		// @property (assign, nonatomic) NSInteger sc;
		[Export ("sc")]
		nint Sc { get; set; }

		// @property (assign, nonatomic) long long hostID;
		[Export ("hostID")]
		long HostID { get; set; }

		// @property (copy, nonatomic) NSString * cdnList;
		[Export ("cdnList")]
		string CdnList { get; set; }
	}
}
