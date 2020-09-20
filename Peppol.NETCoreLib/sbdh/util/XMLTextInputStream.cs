
using System;
using System.IO;
using System.Xml;


namespace VertSoft.Peppol.Sbdh.Util
{
	/// <summary>
	/// Here we get data out of the Reader to the stream
	/// </summary>
	public class XMLTextInputStream : MemoryStream
	{

		private readonly XmlReader _XmlReader;
		private byte[] _Bytes = new byte[0];
		private MemoryStream _MemStream;
		private int _Counter;

		//ORIGINAL LINE: public XMLTextInputStream(XMLStreamReader reader) throws XMLStreamException
		public XMLTextInputStream(XmlReader reader)
		{
			this._XmlReader = reader;
			//REPLACED
			while (!this._XmlReader.HasValue)
			{
				if (!this._XmlReader.Read())
					break;
			}
				
			//ORIGINAL
			/*while (!this._XmlReader.Characters)
			{
				this._XmlReader.Next();
			}*/
		}

		public override bool CanRead
		{
			get { return true; }
		}

		public override bool CanSeek
		{
			get { return false; }
		}

		public override bool CanWrite
		{
			get { return false; }
		}

		public override long Length
		{
			get { throw new NotImplementedException(); }
			
		}

		public override long Position 
		{ get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public override void Flush()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Reads just one byte.
		/// </summary>
		/// <returns></returns>
		//ORIGINAL LINE: @Override public int read() throws java.io.IOException
		public /*override*/ int Read()
		{
			if (this._Counter == this._Bytes.Length)
			{
				//ORIGINAL
				/*if (!this._XmlReader.Characters)
				{
					return -1;
				}
				bytes = this._XmlReader.Text.Bytes;*/

				//REPLACED BY
				if (!this._XmlReader.HasValue)
				{
					return -1;
				}
				//this._Bytes = this._XmlReader.ReadValueChunk();

				this._Counter = 0;

				try
				{
					//ORIGINAL: this._XmlReader.Next();
					//REPLACED BY
					this._XmlReader.Read();						
				}
				catch (XmlException e)
				{
					throw new IOException(e.Message, e);
				}
			}
			return this._Bytes[this._Counter++];
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
			throw new NotImplementedException();
		}
	}
}