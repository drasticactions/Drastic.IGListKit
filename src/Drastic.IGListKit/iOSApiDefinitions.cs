using System;
using CoreGraphics;
using Foundation;
using IGListKit;
using ObjCRuntime;
using UIKit;

namespace IGListKit
{
// 	// @protocol IGListAdapterDataSource <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface IGListAdapterDataSource
	{
		// @required -(NSArray<id> * _Nonnull)objectsForListAdapter:(IGListAdapter * _Nonnull)listAdapter;
		[Abstract]
		[Export ("objectsForListAdapter:")]
		NSObject[] ObjectsForListAdapter (IGListAdapter listAdapter);

		// @required -(IGListSectionController * _Nonnull)listAdapter:(IGListAdapter * _Nonnull)listAdapter sectionControllerForObject:(id _Nonnull)object;
		[Abstract]
		[Export ("listAdapter:sectionControllerForObject:")]
		IGListSectionController ListAdapter (IGListAdapter listAdapter, NSObject @object);

		// @required -(UIView * _Nullable)emptyViewForListAdapter:(IGListAdapter * _Nonnull)listAdapter;
		[Abstract]
		[Export ("emptyViewForListAdapter:")]
		[return: NullAllowed]
		UIView EmptyViewForListAdapter (IGListAdapter listAdapter);
	}

	// @protocol IGListAdapterDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface IGListAdapterDelegate
	{
		// @required -(void)listAdapter:(IGListAdapter * _Nonnull)listAdapter willDisplayObject:(id _Nonnull)object atIndex:(NSInteger)index;
		[Abstract]
		[Export ("listAdapter:willDisplayObject:atIndex:")]
		void WillDisplayObject (IGListAdapter listAdapter, NSObject @object, nint index);

		// @required -(void)listAdapter:(IGListAdapter * _Nonnull)listAdapter didEndDisplayingObject:(id _Nonnull)object atIndex:(NSInteger)index;
		[Abstract]
		[Export ("listAdapter:didEndDisplayingObject:atIndex:")]
		void DidEndDisplayingObject (IGListAdapter listAdapter, NSObject @object, nint index);
	}

	// @protocol IGListAdapterMoveDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface IGListAdapterMoveDelegate
	{
		// @required -(void)listAdapter:(IGListAdapter * _Nonnull)listAdapter moveObject:(id _Nonnull)object from:(NSArray * _Nonnull)previousObjects to:(NSArray * _Nonnull)objects;
		[Abstract]
		[Export ("listAdapter:moveObject:from:to:")]
		//[Verify (StronglyTypedNSArray), Verify (StronglyTypedNSArray)]
		void MoveObject (IGListAdapter listAdapter, NSObject @object, NSObject[] previousObjects, NSObject[] objects);
	}

	// @protocol IGListAdapterPerformanceDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface IGListAdapterPerformanceDelegate
	{
		// @required -(void)listAdapterWillCallDequeueCell:(IGListAdapter * _Nonnull)listAdapter;
		[Abstract]
		[Export ("listAdapterWillCallDequeueCell:")]
		void ListAdapterWillCallDequeueCell (IGListAdapter listAdapter);

		// @required -(void)listAdapter:(IGListAdapter * _Nonnull)listAdapter didCallDequeueCell:(UICollectionViewCell * _Nonnull)cell onSectionController:(IGListSectionController * _Nonnull)sectionController atIndex:(NSInteger)index;
		[Abstract]
		[Export ("listAdapter:didCallDequeueCell:onSectionController:atIndex:")]
		void ListAdapterDidCallDequeueCell (IGListAdapter listAdapter, UICollectionViewCell cell, IGListSectionController sectionController, nint index);

		// @required -(void)listAdapterWillCallDisplayCell:(IGListAdapter * _Nonnull)listAdapter;
		[Abstract]
		[Export ("listAdapterWillCallDisplayCell:")]
		void ListAdapterWillCallDisplayCell (IGListAdapter listAdapter);

		// @required -(void)listAdapter:(IGListAdapter * _Nonnull)listAdapter didCallDisplayCell:(UICollectionViewCell * _Nonnull)cell onSectionController:(IGListSectionController * _Nonnull)sectionController atIndex:(NSInteger)index;
		[Abstract]
		[Export ("listAdapter:didCallDisplayCell:onSectionController:atIndex:")]
		void ListAdapterDidCallDisplayCell (IGListAdapter listAdapter, UICollectionViewCell cell, IGListSectionController sectionController, nint index);

		// @required -(void)listAdapterWillCallEndDisplayCell:(IGListAdapter * _Nonnull)listAdapter;
		[Abstract]
		[Export ("listAdapterWillCallEndDisplayCell:")]
		void ListAdapterWillCallEndDisplayCell (IGListAdapter listAdapter);

		// @required -(void)listAdapter:(IGListAdapter * _Nonnull)listAdapter didCallEndDisplayCell:(UICollectionViewCell * _Nonnull)cell onSectionController:(IGListSectionController * _Nonnull)sectionController atIndex:(NSInteger)index;
		[Abstract]
		[Export ("listAdapter:didCallEndDisplayCell:onSectionController:atIndex:")]
		void ListAdapterDidCallEndDisplayCell (IGListAdapter listAdapter, UICollectionViewCell cell, IGListSectionController sectionController, nint index);

		// @required -(void)listAdapterWillCallSize:(IGListAdapter * _Nonnull)listAdapter;
		[Abstract]
		[Export ("listAdapterWillCallSize:")]
		void ListAdapterWillCallSize (IGListAdapter listAdapter);

		// @required -(void)listAdapter:(IGListAdapter * _Nonnull)listAdapter didCallSizeOnSectionController:(IGListSectionController * _Nonnull)sectionController atIndex:(NSInteger)index;
		[Abstract]
		[Export ("listAdapter:didCallSizeOnSectionController:atIndex:")]
		void ListAdapterDidCallSizeOnSectionController (IGListAdapter listAdapter, IGListSectionController sectionController, nint index);

		// @required -(void)listAdapterWillCallScroll:(IGListAdapter * _Nonnull)listAdapter;
		[Abstract]
		[Export ("listAdapterWillCallScroll:")]
		void ListAdapterWillCallScroll (IGListAdapter listAdapter);

		// @required -(void)listAdapter:(IGListAdapter * _Nonnull)listAdapter didCallScroll:(UIScrollView * _Nonnull)scrollView;
		[Abstract]
		[Export ("listAdapter:didCallScroll:")]
		void ListAdapter (IGListAdapter listAdapter, UIScrollView scrollView);
	}

	// @protocol IGListAdapterUpdateListener <NSObject>
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/[Protocol]
	[BaseType (typeof(NSObject))]
	interface IGListAdapterUpdateListener
	{
		// @required -(void)listAdapter:(IGListAdapter * _Nonnull)listAdapter didFinishUpdate:(IGListAdapterUpdateType)update animated:(BOOL)animated;
		[Abstract]
		[Export ("listAdapter:didFinishUpdate:animated:")]
		void DidFinishUpdate (IGListAdapter listAdapter, IGListAdapterUpdateType update, bool animated);
	}

	// typedef void (^IGListUpdaterCompletion)(BOOL);
	delegate void IGListUpdaterCompletion (bool arg0);

