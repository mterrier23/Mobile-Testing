using System;
using Xamarin.UITest;

namespace FirstUITest
{
    static class AppManager
    {
        //const string ApkPath = "C:/Users/Mailys Surface Pro/Documents/Project/PetInsights/PetInsights_all/PetInsights_all.Android/bin/Release/com.companyname.petinsights_all.apk";
        const string ApkPath = "C:/Users/Mailys Surface Pro/AppData/Local/Xamarin/Mono for Android/Archives/2021-04-13/PetInsights_all.Android 4-13-21 1.46 PM.apkarchive/com.companyname.petinsights_all.apk";
        
        //const string AppPath = "../../../Binaries/TaskyiOS.app";
        //const string IpaBundleId = "com.xamarin.samples.taskytouch";

        static IApp app;
        public static IApp App
        {
            get
            {
                if (app == null)
                    throw new NullReferenceException("'AppManager.App' not set. Call 'AppManager.StartApp()' before trying to access it.");
                return app;
            }
        }

        static Platform? platform;
        public static Platform Platform
        {
            get
            {
                if (platform == null)
                    throw new NullReferenceException("'AppManager.Platform' not set.");
                return platform.Value;
            }

            set
            {
                platform = value;
            }
        }

        public static void StartApp()
        {
            if (Platform == Platform.Android)
            {
                app = ConfigureApp
                    .Android
                    .ApkFile(ApkPath)
                    .StartApp();
               
            }

            /*if (Platform == Platform.iOS)
            {
                app = ConfigureApp
                    .iOS
                    // Used to run a .app file on an ios simulator:
                    .AppBundle(AppPath)
                    // Used to run a .ipa file on a physical ios device:
                    //.InstalledApp(ipaBundleId)
                    .StartApp();
            }*/
        }
    }
}