﻿
using System.Xml;
using System.Xml.Serialization;


namespace VertSoft.Types.Smp_1.Addressing
{
	[System.Serializable()]
	[System.Diagnostics.DebuggerStepThrough()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[XmlType(Namespace = "http://www.w3.org/2005/08/addressing")]
	[XmlRoot("Metadata", Namespace = "http://www.w3.org/2005/08/addressing", IsNullable = false)]
	public class MetadataType
	{
		[XmlAnyElement()]
		public XmlElement[] Any { get; set; }

		[XmlAnyAttribute()]
		public XmlAttribute[] AnyAttr { get; set; }
	}
}