
using System.Xml;


namespace vertSoft.Peppol.Sbdh.Util
{
	public class XMLStreamReaderWrapper : XmlReader
	{

		protected internal XmlReader _Reader;

		public XMLStreamReaderWrapper(XmlReader reader)
		{
			//base.
			this._Reader = reader;
		}

		//ORIGINAL LINE: @Override public void close() throws javax.xml.stream.XMLStreamException
		public override void Close()
		{
			// No action.
		}


		public override string GetAttribute(int i)
		{
			return this.GetAttribute(i);
		}

		public override string GetAttribute(string name)
		{
			return this.GetAttribute(name);
		}

		public override string GetAttribute(string name, string namespaceURI)
		{
			return this.GetAttribute(name, namespaceURI);
		}

		public override string LookupNamespace(string prefix)
		{
			return this.LookupNamespace(prefix);
		}

		public override bool MoveToAttribute(string name)
		{
			return this.MoveToAttribute(name);
		}

		public override bool MoveToAttribute(string name, string ns)
		{
			return this.MoveToAttribute(name, ns);
		}

		public override bool MoveToElement()
		{
			return this.MoveToElement();
		}

		public override bool MoveToFirstAttribute()
		{
			return this.MoveToFirstAttribute();
		}

		public override bool MoveToNextAttribute()
		{
			return this.MoveToNextAttribute();
		}

		public override bool Read()
		{
			return this.Read();
		}

		public override bool ReadAttributeValue()
		{
			return this.ReadAttributeValue();
		}

		public override void ResolveEntity()
		{
			this.ResolveEntity();
		}

		public override string BaseURI
		{
			get { return this.BaseURI; }
		}

		public override int Depth
		{
			get { return this.Depth; }
		}

		public override bool EOF
		{
			get { return this.EOF; }
		}

		public override bool IsEmptyElement
		{
			get { return this.IsEmptyElement; }
		}

		public override XmlNameTable NameTable
		{
			get { return this.NameTable;  }
		} 

		public override XmlNodeType NodeType
		{
			get { return this.NodeType;  }
		}

		public override ReadState ReadState
		{
			get { return this.ReadState; }
		}

		public override string Value
		{
			get { return this.Value;  }
		}

		public override string LocalName
		{
			get { return this.LocalName; }
		}

		public override string NamespaceURI
		{
			get { return this.NamespaceURI;  }
		}

		public override string Prefix
		{
			get { return this.Prefix;  }
		}


		public override int AttributeCount
		{
			get { return this.AttributeCount;  }
		}
	}
}