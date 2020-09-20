
using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using VertSoft.Peppol.Common.Model;
using VertSoft.Peppol.Sbdh.Lang;


namespace VertSoft.Peppol.Sbdh
{
	/// <summary>
	/// To convert a Standard Business Document to an XML (Stream)
	/// </summary>
	public class SbdWriter
	{
		//After Framework 2.0 we should use XmlWriter and not XmlTextWriter
		private XmlWriterSettings _Settings;
		private XmlWriter		_Writer;
		private MemoryStream	_ResultStream;
		private Header			_Header;


		/// <summary>
		/// Constructs the SbdWriter and writes the start of the XML document.
		/// </summary>
		/// <param name="resultstream">The  stream that holds the result</param>
		/// <param name="header">The header that should be written to the resulting stream.</param>
		/// <remarks>Encoding and version can be set with Settings</remarks>
		public SbdWriter(ref MemoryStream resultstream, Header header)
		{
			try
			{
				this._ResultStream = resultstream;
				this._Header = header;
				this._Settings = new XmlWriterSettings();
				this._Settings.NewLineHandling = NewLineHandling.Entitize;
				this._Settings.Indent = true;
				this._Settings.IndentChars = "\t";
				this._Settings.CloseOutput = false;
				this._Settings.WriteEndDocumentOnClose = false;
				this._Writer = XmlWriter.Create(resultstream, this._Settings);
			}
			catch (Exception ex)
			{
				throw new SbdhException("Unable to initiate SBD.", ex);
			}
		}

		/// <summary>
		/// Writes the header to the Resulting stream.
		/// </summary>
		private void WriteHeader()
		{
			//This is not a good solution, we can not use SbdhWriter
			//SbdhWriter is for a standalone header
			StandardBusinessDocumentHeader objSBDH;
			SbdhWriter.Convert(out objSBDH, this._Header);
			XmlSerializer objSerializer = new XmlSerializer(typeof(StandardBusinessDocumentHeader));
			MemoryStream strmSBDH = new MemoryStream();
			objSerializer.Serialize(strmSBDH, objSBDH);
			strmSBDH.Position = 0;
			XmlReader objReader = XmlReader.Create(strmSBDH);
			objReader.Read();
			//If there is an XML-declaration then we need the next node
			if (objReader.NodeType == XmlNodeType.XmlDeclaration)
			{
				objReader.MoveToContent();
			}
			if (!objReader.Name.Equals(Ns.QNAME_SBDH.LocalPart))
			{
				throw new SbdhException("Element <StandardBusinessDocumentHeader> not found as first element.");
			}
			this._Writer.WriteNode(objReader, false);
			objReader.Close();
		}


		/// <summary>
		/// Writes all the data to the resulting stream.
		/// </summary>
		/// <param name="document"></param>
		/// <param name="contenttype"></param>
		/// <param name="mimetype"></param>
		public void Write(MemoryStream document, enContentType contenttype = enContentType.XML, string mimetype= "Application/xml")
		{
			this._Writer.WriteStartDocument();
			this._Writer.WriteStartElement("", Ns.QNAME_SBD.LocalPart, Ns.SBDH);
			this.WriteHeader();	
			// add the content here
			if (contenttype == enContentType.TEXT)
			{
				this._Writer.WriteStartElement("TextContent", "");
				this._Writer.WriteAttributeString("mimeType", mimetype);
				this._Writer.WriteAttributeString("encoding", "UTF8");
				byte[] arDocument = document.ToArray();
				string strDocument = Encoding.UTF8.GetString(arDocument);
				this._Writer.WriteString(strDocument);
				this._Writer.WriteEndElement();
			}
			else if (contenttype == enContentType.BINARY)
			{
				this._Writer.WriteStartElement("BinaryContent", "");
				this._Writer.WriteAttributeString("mimeType", mimetype);
				byte[] arDocument = document.ToArray();
				string strDocument = Convert.ToBase64String(arDocument);
				this._Writer.WriteString(strDocument);
				this._Writer.WriteEndElement();
			}
			else  //Write a stream with XML
			{
				//We need a reader to find the right part
				document.Position = 0;
				XmlReader objXmlReader = XmlReader.Create(document);
				objXmlReader.Read();
				//If there is an XML-declaration then we need the next node
				if (objXmlReader.NodeType == XmlNodeType.XmlDeclaration)
				{
					objXmlReader.MoveToContent();
				}
				if (objXmlReader.Name != this._Header.getInstanceType().Type)
				{
					throw new SbdhException($"Element '{this._Header.getInstanceType().Type}' not found as first element.");
				}
				this._Writer.WriteNode(objXmlReader, false);
				objXmlReader.Close();
			}
			this._Writer.WriteEndDocument();
			this._Writer.Close();
		}
	}
}