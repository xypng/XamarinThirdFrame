using System;
using System.Runtime.InteropServices;

namespace DKNightversion
{
	static class CFunctions
	{
		// extern DKNSIntegerPicker DKNSIntegerPickerWithints (NSInteger normal, ...);
		[DllImport ("__Internal")]
		[Verify (PlatformInvoke)]
		static extern DKNSIntegerPicker DKNSIntegerPickerWithints (nint normal, IntPtr varArgs);
	}
}
