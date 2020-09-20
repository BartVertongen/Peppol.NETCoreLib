
using System;
using System.IO;
using System.Xml.Serialization;


namespace Vertsoft.Tools.Extension.Xml
{
    public static class XMLExtension
    {
        /// <summary>
        /// Serializes an object to an xml string.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string XmlSerialize<T>(this T value)
        {
            if (value == null)
            {
                return string.Empty;
            }
            try
            {
                XmlSerializer xmlserializer = null;

				xmlserializer = new XmlSerializer(typeof(T));
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    xmlserializer.Serialize(memoryStream, value);
                    memoryStream.Position = 0;
                    using (StreamReader streamReader = new StreamReader(memoryStream))
                    {
                        return streamReader.ReadToEnd();
                    }
                }
                //before
                /*var stringWriter = new StringWriter();
                using (var writer = XmlWriter.Create(stringWriter))
                {
                    xmlserializer.Serialize(writer, value);
                    return stringWriter.ToString();
                }*/

            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred", ex);
            }
        }

        static public T XmlDeserialize<T>(string input)
        {
            XmlSerializer ser = new XmlSerializer(typeof(T));

            using (StringReader sr = new StringReader(input))
                return (T)ser.Deserialize(sr);
        }

        public static T DeserializeFromString<T>(string value)
        {
            T outObject;
            XmlSerializer deserializer = new XmlSerializer(typeof(T));
            StringReader stringReader = new StringReader(value);
            outObject = (T)deserializer.Deserialize(stringReader);
            stringReader.Close();
            return outObject;
        }
    }
}