	// @interface IGListAdapter : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface IGListAdapter
	{
		// @property (nonatomic, weak) UIViewController * _Nullable viewController;
		[NullAllowed, Export ("viewController", ArgumentSemantic.Weak)]
		UIViewController ViewController { get; set; }

		// @property (nonatomic, weak) UICollectionView * _Nullable collectionView;
		[NullAllowed, Export ("collectionView", ArgumentSemantic.Weak)]
		UICollectionView CollectionView { get; set; }

		[Wrap ("WeakDataSource")]
		[NullAllowed]
		IGListAdapterDataSource DataSource { get; set; }

		// @property (nonatomic, weak) id<IGListAdapterDataSource> _Nullable dataSource;
		[NullAllowed, Export ("dataSource", ArgumentSemantic.Weak)]
		NSObject WeakDataSource { get; set; }

		[Wrap ("WeakDelegate")]
		[NullAllowed]
		IGListAdapterDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<IGListAdapterDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		[Wrap ("WeakCollectionViewDelegate")]
		[NullAllowed]
		UICollectionViewDelegate CollectionViewDelegate { get; set; }

		// @property (nonatomic, weak) id<UICollectionViewDelegate> _Nullable collectionViewDelegate;
		[NullAllowed, Export ("collectionViewDelegate", ArgumentSemantic.Weak)]
		NSObject WeakCollectionViewDelegate { get; set; }

		[Wrap ("WeakScrollViewDelegate")]
		[NullAllowed]
		UIScrollViewDelegate ScrollViewDelegate { get; set; }

		// @property (nonatomic, weak) id<UIScrollViewDelegate> _Nullable scrollViewDelegate;
		[NullAllowed, Export ("scrollViewDelegate", ArgumentSemantic.Weak)]
		NSObject WeakScrollViewDelegate { get; set; }

		[Wrap ("WeakMoveDelegate")]
		IGListAdapterMoveDelegate MoveDelegate { get; set; }

		// @property (nonatomic, weak) NS_AVAILABLE_IOS(9_0) id<IGListAdapterMoveDelegate> moveDelegate __attribute__((availability(ios, introduced=9.0)));
		//[iOS (9, 0)]
		[NullAllowed, Export ("moveDelegate", ArgumentSemantic.Weak)]
		NSObject WeakMoveDelegate { get; set; }

		[Wrap ("WeakPerformanceDelegate")]
		[NullAllowed]
		IGListAdapterPerformanceDelegate PerformanceDelegate { get; set; }

		// @property (nonatomic, weak) id<IGListAdapterPerformanceDelegate> _Nullable performanceDelegate;
		[NullAllowed, Export ("performanceDelegate", ArgumentSemantic.Weak)]
		NSObject WeakPerformanceDelegate { get; set; }

		// @property (readonly, nonatomic, strong) id<IGListUpdatingDelegate> _Nonnull updater;
		[Export ("updater", ArgumentSemantic.Strong)]
		IGListUpdatingDelegate Updater { get; }

		// @property (assign, nonatomic) int experiments;
		[Export ("experiments")]
		int Experiments { get; set; }

		// -(instancetype _Nonnull)initWithUpdater:(id<IGListUpdatingDelegate> _Nonnull)updater viewController:(UIViewController * _Nullable)viewController workingRangeSize:(NSInteger)workingRangeSize __attribute__((objc_designated_initializer));
		[Export ("initWithUpdater:viewController:workingRangeSize:")]
		[DesignatedInitializer]
		NativeHandle Constructor (IGListUpdatingDelegate updater, [NullAllowed] UIViewController viewController, nint workingRangeSize);

		// -(instancetype _Nonnull)initWithUpdater:(id<IGListUpdatingDelegate> _Nonnull)updater viewController:(UIViewController * _Nullable)viewController;
		[Export ("initWithUpdater:viewController:")]
		NativeHandle Constructor (IGListUpdatingDelegate updater, [NullAllowed] UIViewController viewController);

		// -(void)performUpdatesAnimated:(BOOL)animated completion:(IGListUpdaterCompletion _Nullable)completion;
		[Export ("performUpdatesAnimated:completion:")]
		void PerformUpdatesAnimated (bool animated, [NullAllowed] IGListUpdaterCompletion completion);

		// -(void)reloadDataWithCompletion:(IGListUpdaterCompletion _Nullable)completion;
		[Export ("reloadDataWithCompletion:")]
		void ReloadDataWithCompletion ([NullAllowed] IGListUpdaterCompletion completion);

		// -(void)reloadObjects:(NSArray * _Nonnull)objects;
		[Export ("reloadObjects:")]
		//[Verify (StronglyTypedNSArray)]
		void ReloadObjects (NSObject[] objects);

		// -(IGListSectionController * _Nullable)sectionControllerForSection:(NSInteger)section;
		[Export ("sectionControllerForSection:")]
		[return: NullAllowed]
		IGListSectionController SectionControllerForSection (nint section);

		// -(NSInteger)sectionForSectionController:(IGListSectionController * _Nonnull)sectionController;
		[Export ("sectionForSectionController:")]
		nint SectionForSectionController (IGListSectionController sectionController);

		// -(__kindof IGListSectionController * _Nullable)sectionControllerForObject:(id _Nonnull)object;
		[Export ("sectionControllerForObject:")]
		[return: NullAllowed]
		IGListSectionController SectionControllerForObject (NSObject @object);

		// -(id _Nullable)objectForSectionController:(IGListSectionController * _Nonnull)sectionController;
		[Export ("objectForSectionController:")]
		[return: NullAllowed]
		NSObject ObjectForSectionController (IGListSectionController sectionController);

		// -(id _Nullable)objectAtSection:(NSInteger)section;
		[Export ("objectAtSection:")]
		[return: NullAllowed]
		NSObject ObjectAtSection (nint section);

		// -(NSInteger)sectionForObject:(id _Nonnull)object;
		[Export ("sectionForObject:")]
		nint SectionForObject (NSObject @object);

		// -(NSArray * _Nonnull)objects;
		[Export ("objects")]
		//[Verify (MethodToProperty), Verify (StronglyTypedNSArray)]
		NSObject[] Objects { get; }

		// -(NSArray<IGListSectionController *> * _Nonnull)visibleSectionControllers;
		[Export ("visibleSectionControllers")]
		//[Verify (MethodToProperty)]
		IGListSectionController[] VisibleSectionControllers { get; }

		// -(NSArray * _Nonnull)visibleObjects;
		[Export ("visibleObjects")]
		//[Verify (MethodToProperty), Verify (StronglyTypedNSArray)]
		NSObject[] VisibleObjects { get; }

		// -(NSArray<UICollectionViewCell *> * _Nonnull)visibleCellsForObject:(id _Nonnull)object;
		[Export ("visibleCellsForObject:")]
		UICollectionViewCell[] VisibleCellsForObject (NSObject @object);

		// -(void)scrollToObject:(id _Nonnull)object supplementaryKinds:(NSArray<NSString *> * _Nullable)supplementaryKinds scrollDirection:(UICollectionViewScrollDirection)scrollDirection scrollPosition:(UICollectionViewScrollPosition)scrollPosition additionalOffset:(CGFloat)additionalOffset animated:(BOOL)animated;
		[Export ("scrollToObject:supplementaryKinds:scrollDirection:scrollPosition:additionalOffset:animated:")]
		void ScrollToObject (NSObject @object, [NullAllowed] string[] supplementaryKinds, UICollectionViewScrollDirection scrollDirection, UICollectionViewScrollPosition scrollPosition, nfloat additionalOffset, bool animated);

		// -(NSIndexPath * _Nullable)indexPathForFirstVisibleItem;
		[NullAllowed, Export ("indexPathForFirstVisibleItem")]
		//[Verify (MethodToProperty)]
		NSIndexPath IndexPathForFirstVisibleItem { get; }

		// -(CGFloat)offsetForFirstVisibleItemWithScrollDirection:(UICollectionViewScrollDirection)scrollDirection;
		[Export ("offsetForFirstVisibleItemWithScrollDirection:")]
		nfloat OffsetForFirstVisibleItemWithScrollDirection (UICollectionViewScrollDirection scrollDirection);

		// -(CGSize)sizeForItemAtIndexPath:(NSIndexPath * _Nonnull)indexPath;
		[Export ("sizeForItemAtIndexPath:")]
		CGSize SizeForItemAtIndexPath (NSIndexPath indexPath);

		// -(CGSize)sizeForSupplementaryViewOfKind:(NSString * _Nonnull)elementKind atIndexPath:(NSIndexPath * _Nonnull)indexPath;
		[Export ("sizeForSupplementaryViewOfKind:atIndexPath:")]
		CGSize SizeForSupplementaryViewOfKind (string elementKind, NSIndexPath indexPath);

		// -(void)addUpdateListener:(id<IGListAdapterUpdateListener> _Nonnull)updateListener;
		[Export ("addUpdateListener:")]
		void AddUpdateListener (IGListAdapterUpdateListener updateListener);

		// -(void)removeUpdateListener:(id<IGListAdapterUpdateListener> _Nonnull)updateListener;
		[Export ("removeUpdateListener:")]
		void RemoveUpdateListener (IGListAdapterUpdateListener updateListener);
	}

	// typedef void (^IGListUpdatingCompletion)(BOOL);
	delegate void IGListUpdatingCompletion (bool arg0);

	// typedef void (^IGListObjectTransitionBlock)(NSArray * _Nonnull);
	delegate void IGListObjectTransitionBlock (NSObject[] arg0);

	// typedef void (^IGListItemUpdateBlock)();
	delegate void IGListItemUpdateBlock ();

	// typedef void (^IGListReloadUpdateBlock)();
	delegate void IGListReloadUpdateBlock ();

	// typedef NSArray * _Nullable (^IGListToObjectBlock)();
	delegate NSObject[] IGListToObjectBlock ();

	// typedef UICollectionView * _Nullable (^IGListCollectionViewBlock)();
	delegate UICollectionView IGListCollectionViewBlock ();

	// typedef void (^IGListDataSourceChangeBlock)();
	delegate void IGListDataSourceChangeBlock ();

	// typedef IGListTransitionData * _Nullable (^IGListTransitionDataBlock)();
	delegate IGListTransitionData IGListTransitionDataBlock ();

	// typedef void (^IGListTransitionDataApplyBlock)(IGListTransitionData * _Nonnull);
	delegate void IGListTransitionDataApplyBlock (IGListTransitionData arg0);

