using System;
using Foundation;
using IGListDiffKit;
using ObjCRuntime;

namespace IGListDiffKit
{
	// @interface IGListMoveIndex : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface IGListMoveIndex
	{
		// @property (readonly, assign, nonatomic) NSInteger from;
		[Export ("from")]
		nint From { get; }

		// @property (readonly, assign, nonatomic) NSInteger to;
		[Export ("to")]
		nint To { get; }
	}

	// @interface IGListMoveIndexPath : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface IGListMoveIndexPath
	{
		// @property (readonly, nonatomic, strong) NSIndexPath * _Nonnull from;
		[Export ("from", ArgumentSemantic.Strong)]
		NSIndexPath From { get; }

		// @property (readonly, nonatomic, strong) NSIndexPath * _Nonnull to;
		[Export ("to", ArgumentSemantic.Strong)]
		NSIndexPath To { get; }
	}

	// @interface IGListBatchUpdateData : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface IGListBatchUpdateData
	{
		// @property (readonly, nonatomic, strong) NSIndexSet * _Nonnull insertSections;
		[Export ("insertSections", ArgumentSemantic.Strong)]
		NSIndexSet InsertSections { get; }

		// @property (readonly, nonatomic, strong) NSIndexSet * _Nonnull deleteSections;
		[Export ("deleteSections", ArgumentSemantic.Strong)]
		NSIndexSet DeleteSections { get; }

		// @property (readonly, nonatomic, strong) NSSet<IGListMoveIndex *> * _Nonnull moveSections;
		[Export ("moveSections", ArgumentSemantic.Strong)]
		NSSet<IGListMoveIndex> MoveSections { get; }

		// @property (readonly, nonatomic, strong) NSArray<NSIndexPath *> * _Nonnull insertIndexPaths;
		[Export ("insertIndexPaths", ArgumentSemantic.Strong)]
		NSIndexPath[] InsertIndexPaths { get; }

		// @property (readonly, nonatomic, strong) NSArray<NSIndexPath *> * _Nonnull deleteIndexPaths;
		[Export ("deleteIndexPaths", ArgumentSemantic.Strong)]
		NSIndexPath[] DeleteIndexPaths { get; }

		// @property (readonly, nonatomic, strong) NSArray<NSIndexPath *> * _Nonnull updateIndexPaths;
		[Export ("updateIndexPaths", ArgumentSemantic.Strong)]
		NSIndexPath[] UpdateIndexPaths { get; }

		// @property (readonly, nonatomic, strong) NSArray<IGListMoveIndexPath *> * _Nonnull moveIndexPaths;
		[Export ("moveIndexPaths", ArgumentSemantic.Strong)]
		IGListMoveIndexPath[] MoveIndexPaths { get; }

		// -(instancetype _Nonnull)initWithInsertSections:(NSIndexSet * _Nonnull)insertSections deleteSections:(NSIndexSet * _Nonnull)deleteSections moveSections:(NSSet<IGListMoveIndex *> * _Nonnull)moveSections insertIndexPaths:(NSArray<NSIndexPath *> * _Nonnull)insertIndexPaths deleteIndexPaths:(NSArray<NSIndexPath *> * _Nonnull)deleteIndexPaths updateIndexPaths:(NSArray<NSIndexPath *> * _Nonnull)updateIndexPaths moveIndexPaths:(NSArray<IGListMoveIndexPath *> * _Nonnull)moveIndexPaths __attribute__((objc_designated_initializer));
		[Export ("initWithInsertSections:deleteSections:moveSections:insertIndexPaths:deleteIndexPaths:updateIndexPaths:moveIndexPaths:")]
		[DesignatedInitializer]
		NativeHandle Constructor (NSIndexSet insertSections, NSIndexSet deleteSections, NSSet<IGListMoveIndex> moveSections, NSIndexPath[] insertIndexPaths, NSIndexPath[] deleteIndexPaths, NSIndexPath[] updateIndexPaths, IGListMoveIndexPath[] moveIndexPaths);
	}

	// @protocol IGListDiffable
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/[Protocol]
	interface IGListDiffable
	{
		// @required -(id<NSObject> _Nonnull)diffIdentifier;
		[Abstract]
		[Export ("diffIdentifier")]
		[Verify (MethodToProperty)]
		NSObject DiffIdentifier { get; }

		// @required -(BOOL)isEqualToDiffableObject:(id<IGListDiffable> _Nullable)object;
		[Abstract]
		[Export ("isEqualToDiffableObject:")]
		bool IsEqualToDiffableObject ([NullAllowed] IGListDiffable @object);
	}

