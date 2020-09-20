
using System;
using System.Xml.Serialization;


namespace VertSoft.Peppol.Sbdh
{
	[Serializable()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategory("code")]
	[XmlType(Namespace = "http://www.unece.org/cefact/namespaces/StandardBusinessDocumentHeader")]
	public class DocumentIdentification
	{
		public string Standard { get; set; }


		public string TypeVersion { get; set; }


		public string InstanceIdentifier { get; set; }


		public string Type { get; set; }


		public bool MultipleType { get; set; }


		[XmlIgnoreAttribute()]
		public bool MultipleTypeSpecified { get; set; }


		public DateTime CreationDateAndTime { get; set; }
	}
}