	// @protocol IGListUpdatingDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface IGListUpdatingDelegate
	{
		// // @required -(NSPointerFunctions * _Nonnull)objectLookupPointerFunctions;
		// [Abstract]
		// [Export ("objectLookupPointerFunctions")]
		// //[Verify (MethodToProperty)]
		// NSPointerFunctions ObjectLookupPointerFunctions { get; }

		// @required -(void)performUpdateWithCollectionViewBlock:(IGListCollectionViewBlock _Nonnull)collectionViewBlock animated:(BOOL)animated sectionDataBlock:(IGListTransitionDataBlock _Nonnull)sectionDataBlock applySectionDataBlock:(IGListTransitionDataApplyBlock _Nonnull)applySectionDataBlock completion:(IGListUpdatingCompletion _Nullable)completion;
		[Abstract]
		[Export ("performUpdateWithCollectionViewBlock:animated:sectionDataBlock:applySectionDataBlock:completion:")]
		void PerformUpdateWithCollectionViewBlock (IGListCollectionViewBlock collectionViewBlock, bool animated, IGListTransitionDataBlock sectionDataBlock, IGListTransitionDataApplyBlock applySectionDataBlock, [NullAllowed] IGListUpdatingCompletion completion);

		// @required -(void)performUpdateWithCollectionViewBlock:(IGListCollectionViewBlock _Nonnull)collectionViewBlock animated:(BOOL)animated itemUpdates:(IGListItemUpdateBlock _Nonnull)itemUpdates completion:(IGListUpdatingCompletion _Nullable)completion;
		[Abstract]
		[Export ("performUpdateWithCollectionViewBlock:animated:itemUpdates:completion:")]
		void PerformUpdateWithCollectionViewBlock (IGListCollectionViewBlock collectionViewBlock, bool animated, IGListItemUpdateBlock itemUpdates, [NullAllowed] IGListUpdatingCompletion completion);

		// @required -(void)performDataSourceChange:(IGListDataSourceChangeBlock _Nonnull)block;
		[Abstract]
		[Export ("performDataSourceChange:")]
		void PerformDataSourceChange (IGListDataSourceChangeBlock block);

		// @required -(void)reloadDataWithCollectionViewBlock:(IGListCollectionViewBlock _Nonnull)collectionViewBlock reloadUpdateBlock:(IGListReloadUpdateBlock _Nonnull)reloadUpdateBlock completion:(IGListUpdatingCompletion _Nullable)completion;
		[Abstract]
		[Export ("reloadDataWithCollectionViewBlock:reloadUpdateBlock:completion:")]
		void ReloadDataWithCollectionViewBlock (IGListCollectionViewBlock collectionViewBlock, IGListReloadUpdateBlock reloadUpdateBlock, [NullAllowed] IGListUpdatingCompletion completion);

		// @required -(void)insertItemsIntoCollectionView:(UICollectionView * _Nonnull)collectionView indexPaths:(NSArray<NSIndexPath *> * _Nonnull)indexPaths;
		[Abstract]
		[Export ("insertItemsIntoCollectionView:indexPaths:")]
		void InsertItemsIntoCollectionView (UICollectionView collectionView, NSIndexPath[] indexPaths);

		// @required -(void)deleteItemsFromCollectionView:(UICollectionView * _Nonnull)collectionView indexPaths:(NSArray<NSIndexPath *> * _Nonnull)indexPaths;
		[Abstract]
		[Export ("deleteItemsFromCollectionView:indexPaths:")]
		void DeleteItemsFromCollectionView (UICollectionView collectionView, NSIndexPath[] indexPaths);

		// @required -(void)moveItemInCollectionView:(UICollectionView * _Nonnull)collectionView fromIndexPath:(NSIndexPath * _Nonnull)fromIndexPath toIndexPath:(NSIndexPath * _Nonnull)toIndexPath;
		[Abstract]
		[Export ("moveItemInCollectionView:fromIndexPath:toIndexPath:")]
		void MoveItemInCollectionView (UICollectionView collectionView, NSIndexPath fromIndexPath, NSIndexPath toIndexPath);

		// @required -(void)reloadItemInCollectionView:(UICollectionView * _Nonnull)collectionView fromIndexPath:(NSIndexPath * _Nonnull)fromIndexPath toIndexPath:(NSIndexPath * _Nonnull)toIndexPath;
		[Abstract]
		[Export ("reloadItemInCollectionView:fromIndexPath:toIndexPath:")]
		void ReloadItemInCollectionView (UICollectionView collectionView, NSIndexPath fromIndexPath, NSIndexPath toIndexPath);

		// @required -(void)moveSectionInCollectionView:(UICollectionView * _Nonnull)collectionView fromIndex:(NSInteger)fromIndex toIndex:(NSInteger)toIndex;
		[Abstract]
		[Export ("moveSectionInCollectionView:fromIndex:toIndex:")]
		void MoveSectionInCollectionView (UICollectionView collectionView, nint fromIndex, nint toIndex);

		// @required -(void)reloadCollectionView:(UICollectionView * _Nonnull)collectionView sections:(NSIndexSet * _Nonnull)sections;
		[Abstract]
		[Export ("reloadCollectionView:sections:")]
		void ReloadCollectionView (UICollectionView collectionView, NSIndexSet sections);
	}

	// @protocol IGListAdapterUpdaterDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface IGListAdapterUpdaterDelegate
	{
		// @required -(void)listAdapterUpdater:(IGListAdapterUpdater * _Nonnull)listAdapterUpdater willDiffFromObjects:(NSArray<id<IGListDiffable>> * _Nullable)fromObjects toObjects:(NSArray<id<IGListDiffable>> * _Nullable)toObjects;
		[Abstract]
		[Export ("listAdapterUpdater:willDiffFromObjects:toObjects:")]
		void WillDiffFromObjects (IGListAdapterUpdater listAdapterUpdater, [NullAllowed] IGListDiffable[] fromObjects, [NullAllowed] IGListDiffable[] toObjects);

		// @required -(void)listAdapterUpdater:(IGListAdapterUpdater * _Nonnull)listAdapterUpdater didDiffWithResults:(IGListIndexSetResult * _Nullable)listIndexSetResults onBackgroundThread:(BOOL)onBackgroundThread;
		[Abstract]
		[Export ("listAdapterUpdater:didDiffWithResults:onBackgroundThread:")]
		void DidDiffWithResults (IGListAdapterUpdater listAdapterUpdater, [NullAllowed] IGListIndexSetResult listIndexSetResults, bool onBackgroundThread);

		// @required -(void)listAdapterUpdater:(IGListAdapterUpdater * _Nonnull)listAdapterUpdater willPerformBatchUpdatesWithCollectionView:(UICollectionView * _Nonnull)collectionView fromObjects:(NSArray<id<IGListDiffable>> * _Nullable)fromObjects toObjects:(NSArray<id<IGListDiffable>> * _Nullable)toObjects listIndexSetResult:(IGListIndexSetResult * _Nullable)listIndexSetResults animated:(BOOL)animated;
		[Abstract]
		[Export ("listAdapterUpdater:willPerformBatchUpdatesWithCollectionView:fromObjects:toObjects:listIndexSetResult:animated:")]
		void WillPerformBatchUpdatesWithCollectionView (IGListAdapterUpdater listAdapterUpdater, UICollectionView collectionView, [NullAllowed] IGListDiffable[] fromObjects, [NullAllowed] IGListDiffable[] toObjects, [NullAllowed] IGListIndexSetResult listIndexSetResults, bool animated);

		// @required -(void)listAdapterUpdater:(IGListAdapterUpdater * _Nonnull)listAdapterUpdater didPerformBatchUpdates:(id)updates collectionView:(UICollectionView * _Nonnull)collectionView;
		[Abstract]
		[Export ("listAdapterUpdater:didPerformBatchUpdates:collectionView:")]
		void DidPerformBatchUpdates (IGListAdapterUpdater listAdapterUpdater, NSObject updates, UICollectionView collectionView);

		// @required -(void)listAdapterUpdater:(IGListAdapterUpdater * _Nonnull)listAdapterUpdater willInsertIndexPaths:(NSArray<NSIndexPath *> * _Nonnull)indexPaths collectionView:(UICollectionView * _Nonnull)collectionView;
		[Abstract]
		[Export ("listAdapterUpdater:willInsertIndexPaths:collectionView:")]
		void WillInsertIndexPaths (IGListAdapterUpdater listAdapterUpdater, NSIndexPath[] indexPaths, UICollectionView collectionView);

		// @required -(void)listAdapterUpdater:(IGListAdapterUpdater * _Nonnull)listAdapterUpdater willDeleteIndexPaths:(NSArray<NSIndexPath *> * _Nonnull)indexPaths collectionView:(UICollectionView * _Nonnull)collectionView;
		[Abstract]
		[Export ("listAdapterUpdater:willDeleteIndexPaths:collectionView:")]
		void WillDeleteIndexPaths (IGListAdapterUpdater listAdapterUpdater, NSIndexPath[] indexPaths, UICollectionView collectionView);

		// @required -(void)listAdapterUpdater:(IGListAdapterUpdater * _Nonnull)listAdapterUpdater willMoveFromIndexPath:(NSIndexPath * _Nonnull)fromIndexPath toIndexPath:(NSIndexPath * _Nonnull)toIndexPath collectionView:(UICollectionView * _Nonnull)collectionView;
		[Abstract]
		[Export ("listAdapterUpdater:willMoveFromIndexPath:toIndexPath:collectionView:")]
		void WillMoveFromIndexPath (IGListAdapterUpdater listAdapterUpdater, NSIndexPath fromIndexPath, NSIndexPath toIndexPath, UICollectionView collectionView);

		// @required -(void)listAdapterUpdater:(IGListAdapterUpdater * _Nonnull)listAdapterUpdater willReloadIndexPaths:(NSArray<NSIndexPath *> * _Nonnull)indexPaths collectionView:(UICollectionView * _Nonnull)collectionView;
		[Abstract]
		[Export ("listAdapterUpdater:willReloadIndexPaths:collectionView:")]
		void WillReloadIndexPaths (IGListAdapterUpdater listAdapterUpdater, NSIndexPath[] indexPaths, UICollectionView collectionView);

		// @required -(void)listAdapterUpdater:(IGListAdapterUpdater * _Nonnull)listAdapterUpdater willReloadSections:(NSIndexSet * _Nonnull)sections collectionView:(UICollectionView * _Nonnull)collectionView;
		[Abstract]
		[Export ("listAdapterUpdater:willReloadSections:collectionView:")]
		void WillReloadSections (IGListAdapterUpdater listAdapterUpdater, NSIndexSet sections, UICollectionView collectionView);

		// @required -(void)listAdapterUpdater:(IGListAdapterUpdater * _Nonnull)listAdapterUpdater willReloadDataWithCollectionView:(UICollectionView * _Nonnull)collectionView isFallbackReload:(BOOL)isFallbackReload;
		[Abstract]
		[Export ("listAdapterUpdater:willReloadDataWithCollectionView:isFallbackReload:")]
		void WillReloadDataWithCollectionView (IGListAdapterUpdater listAdapterUpdater, UICollectionView collectionView, bool isFallbackReload);

		// @required -(void)listAdapterUpdater:(IGListAdapterUpdater * _Nonnull)listAdapterUpdater didReloadDataWithCollectionView:(UICollectionView * _Nonnull)collectionView isFallbackReload:(BOOL)isFallbackReload;
		[Abstract]
		[Export ("listAdapterUpdater:didReloadDataWithCollectionView:isFallbackReload:")]
		void DidReloadDataWithCollectionView (IGListAdapterUpdater listAdapterUpdater, UICollectionView collectionView, bool isFallbackReload);

		// @required -(void)listAdapterUpdater:(IGListAdapterUpdater * _Nonnull)listAdapterUpdater collectionView:(UICollectionView * _Nonnull)collectionView willCrashWithException:(NSException * _Nonnull)exception fromObjects:(NSArray * _Nullable)fromObjects toObjects:(NSArray * _Nullable)toObjects diffResult:(IGListIndexSetResult * _Nonnull)diffResult updates:(id)updates;
		[Abstract]
		[Export ("listAdapterUpdater:collectionView:willCrashWithException:fromObjects:toObjects:diffResult:updates:")]
		//[Verify (StronglyTypedNSArray), Verify (StronglyTypedNSArray)]
		void CollectionView (IGListAdapterUpdater listAdapterUpdater, UICollectionView collectionView, NSException exception, [NullAllowed] NSObject[] fromObjects, [NullAllowed] NSObject[] toObjects, IGListIndexSetResult diffResult, NSObject updates);

		// @required -(void)listAdapterUpdater:(IGListAdapterUpdater * _Nonnull)listAdapterUpdater didFinishWithoutUpdatesWithCollectionView:(UICollectionView * _Nullable)collectionView;
		[Abstract]
		[Export ("listAdapterUpdater:didFinishWithoutUpdatesWithCollectionView:")]
		void DidFinishWithoutUpdatesWithCollectionView (IGListAdapterUpdater listAdapterUpdater, [NullAllowed] UICollectionView collectionView);
	}

