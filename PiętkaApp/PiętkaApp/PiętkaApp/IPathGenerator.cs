using System;
using System.Collections.Generic;
using System.Text;
using PiętkaApp;

namespace PiętkaApp{
    public interface IPathGenerator{
        String GetPath(String pathPart);
    }
}
