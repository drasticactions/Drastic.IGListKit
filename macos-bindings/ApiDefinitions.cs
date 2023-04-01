using Foundation;

namespace IGListKit
{
	[Static]
	[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern int IGListKitVersionNumber;
		[Field ("IGListKitVersionNumber")]
		int IGListKitVersionNumber { get; }

		// extern const int[] IGListKitVersionString;
		[Field ("IGListKitVersionString")]
		int[] IGListKitVersionString { get; }
	}
}
