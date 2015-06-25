using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Xml.Serialization;
using System.IO;
using System.Reflection;
using System.Data;

namespace BGU.DRPL.SignificantOwnership.Utility
{
    public class Tools
    {
        public static string GetTypeClassDescription(Type typ)
        {
            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])typ.GetCustomAttributes(
                typeof(DescriptionAttribute),
                false);

            if (attributes != null &&
                attributes.Length > 0)
                return attributes[0].Description;
            else
                return string.Empty;
        }
        public static string GetObjectClassDescription(object classInstance)
        {
            return GetTypeClassDescription(classInstance.GetType());

        }

        public static string GetPropDescription(PropertyDescriptor prop)
        {
            
            foreach (Attribute attr in prop.Attributes)
            {
                if (attr is DescriptionAttribute)
                    return ((DescriptionAttribute)attr).Description;
            }
            return string.Empty;
        }

        public static string GetPropCategory(PropertyDescriptor prop)
        {

            foreach (Attribute attr in prop.Attributes)
            {
                if (attr is CategoryAttribute)
                    return ((CategoryAttribute)attr).Category;
            }
            return string.Empty;
        }

        public static string GetPropDisplayName(PropertyDescriptor prop)
        {
            foreach (Attribute attr in prop.Attributes)
            {
                if (attr is DisplayNameAttribute)
                    return ((DisplayNameAttribute)attr).DisplayName;
            }
            return string.Empty;
        }

        //public static string GetPropDescription(PropertyInfo prop)
        //{
        //    foreach (Attribute attr in prop.Attributes)
        //    {
        //        if (attr is DescriptionAttribute)
        //            return ((DescriptionAttribute)attr).Description;
        //    }
        //    return string.Empty;
        //}


        //public static string GetPropDisplayName(PropertyInfo prop)
        //{
        //    foreach (Attribute attr in prop.Attributes)
        //    {
        //        if (attr is DisplayNameAttribute)
        //            return ((DisplayNameAttribute)attr).DisplayName;
        //    }
        //    return string.Empty;
        //}

        public static void WriteXML<T>(T obj, string saveAs)
        {
            using (FileStream fs = File.Create(saveAs))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(fs, obj);
            }
        }

        public static T ReadXML<T>(string fromFile)
        {
            using (FileStream fs = new FileStream(fromFile, FileMode.Open))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                object o = serializer.Deserialize(fs);
                return (T)o;
            }
        }

        public static void WriteXML(object obj, string saveAs)
        {
            using (FileStream fs = File.Create(saveAs))
            {
                XmlSerializer serializer = new XmlSerializer(obj.GetType());
                serializer.Serialize(fs, obj);
            }
        }

        public static object ReadXML(string fromFile, Type targetType)
        {
            using (FileStream fs = new FileStream(fromFile, FileMode.Open))
            {
                XmlSerializer serializer = new XmlSerializer(targetType);
                object o = serializer.Deserialize(fs);
                return o;
            }
        }



        public static bool DataTableToCSV(DataTable dtSource, string saveAsPath, bool includeHeader)
        {

            using (StreamWriter sw = new StreamWriter(saveAsPath, false,Encoding.Unicode))
            {
                return DataTableToCSV(dtSource, sw, includeHeader);
            }
        }
        public static bool DataTableToCSV(DataTable dtSource, StreamWriter writer, bool includeHeader)
        {
            if (dtSource == null || writer == null) return false;

            if (includeHeader)
            {
                //string[] columnNames = dtSource.Columns.Cast<DataColumn>().Select(column => "\"" + column.ColumnName.Replace("\"", "\"\"") + "\"").ToArray<string>();
                string[] columnNames = dtSource.Columns.Cast<DataColumn>().Select(column => column.ColumnName).ToArray<string>();
                writer.WriteLine(String.Join("\t", columnNames));
                writer.Flush();
            }

            foreach (DataRow row in dtSource.Rows)
            {
                //string[] fields = row.ItemArray.Select(field => "\"" + field.ToString().Replace("\"", "\"\"") + "\"").ToArray<string>();
                string[] fields = row.ItemArray.Select(field => field.ToString()).ToArray<string>();
                writer.WriteLine(String.Join("\t", fields));
                writer.Flush();
            }

            return true;
        }
    }
}
