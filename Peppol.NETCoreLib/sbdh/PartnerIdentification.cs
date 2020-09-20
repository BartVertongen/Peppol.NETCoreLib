
using System;
using System.Xml.Serialization;


namespace VertSoft.Peppol.Sbdh
{
	[Serializable()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[XmlType(Namespace = "http://www.unece.org/cefact/namespaces/StandardBusinessDocumentHeader")]
	public class PartnerIdentification
	{
		[XmlAttribute()]
		public string Authority { get; set; }


		[XmlText()]
		public string Value { get; set; }
	}
}