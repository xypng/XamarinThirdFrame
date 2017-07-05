using Foundation;

namespace Reachability.iOS
{
	[Static]
	[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern NSString * kReachabilityChangedNotification;
		[Field ("kReachabilityChangedNotification", "__Internal")]
		NSString kReachabilityChangedNotification { get; }
	}

	// @interface Reachability : NSObject
	[BaseType (typeof(NSObject))]
	interface Reachability
	{
		// +(instancetype)reachabilityWithHostName:(NSString *)hostName;
		[Static]
		[Export ("reachabilityWithHostName:")]
		Reachability ReachabilityWithHostName (string hostName);

		// +(instancetype)reachabilityWithAddress:(const struct sockaddr *)hostAddress;
		[Static]
		[Export ("reachabilityWithAddress:")]
		unsafe Reachability ReachabilityWithAddress (sockaddr* hostAddress);

		// +(instancetype)reachabilityForInternetConnection;
		[Static]
		[Export ("reachabilityForInternetConnection")]
		Reachability ReachabilityForInternetConnection ();

		// -(BOOL)startNotifier;
		[Export ("startNotifier")]
		[Verify (MethodToProperty)]
		bool StartNotifier { get; }

		// -(void)stopNotifier;
		[Export ("stopNotifier")]
		void StopNotifier ();

		// -(NetworkStatus)currentReachabilityStatus;
		[Export ("currentReachabilityStatus")]
		[Verify (MethodToProperty)]
		NetworkStatus CurrentReachabilityStatus { get; }

		// -(BOOL)connectionRequired;
		[Export ("connectionRequired")]
		[Verify (MethodToProperty)]
		bool ConnectionRequired { get; }
	}
}
