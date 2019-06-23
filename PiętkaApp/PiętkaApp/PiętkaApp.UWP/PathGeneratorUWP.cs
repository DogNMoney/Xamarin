using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using PiętkaApp;
using PiętkaApp.UWP;
using Windows.Storage;

[assembly: Xamarin.Forms.Dependency(typeof(PiętkaApp.UWP.PathGeneratorUWP))]
namespace PiętkaApp.UWP{

    class PathGeneratorUWP : IPathGenerator{
        public String GetPath(String pathPart) {
            String pathGen = String.Empty;

            pathGen = Path.Combine(ApplicationData.Current.LocalFolder.Path, pathPart);

            return pathGen;
        }
    }
}
