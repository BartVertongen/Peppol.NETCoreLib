
using System;
using System.Xml.Serialization;


namespace VertSoft.Peppol.Sbdh
{
	[Serializable()]
	[System.Diagnostics.DebuggerStepThrough()]
	[System.ComponentModel.DesignerCategory("code")]
	[XmlType(Namespace = "http://www.unece.org/cefact/namespaces/StandardBusinessDocumentHeader")]
	public class Partner
	{
		public PartnerIdentification Identifier { get; set; }


		[XmlElement("ContactInformation")]
		public ContactInformation[] ContactInformation { get; set; }
	}
}