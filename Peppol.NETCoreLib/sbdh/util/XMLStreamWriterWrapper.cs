
using System.Xml;


namespace vertSoft.Peppol.Sbdh.Util
{
	//REM: Maybe here we can just create an XmlWriter from an XmlWriter
	public class XMLStreamWriterWrapper : XmlWriter
	{
		private XmlWriter _XmlWriter;

		public override WriteState WriteState
		{
			get { return this.WriteState; }
		}

		public XMLStreamWriterWrapper(XmlWriter xmlStreamWriter)
		{
			this._XmlWriter = xmlStreamWriter;
		}

		public override void Flush()
		{
			this.Flush();
		}


		public override void WriteBase64(byte[] buffer, int index, int count)
		{
			this.WriteBase64(buffer, index, count);
		}

		public override void WriteCData(string text)
		{
			this.WriteCData(text);
		}

		public override void WriteCharEntity(char ch)
		{
			this.WriteCharEntity(ch);
		}

		public override void WriteChars(char[] buffer, int index, int count)
		{
			this.WriteChars(buffer, index, count);
		}

		public override void WriteComment(string text)
		{
			this.WriteComment(text);
		}

		public override void WriteDocType(string name, string pubid, string sysid, string subset)
		{
			this.WriteDocType(name, pubid, sysid, subset);
		}

		public override void WriteEndAttribute()
		{
			this.WriteEndAttribute();
		}

		public override void WriteEndDocument()
		{
			this.WriteEndDocument();
		}

		public override void WriteEndElement()
		{
			this.WriteEndElement();
		}

		public override void WriteEntityRef(string name)
		{
			this.WriteEntityRef(name);
		}

		public override void WriteFullEndElement()
		{
			this.WriteFullEndElement();
		}

		public override void WriteProcessingInstruction(string name, string text)
		{
			this.WriteProcessingInstruction(name, text);
		}

		public override void WriteRaw(char[] buffer, int index, int count)
		{
			this.WriteRaw(buffer, index, count);
		}

		public override void WriteRaw(string data)
		{
			this.WriteRaw(data);
		}

		public override void WriteStartAttribute(string prefix, string localName, string ns)
		{
			this.WriteStartAttribute(prefix, localName, ns);
		}

		public override void WriteStartDocument()
		{
			this.WriteStartDocument();
		}

		public override void WriteStartDocument(bool standalone)
		{
			this.WriteStartDocument(standalone);
		}

		public override void WriteStartElement(string prefix, string localName, string ns)
		{
			this.WriteStartElement(prefix, localName, ns);
		}

		public override void WriteString(string text)
		{
			this.WriteString(text);
		}

		public override void WriteSurrogateCharEntity(char lowChar, char highChar)
		{
			this.WriteSurrogateCharEntity(lowChar, highChar);
		}

		public override void WriteWhitespace(string ws)
		{
			this.WriteWhitespace(ws);
		}

		public override string LookupPrefix(string ns)
		{
			return this.LookupPrefix(ns);
		}
	}
}