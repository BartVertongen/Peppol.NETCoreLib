
using System.Xml.Serialization;


namespace VertSoft.Types.Smp_1.Wssecurity
{
	[System.Serializable()]
	[System.Diagnostics.DebuggerStepThrough()]
	[System.ComponentModel.DesignerCategory("code")]
	[XmlType(Namespace = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd")]
	[XmlRoot("Timestamp", Namespace = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd", IsNullable = false)]
	public class TimestampType
	{
		public AttributedDateTime Created { get; set; }

		public AttributedDateTime Expires { get; set; }

		[XmlAnyElement()]
		public System.Xml.XmlElement[] Items { get; set; }


		[XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, DataType = "ID")]
		public string Id { get; set; }


		[XmlAnyAttribute()]
		public System.Xml.XmlAttribute[] AnyAttr { get; set; }
	}
}
