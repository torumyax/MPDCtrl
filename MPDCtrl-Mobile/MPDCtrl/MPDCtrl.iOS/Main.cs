﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using Foundation;
using UIKit;

namespace MPDCtrl.iOS
{
    public class Application
    {
        // This is the main entry point of the application.
        static void Main(string[] args)
        {
            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            try
            {
                UIApplication.Main(args, null, "AppDelegate");
            }
            catch (Exception e)
            {
                Debug.WriteLine("exception at Main: " + e.Message + ", " + e.InnerException.Message);
            }
        }
    }
}
