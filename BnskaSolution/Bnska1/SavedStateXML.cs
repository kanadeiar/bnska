using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bnska1
{
    [Serializable]
    public class SavedStateXML
    {
        public class MainWindowXML
        {
            [XmlAttribute]
            public bool checkPump1;
            [XmlAttribute]
            public bool checkPump2;
            [XmlAttribute]
            public bool checkPump3;
            [XmlAttribute]
            public bool checkPump4;
            [XmlAttribute]
            public bool checkPump5;
            [XmlAttribute]
            public bool checkPump6;
            [XmlAttribute]
            public string textPathCSV1;
            [XmlAttribute]
            public string textPathCSV2;
            [XmlAttribute]
            public string textPathCSV3;
            [XmlAttribute]
            public string textPathCSV4;
            [XmlAttribute]
            public string textPathCSV5;
            [XmlAttribute]
            public string textPathCSV6;
            [XmlAttribute]
            public string textPathXSLX1;
            [XmlAttribute]
            public string textPathXSLX2;
            [XmlAttribute]
            public string textPathXSLX3;
            [XmlAttribute]
            public string textPathXSLX4;
            [XmlAttribute]
            public string textPathXSLX5;
            [XmlAttribute]
            public string textPathXSLX6;
        }
        public MainWindowXML MainWindow;
        public static void SaveStateToXML(SavedStateXML obj, string fileName)
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(SavedStateXML));
            using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                xmlFormat.Serialize(fs, obj);
            }
        }
        public static SavedStateXML LoadFromXMLToState(string filename)
        {
            SavedStateXML state = new SavedStateXML();
            XmlSerializer xmlFormat = new XmlSerializer(typeof(SavedStateXML));
            using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                state = xmlFormat.Deserialize(fs) as SavedStateXML;
            }
            return state;
        }
    }

}
