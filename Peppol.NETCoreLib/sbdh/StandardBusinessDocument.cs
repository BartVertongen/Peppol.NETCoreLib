
using System;
using System.Xml;
using System.Xml.Serialization;


namespace VertSoft.Peppol.Sbdh
{
	[Serializable()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[XmlType(Namespace = "http://www.unece.org/cefact/namespaces/StandardBusinessDocumentHeader")]
	[XmlRoot(Namespace = "http://www.unece.org/cefact/namespaces/StandardBusinessDocumentHeader", IsNullable = false)]
	public class StandardBusinessDocument
	{
		public StandardBusinessDocumentHeader StandardBusinessDocumentHeader { get; set; }


		[XmlAnyElement()]
		public XmlElement Any { get; set; }
	}
}