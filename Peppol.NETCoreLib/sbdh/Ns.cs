

namespace VertSoft.Peppol.Sbdh
{
    public class QName
    {
        public string NamespaceURI { get; private set; }

        public string LocalPart { get; private set;  }

        public string Prefix { get; private set; }


        public QName(string namespaceuri, string localpart, string prefix = "")
        {
			this.NamespaceURI = namespaceuri;
			this.LocalPart = localpart;
			this.Prefix = prefix;
        }
    }


	/// <summary>
	/// Namespaces for SBDH
	/// </summary>
	public static class Ns
	{
		public const string SBDH = "http://www.unece.org/cefact/namespaces/StandardBusinessDocumentHeader";
		public const string EXTENSION = "http://peppol.eu/xsd/ticc/envelope/1.0";
		public static readonly QName QNAME_BINARY_CONTENT = new QName(EXTENSION, "BinaryContent");
		public static QName QNAME_TEXT_CONTENT = new QName(EXTENSION, "TextContent");
		public static readonly QName QNAME_SBD = new QName(SBDH, "StandardBusinessDocument");
		public static QName QNAME_SBDH = new QName(SBDH, "StandardBusinessDocumentHeader");
	}
}