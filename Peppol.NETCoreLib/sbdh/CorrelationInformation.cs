
using System;
using System.Xml.Serialization;


namespace VertSoft.Peppol.Sbdh.Businessscope
{
	[SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[XmlType(Namespace = "http://www.unece.org/cefact/namespaces/StandardBusinessDocumentHeader")]
	[XmlRoot(Namespace = "http://www.unece.org/cefact/namespaces/StandardBusinessDocumentHeader", IsNullable = false)]
	public class CorrelationInformation
	{
		public DateTime RequestingDocumentCreationDateTime { get; set; }


		[XmlIgnoreAttribute()]
		public bool RequestingDocumentCreationDateTimeSpecified { get; set; }


		public string RequestingDocumentInstanceIdentifier { get; set; }


		public DateTime ExpectedResponseDateTime { get; set; }


		[XmlIgnoreAttribute()]
		public bool ExpectedResponseDateTimeSpecified { get; set; }
	}
}