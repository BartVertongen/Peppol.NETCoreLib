
using System.Xml;
using System.Xml.Serialization;


namespace VertSoft.Types.Smp_1.Addressing
{
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThrough()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[XmlType(Namespace = "http://www.w3.org/2005/08/addressing")]
	[XmlRoot("ProblemHeaderQName", Namespace = "http://www.w3.org/2005/08/addressing", IsNullable = false)]
	public class AttributedQNameType
	{
		[XmlAnyAttribute()]
		public XmlAttribute[] AnyAttr { get; set; }


		[XmlText()]
		public XmlQualifiedName Value { get; set; }
	}
}
