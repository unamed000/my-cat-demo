﻿using System;
using System.Collections.Generic;
using System.Linq;
using FFImageLoading.Forms;
using Foundation;
using MyOrg.Storage.Secure;
using Newtonsoft.Json;
using Sentry;
using UIKit;

namespace MyCats.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            SentryXamarin.Init(ops => {
                ops.Debug = true;
                ops.Dsn = "https://02e9625a9d8d45218d146935562680b6@o781646.ingest.sentry.io/5798276";
                ops.AddXamarinFormsIntegration();
            });
            
            
            MyOrg.Storage.Secure.Startup.LinkMePlease();
            MyOrg.Api.Cats.Client.Startup.LinkMePlease();
            MyOrg.Api.Core.Startup.LinkMePlease();
            MyOrg.Forms.Core.iOS.Startup.LinkMePlease();
            
            FFImageLoading.Forms.Platform.CachedImageRenderer.Init();

            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
