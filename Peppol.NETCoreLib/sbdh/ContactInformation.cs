
using System;
using System.Xml.Serialization;


namespace VertSoft.Peppol.Sbdh
{
	[SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[XmlType(Namespace = "http://www.unece.org/cefact/namespaces/StandardBusinessDocumentHeader")]
	public class ContactInformation
	{
		public string Contact { get; set; }

		public string EmailAddress { get; set; }

		public string FaxNumber { get; set; }

		public string TelephoneNumber { get; set; }

		public string ContactTypeIdentifier { get; set; }
	}
}