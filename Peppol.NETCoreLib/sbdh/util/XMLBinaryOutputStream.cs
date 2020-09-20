
using System;
using System.IO;
using System.Xml;
using VertSoft.Peppol.Sbdh;


namespace VertSoft.Peppol.Sbdh.Util
{
	//using BaseEncoding = com.google.common.io.BaseEncoding;

	/// <summary>
	/// This class should be a mix of a OutputStream and Writer.
	/// In java it is enough if you can write 1 byte to have a Stream, in C# we need more.
	/// </summary>
	public class XMLBinaryOutputStream : Stream
	{
		//the base of the encoding?
		//private readonly BaseEncoding baseEncoding = BaseEncoding.base64().withSeparator("\n", 76);

		private readonly XmlWriter _xmlWriter;

		private byte[] _Bytes = new byte[3 * 20];

		private int _Counter;
		private long _Length;


		//ORIGINAL LINE: public XMLBinaryOutputStream(XMLStreamWriter xmlStreamWriter, String mimeType, String encoding) 
		//	throws javax.xml.stream.XMLStreamException
		public XMLBinaryOutputStream(XmlWriter xmlStreamWriter, string mimeType, string encoding)
		{
			this._xmlWriter = xmlStreamWriter;

			this._xmlWriter.WriteStartElement("", Ns.QNAME_BINARY_CONTENT.LocalPart, Ns.EXTENSION);
			//xmlStreamWriter.WriteDefaultNamespace(Ns.EXTENSION);
			this._xmlWriter.WriteAttributeString("mimeType", mimeType);

			if (!string.ReferenceEquals(encoding, null))
			{
				this._xmlWriter.WriteAttributeString("encoding", encoding);
			}
		}

		/// <summary>
		/// We write one byte to the buffer.
		/// If the buffer is full, the buffer is written to the writer
		/// </summary>
		/// <param name="b"></param>
		//ORIGINAL LINE: @Override public void write(int b) throws java.io.IOException
		public /*override*/ void Write(int b)
		{
			_Bytes[_Counter++] = (byte) b;

			if (this._Counter == this._Bytes.Length)
			{
				try
				{
					this._xmlWriter.WriteBinHex(this._Bytes, 0, this._Counter);
					this._Length += this._Counter;
					this._Counter = 0;
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
				if (this._Counter > 0)
				{
					//Original this._xmlWriter.WriteCharacters(baseEncoding.encode(Arrays.copyOf(this._Bytes, this._Counter)));
					this._xmlWriter.WriteBinHex(this._Bytes, 0, this._Counter);
					this._Length += this._Counter;
					this._Counter = 0;
				}
				this._xmlWriter.WriteEndElement();
			}
			catch (Exception e)
			{
				throw new IOException(e.Message, e);
			}
		}

		/// <summary>
		/// Override of Stream, returns false because it is an OutputStream
		/// </summary>
		public override bool CanRead
		{
			get { return false; }
		}

		public override bool CanSeek
		{
			get { return false; }
		}

		public override bool CanWrite
		{
			get { return true; }
		}

		public override long Length
		{
			get { return (this._Length + this._Counter); }
		}

		public override long Position
		{
			get { return this.Length; }
			set => throw new NotImplementedException(); 
		}


		public override void Flush()
		{
			throw new NotImplementedException();
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			throw new NotImplementedException();
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			throw new NotImplementedException();
		}

		public override void SetLength(long value)
		{
			throw new NotImplementedException();
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			for(int i = offset; i < count; i++)
			{
				this.Write(buffer[i]);
			}
		}
	}
}