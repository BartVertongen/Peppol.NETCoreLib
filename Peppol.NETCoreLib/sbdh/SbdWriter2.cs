
using System;
using System.IO;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;
using VertSoft.Peppol.Common.Model;
using VertSoft.Peppol.Sbdh;
using VertSoft.Peppol.Sbdh.Lang;


namespace VertSoft.Peppol.Sbdh
{
	/// <summary>
	/// To convert a Standard Business Document to an XML (Stream)
	/// A new version using XDocument, XPathSelectElement, XPathEvaluate
	/// </summary>
	public class SbdWriter2
	{
		private Header			_Header;
		public XDocument BusinessDocument { get; private set; }


		/// <summary>
		/// Constructs the SbdWriter and writes the start of the XML document.
		/// </summary>
		/// <param name="resultstream">The  stream that holds the result</param>
		/// <param name="header">The header that should be written to the resulting stream.</param>
		/// <remarks>Encoding and version can be set with Settings</remarks>
		public SbdWriter2(Header header)
		{
			try
			{
				this._Header = header;
			}
			catch (Exception ex)
			{
				throw new SbdhException("Unable to initiate SBD.", ex);
			}
		}

		/// <summary>
		/// Writes the header to the Resulting stream.
		/// </summary>
		private XElement WriteHeader()
		{		
			StandardBusinessDocumentHeader objSBDH;
			SbdhWriter.Convert(out objSBDH, this._Header);
			XmlSerializer objSerializer = new XmlSerializer(typeof(StandardBusinessDocumentHeader));
			MemoryStream strmSBDH = new MemoryStream();
			objSerializer.Serialize(strmSBDH, objSBDH);
			strmSBDH.Position = 0;
			XElement XmlHeader = XElement.Load(strmSBDH, LoadOptions.SetLineInfo);
			return XmlHeader;
		}


		/// <summary>
		/// Writes all the data to the resulting BusinessDocument.
		/// </summary>
		/// <param name="document">The document to be wrapped</param>
		/// <param name="contenttype"></param>
		/// <param name="mimetype"></param>
		public void Write(MemoryStream document, enContentType contenttype = enContentType.XML, string mimetype= "Application/xml")
		{
			XNamespace nmspace = Ns.QNAME_SBD.NamespaceURI;
			this.BusinessDocument = new XDocument(new XDeclaration("1.0","utf-8", "yes"), new XElement(nmspace + Ns.QNAME_SBD.LocalPart));
			XElement xmlHeader = this.WriteHeader();			
			// add the content here
			XElement xmlContent;
			if (contenttype == enContentType.TEXT)
			{
				byte[] arDocument = document.ToArray();
				string strDocument = Encoding.UTF8.GetString(arDocument);
				xmlContent = new XElement("TextContent",
									new XAttribute("mimeType", mimetype),
									new XAttribute("encoding", "UTF8"),
									new XText(strDocument)
								);
			}
			else if (contenttype == enContentType.BINARY)
			{
				byte[] arDocument = document.ToArray();
				string strDocument = Convert.ToBase64String(arDocument);
				xmlContent = new XElement("BinaryContent",
									new XAttribute("mimeType", mimetype),
									new XText(strDocument)
								);
			}
			else  //Write a stream with XML
			{
				document.Position = 0;
				xmlContent = XElement.Load(document);
				if (xmlContent.Name.LocalName != this._Header.getInstanceType().Type)
				{
					throw new SbdhException($"Element '{this._Header.getInstanceType().Type}' not found as first element.");
				}
			}
			this.BusinessDocument.Root.Add(xmlHeader, xmlContent);
		}
	}
}