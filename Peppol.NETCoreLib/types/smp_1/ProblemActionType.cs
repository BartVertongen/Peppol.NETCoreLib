
using System.Xml;
using System.Xml.Serialization;
using VertSoft.Types.Smp_1.Addressing;

namespace Vertsoft.Types.Smp_1.Addressing
{
	[System.Serializable()]
	[System.Diagnostics.DebuggerStepThrough()]
	[System.ComponentModel.DesignerCategory("code")]
	[XmlType(Namespace = "http://www.w3.org/2005/08/addressing")]
	[XmlRoot("ProblemAction", Namespace = "http://www.w3.org/2005/08/addressing", IsNullable = false)]
	public class ProblemActionType
	{
		public AttributedURIType Action { get; set; }

		[XmlElement(DataType = "anyURI")]
		public string SoapAction { get; set; }

		[XmlAnyAttribute()]
		public XmlAttribute[] AnyAttr { get; set; }
	}
}