	// @interface IGListIndexPathResult : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface IGListIndexPathResult
	{
		// @property (readonly, copy, nonatomic) NSArray<NSIndexPath *> * _Nonnull inserts;
		[Export ("inserts", ArgumentSemantic.Copy)]
		NSIndexPath[] Inserts { get; }

		// @property (readonly, copy, nonatomic) NSArray<NSIndexPath *> * _Nonnull deletes;
		[Export ("deletes", ArgumentSemantic.Copy)]
		NSIndexPath[] Deletes { get; }

		// @property (readonly, copy, nonatomic) NSArray<NSIndexPath *> * _Nonnull updates;
		[Export ("updates", ArgumentSemantic.Copy)]
		NSIndexPath[] Updates { get; }

		// @property (readonly, copy, nonatomic) NSArray<IGListMoveIndexPath *> * _Nonnull moves;
		[Export ("moves", ArgumentSemantic.Copy)]
		IGListMoveIndexPath[] Moves { get; }

		// @property (readonly, assign, nonatomic) BOOL hasChanges;
		[Export ("hasChanges")]
		bool HasChanges { get; }

		// -(NSIndexPath * _Nullable)oldIndexPathForIdentifier:(id<NSObject> _Nonnull)identifier;
		[Export ("oldIndexPathForIdentifier:")]
		[return: NullAllowed]
		NSIndexPath OldIndexPathForIdentifier (NSObject identifier);

		// -(NSIndexPath * _Nullable)newIndexPathForIdentifier:(id<NSObject> _Nonnull)identifier;
		[Export ("newIndexPathForIdentifier:")]
		[return: NullAllowed]
		NSIndexPath NewIndexPathForIdentifier (NSObject identifier);

		// -(IGListIndexPathResult * _Nonnull)resultForBatchUpdates;
		[Export ("resultForBatchUpdates")]
		[Verify (MethodToProperty)]
		IGListIndexPathResult ResultForBatchUpdates { get; }
	}

	// @interface IGListIndexSetResult : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface IGListIndexSetResult
	{
		// @property (readonly, nonatomic, strong) NSIndexSet * _Nonnull inserts;
		[Export ("inserts", ArgumentSemantic.Strong)]
		NSIndexSet Inserts { get; }

		// @property (readonly, nonatomic, strong) NSIndexSet * _Nonnull deletes;
		[Export ("deletes", ArgumentSemantic.Strong)]
		NSIndexSet Deletes { get; }

		// @property (readonly, nonatomic, strong) NSIndexSet * _Nonnull updates;
		[Export ("updates", ArgumentSemantic.Strong)]
		NSIndexSet Updates { get; }

		// @property (readonly, copy, nonatomic) NSArray<IGListMoveIndex *> * _Nonnull moves;
		[Export ("moves", ArgumentSemantic.Copy)]
		IGListMoveIndex[] Moves { get; }

		// @property (readonly, assign, nonatomic) BOOL hasChanges;
		[Export ("hasChanges")]
		bool HasChanges { get; }

		// -(NSInteger)oldIndexForIdentifier:(id<NSObject> _Nonnull)identifier;
		[Export ("oldIndexForIdentifier:")]
		nint OldIndexForIdentifier (NSObject identifier);

		// -(NSInteger)newIndexForIdentifier:(id<NSObject> _Nonnull)identifier;
		[Export ("newIndexForIdentifier:")]
		nint NewIndexForIdentifier (NSObject identifier);

		// -(IGListIndexSetResult * _Nonnull)resultForBatchUpdates;
		[Export ("resultForBatchUpdates")]
		[Verify (MethodToProperty)]
		IGListIndexSetResult ResultForBatchUpdates { get; }
	}

	[Static]
	[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern double IGListKitVersionNumber;
		[Field ("IGListKitVersionNumber", "__Internal")]
		double IGListKitVersionNumber { get; }

		// extern const unsigned char[] IGListKitVersionString;
		[Field ("IGListKitVersionString", "__Internal")]
		byte[] IGListKitVersionString { get; }
	}

	// @interface IGListDiffable (NSNumber) <IGListDiffable>
	[Category]
	[BaseType (typeof(NSNumber))]
	interface NSNumber_IGListDiffable : IIGListDiffable
	{
	}

	// @interface IGListDiffable (NSString) <IGListDiffable>
	[Category]
	[BaseType (typeof(NSString))]
	interface NSString_IGListDiffable : IIGListDiffable
	{
	}
}
