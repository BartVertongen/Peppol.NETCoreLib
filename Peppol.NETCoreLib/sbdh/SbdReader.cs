
using System;
using System.IO;
using System.Text;
using System.Xml;
using VertSoft.Peppol.Common.Model;
using VertSoft.Peppol.Sbdh.Lang;


namespace VertSoft.Peppol.Sbdh
{
	public enum enContentType { UNKOWN, BINARY, TEXT, XML }

	/// <summary>
	/// Converts a (XML) Stream to a Standard Business Document.
	/// Containng a Header and the Contents of a Document.
	/// </summary>
	public class SbdReader 
	{


		public enContentType ContentType { get; private set; } = enContentType.UNKOWN;

		public MemoryStream ContentStream { get; private set; } = null;

		public string ContentString { get; private set; } = null;

		public Header Header { get; private set; } = null;

		public string MimeType { get; private set; } = null;


		//Is an object used to read xml data from a stream, file , string,...
		//From Framework 2.0 XmlTextReader should be replaced by XmlReader
		private XmlReaderSettings	_Settings;
		private XmlReader			_XmlReader;
		//Keeps the stream used as input
		private Stream				_InputStream = null;


		//throws SbdhException
		public SbdReader(Stream inputStream)
		{
			this._InputStream = inputStream;
			this._InputStream.Position = 0;
			this._Settings = new XmlReaderSettings();
			this._Settings.Async = false;
			this._Settings.IgnoreWhitespace = false;
			this._XmlReader = XmlReader.Create(this._InputStream);
		}


		/// <summary>
		/// Reads the given input Stream til the end to get all the data from it.
		/// </summary>
		public void Read()
		{
			try
			{
				// First element, SBD expected.
				this._XmlReader.Read();
				//If there is an XML-declaration then we need the next node
				if (this._XmlReader.NodeType == XmlNodeType.XmlDeclaration)
				{
					this._XmlReader.MoveToContent();
				}
				if (this._XmlReader.Name != Ns.QNAME_SBD.LocalPart)
				{
					throw new SbdhException("Element 'StandardBusinessDocument' not found as first element.");
				}
				this._XmlReader.Read();
				while (this._XmlReader.NodeType == XmlNodeType.Whitespace)
				{
					this._XmlReader.Read();
				}
				if (!this._XmlReader.Name.Equals(Ns.QNAME_SBDH.LocalPart))
				{
					throw new SbdhException("Element 'StandardBusinessDocumentHeader' not found as first element in 'StandardBusinessDocument'.");
				}
				//Get the currents Node complete contents
				string strHeaderContent = this._XmlReader.ReadOuterXml();
				byte[] byteArray = Encoding.UTF8.GetBytes(strHeaderContent);
				MemoryStream strmHeader = new MemoryStream(byteArray);
				this.Header = SbdhReader.Read(strmHeader);
				// Go to payload
				byte[] arDocument;
				this._XmlReader.Skip();
				if (this._XmlReader.Name == "TextContent")
				{
					this.ContentType = enContentType.TEXT;
					this.ContentString = this._XmlReader.ReadElementContentAsString().Trim();
					arDocument = Encoding.UTF8.GetBytes(this.ContentString);
					this.ContentStream = new MemoryStream(arDocument);
				}
				else if (this._XmlReader.Name == "BinaryContent")
				{
					this.ContentType = enContentType.BINARY;
					this.ContentString = this._XmlReader.ReadElementContentAsString().Trim();
					arDocument = Convert.FromBase64String(this.ContentString);
					this.ContentStream = new MemoryStream(arDocument);
				}
				else if (this._XmlReader.Name == this.Header.getInstanceType().Type)
				{
					this.ContentType = enContentType.XML;
					//only pure XML Content is possible
					//We can check with the header information which kind
					//of XML node should be there
					this.ContentString = this._XmlReader.ReadOuterXml();
					arDocument = Encoding.UTF8.GetBytes(this.ContentString);
					this.ContentStream = new MemoryStream(arDocument);
				}
				else
				{
					this.ContentType = enContentType.XML;
					string strTag = this.Header.getInstanceType().Type;
					throw new SbdhException($"The Content is Xml but should start with <{strTag}>");
				}
			}
			catch (XmlException e)
			{
				throw new SbdhException("XML error: " + e.Message, e);
			}
		}
		
		public void Close()
		{
			this._InputStream.Close();
			this._XmlReader.Close();
		}
	}
}