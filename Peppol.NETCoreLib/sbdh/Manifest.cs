
using System.Xml.Serialization;

namespace VertSoft.Peppol.Sbdh
{
	[System.Serializable()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategory("code")]
	[XmlType(Namespace = "http://www.unece.org/cefact/namespaces/StandardBusinessDocumentHeader")]
	public class Manifest
	{
		[XmlElement(DataType = "integer")]
		public string NumberOfItems { get; set; }


		[XmlElement("ManifestItem")]
		public ManifestItem[] ManifestItem { get; set; }
	}
}