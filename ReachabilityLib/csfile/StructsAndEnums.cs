using System;
using ObjCRuntime;

namespace Reachability.iOS
{
	[Native]
	public enum NetworkStatus : nint
	{
		NotReachable = 0,
		ReachableViaWiFi,
		ReachableViaWWAN
	}
}
