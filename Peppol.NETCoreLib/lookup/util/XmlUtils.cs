using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml;


namespace VertSoft.Peppol.Lookup.Util
{

	public class XmlUtils
	{

		private static readonly Regex ROOT_TAG_PATTERN = 
                new Regex("<(\\w*:{0,1}[^<?|^<!]*)>", RegexOptions.Multiline | RegexOptions.Compiled);

		private static readonly Regex NAMESPACE_PATTERN = 
                new Regex("xmlns:{0,1}([A-Za-z0-9]*)\\w*=\\w*\"(.+?)\"", RegexOptions.Multiline | RegexOptions.Compiled);

		//private static XMLInputFactory XML_INPUT_FACTORY;

		static XmlUtils()
		{
            //These are settings
			//XML_INPUT_FACTORY = XMLInputFactory.newFactory();
			//XML_INPUT_FACTORY.setProperty(XMLInputFactory.SUPPORT_DTD, false);
			//XML_INPUT_FACTORY.setProperty("javax.xml.stream.isSupportingExternalEntities", false);
		}

        /// <summary>
        /// Get the Rootnamespace from an XML string
        /// </summary>
        /// <param name="xmlContent"></param>
        /// <returns></returns>
		public static string extractRootNamespace(string xmlContent)
		{
			Match matcher = ROOT_TAG_PATTERN.Match(xmlContent);
			if (matcher.Success)
			{
				string rootElement = matcher.Groups[0].Value.Trim();
				string rootNs = rootElement.Split(" ", 2)[0].Contains(":") ? rootElement.Substring(0, rootElement.IndexOf(":", StringComparison.Ordinal)) : "";

				Match nsMatcher = NAMESPACE_PATTERN.Match(rootElement);
				while (nsMatcher.Success)
				{
					if (nsMatcher.Groups[0].Value.Equals(rootNs))
					{
						return nsMatcher.Groups[1].Value;
					}
				}
			}
			return null;
		}

        //ORIGINAL LINE: public static javax.xml.stream.XMLStreamReader streamReader(Stream inputStream) throws XMLStreamException
		public static XmlReader streamReader(Stream inputStream)
		{
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.Async = false;
            return XmlReader.Create(inputStream);
		}

		internal XmlUtils()
		{

		}
	}
}