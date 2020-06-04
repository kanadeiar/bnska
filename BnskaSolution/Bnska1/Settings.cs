using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bnska1
{
    [Serializable]
    class Settings
    {
        private static string filename = "paths.xml";
        public static bool[] CheckPump { get; set; } = new bool[6];
        public string Path = "1";
        public static string[] PathsToSCV { get; set; } = new string[6];
        public static string[] PathsToXLSX { get; set; } = new string[6];
        static Settings()
        {

        }
        public static void SaveDataToXML()
        {

        }
    }
}
