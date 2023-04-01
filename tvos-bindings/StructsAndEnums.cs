using System.Runtime.InteropServices;
using ObjCRuntime;

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
}
