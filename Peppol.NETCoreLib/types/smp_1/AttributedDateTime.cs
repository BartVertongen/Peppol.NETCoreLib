
using System.Xml.Serialization;


namespace VertSoft.Types.Smp_1.Wssecurity
{
	[System.Serializable()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[XmlType(Namespace = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd")]
	[XmlRoot("Expires", Namespace = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd", IsNullable = false)]
	public class AttributedDateTime
	{
		[XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, DataType = "ID")]
		public string Id { get; set; }

		[XmlAnyAttribute()]
		public System.Xml.XmlAttribute[] AnyAttr { get; set; }

		[XmlText()]
		public string Value { get; set; }
	}
}
