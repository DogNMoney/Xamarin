using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using PiętkaApp;
using PiętkaApp.Droid;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace PiętkaApp.Droid {

    class PathGeneratorAndroid : IPathGenerator{

        public String GetPath(String pathPart) {
            String stringPath = String.Empty;

            stringPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), pathPart);

            return stringPath;
        }
    }
}