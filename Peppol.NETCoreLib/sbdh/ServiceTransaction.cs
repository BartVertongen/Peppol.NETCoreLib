
using System;
using System.Xml.Serialization;


namespace VertSoft.Peppol.Sbdh.Businessscope
{
	[Serializable()]
	[XmlTypeAttribute(Namespace = "http://www.unece.org/cefact/namespaces/StandardBusinessDocumentHeader")]
	public enum TypeOfServiceTransaction { RequestingServiceTransaction, RespondingServiceTransaction }


	[Serializable()]
	[System.Diagnostics.DebuggerStepThrough()]
	[System.ComponentModel.DesignerCategory("code")]
	[XmlTypeAttribute(Namespace = "http://www.unece.org/cefact/namespaces/StandardBusinessDocumentHeader")]
	public class ServiceTransaction
	{
		[XmlAttribute()]
		public TypeOfServiceTransaction TypeOfServiceTransaction { get; set; }


		[XmlIgnore()]
		public bool TypeOfServiceTransactionSpecified { get; set; }


		[XmlAttributeAttribute()]
		public string IsNonRepudiationRequired { get; set; }


		[XmlAttributeAttribute()]
		public string IsAuthenticationRequired { get; set; }


		[XmlAttributeAttribute()]
		public string IsNonRepudiationOfReceiptRequired { get; set; }


		[XmlAttribute()]
		public string IsIntelligibleCheckRequired { get; set; }


		[XmlAttribute()]
		public string IsApplicationErrorResponseRequested { get; set; }


		[XmlAttributeAttribute()]
		public string TimeToAcknowledgeReceipt { get; set; }


		[XmlAttributeAttribute()]
		public string TimeToAcknowledgeAcceptance { get; set; }


		[XmlAttributeAttribute()]
		public string TimeToPerform { get; set; }


		[XmlAttributeAttribute()]
		public string Recurrence { get; set; }
	}
}
