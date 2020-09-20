
using System.Xml;
using System.Xml.Serialization;


namespace VertSoft.Peppol.Sbdh
{
	[System.Serializable()]
	[System.Diagnostics.DebuggerStepThrough()]
	[System.ComponentModel.DesignerCategory("code")]
	[XmlType(Namespace = "http://www.unece.org/cefact/namespaces/StandardBusinessDocumentHeader")]
	[XmlRoot(Namespace = "http://www.unece.org/cefact/namespaces/StandardBusinessDocumentHeader", IsNullable = false)]
	public class StandardBusinessDocumentHeader
	{
		public string HeaderVersion { get; set; }


		[XmlElement("Sender")]
		public Partner[] Sender { get; set; }


		[XmlElement("Receiver")]
		public Partner[] Receiver { get; set; }


		public DocumentIdentification DocumentIdentification { get; set; }


		public Manifest Manifest { get; set; }


		[XmlArrayItem(IsNullable = false)]
		public Scope[] BusinessScope { get; set; }
	}
}