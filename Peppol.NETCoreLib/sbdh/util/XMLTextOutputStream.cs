
using System;
using System.IO;
using System.Xml;
using VertSoft.Peppol.Sbdh;


namespace VertSoft.Peppol.Sbdh.Util
{
	public class XMLTextOutputStream : MemoryStream
	{

		private readonly XmlWriter _XmlWriter;

		private byte[] bytes = new byte[64];

		private int counter;


		//ORIGINAL LINE: public XMLTextOutputStream(javax.xml.stream.XMLStreamWriter xmlStreamWriter, String mimeType)
		//throws javax.xml.stream.XMLStreamException
		public XMLTextOutputStream(XmlWriter xmlStreamWriter, string mimeType)
		{
			this._XmlWriter = xmlStreamWriter;

			xmlStreamWriter.WriteStartElement("", Ns.QNAME_TEXT_CONTENT.LocalPart, Ns.EXTENSION);
			//xmlStreamWriter.writeDefaultNamespace(Ns.EXTENSION);
			xmlStreamWriter.WriteAttributeString("mimeType", mimeType);
		}


		//ORIGINAL LINE: @Override public void write(int b) throws java.io.IOException
		public /*override*/ void Write(int b)
		{
			bytes[counter++] = (byte) b;

			if (counter == bytes.Length)
			{
				try
				{
					//REPLACE -> this._XmlWriter.writeCharacters(StringHelper.NewString(bytes));
					counter = 0;
				}
				catch (Exception e)
				{
					throw new IOException(e.Message, e);
				}
			}
		}


		//ORIGINAL LINE: @Override public void close() throws java.io.IOException
		public override void Close()
		{
			try
			{
				if (counter > 0)
				{
					//REPLACE -->this._XmlWriter.writeCharacters(new string(Arrays.copyOf(bytes, counter)));
				}

				this._XmlWriter.WriteEndElement();
			}
			catch (Exception e)
			{
				throw new IOException(e.Message, e);
			}
		}
	}
}