	// @interface IGListAdapterUpdater : NSObject <IGListUpdatingDelegate>
	[BaseType (typeof(NSObject))]
	interface IGListAdapterUpdater : IGListUpdatingDelegate
	{
		[Wrap ("WeakDelegate")]
		[NullAllowed]
		IGListAdapterUpdaterDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<IGListAdapterUpdaterDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (assign, nonatomic) BOOL sectionMovesAsDeletesInserts;
		[Export ("sectionMovesAsDeletesInserts")]
		bool SectionMovesAsDeletesInserts { get; set; }

		// @property (assign, nonatomic) BOOL singleItemSectionUpdates;
		[Export ("singleItemSectionUpdates")]
		bool SingleItemSectionUpdates { get; set; }

		// @property (assign, nonatomic) BOOL preferItemReloadsForSectionReloads;
		[Export ("preferItemReloadsForSectionReloads")]
		bool PreferItemReloadsForSectionReloads { get; set; }

		// @property (assign, nonatomic) BOOL allowsReloadingOnTooManyUpdates;
		[Export ("allowsReloadingOnTooManyUpdates")]
		bool AllowsReloadingOnTooManyUpdates { get; set; }

		// @property (assign, nonatomic) BOOL allowsBackgroundDiffing;
		[Export ("allowsBackgroundDiffing")]
		bool AllowsBackgroundDiffing { get; set; }

		// @property (assign, nonatomic) int experiments;
		[Export ("experiments")]
		int Experiments { get; set; }
	}

	// @protocol IGListBatchContext <NSObject>
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/[Protocol]
	[BaseType (typeof(NSObject))]
	interface IGListBatchContext
	{
		// @required -(void)reloadInSectionController:(IGListSectionController * _Nonnull)sectionController atIndexes:(NSIndexSet * _Nonnull)indexes;
		[Abstract]
		[Export ("reloadInSectionController:atIndexes:")]
		void ReloadInSectionController (IGListSectionController sectionController, NSIndexSet indexes);

		// @required -(void)insertInSectionController:(IGListSectionController * _Nonnull)sectionController atIndexes:(NSIndexSet * _Nonnull)indexes;
		[Abstract]
		[Export ("insertInSectionController:atIndexes:")]
		void InsertInSectionController (IGListSectionController sectionController, NSIndexSet indexes);

		// @required -(void)deleteInSectionController:(IGListSectionController * _Nonnull)sectionController atIndexes:(NSIndexSet * _Nonnull)indexes;
		[Abstract]
		[Export ("deleteInSectionController:atIndexes:")]
		void DeleteInSectionController (IGListSectionController sectionController, NSIndexSet indexes);

		// @required -(void)invalidateLayoutInSectionController:(IGListSectionController * _Nonnull)sectionController atIndexes:(NSIndexSet * _Nonnull)indexes;
		[Abstract]
		[Export ("invalidateLayoutInSectionController:atIndexes:")]
		void InvalidateLayoutInSectionController (IGListSectionController sectionController, NSIndexSet indexes);

		// @required -(void)moveInSectionController:(IGListSectionController * _Nonnull)sectionController fromIndex:(NSInteger)fromIndex toIndex:(NSInteger)toIndex;
		[Abstract]
		[Export ("moveInSectionController:fromIndex:toIndex:")]
		void MoveInSectionController (IGListSectionController sectionController, nint fromIndex, nint toIndex);

		// @required -(void)reloadSectionController:(IGListSectionController * _Nonnull)sectionController;
		[Abstract]
		[Export ("reloadSectionController:")]
		void ReloadSectionController (IGListSectionController sectionController);

		// @required -(void)moveSectionControllerInteractive:(IGListSectionController * _Nonnull)sectionController fromIndex:(NSInteger)fromIndex toIndex:(NSInteger)toIndex __attribute__((availability(ios, introduced=9.0)));
		//[iOS (9,0)]
		[Abstract]
		[Export ("moveSectionControllerInteractive:fromIndex:toIndex:")]
		void MoveSectionControllerInteractive (IGListSectionController sectionController, nint fromIndex, nint toIndex);

		// @required -(void)moveInSectionControllerInteractive:(IGListSectionController * _Nonnull)sectionController fromIndex:(NSInteger)fromIndex toIndex:(NSInteger)toIndex __attribute__((availability(ios, introduced=9.0)));
		//[iOS (9,0)]
		[Abstract]
		[Export ("moveInSectionControllerInteractive:fromIndex:toIndex:")]
		void MoveInSectionControllerInteractive (IGListSectionController sectionController, nint fromIndex, nint toIndex);

		// @required -(void)revertInvalidInteractiveMoveFromIndexPath:(NSIndexPath * _Nonnull)sourceIndexPath toIndexPath:(NSIndexPath * _Nonnull)destinationIndexPath __attribute__((availability(ios, introduced=9.0)));
		//[iOS (9,0)]
		[Abstract]
		[Export ("revertInvalidInteractiveMoveFromIndexPath:toIndexPath:")]
		void RevertInvalidInteractiveMoveFromIndexPath (NSIndexPath sourceIndexPath, NSIndexPath destinationIndexPath);
	}

	// @protocol IGListBindable <NSObject>
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/[Protocol]
	[BaseType (typeof(NSObject))]
	interface IGListBindable
	{
		// @required -(void)bindViewModel:(id _Nonnull)viewModel;
		[Abstract]
		[Export ("bindViewModel:")]
		void BindViewModel (NSObject viewModel);
	}

	// @protocol IGListBindingSectionControllerDataSource <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface IGListBindingSectionControllerDataSource
	{
		// @required -(NSArray<id<IGListDiffable>> * _Nonnull)sectionController:(IGListBindingSectionController * _Nonnull)sectionController viewModelsForObject:(id _Nonnull)object;
		[Abstract]
		[Export ("sectionController:viewModelsForObject:")]
		IGListDiffable[] SectionControllerViewModelsForObject (IGListBindingSectionController sectionController, NSObject @object);

		// @required -(UICollectionViewCell<IGListBindable> * _Nonnull)sectionController:(IGListBindingSectionController * _Nonnull)sectionController cellForViewModel:(id _Nonnull)viewModel atIndex:(NSInteger)index;
		[Abstract]
		[Export ("sectionController:cellForViewModel:atIndex:")]
		IGListBindable CellForViewModel (IGListBindingSectionController sectionController, NSObject viewModel, nint index);

		// @required -(CGSize)sectionController:(IGListBindingSectionController * _Nonnull)sectionController sizeForViewModel:(id _Nonnull)viewModel atIndex:(NSInteger)index;
		[Abstract]
		[Export ("sectionController:sizeForViewModel:atIndex:")]
		CGSize SizeForViewModel (IGListBindingSectionController sectionController, NSObject viewModel, nint index);
	}

