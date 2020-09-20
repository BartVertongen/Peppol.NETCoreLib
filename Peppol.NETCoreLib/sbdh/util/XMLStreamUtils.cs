
using System.IO;
using System.Xml;


namespace VertSoft.Peppol.Sbdh.Util
{
    public class XMLStreamUtils
    {
        //throws XMLStreamException
        static void Copy(TextReader reader, XmlWriter xmlStreamWriter)
        {
            XmlReader xmlStreamReader = XmlReader.Create(reader);
            Copy(xmlStreamReader, xmlStreamWriter);
            xmlStreamReader.Close();
        }


        //throws XMLStreamException
        static void Copy(XmlReader xmlStreamReader, TextWriter writer)
        {
            XmlWriter xmlStreamWriter = XmlWriter.Create(writer);
            Copy(xmlStreamReader, xmlStreamWriter);
            xmlStreamWriter.Close();
        }


        ////throws XMLStreamException
        static public void Copy(Stream inputStream, XmlWriter xmlStreamWriter)
        {
            XmlReader xmlStreamReader = XmlReader.Create(inputStream/*, "UTF-8"*/);
            Copy(xmlStreamReader, xmlStreamWriter);
            xmlStreamReader.Close();
        }


        //throws XMLStreamException
        static public void Copy(XmlReader xmlStreamReader, Stream outputStream)
        {
            XmlWriter xmlStreamWriter = XmlWriter.Create(outputStream/*, "UTF-8"*/);
            Copy(xmlStreamReader, xmlStreamWriter);
            xmlStreamWriter.Close();
        }


        //throws XMLStreamException
        static public void Copy(XmlReader reader, XmlWriter writer)
        {
            bool hasNext = true;

            reader.MoveToContent();
            while (hasNext && reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Document:
                        writer.WriteStartDocument();
                        break;
        
                    case XmlNodeType.Element:
                        writer.WriteStartElement(reader.Prefix, reader.LocalName, reader.NamespaceURI);
        
                        /*for (int i = 0; i<reader.getNamespaceCount(); i++)
                            writer.writeNamespace(reader.getNamespacePrefix(i), reader.getNamespaceURI(i));*/
                        for (int i = 0; i < reader.AttributeCount; i++)
                        {
                            string prefix = reader.GetAttribute(i);
                            if (prefix == null || prefix=="")
                                /*writer.WriteAttributeString(reader.GetAttribute(i), reader.getAttributeValue(i))*/;
                            else
                                /*writer.writeAttribute(prefix, reader.getAttributeNamespace(i), reader.getAttributeLocalName(i), reader.getAttributeValue(i))*/;
                        }
                        break;

                    case XmlNodeType.EndElement:
                        writer.WriteEndElement();
                        break;
        
                    case XmlNodeType.Text:
                        writer.WriteValue(reader.Value);
                        break;

                    case XmlNodeType.CDATA:
                        writer.WriteCData(reader.Value);
                        break;
                }
                hasNext = reader.Read();
            };
            writer.WriteEndDocument();
        }
    }
}
