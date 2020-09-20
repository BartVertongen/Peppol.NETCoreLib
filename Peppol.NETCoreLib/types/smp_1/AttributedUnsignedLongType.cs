
using System.Xml;
using System.Xml.Serialization;


namespace VertSoft.Types.Smp_1.Addressing
{
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[XmlType(Namespace = "http://www.w3.org/2005/08/addressing")]
	[XmlRoot("RetryAfter", Namespace = "http://www.w3.org/2005/08/addressing", IsNullable = false)]
	public class AttributedUnsignedLongType
	{
		[XmlAnyAttribute()]
		public XmlAttribute[] AnyAttr { get; set; }

		[XmlText()]
		public ulong Value { get; set; }
	}
}