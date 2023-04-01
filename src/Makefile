XBUILD=/Applications/Xcode_14.2.0.app/Contents/Developer/usr/bin/xcodebuild
ROOT=$(PWD)
PROJECT_ROOT=$(ROOT)/../external/IGListKit
PROJECT_IOS=$(PROJECT_ROOT)/IGListKit.xcworkspace
BUILD_ROOT=$(PROJECT_ROOT)/build
PROJECTNAME=IGListKit
FRAMEWORK_PATH=Products/Library/Frameworks/IGListKit.framework
DIFF_FRAMEWORK_PATH=Products/Library/Frameworks/IGListDiffKit.framework
FRAMEWORKS=$(ROOT)/Frameworks
TARGET_IOS="IGListKit"
TARGET_TVOS="IGListKit-tvOS"
TARGET_MACOS="IGListKit-macOS"
IOS_SDK=iphoneos16.2
TVOS_SDK=appletvos16.1
MACOS_SDK=macosx13.1
IOS_BINDING_OUTPUT=$(ROOT)/../ios-bindings
IOS_DIFF_BINDING_OUTPUT=$(ROOT)/../ios-bindings-diff
TVOS_BINDING_OUTPUT=$(ROOT)/../tvos-bindings
TVOS_DIFF_BINDING_OUTPUT=$(ROOT)/../tvos-bindings-diff
MACOS_BINDING_OUTPUT=$(ROOT)/../macos-bindings
MACOS_DIFF_BINDING_OUTPUT=$(ROOT)/../macos-bindings-diff
HEADERS=$(FRAMEWORKS)/IGListKit.xcframework/ios-arm64/IGListKit.framework/Headers
DIFFHEADERS=$(FRAMEWORKS)/IGListDiffKit.xcframework/ios-arm64/IGListDiffKit.framework/Headers
TV_HEADERS=$(FRAMEWORKS)/IGListKit.xcframework/tvos-arm64/IGListKit.framework/Headers
TV_DIFFHEADERS=$(FRAMEWORKS)/IGListDiffKit.xcframework/tvos-arm64/IGListDiffKit.framework/Headers
MACOS_HEADERS=$(FRAMEWORKS)/IGListKit.xcframework/macos-arm64_x86_64/IGListKit.framework/Headers
MACOS_DIFFHEADERS=$(FRAMEWORKS)/IGListDiffKit.xcframework/macos-arm64_x86_64/IGListDiffKit.framework/Headers

build: iossimulator iosdevice maccatalyst tvossimulator tvosdevice mac xcframework

iossimulator:
	$(XBUILD) archive ONLY_ACTIVE_ARCH=NO -workspace $(PROJECT_IOS) -scheme $(TARGET_IOS) -configuration Debug -destination "generic/platform=iOS Simulator" -archivePath $(BUILD_ROOT)/simulator.xcarchive -sdk iphonesimulator SKIP_INSTALL=NO BUILD_LIBRARY_FOR_DISTRIBUTION=YES
	
iosdevice:
	$(XBUILD) archive ONLY_ACTIVE_ARCH=NO -workspace $(PROJECT_IOS) -scheme $(TARGET_IOS) -configuration Debug -destination "generic/platform=iOS" -archivePath $(BUILD_ROOT)/iOS.xcarchive -sdk iphoneos SKIP_INSTALL=NO BUILD_LIBRARY_FOR_DISTRIBUTION=YES

maccatalyst:
	$(XBUILD) archive ONLY_ACTIVE_ARCH=NO -workspace $(PROJECT_IOS) -scheme $(TARGET_IOS) -destination "generic/platform=macOS,variant=Mac Catalyst,name=Any Mac" -archivePath $(BUILD_ROOT)/catalyst.xcarchive SKIP_INSTALL=NO BUILD_LIBRARY_FOR_DISTRIBUTION=YES

tvossimulator:
	$(XBUILD) archive ONLY_ACTIVE_ARCH=NO -workspace $(PROJECT_IOS) -scheme $(TARGET_TVOS) -archivePath $(BUILD_ROOT)/tvsimulator.xcarchive -sdk appletvsimulator SKIP_INSTALL=NO BUILD_LIBRARY_FOR_DISTRIBUTION=YES