	// @protocol IGListBindingSectionControllerSelectionDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface IGListBindingSectionControllerSelectionDelegate
	{
		// @required -(void)sectionController:(IGListBindingSectionController * _Nonnull)sectionController didSelectItemAtIndex:(NSInteger)index viewModel:(id _Nonnull)viewModel;
		[Abstract]
		[Export ("sectionController:didSelectItemAtIndex:viewModel:")]
		void DidSelectItemAtIndex (IGListBindingSectionController sectionController, nint index, NSObject viewModel);

		// @required -(void)sectionController:(IGListBindingSectionController * _Nonnull)sectionController didDeselectItemAtIndex:(NSInteger)index viewModel:(id _Nonnull)viewModel;
		[Abstract]
		[Export ("sectionController:didDeselectItemAtIndex:viewModel:")]
		void DidDeselectItemAtIndex (IGListBindingSectionController sectionController, nint index, NSObject viewModel);

		// @required -(void)sectionController:(IGListBindingSectionController * _Nonnull)sectionController didHighlightItemAtIndex:(NSInteger)index viewModel:(id _Nonnull)viewModel;
		[Abstract]
		[Export ("sectionController:didHighlightItemAtIndex:viewModel:")]
		void DidHighlightItemAtIndex (IGListBindingSectionController sectionController, nint index, NSObject viewModel);

		// @required -(void)sectionController:(IGListBindingSectionController * _Nonnull)sectionController didUnhighlightItemAtIndex:(NSInteger)index viewModel:(id _Nonnull)viewModel;
		[Abstract]
		[Export ("sectionController:didUnhighlightItemAtIndex:viewModel:")]
		void DidUnhighlightItemAtIndex (IGListBindingSectionController sectionController, nint index, NSObject viewModel);
	}

	// @protocol IGListCollectionContext <NSObject>
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/[Protocol]
	[BaseType (typeof(NSObject))]
	interface IGListCollectionContext
	{
		// @required @property (readonly, nonatomic) CGSize containerSize;
		[Abstract]
		[Export ("containerSize")]
		CGSize ContainerSize { get; }

		// @required @property (readonly, nonatomic) UIEdgeInsets containerInset;
		[Abstract]
		[Export ("containerInset")]
		UIEdgeInsets ContainerInset { get; }

		// @required @property (readonly, nonatomic) UIEdgeInsets adjustedContainerInset;
		[Abstract]
		[Export ("adjustedContainerInset")]
		UIEdgeInsets AdjustedContainerInset { get; }

		// @required @property (readonly, nonatomic) CGSize insetContainerSize;
		[Abstract]
		[Export ("insetContainerSize")]
		CGSize InsetContainerSize { get; }

		// @required @property (readonly, nonatomic) CGPoint containerContentOffset;
		[Abstract]
		[Export ("containerContentOffset")]
		CGPoint ContainerContentOffset { get; }

		// @required @property (readonly, nonatomic) IGListCollectionScrollingTraits scrollingTraits;
		[Abstract]
		[Export ("scrollingTraits")]
		IGListCollectionScrollingTraits ScrollingTraits { get; }

		// @required @property (assign, nonatomic) int experiments;
		[Abstract]
		[Export ("experiments")]
		int Experiments { get; set; }

		// @required -(CGSize)containerSizeForSectionController:(IGListSectionController * _Nonnull)sectionController;
		[Abstract]
		[Export ("containerSizeForSectionController:")]
		CGSize ContainerSizeForSectionController (IGListSectionController sectionController);

		// @required -(NSInteger)indexForCell:(UICollectionViewCell * _Nonnull)cell sectionController:(IGListSectionController * _Nonnull)sectionController;
		[Abstract]
		[Export ("indexForCell:sectionController:")]
		nint IndexForCell (UICollectionViewCell cell, IGListSectionController sectionController);

		// @required -(__kindof UICollectionViewCell * _Nullable)cellForItemAtIndex:(NSInteger)index sectionController:(IGListSectionController * _Nonnull)sectionController;
		[Abstract]
		[Export ("cellForItemAtIndex:sectionController:")]
		[return: NullAllowed]
		UICollectionViewCell CellForItemAtIndex (nint index, IGListSectionController sectionController);

		// @required -(__kindof UICollectionReusableView * _Nullable)viewForSupplementaryElementOfKind:(NSString * _Nonnull)elementKind atIndex:(NSInteger)index sectionController:(IGListSectionController * _Nonnull)sectionController;
		[Abstract]
		[Export ("viewForSupplementaryElementOfKind:atIndex:sectionController:")]
		[return: NullAllowed]
		UICollectionReusableView ViewForSupplementaryElementOfKind (string elementKind, nint index, IGListSectionController sectionController);

		// @required -(NSArray<UICollectionViewCell *> * _Nonnull)fullyVisibleCellsForSectionController:(IGListSectionController * _Nonnull)sectionController;
		[Abstract]
		[Export ("fullyVisibleCellsForSectionController:")]
		UICollectionViewCell[] FullyVisibleCellsForSectionController (IGListSectionController sectionController);

		// @required -(NSArray<UICollectionViewCell *> * _Nonnull)visibleCellsForSectionController:(IGListSectionController * _Nonnull)sectionController;
		[Abstract]
		[Export ("visibleCellsForSectionController:")]
		UICollectionViewCell[] VisibleCellsForSectionController (IGListSectionController sectionController);

		// @required -(NSArray<NSIndexPath *> * _Nonnull)visibleIndexPathsForSectionController:(IGListSectionController * _Nonnull)sectionController;
		[Abstract]
		[Export ("visibleIndexPathsForSectionController:")]
		NSIndexPath[] VisibleIndexPathsForSectionController (IGListSectionController sectionController);

		// @required -(void)deselectItemAtIndex:(NSInteger)index sectionController:(IGListSectionController * _Nonnull)sectionController animated:(BOOL)animated;
		[Abstract]
		[Export ("deselectItemAtIndex:sectionController:animated:")]
		void DeselectItemAtIndex (nint index, IGListSectionController sectionController, bool animated);

		// @required -(void)selectItemAtIndex:(NSInteger)index sectionController:(IGListSectionController * _Nonnull)sectionController animated:(BOOL)animated scrollPosition:(UICollectionViewScrollPosition)scrollPosition;
		[Abstract]
		[Export ("selectItemAtIndex:sectionController:animated:scrollPosition:")]
		void SelectItemAtIndex (nint index, IGListSectionController sectionController, bool animated, UICollectionViewScrollPosition scrollPosition);

		// @required -(__kindof UICollectionViewCell * _Nonnull)dequeueReusableCellOfClass:(Class _Nonnull)cellClass withReuseIdentifier:(NSString * _Nullable)reuseIdentifier forSectionController:(IGListSectionController * _Nonnull)sectionController atIndex:(NSInteger)index;
		[Abstract]
		[Export ("dequeueReusableCellOfClass:withReuseIdentifier:forSectionController:atIndex:")]
		UICollectionViewCell DequeueReusableCellOfClass (Class cellClass, [NullAllowed] string reuseIdentifier, IGListSectionController sectionController, nint index);

		// @required -(__kindof UICollectionViewCell * _Nonnull)dequeueReusableCellOfClass:(Class _Nonnull)cellClass forSectionController:(IGListSectionController * _Nonnull)sectionController atIndex:(NSInteger)index;
		[Abstract]
		[Export ("dequeueReusableCellOfClass:forSectionController:atIndex:")]
		UICollectionViewCell DequeueReusableCellOfClass (Class cellClass, IGListSectionController sectionController, nint index);

		// @required -(__kindof UICollectionViewCell * _Nonnull)dequeueReusableCellWithNibName:(NSString * _Nonnull)nibName bundle:(NSBundle * _Nullable)bundle forSectionController:(IGListSectionController * _Nonnull)sectionController atIndex:(NSInteger)index;
		[Abstract]
		[Export ("dequeueReusableCellWithNibName:bundle:forSectionController:atIndex:")]
		UICollectionViewCell DequeueReusableCellWithNibName (string nibName, [NullAllowed] NSBundle bundle, IGListSectionController sectionController, nint index);

		// @required -(__kindof UICollectionViewCell * _Nonnull)dequeueReusableCellFromStoryboardWithIdentifier:(NSString * _Nonnull)identifier forSectionController:(IGListSectionController * _Nonnull)sectionController atIndex:(NSInteger)index;
		[Abstract]
		[Export ("dequeueReusableCellFromStoryboardWithIdentifier:forSectionController:atIndex:")]
		UICollectionViewCell DequeueReusableCellFromStoryboardWithIdentifier (string identifier, IGListSectionController sectionController, nint index);

		// @required -(__kindof UICollectionReusableView * _Nonnull)dequeueReusableSupplementaryViewOfKind:(NSString * _Nonnull)elementKind forSectionController:(IGListSectionController * _Nonnull)sectionController class:(Class _Nonnull)viewClass atIndex:(NSInteger)index;
		[Abstract]
		[Export ("dequeueReusableSupplementaryViewOfKind:forSectionController:class:atIndex:")]
		UICollectionReusableView DequeueReusableSupplementaryViewOfKind (string elementKind, IGListSectionController sectionController, Class viewClass, nint index);

		// @required -(__kindof UICollectionReusableView * _Nonnull)dequeueReusableSupplementaryViewFromStoryboardOfKind:(NSString * _Nonnull)elementKind withIdentifier:(NSString * _Nonnull)identifier forSectionController:(IGListSectionController * _Nonnull)sectionController atIndex:(NSInteger)index;
		[Abstract]
		[Export ("dequeueReusableSupplementaryViewFromStoryboardOfKind:withIdentifier:forSectionController:atIndex:")]
		UICollectionReusableView DequeueReusableSupplementaryViewFromStoryboardOfKind (string elementKind, string identifier, IGListSectionController sectionController, nint index);

