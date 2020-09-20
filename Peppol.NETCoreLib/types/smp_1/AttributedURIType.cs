
using System.Xml;
using System.Xml.Serialization;


namespace VertSoft.Types.Smp_1.Addressing
{

	[System.Serializable()]
	[System.Diagnostics.DebuggerStepThrough()]
	[System.ComponentModel.DesignerCategory("code")]
	[XmlType(Namespace = "http://www.w3.org/2005/08/addressing")]
	[XmlRoot("MessageID", Namespace = "http://www.w3.org/2005/08/addressing", IsNullable = false)]
	public class AttributedURIType
	{
		[XmlAnyAttribute()]
		public XmlAttribute[] AnyAttr { get; set; }


		[XmlText(DataType = "anyURI")]
		public string Value { get; set; }
	}
}
