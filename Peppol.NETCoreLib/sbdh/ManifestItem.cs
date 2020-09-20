
using System.Xml.Serialization;


namespace VertSoft.Peppol.Sbdh
{
	[System.Serializable()]
	[System.Diagnostics.DebuggerStepThrough()]
	[System.ComponentModel.DesignerCategory("code")]
	[XmlType(Namespace = "http://www.unece.org/cefact/namespaces/StandardBusinessDocumentHeader")]
	public class ManifestItem
	{
		public string MimeTypeQualifierCode { get; set; }


		[XmlElement(DataType = "anyURI")]
		public string UniformResourceIdentifier { get; set; }


		public string Description { get; set; }


		public string LanguageCode { get; set; }
	}
}