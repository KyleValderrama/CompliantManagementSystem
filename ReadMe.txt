Software Requirements
------------------------------------------
> Visual Studio Community 2017
	> Xamarin Framework
	> Mobile Develpment with JavaScript
------------------------------------------

Visual Studio NuGet Packages
------------------------------------------
> Microsoft.Net.Http
> Newtosoft.Json
> Refit [optional]
> Xam.Plugin.Connectivity
> Xamarin.Android.Support.Design

Other Requirements
-----------------------------------------
> Android Device Manager (Emulator)
	> Click New Device > Select OS: Lollipop 5.1 > Create
> Android SDK Manager
	> Platforms 
		> Check: Android 8.1-Oreo > Apply Changes
		> Check: Android 5.1-Lollipop > Apply Changes
	> Tools
		> Android SDK Tools
		> Android SDK Platform-Tools
		> Android SDK Build Tools
			> Android SDK Build-Tools 27.0.3
			> Android SDK Build-Tools 25.0.3
		> Android Emulator
		> Extras
			> SDK Patch Applier v4
> Android-sdk
> Android-ndk-r18
> JDK1.8.0_181


How to Archive
-----------------------------------
Right Click: AppName > Android Options > Make sure "Use Shared Runtime" Checkbox is UNCHECKED.
Right Click: AppName > Build
Right Click: AppName > Archive...> Select Latest Archive > Distribute > Ad Hoc > Select Signing Identity
> if theres no existing identity, Click " + " Button > Fill Up > Select Signing Identity > Save As > Select File Destination Folder