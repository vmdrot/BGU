using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace BGU.DRPL.DRClientAutomationLib
{
    public class Tools
    {
        public static T ReadXML<T>(string fromFile)
        {
            using (FileStream fs = new FileStream(fromFile, FileMode.Open))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                object o = serializer.Deserialize(fs);
                return (T)o;
            }
        }

        public static void WriteXML<T>(T obj, string saveAs)
        {
            using (FileStream fs = File.Create(saveAs))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(fs, obj);
            }
        }

    }
}
