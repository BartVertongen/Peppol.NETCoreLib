
using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using VertSoft.Peppol.Common.Model;
using VertSoft.Peppol.Sbdh.Lang;
using VertSoft.Peppol.Sbdh.Util;


namespace VertSoft.Peppol.Sbdh
{
	/// <summary>
	/// Converts a (XML) Stream to a Standard Business Document.
	/// Containng a Header and the Contents of a Document.
	/// </summary>
	public class SbdReader2 
	{
		private XDocument _xmlBusinessDocument;

		public enContentType ContentType { get; private set; } = enContentType.UNKOWN;

		public MemoryStream ContentStream { get; private set; } = new MemoryStream();

		public string ContentString { get; private set; } = null;

		public Header Header { get; private set; } = null;

		public string MimeType { get; private set; } = null;


		/// <summary>
		/// Constructor with the Stream to read.
		/// </summary>
		/// <param name="inputStream"></param>
		public SbdReader2(Stream inputStream)
		{
			//throws SbdhException
			inputStream.Position = 0;
			this._xmlBusinessDocument = XDocument.Load(inputStream);
		}


		/// <summary>
		/// Reads the given input Stream til the end to get all the data from it.
		/// </summary>
		public void Read()
		{
			try
			{
				// First element, SBD expected.
				if (this._xmlBusinessDocument.Root.Name.LocalName != Ns.QNAME_SBD.LocalPart)
				{
					throw new SbdhException("Element 'StandardBusinessDocument' not found as first element.");
				}
				var Iterator = this._xmlBusinessDocument.Root.Elements().GetEnumerator();
				Iterator.MoveNext(); //Go to the first element
				XElement xmlHeader = Iterator.Current;
				if (xmlHeader == null || xmlHeader.Name.LocalName != Ns.QNAME_SBDH.LocalPart)
				{
					throw new SbdhException("Element 'StandardBusinessDocumentHeader' not found as first element in 'StandardBusinessDocument'.");
				}
				//Convert xmlHeader to Header object.
				xmlHeader.Save(this.ContentStream);
				this.Header = SbdhReader.Read(this.ContentStream);
				if (!Iterator.MoveNext())
				{
					throw new SbdhException("No payload found in this 'StandardBusinessDocument'.");
				}
				XElement xmlPayload = Iterator.Current;
				if (xmlPayload.Name.LocalName == "TextContent")
				{
					this.ContentType = enContentType.TEXT;
					this.ContentString = xmlPayload.Value;
					byte[] arDocument = Encoding.UTF8.GetBytes(this.ContentString);
					this.ContentStream = new MemoryStream(arDocument);
				}
				else if (xmlPayload.Name.LocalName == "BinaryContent")
				{
					this.ContentType = enContentType.BINARY;
					this.ContentString = xmlPayload.Value;
					byte[] arDocument = Convert.FromBase64String(this.ContentString);
					this.ContentStream = new MemoryStream(arDocument);
				}
				else if (xmlPayload.Name.LocalName == this.Header.getInstanceType().Type)
				{
					this.ContentType = enContentType.XML;
					this.ContentString = xmlPayload.ToString();
					byte[] arDocument = Encoding.UTF8.GetBytes(this.ContentString);
					this.ContentStream = new MemoryStream(arDocument);
				}
				else
				{
					this.ContentType = enContentType.XML;
					string strTag = this.Header.getInstanceType().Type;
					throw new SbdhException($"The Content is Xml but should start with <{strTag}>");
				}
			}
			catch (SbdhException e)
			{
				throw e;
			}
			catch (XmlException e)
			{
				throw new SbdhException("XML error: " + e.Message, e);
			}
			catch (Exception e)
			{
				throw new SbdhException("error: " + e.Message, e);
			}
		}	
	}
}