		// @required -(__kindof UICollectionReusableView * _Nonnull)dequeueReusableSupplementaryViewOfKind:(NSString * _Nonnull)elementKind forSectionController:(IGListSectionController * _Nonnull)sectionController nibName:(NSString * _Nonnull)nibName bundle:(NSBundle * _Nullable)bundle atIndex:(NSInteger)index;
		[Abstract]
		[Export ("dequeueReusableSupplementaryViewOfKind:forSectionController:nibName:bundle:atIndex:")]
		UICollectionReusableView DequeueReusableSupplementaryViewOfKind (string elementKind, IGListSectionController sectionController, string nibName, [NullAllowed] NSBundle bundle, nint index);

		// @required -(void)invalidateLayoutForSectionController:(IGListSectionController * _Nonnull)sectionController completion:(void (^ _Nullable)(BOOL))completion;
		[Abstract]
		[Export ("invalidateLayoutForSectionController:completion:")]
		void InvalidateLayoutForSectionController (IGListSectionController sectionController, [NullAllowed] Action<bool> completion);

		// @required -(void)performBatchAnimated:(BOOL)animated updates:(void (^ _Nonnull)(id<IGListBatchContext> _Nonnull))updates completion:(void (^ _Nullable)(BOOL))completion;
		[Abstract]
		[Export ("performBatchAnimated:updates:completion:")]
		void PerformBatchAnimated (bool animated, Action<IGListBatchContext> updates, [NullAllowed] Action<bool> completion);

		// @required -(void)scrollToSectionController:(IGListSectionController * _Nonnull)sectionController atIndex:(NSInteger)index scrollPosition:(UICollectionViewScrollPosition)scrollPosition animated:(BOOL)animated;
		[Abstract]
		[Export ("scrollToSectionController:atIndex:scrollPosition:animated:")]
		void ScrollToSectionController (IGListSectionController sectionController, nint index, UICollectionViewScrollPosition scrollPosition, bool animated);
	}

	// @protocol IGListDisplayDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface IGListDisplayDelegate
	{
		// @required -(void)listAdapter:(IGListAdapter * _Nonnull)listAdapter willDisplaySectionController:(IGListSectionController * _Nonnull)sectionController;
		[Abstract]
		[Export ("listAdapter:willDisplaySectionController:")]
		void WillDisplaySectionController (IGListAdapter listAdapter, IGListSectionController sectionController);

		// @required -(void)listAdapter:(IGListAdapter * _Nonnull)listAdapter didEndDisplayingSectionController:(IGListSectionController * _Nonnull)sectionController;
		[Abstract]
		[Export ("listAdapter:didEndDisplayingSectionController:")]
		void DidEndDisplayingSectionController (IGListAdapter listAdapter, IGListSectionController sectionController);

		// @required -(void)listAdapter:(IGListAdapter * _Nonnull)listAdapter willDisplaySectionController:(IGListSectionController * _Nonnull)sectionController cell:(UICollectionViewCell * _Nonnull)cell atIndex:(NSInteger)index;
		[Abstract]
		[Export ("listAdapter:willDisplaySectionController:cell:atIndex:")]
		void WillDisplaySectionController (IGListAdapter listAdapter, IGListSectionController sectionController, UICollectionViewCell cell, nint index);

		// @required -(void)listAdapter:(IGListAdapter * _Nonnull)listAdapter didEndDisplayingSectionController:(IGListSectionController * _Nonnull)sectionController cell:(UICollectionViewCell * _Nonnull)cell atIndex:(NSInteger)index;
		[Abstract]
		[Export ("listAdapter:didEndDisplayingSectionController:cell:atIndex:")]
		void DidEndDisplayingSectionController (IGListAdapter listAdapter, IGListSectionController sectionController, UICollectionViewCell cell, nint index);
	}

	// @protocol IGListScrollDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface IGListScrollDelegate
	{
		// @required -(void)listAdapter:(IGListAdapter * _Nonnull)listAdapter didScrollSectionController:(IGListSectionController * _Nonnull)sectionController;
		[Abstract]
		[Export ("listAdapter:didScrollSectionController:")]
		void DidScrollSectionController (IGListAdapter listAdapter, IGListSectionController sectionController);

		// @required -(void)listAdapter:(IGListAdapter * _Nonnull)listAdapter willBeginDraggingSectionController:(IGListSectionController * _Nonnull)sectionController;
		[Abstract]
		[Export ("listAdapter:willBeginDraggingSectionController:")]
		void WillBeginDraggingSectionController (IGListAdapter listAdapter, IGListSectionController sectionController);

		// @required -(void)listAdapter:(IGListAdapter * _Nonnull)listAdapter didEndDraggingSectionController:(IGListSectionController * _Nonnull)sectionController willDecelerate:(BOOL)decelerate;
		[Abstract]
		[Export ("listAdapter:didEndDraggingSectionController:willDecelerate:")]
		void DidEndDraggingSectionController (IGListAdapter listAdapter, IGListSectionController sectionController, bool decelerate);

		// @optional -(void)listAdapter:(IGListAdapter * _Nonnull)listAdapter didEndDeceleratingSectionController:(IGListSectionController * _Nonnull)sectionController;
		[Export ("listAdapter:didEndDeceleratingSectionController:")]
		void DidEndDeceleratingSectionController (IGListAdapter listAdapter, IGListSectionController sectionController);
	}

	// @protocol IGListSupplementaryViewSource <NSObject>
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/[Protocol]
	[BaseType (typeof(NSObject))]
	interface IGListSupplementaryViewSource
	{
		// @required -(NSArray<NSString *> * _Nonnull)supportedElementKinds;
		[Abstract]
		[Export ("supportedElementKinds")]
		//[Verify (MethodToProperty)]
		string[] SupportedElementKinds { get; }

		// @required -(__kindof UICollectionReusableView * _Nonnull)viewForSupplementaryElementOfKind:(NSString * _Nonnull)elementKind atIndex:(NSInteger)index;
		[Abstract]
		[Export ("viewForSupplementaryElementOfKind:atIndex:")]
		UICollectionReusableView ViewForSupplementaryElementOfKind (string elementKind, nint index);

		// @required -(CGSize)sizeForSupplementaryViewOfKind:(NSString * _Nonnull)elementKind atIndex:(NSInteger)index;
		[Abstract]
		[Export ("sizeForSupplementaryViewOfKind:atIndex:")]
		CGSize SizeForSupplementaryViewOfKind (string elementKind, nint index);
	}

	// @protocol IGListTransitionDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface IGListTransitionDelegate
	{
		// @required -(UICollectionViewLayoutAttributes *)listAdapter:(IGListAdapter *)listAdapter customizedInitialLayoutAttributes:(UICollectionViewLayoutAttributes *)attributes sectionController:(IGListSectionController *)sectionController atIndex:(NSInteger)index;
		[Abstract]
		[Export ("listAdapter:customizedInitialLayoutAttributes:sectionController:atIndex:")]
		UICollectionViewLayoutAttributes CustomizedInitialLayoutAttributes (IGListAdapter listAdapter, UICollectionViewLayoutAttributes attributes, IGListSectionController sectionController, nint index);

		// @required -(UICollectionViewLayoutAttributes *)listAdapter:(IGListAdapter *)listAdapter customizedFinalLayoutAttributes:(UICollectionViewLayoutAttributes *)attributes sectionController:(IGListSectionController *)sectionController atIndex:(NSInteger)index;
		[Abstract]
		[Export ("listAdapter:customizedFinalLayoutAttributes:sectionController:atIndex:")]
		UICollectionViewLayoutAttributes CustomizedFinalLayoutAttributes (IGListAdapter listAdapter, UICollectionViewLayoutAttributes attributes, IGListSectionController sectionController, nint index);
	}

	// @protocol IGListWorkingRangeDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface IGListWorkingRangeDelegate
	{
		// @required -(void)listAdapter:(IGListAdapter * _Nonnull)listAdapter sectionControllerWillEnterWorkingRange:(IGListSectionController * _Nonnull)sectionController;
		[Abstract]
		[Export ("listAdapter:sectionControllerWillEnterWorkingRange:")]
		void SectionControllerWillEnterWorkingRange (IGListAdapter listAdapter, IGListSectionController sectionController);

		// @required -(void)listAdapter:(IGListAdapter * _Nonnull)listAdapter sectionControllerDidExitWorkingRange:(IGListSectionController * _Nonnull)sectionController;
		[Abstract]
		[Export ("listAdapter:sectionControllerDidExitWorkingRange:")]
		void SectionControllerDidExitWorkingRange (IGListAdapter listAdapter, IGListSectionController sectionController);
	}

	// @interface IGListSectionController : NSObject
	[BaseType (typeof(NSObject))]
	interface IGListSectionController
	{
		// -(NSInteger)numberOfItems;
		[Export ("numberOfItems")]
		//[Verify (MethodToProperty)]
		nint NumberOfItems { get; }

		// -(CGSize)sizeForItemAtIndex:(NSInteger)index;
		[Export ("sizeForItemAtIndex:")]
		CGSize SizeForItemAtIndex (nint index);

		// -(__kindof UICollectionViewCell * _Nonnull)cellForItemAtIndex:(NSInteger)index;
		[Export ("cellForItemAtIndex:")]
		UICollectionViewCell CellForItemAtIndex (nint index);

		// -(void)didUpdateToObject:(id _Nonnull)object;
		[Export ("didUpdateToObject:")]
		void DidUpdateToObject (NSObject @object);

		// -(BOOL)shouldSelectItemAtIndex:(NSInteger)index;
		[Export ("shouldSelectItemAtIndex:")]
		bool ShouldSelectItemAtIndex (nint index);

		// -(BOOL)shouldDeselectItemAtIndex:(NSInteger)index;
		[Export ("shouldDeselectItemAtIndex:")]
		bool ShouldDeselectItemAtIndex (nint index);

