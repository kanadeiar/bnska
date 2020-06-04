using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bnska1
{
    [Serializable]
    static class PathsToFiles
    {
        private static string filename = "paths.xml";
        public static List<string> PathsToSCV { get; set; }
        public static List<string> PathsToXLSX { get; set; }
        static PathsToFiles()
        {

        }
        static void SaveDataToXML()
        {

        }
    }
}
