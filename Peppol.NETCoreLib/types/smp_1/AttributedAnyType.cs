
using System.Xml;
using System.Xml.Serialization;


namespace VertSoft.Types.Smp_1.Addressing
{
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThrough()]
	[System.ComponentModel.DesignerCategory("code")]
	[XmlType(Namespace = "http://www.w3.org/2005/08/addressing")]
	[XmlRoot("ProblemHeader", Namespace = "http://www.w3.org/2005/08/addressing", IsNullable = false)]
	public class AttributedAnyType
	{
		[XmlAnyElement()]
		public XmlElement Any { get; set; }


		[XmlAnyAttribute()]
		public XmlAttribute[] AnyAttr { get; set; }
	}
}
