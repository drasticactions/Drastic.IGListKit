using System;
using System.Runtime.InteropServices;
using IGListDiffKit;
using ObjCRuntime;

namespace IGListDiffKit
{
	[Native]
	public enum IGListDiffOption : long
	{
		PointerPersonality,
		Equality
	}

	static class CFunctions
	{
		// extern IGListIndexSetResult * _Nonnull IGListDiff (NSArray<id<IGListDiffable>> * _Nullable oldArray, NSArray<id<IGListDiffable>> * _Nullable newArray, IGListDiffOption option) __attribute__((swift_name("ListDiff(oldArray:newArray:option:)")));
		[DllImport ("__Internal")]
		[Verify (PlatformInvoke)]
		static extern IGListIndexSetResult IGListDiff ([NullAllowed] IGListDiffable[] oldArray, [NullAllowed] IGListDiffable[] newArray, IGListDiffOption option);

		// extern IGListIndexPathResult * _Nonnull IGListDiffPaths (NSInteger fromSection, NSInteger toSection, NSArray<id<IGListDiffable>> * _Nullable oldArray, NSArray<id<IGListDiffable>> * _Nullable newArray, IGListDiffOption option) __attribute__((swift_name("ListDiffPaths(fromSection:toSection:oldArray:newArray:option:)")));
		[DllImport ("__Internal")]
		[Verify (PlatformInvoke)]
		static extern IGListIndexPathResult IGListDiffPaths (nint fromSection, nint toSection, [NullAllowed] IGListDiffable[] oldArray, [NullAllowed] IGListDiffable[] newArray, IGListDiffOption option);

		// BOOL IGListExperimentEnabled (IGListExperiment mask, IGListExperiment option) __attribute__((swift_name("ListExperimentEnabled(mask:option:)")));
		[DllImport ("__Internal")]
		[Verify (PlatformInvoke)]
		static extern bool IGListExperimentEnabled (IGListExperiment mask, IGListExperiment option);
	}

	[Flags]
	[Native]
	public enum IGListExperiment : long
	{
		None = 1L << 1,
		InvalidateLayoutForUpdates = 1L << 2,
		SkipPerformUpdateIfPossible = 1L << 3,
		SkipViewSectionControllerMap = 1L << 4
	}
}
