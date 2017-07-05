using System;
using ObjCRuntime;

namespace GenseePlayer.ios
{
	[Native]
	public enum GSPChatType : nint
	{
		Public,
		Private,
		System
	}

	[Native]
	public enum GSPServiceType : nuint
	{
		Webcast,
		Training
	}

	[Native]
	public enum GSPDocumentAnnoType : nint
	{
		Null = 0,
		Point,
		FreePen,
		Cleaner,
		Text,
		Circle,
		Rect,
		Line,
		LineEx,
		PointEx,
		FreePenEx
	}

	[Native]
	public enum GSPDocShowType : nint
	{
		ToFill = 1,
		AspectFit,
		AspectFill,
		AspectFitEx
	}

	[Native]
	public enum GSPInvestigationQuestionType : nuint
	{
		SingleChoice,
		MultiChoice,
		Essay
	}

	[Native]
	public enum GSRate : nint
	{
		Normal,
		Low
	}

	[Native]
	public enum GSLottryType : nint
	{
		Start = 1,
		Stop = 2,
		Abort = 3
	}

	[Native]
	public enum GSPLogLevel : nint
	{
		Off,
		Error,
		Warning,
		All
	}

	[Native]
	public enum GSPMediaInvitationType : nint
	{
		AudioOnly = 1,
		VideoOnly = 2,
		AVBoth = 3
	}

	[Native]
	public enum GSPLeaveReason : nint
	{
		Normal = 1,
		Ejected = 2,
		Timeout = 3,
		Closed = 4,
		Unknown = 5,
		ReLogin = 14
	}

	[Native]
	public enum GSPJoinResult : nint
	{
		CreateRtmpPlayerFailed = 1,
		JoinReturnFailed = 2,
		NetworkError = 3,
		UnknowError = 4,
		ParamsError = 5,
		Ok = 6,
		Connnecting = 7,
		ConnectFailed = 8,
		Timeout = 9,
		RtmpFailed = 10,
		TooEarly = 11,
		License = 12,
		ErrorFile = 13,
		Rejoin = 16,
		IpForbid = 17,
		ThirdTokenError,
		MobileUnsupported,
		WebcastIDNotFound,
		WebcastIDInvalid,
		LoginFailed,
		JoinCastPasswordError,
		RoleOrDomainError,
		InitFailed
	}

	[Native]
	public enum GSModuleFocusType : nuint
	{
		DocMain = 0,
		VideoMax = 1,
		DocMax = 2,
		VideoMain = 3
	}

	[Native]
	public enum GSPVideoCrop : nuint
	{
		GSPVideoCrop4x3,
		GSPVideoCrop16x9
	}

	[Native]
	public enum GSPDiagnosisType : nint
	{
		UploadSuccess = 0,
		UploadFailure = 1,
		NetError = 2
	}

	[Native]
	public enum GSVodDocumentAnnoType : nint
	{
		Null = 0,
		Point,
		FreePen,
		Cleaner,
		Text,
		Circle,
		Rect,
		Line,
		LineEx,
		PointEx,
		FreePenEx
	}

	[Native]
	public enum GSVodDocShowType : nint
	{
		ToFill = 1,
		AspectFit,
		AspectFill,
		AspectFitEx
	}

	public enum ResultType : uint
	{
		RoomNumberUnexist = 0,
		Success = 1,
		NotExsite = 2,
		FailWebcast = 3,
		FailToken = 4,
		FailLogin = 5,
		IsonlyWeb = 7,
		RoomUneable = 8,
		OwnerError = 9,
		InvalidAddress = 10,
		RoomOverdue = 11,
		AuthorizationNotEnough = 12,
		InitDownloadFailed = 13,
		FailedNetRequired,
		UnsurportMobile = 18
	}

	public enum Downstate : uint
	{
		Reday,
		Begin,
		Pause,
		Finish,
		Failed
	}

	public enum VodDownLoadStatus : uint
	{
		ErrorNet
	}

	public enum DocType : uint
	{
		PngType = 1,
		SwfType = 2
	}

	public enum SpeedValue : uint
	{
		Normal,
		Speed125,
		Speed150,
		Speed175,
		Speed2,
		Speed25,
		Speed3,
		Speed35,
		Speed4
	}
}