		// -(void)didSelectItemAtIndex:(NSInteger)index;
		[Export ("didSelectItemAtIndex:")]
		void DidSelectItemAtIndex (nint index);

		// -(void)didDeselectItemAtIndex:(NSInteger)index;
		[Export ("didDeselectItemAtIndex:")]
		void DidDeselectItemAtIndex (nint index);

		// -(void)didHighlightItemAtIndex:(NSInteger)index;
		[Export ("didHighlightItemAtIndex:")]
		void DidHighlightItemAtIndex (nint index);

		// -(void)didUnhighlightItemAtIndex:(NSInteger)index;
		[Export ("didUnhighlightItemAtIndex:")]
		void DidUnhighlightItemAtIndex (nint index);

		// -(BOOL)canMoveItemAtIndex:(NSInteger)index;
		[Export ("canMoveItemAtIndex:")]
		bool CanMoveItemAtIndex (nint index);

		// -(void)moveObjectFromIndex:(NSInteger)sourceIndex toIndex:(NSInteger)destinationIndex __attribute__((availability(ios, introduced=9.0)));
		//[iOS (9,0)]
		[Export ("moveObjectFromIndex:toIndex:")]
		void MoveObjectFromIndex (nint sourceIndex, nint destinationIndex);

		// @property (readonly, nonatomic, weak) UIViewController * _Nullable viewController;
		[NullAllowed, Export ("viewController", ArgumentSemantic.Weak)]
		UIViewController ViewController { get; }

		// @property (readonly, nonatomic, weak) id<IGListCollectionContext> _Null_unspecified collectionContext;
		[Export ("collectionContext", ArgumentSemantic.Weak)]
		IGListCollectionContext CollectionContext { get; }

		// @property (readonly, assign, nonatomic) NSInteger section;
		[Export ("section")]
		nint Section { get; }

		// @property (readonly, assign, nonatomic) BOOL isFirstSection;
		[Export ("isFirstSection")]
		bool IsFirstSection { get; }

		// @property (readonly, assign, nonatomic) BOOL isLastSection;
		[Export ("isLastSection")]
		bool IsLastSection { get; }

		// @property (assign, nonatomic) UIEdgeInsets inset;
		[Export ("inset", ArgumentSemantic.Assign)]
		UIEdgeInsets Inset { get; set; }

		// @property (assign, nonatomic) CGFloat minimumLineSpacing;
		[Export ("minimumLineSpacing")]
		nfloat MinimumLineSpacing { get; set; }

		// @property (assign, nonatomic) CGFloat minimumInteritemSpacing;
		[Export ("minimumInteritemSpacing")]
		nfloat MinimumInteritemSpacing { get; set; }

		// @property (nonatomic, weak) id<IGListSupplementaryViewSource> _Nullable supplementaryViewSource;
		[NullAllowed, Export ("supplementaryViewSource", ArgumentSemantic.Weak)]
		IGListSupplementaryViewSource SupplementaryViewSource { get; set; }

		[Wrap ("WeakDisplayDelegate")]
		[NullAllowed]
		IGListDisplayDelegate DisplayDelegate { get; set; }

		// @property (nonatomic, weak) id<IGListDisplayDelegate> _Nullable displayDelegate;
		[NullAllowed, Export ("displayDelegate", ArgumentSemantic.Weak)]
		NSObject WeakDisplayDelegate { get; set; }

		[Wrap ("WeakWorkingRangeDelegate")]
		[NullAllowed]
		IGListWorkingRangeDelegate WorkingRangeDelegate { get; set; }

		// @property (nonatomic, weak) id<IGListWorkingRangeDelegate> _Nullable workingRangeDelegate;
		[NullAllowed, Export ("workingRangeDelegate", ArgumentSemantic.Weak)]
		NSObject WeakWorkingRangeDelegate { get; set; }

		[Wrap ("WeakScrollDelegate")]
		[NullAllowed]
		IGListScrollDelegate ScrollDelegate { get; set; }

		// @property (nonatomic, weak) id<IGListScrollDelegate> _Nullable scrollDelegate;
		[NullAllowed, Export ("scrollDelegate", ArgumentSemantic.Weak)]
		NSObject WeakScrollDelegate { get; set; }

		[Wrap ("WeakTransitionDelegate")]
		[NullAllowed]
		IGListTransitionDelegate TransitionDelegate { get; set; }

		// @property (nonatomic, weak) id<IGListTransitionDelegate> _Nullable transitionDelegate;
		[NullAllowed, Export ("transitionDelegate", ArgumentSemantic.Weak)]
		NSObject WeakTransitionDelegate { get; set; }
	}

	// audit-objc-generics: @interface IGListBindingSectionController<__covariant ObjectType : id<IGListDiffable>> : IGListSectionController
	[BaseType (typeof(IGListSectionController))]
	interface IGListBindingSectionController
	{
		[Wrap ("WeakDataSource")]
		[NullAllowed]
		IGListBindingSectionControllerDataSource DataSource { get; set; }

		// @property (nonatomic, weak) id<IGListBindingSectionControllerDataSource> _Nullable dataSource;
		[NullAllowed, Export ("dataSource", ArgumentSemantic.Weak)]
		NSObject WeakDataSource { get; set; }

		[Wrap ("WeakSelectionDelegate")]
		[NullAllowed]
		IGListBindingSectionControllerSelectionDelegate SelectionDelegate { get; set; }

		// @property (nonatomic, weak) id<IGListBindingSectionControllerSelectionDelegate> _Nullable selectionDelegate;
		[NullAllowed, Export ("selectionDelegate", ArgumentSemantic.Weak)]
		NSObject WeakSelectionDelegate { get; set; }

		// @property (readonly, nonatomic, strong) ObjectType _Nullable object;
		[NullAllowed, Export ("object", ArgumentSemantic.Strong)]
		IGListDiffable Object { get; }

		// @property (readonly, copy, nonatomic) NSArray<id<IGListDiffable>> * _Nonnull viewModels;
		[Export ("viewModels", ArgumentSemantic.Copy)]
		IGListDiffable[] ViewModels { get; }

		// -(void)updateAnimated:(BOOL)animated completion:(void (^ _Nullable)(BOOL))completion;
		[Export ("updateAnimated:completion:")]
		void UpdateAnimated (bool animated, [NullAllowed] Action<bool> completion);

		// -(void)moveObjectFromIndex:(NSInteger)sourceIndex toIndex:(NSInteger)destinationIndex __attribute__((objc_requires_super));
		[Export ("moveObjectFromIndex:toIndex:")]
		[RequiresSuper]
		void MoveObjectFromIndex (nint sourceIndex, nint destinationIndex);
	}

	// @interface IGListCollectionView : UICollectionView
	[BaseType (typeof(UICollectionView))]
	interface IGListCollectionView
	{
		// -(instancetype _Nonnull)initWithFrame:(CGRect)frame listCollectionViewLayout:(UICollectionViewLayout<IGListCollectionViewLayoutCompatible> * _Nonnull)collectionViewLayout __attribute__((objc_designated_initializer));
		[Export ("initWithFrame:listCollectionViewLayout:")]
		[DesignatedInitializer]
		NativeHandle Constructor (CGRect frame, IGListCollectionViewLayoutCompatible collectionViewLayout);
	}

	// @protocol IGListCollectionViewDelegateLayout <UICollectionViewDelegateFlowLayout>
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/[Protocol]
	interface IGListCollectionViewDelegateLayout : IUICollectionViewDelegateFlowLayout
	{
		// @required -(UICollectionViewLayoutAttributes *)collectionView:(UICollectionView *)collectionView layout:(UICollectionViewLayout *)collectionViewLayout customizedInitialLayoutAttributes:(UICollectionViewLayoutAttributes *)attributes atIndexPath:(NSIndexPath *)indexPath;
		[Abstract]
		[Export ("collectionView:layout:customizedInitialLayoutAttributes:atIndexPath:")]
		UICollectionViewLayoutAttributes LayoutInitial (UICollectionView collectionView, UICollectionViewLayout collectionViewLayout, UICollectionViewLayoutAttributes attributes, NSIndexPath indexPath);

		// @required -(UICollectionViewLayoutAttributes *)collectionView:(UICollectionView *)collectionView layout:(UICollectionViewLayout *)collectionViewLayout customizedFinalLayoutAttributes:(UICollectionViewLayoutAttributes *)attributes atIndexPath:(NSIndexPath *)indexPath;
		[Abstract]
		[Export ("collectionView:layout:customizedFinalLayoutAttributes:atIndexPath:")]
		UICollectionViewLayoutAttributes LayoutFinal (UICollectionView collectionView, UICollectionViewLayout collectionViewLayout, UICollectionViewLayoutAttributes attributes, NSIndexPath indexPath);
	}

	// @protocol IGListCollectionViewLayoutCompatible <NSObject>
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/[Protocol]
	[BaseType (typeof(NSObject))]
	interface IGListCollectionViewLayoutCompatible
	{
		// @required -(void)didModifySection:(NSInteger)modifiedSection;
		[Abstract]
		[Export ("didModifySection:")]
		void DidModifySection (nint modifiedSection);
	}

	// @interface IGListCollectionViewLayout : UICollectionViewLayout <IGListCollectionViewLayoutCompatible>
	[BaseType (typeof(UICollectionViewLayout))]
	[DisableDefaultCtor]
	interface IGListCollectionViewLayout : IGListCollectionViewLayoutCompatible
	{
		// @property (readonly, nonatomic) UICollectionViewScrollDirection scrollDirection;
		[Export ("scrollDirection")]
		UICollectionViewScrollDirection ScrollDirection { get; }

