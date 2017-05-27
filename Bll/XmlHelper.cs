using System.IO;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Reflection;

namespace Bll
{
    public class XmlHelper
    {
        public static string FilePath { get; set; }

        private static XmlDocument XmlDoc;

        public static void Create()
        {
            XmlDocument doc = new XmlDocument();
            XmlDeclaration declaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement docele = doc.CreateElement("Settings");
            doc.AppendChild(declaration);
            doc.AppendChild(docele);
            doc.Save(FilePath);
            XmlDoc = doc;
        }

        private static void LoadDocument()
        {
            if (!File.Exists(FilePath)) throw new Exception("地址不能为空");
            if (XmlDoc != null) return;
            XmlDoc = new XmlDocument();
            XmlDoc.Load(FilePath);
        }

        public static T Load<T>()
        {
            bool isaddnode = false;
            T t = default(T);
            LoadDocument();
            XmlNode node = XmlDoc.DocumentElement.SelectSingleNode(typeof(T).Name);
            if (node == null) return t;
            t = Activator.CreateInstance<T>();
            PropertyInfo[] pinfo = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            foreach (PropertyInfo item in pinfo)
            {
                XmlNode selectednode = node.SelectSingleNode(item.Name);
                if (selectednode == null)
                {
                    AddNode(node, item.Name);
                    isaddnode = true;
                    continue;
                }
                item.SetValue(t, GetDataType(item, selectednode.InnerText), null);
            }
            if (isaddnode)
            {
                XmlDoc.Save(FilePath);
            }
            return t;
        }

        private static object GetDataType(PropertyInfo t, object obj)
        {
            if (t.PropertyType == typeof(int))
            {
                if (obj == null)
                    obj = 0;
                obj = Convert.ToInt32(obj);
            }
            else if (t.PropertyType == typeof(DateTime))
            {
                obj = Convert.ToDateTime(obj);
            }
            else if (t.PropertyType == typeof(bool))
            {
                obj = Convert.ToBoolean(obj);
            }
            else if (t.PropertyType == typeof(double))
            {
                obj = Convert.ToDouble(obj);
            }
            return obj;
        }

        public static void Add<T>(T value)
        {
            XmlElement documentelement = XmlDoc.CreateElement(typeof(T).Name);
            PropertyInfo[] pinfo = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            foreach (PropertyInfo item in pinfo)
            {
                XmlElement node = XmlDoc.CreateElement(item.Name);
                object obj = item.GetValue(value, null);
                if (obj != null)
                    node.InnerText = item.GetValue(value, null).ToString();
                documentelement.AppendChild(node);
            }
            XmlDoc.DocumentElement.AppendChild(documentelement);
            XmlDoc.Save(FilePath);
        }

        private static void AddNode(XmlNode documentnode, string nodename)
        {
            XmlElement node = XmlDoc.CreateElement(nodename);
            documentnode.AppendChild(node);
        }

        public static List<T> Loads<T>()
        {
            List<T> tlist = new List<T>();
            LoadDocument();
            XmlNodeList nodelist = XmlDoc.DocumentElement.SelectNodes(typeof(T).Name);
            if (nodelist.Count > 0)
            {
                PropertyInfo[] pinfo = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
                foreach (XmlNode nodeitem in nodelist)
                {
                    T t = Activator.CreateInstance<T>();
                    foreach (PropertyInfo item in pinfo)
                    {
                        XmlNode selectednode = nodeitem.SelectSingleNode(item.Name);
                        if (selectednode == null)
                        {
                            continue;
                        }
                        item.SetValue(t, GetDataType(item, selectednode.InnerText), null);
                    }
                    tlist.Add(t);
                }
            }
            return tlist;
        }

        public static void Update<T>(T value)
        {
            LoadDocument();
            XmlNode documentnode = XmlDoc.DocumentElement.SelectSingleNode(typeof(T).Name);
            PropertyInfo[] pinfo = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            foreach (PropertyInfo item in pinfo)
            {
                XmlNode selectednode = documentnode.SelectSingleNode(item.Name);
                object obj = item.GetValue(value, null);
                if (obj == null) continue;
                selectednode.InnerText = obj.ToString();
            }
            XmlDoc.Save(FilePath);
        }

        public static void Update<T>(T value, int index)
        {
            LoadDocument();
            XmlNodeList documentnodelist = XmlDoc.DocumentElement.SelectNodes(typeof(T).Name);
            XmlNode documentnode = documentnodelist[index];
            PropertyInfo[] pinfo = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.Instance);
            foreach (PropertyInfo item in pinfo)
            {
                XmlNode selectednode = documentnode.SelectSingleNode(item.Name);
                object obj = item.GetValue(value, null);
                selectednode.InnerText = obj.ToString();
            }
            XmlDoc.Save(FilePath);
        }

        public static void Del<T>(int index)
        {
            LoadDocument();
            XmlNodeList documentnodelist = XmlDoc.DocumentElement.SelectNodes(typeof(T).Name);
            documentnodelist[index].RemoveAll();
            XmlDoc.Save(FilePath);
        }
    }
}
