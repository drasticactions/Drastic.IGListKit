using System.Runtime.InteropServices;
using ObjCRuntime;
using System;

namespace IGListKit
{
	[Native]
	public enum IGListAdapterUpdateType : long
	{
		PerformUpdates,
		ReloadData,
		ItemUpdates
	}

	[StructLayout (LayoutKind.Sequential)]
	public struct IGListCollectionScrollingTraits
	{
		public bool isTracking;

		public bool isDragging;

		public bool isDecelerating;
	}

	[Native]
	public enum IGListDiffOption : long
	{
		PointerPersonality,
		Equality
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
