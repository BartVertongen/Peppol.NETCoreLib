
using System.Xml;
using System.Xml.Serialization;


namespace VertSoft.Types.Smp_1.Addressing
{
	[System.Serializable()]
	[System.Diagnostics.DebuggerStepThrough()]
	[System.ComponentModel.DesignerCategory("code")]
	[XmlType(Namespace = "http://www.w3.org/2005/08/addressing")]
	[XmlRoot("EndpointReference", Namespace = "http://www.w3.org/2005/08/addressing", IsNullable = false)]
	public class EndpointReferenceType
	{
		public AttributedURIType Address { get; set; }

		public ReferenceParametersType ReferenceParameters { get; set; }

		public MetadataType Metadata { get; set; }

		[XmlAnyElement()]
		public XmlElement[] Any { get; set; }

		[XmlAnyAttribute()]
		public XmlAttribute[] AnyAttr { get; set; }
	}
}