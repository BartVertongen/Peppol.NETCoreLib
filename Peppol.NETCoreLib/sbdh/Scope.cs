
using System.Xml.Serialization;


namespace VertSoft.Peppol.Sbdh
{
	[System.Serializable()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[XmlTypeAttribute(Namespace = "http://www.unece.org/cefact/namespaces/StandardBusinessDocumentHeader")]
	public class Scope
	{
		public string Type { get; set; }


		public string InstanceIdentifier { get; set; }


		public string Identifier { get; set; }


		[XmlElement("ScopeInformation")]
		public object[] ScopeInformation { get; set; }
	}
}