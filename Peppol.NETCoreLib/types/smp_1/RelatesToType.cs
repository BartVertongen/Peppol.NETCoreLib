
using System.Xml;
using System.Xml.Serialization;


namespace Vertsoft.Types.Smp_1.Addressing
{
	[System.Serializable()]
	[System.Diagnostics.DebuggerStepThrough()]
	[System.ComponentModel.DesignerCategory("code")]
	[XmlType(Namespace = "http://www.w3.org/2005/08/addressing")]
	[XmlRoot("RelatesTo", Namespace = "http://www.w3.org/2005/08/addressing", IsNullable = false)]
	public class RelatesToType
	{
		[XmlAttribute()]
		[System.ComponentModel.DefaultValue("http://www.w3.org/2005/08/addressing/reply")]
		public string RelationshipType { get; set; } = "http://www.w3.org/2005/08/addressing/reply";


		[XmlAnyAttribute()]
		public XmlAttribute[] AnyAttr { get; set; }


		[XmlText(DataType = "anyURI")]
		public string Value { get; set; }
	}
}