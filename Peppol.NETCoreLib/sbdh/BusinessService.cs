using System;
using System.Xml.Serialization;


namespace VertSoft.Peppol.Sbdh.Businessscope
{
	[Serializable()]
	[System.Diagnostics.DebuggerStepThrough()]
	[System.ComponentModel.DesignerCategory("code")]
	[XmlTypeAttribute(Namespace = "http://www.unece.org/cefact/namespaces/StandardBusinessDocumentHeader")]
	[XmlRootAttribute(Namespace = "http://www.unece.org/cefact/namespaces/StandardBusinessDocumentHeader", IsNullable = false)]
	public class BusinessService
	{
		public string BusinessServiceName { get; set; }

		public ServiceTransaction ServiceTransaction { get; set; }
	}
}