		// @property (assign, nonatomic) CGFloat stickyHeaderYOffset;
		[Export ("stickyHeaderYOffset")]
		nfloat StickyHeaderYOffset { get; set; }

		// @property (assign, nonatomic) BOOL showHeaderWhenEmpty;
		[Export ("showHeaderWhenEmpty")]
		bool ShowHeaderWhenEmpty { get; set; }

		// -(instancetype _Nonnull)initWithStickyHeaders:(BOOL)stickyHeaders scrollDirection:(UICollectionViewScrollDirection)scrollDirection topContentInset:(CGFloat)topContentInset stretchToEdge:(BOOL)stretchToEdge __attribute__((objc_designated_initializer));
		[Export ("initWithStickyHeaders:scrollDirection:topContentInset:stretchToEdge:")]
		[DesignatedInitializer]
		NativeHandle Constructor (bool stickyHeaders, UICollectionViewScrollDirection scrollDirection, nfloat topContentInset, bool stretchToEdge);

		// -(instancetype _Nonnull)initWithStickyHeaders:(BOOL)stickyHeaders topContentInset:(CGFloat)topContentInset stretchToEdge:(BOOL)stretchToEdge;
		[Export ("initWithStickyHeaders:topContentInset:stretchToEdge:")]
		NativeHandle Constructor (bool stickyHeaders, nfloat topContentInset, bool stretchToEdge);
	}

	// audit-objc-generics: @interface IGListGenericSectionController<__covariant ObjectType> : IGListSectionController
	[BaseType (typeof(IGListSectionController))]
	interface IGListGenericSectionController
	{
		// @property (readonly, nonatomic, strong) ObjectType _Null_unspecified object;
		[Export ("object", ArgumentSemantic.Strong)]
		NSObject Object { get; }

		// -(void)didUpdateToObject:(ObjectType _Nonnull)object __attribute__((objc_requires_super));
		[Export ("didUpdateToObject:")]
		[RequiresSuper]
		void DidUpdateToObject (NSObject @object);
	}

	// [Static]
	// //[Verify (ConstantsInterfaceAssociation)]
	// partial interface Constants
	// {
	// 	// extern double IGListKitVersionNumber;
	// 	[Field ("IGListKitVersionNumber", "__Internal")]
	// 	double IGListKitVersionNumber { get; }

	// 	// extern const unsigned char[] IGListKitVersionString;
	// 	[Field ("IGListKitVersionString", "__Internal")]
	// 	byte[] IGListKitVersionString { get; }
	// }

	// @interface IGListReloadDataUpdater : NSObject <IGListUpdatingDelegate>
	[BaseType (typeof(NSObject))]
	interface IGListReloadDataUpdater : IGListUpdatingDelegate
	{
	}

	// typedef void (^IGListSingleSectionCellConfigureBlock)(id _Nonnull, __kindof UICollectionViewCell * _Nonnull);
	delegate void IGListSingleSectionCellConfigureBlock (NSObject arg0, UICollectionViewCell arg1);

	// typedef CGSize (^IGListSingleSectionCellSizeBlock)(id _Nonnull, id<IGListCollectionContext> _Nullable);
	delegate CGSize IGListSingleSectionCellSizeBlock (NSObject arg0, [NullAllowed] IGListCollectionContext arg1);

	// @protocol IGListSingleSectionControllerDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface IGListSingleSectionControllerDelegate
	{
		// @required -(void)didSelectSectionController:(IGListSingleSectionController * _Nonnull)sectionController withObject:(id _Nonnull)object;
		[Abstract]
		[Export ("didSelectSectionController:withObject:")]
		void DidSelectSectionController (IGListSingleSectionController sectionController, NSObject @object);

		// @optional -(void)didDeselectSectionController:(IGListSingleSectionController * _Nonnull)sectionController withObject:(id _Nonnull)object;
		[Export ("didDeselectSectionController:withObject:")]
		void DidDeselectSectionController (IGListSingleSectionController sectionController, NSObject @object);
	}

	// @interface IGListSingleSectionController : IGListSectionController
	[BaseType (typeof(IGListSectionController))]
	[DisableDefaultCtor]
	interface IGListSingleSectionController
	{
		// -(instancetype _Nonnull)initWithCellClass:(Class _Nonnull)cellClass configureBlock:(IGListSingleSectionCellConfigureBlock _Nonnull)configureBlock sizeBlock:(IGListSingleSectionCellSizeBlock _Nonnull)sizeBlock;
		[Export ("initWithCellClass:configureBlock:sizeBlock:")]
		NativeHandle Constructor (Class cellClass, IGListSingleSectionCellConfigureBlock configureBlock, IGListSingleSectionCellSizeBlock sizeBlock);

		// -(instancetype _Nonnull)initWithNibName:(NSString * _Nonnull)nibName bundle:(NSBundle * _Nullable)bundle configureBlock:(IGListSingleSectionCellConfigureBlock _Nonnull)configureBlock sizeBlock:(IGListSingleSectionCellSizeBlock _Nonnull)sizeBlock;
		[Export ("initWithNibName:bundle:configureBlock:sizeBlock:")]
		NativeHandle Constructor (string nibName, [NullAllowed] NSBundle bundle, IGListSingleSectionCellConfigureBlock configureBlock, IGListSingleSectionCellSizeBlock sizeBlock);

		// -(instancetype _Nonnull)initWithStoryboardCellIdentifier:(NSString * _Nonnull)identifier configureBlock:(IGListSingleSectionCellConfigureBlock _Nonnull)configureBlock sizeBlock:(IGListSingleSectionCellSizeBlock _Nonnull)sizeBlock;
		[Export ("initWithStoryboardCellIdentifier:configureBlock:sizeBlock:")]
		NativeHandle Constructor (string identifier, IGListSingleSectionCellConfigureBlock configureBlock, IGListSingleSectionCellSizeBlock sizeBlock);

		[Wrap ("WeakSelectionDelegate")]
		[NullAllowed]
		IGListSingleSectionControllerDelegate SelectionDelegate { get; set; }

		// @property (nonatomic, weak) id<IGListSingleSectionControllerDelegate> _Nullable selectionDelegate;
		[NullAllowed, Export ("selectionDelegate", ArgumentSemantic.Weak)]
		NSObject WeakSelectionDelegate { get; set; }
	}

	// @interface IGListTransitionData : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface IGListTransitionData
	{
		// -(instancetype _Nonnull)initFromObjects:(NSArray * _Nonnull)fromObjects toObjects:(NSArray * _Nonnull)toObjects toSectionControllers:(NSArray<IGListSectionController *> * _Nonnull)toSectionControllers __attribute__((objc_designated_initializer));
		[Export ("initFromObjects:toObjects:toSectionControllers:")]
		[DesignatedInitializer]
		//[Verify (StronglyTypedNSArray), Verify (StronglyTypedNSArray)]
		NativeHandle Constructor (NSObject[] fromObjects, NSObject[] toObjects, IGListSectionController[] toSectionControllers);

		// @property (readonly, copy, nonatomic) NSArray * _Nonnull fromObjects;
		[Export ("fromObjects", ArgumentSemantic.Copy)]
		//[Verify (StronglyTypedNSArray)]
		NSObject[] FromObjects { get; }

		// @property (readonly, copy, nonatomic) NSArray * _Nonnull toObjects;
		[Export ("toObjects", ArgumentSemantic.Copy)]
		//[Verify (StronglyTypedNSArray)]
		NSObject[] ToObjects { get; }

		// @property (readonly, copy, nonatomic) NSArray<IGListSectionController *> * _Nonnull toSectionControllers;
		[Export ("toSectionControllers", ArgumentSemantic.Copy)]
		IGListSectionController[] ToSectionControllers { get; }
	}

	// @interface IGListMoveIndex : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface IGListMoveIndex : INativeObject
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
*/
	// @protocol IGListDiffable
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface IGListDiffable
    {
        // @required -(id<NSObject> _Nonnull)diffIdentifier;
        [Abstract]
        [Export("diffIdentifier")]
        //[Verify(MethodToProperty)]
        NSObject DiffIdentifier { get; }

        // @required -(BOOL)isEqualToDiffableObject:(id<IGListDiffable> _Nullable)object;
        [Abstract]
        [Export("isEqualToDiffableObject:")]
        bool IsEqualToDiffableObject([NullAllowed] IGListDiffable @object);
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
		//[Verify (MethodToProperty)]
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
		//[Verify (MethodToProperty)]
		IGListIndexSetResult ResultForBatchUpdates { get; }
	}

	// [Static]
	// //[Verify (ConstantsInterfaceAssociation)]
	// partial interface Constants
	// {
	// 	// extern double IGListKitVersionNumber;
	// 	[Field ("IGListKitVersionNumber", "__Internal")]
	// 	double IGListKitVersionNumber { get; }

	// 	// extern const unsigned char[] IGListKitVersionString;
	// 	[Field ("IGListKitVersionString", "__Internal")]
	// 	byte[] IGListKitVersionString { get; }
	// }

	// @interface IGListDiffable (NSNumber) <IGListDiffable>
	//[Category]
	// [BaseType (typeof(NSNumber))]
	// interface NSNumber_IGListDiffable : IGListDiffable
	// {
	// }

	// // @interface IGListDiffable (NSString) <IGListDiffable>
	// //[Category]
	// [BaseType (typeof(NSString))]
	// interface NSString_IGListDiffable : IGListDiffable
	// {
	// }
}
