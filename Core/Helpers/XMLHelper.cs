using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Core.Helpers
{
    public class XMLHelper<T> where T : class
    {
        public static T DeserializeFromXmlString(string xmlData)
        {
            T parsedObj = default;
            try
            {
                byte[] byteArray = Encoding.UTF8.GetBytes(xmlData);
                using (MemoryStream stream = new MemoryStream(byteArray))
                {
                    var s = new XmlSerializer(typeof(T));
                    parsedObj = (T)s.Deserialize(XmlReader.Create(stream));
                }
            }
            catch (Exception e)
            {
            }
            return parsedObj;
        }

        public static List<T> DeserializeFromXmlList(List<dynamic> xmlData)
        {
            List<T> parsedList = default;
            try
            {
                foreach (var data in xmlData)
                {
                    byte[] byteArray = Encoding.UTF8.GetBytes(data);
                    using (MemoryStream stream = new MemoryStream(byteArray))
                    {
                        var s = new XmlSerializer(typeof(T));
                        parsedList.Add((T)s.Deserialize(XmlReader.Create(stream)));
                    }
                }

            }
            catch (Exception e)
            {
            }
            return parsedList;
        }


        public static XmlElement SerializeToXmlElement(T obj)
        {
            XmlDocument doc = new XmlDocument();
            try
            {
                using (XmlWriter writer = doc.CreateNavigator().AppendChild())
                {
                    new XmlSerializer(typeof(T)).Serialize(writer, obj);
                }
            }
            catch (Exception e)
            {
            }
            return doc.DocumentElement;
        }
    }
}