tvosdevice:
	$(XBUILD) archive ONLY_ACTIVE_ARCH=NO -workspace $(PROJECT_IOS) -scheme $(TARGET_TVOS) -archivePath $(BUILD_ROOT)/tvos.xcarchive -sdk appletvos SKIP_INSTALL=NO BUILD_LIBRARY_FOR_DISTRIBUTION=YES

mac:
	$(XBUILD) archive ONLY_ACTIVE_ARCH=NO -workspace $(PROJECT_IOS) -scheme $(TARGET_MACOS) -destination "generic/platform=macOS,name=Any Mac" -archivePath $(BUILD_ROOT)/mac.xcarchive SKIP_INSTALL=NO BUILD_LIBRARY_FOR_DISTRIBUTION=YES

xcframework:
	rm -rf $(BUILD_ROOT)/IGListKit.xcframework
	$(XBUILD) -create-xcframework -framework $(BUILD_ROOT)/mac.xcarchive/$(FRAMEWORK_PATH) -framework $(BUILD_ROOT)/simulator.xcarchive/$(FRAMEWORK_PATH) -framework $(BUILD_ROOT)/tvsimulator.xcarchive/$(FRAMEWORK_PATH) -framework $(BUILD_ROOT)/tvos.xcarchive/$(FRAMEWORK_PATH) -framework $(BUILD_ROOT)/iOS.xcarchive/$(FRAMEWORK_PATH) -framework $(BUILD_ROOT)/catalyst.xcarchive/$(FRAMEWORK_PATH) -output $(BUILD_ROOT)/IGListKit.xcframework
	$(XBUILD) -create-xcframework -framework $(BUILD_ROOT)/mac.xcarchive/$(DIFF_FRAMEWORK_PATH) -framework $(BUILD_ROOT)/simulator.xcarchive/$(DIFF_FRAMEWORK_PATH) -framework $(BUILD_ROOT)/tvsimulator.xcarchive/$(DIFF_FRAMEWORK_PATH) -framework $(BUILD_ROOT)/tvos.xcarchive/$(DIFF_FRAMEWORK_PATH) -framework $(BUILD_ROOT)/iOS.xcarchive/$(DIFF_FRAMEWORK_PATH) -framework $(BUILD_ROOT)/catalyst.xcarchive/$(DIFF_FRAMEWORK_PATH) -output $(BUILD_ROOT)/IGListDiffKit.xcframework
	rm -rf $(FRAMEWORKS)
	mkdir -p $(FRAMEWORKS)
	cp -R $(BUILD_ROOT)/ $(FRAMEWORKS)

pack: 
	dotnet pack $(ROOT)/Drastic.IGListKit/Drastic.IGListKit.csproj --configuration Release --output $(ROOT)/../nuget

ios_sharpie:
	sharpie bind --sdk=$(IOS_SDK) --output="$(IOS_BINDING_OUTPUT)" --namespace="IGListKit" --scope="$(HEADERS)" $(HEADERS)/*.h

ios_sharpie_diff:
	sharpie bind --sdk=$(IOS_SDK) --output="$(IOS_DIFF_BINDING_OUTPUT)" --namespace="IGListDiffKit" --scope="$(DIFFHEADERS)" $(DIFFHEADERS)/*.h

tvos_sharpie:
	sharpie bind --sdk=$(TVOS_SDK) --output="$(TVOS_BINDING_OUTPUT)" --namespace="IGListKit" --scope="$(TV_HEADERS)" $(TV_HEADERS)/*.h

tvos_sharpie_diff:
	sharpie bind --sdk=$(TVOS_SDK) --output="$(TVOS_DIFF_BINDING_OUTPUT)" --namespace="IGListDiffKit" --scope="$(TV_DIFFHEADERS)" $(TV_DIFFHEADERS)/*.h

macos_sharpie:
	sharpie bind --sdk=$(MACOS_SDK) --output="$(MACOS_BINDING_OUTPUT)" --namespace="IGListKit" --scope="$(MACOS_HEADERS)" $(MACOS_HEADERS)/*.h

macos_sharpie_diff:
	sharpie bind --sdk=$(TVOS_SDK) --output="$(MACOS_DIFF_BINDING_OUTPUT)" --namespace="IGListDiffKit" --scope="$(MACOS_DIFFHEADERS)" $(MACOS_DIFFHEADERS)/*.h