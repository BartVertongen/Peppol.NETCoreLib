
using VertSoft.Peppol.Types.Smp.Xmldsig;
using System.Xml.Serialization;


namespace VertSoft.Types.Smp.Publishing.Bdxr201605
{
	[System.Serializable()]
	[System.Diagnostics.DebuggerStepThrough()]
	[System.ComponentModel.DesignerCategory("code")]
	[XmlType(Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2016/05")]
	[XmlRoot("ServiceGroup", Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2016/05", IsNullable = false)]
	public class ServiceGroupType
	{
		public ParticipantIdentifierType ParticipantIdentifier { get; set; }


		[XmlArrayItem("ServiceMetadataReference", IsNullable = false)]
		public ServiceMetadataReferenceType[] ServiceMetadataReferenceCollection { get; set; }


		[XmlElement("Extension")]
		public ExtensionType[] Extension { get; set; }
	}


	[System.Serializable()]
	[System.Diagnostics.DebuggerStepThrough()]
	[System.ComponentModel.DesignerCategory("code")]
	[XmlType(Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2016/05")]
	[XmlRoot("ParticipantIdentifier", Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2016/05", IsNullable = false)]
	public class ParticipantIdentifierType
	{
		[XmlAttribute()]
		public string scheme { get; set; }

		[XmlText()]
		public string Value { get; set; }
	}


	[System.Serializable()]
	[System.Diagnostics.DebuggerStepThrough()]
	[System.ComponentModel.DesignerCategory("code")]
	[XmlType(Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2016/05")]
	public class RedirectType
	{
		public string CertificateUID { get; set; }

		[XmlElement("Extension")]
		public ExtensionType[] Extension { get; set; }

		[XmlAttribute(DataType = "anyURI")]
		public string href { get; set; }
	}


	[System.Serializable()]
	[System.Diagnostics.DebuggerStepThrough()]
	[System.ComponentModel.DesignerCategory("code")]
	[XmlType(Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2016/05")]
	public class ExtensionType
	{
		[XmlElement(DataType = "token")]
		public string ExtensionID { get; set; }

		public string ExtensionName { get; set; }

		public string ExtensionAgencyID { get; set; }

		public string ExtensionAgencyName { get; set; }


		[XmlElement(DataType = "anyURI")]
		public string ExtensionAgencyURI { get; set; }

		[XmlElement(DataType = "normalizedString")]
		public string ExtensionVersionID { get; set; }

		[XmlElement(DataType = "anyURI")]
		public string ExtensionURI { get; set; }


		[XmlElement(DataType = "token")]
		public string ExtensionReasonCode { get; set; }

		public string ExtensionReason { get; set; }

		[XmlAnyElement()]
		public System.Xml.XmlElement Any { get; set; }
	}


	[System.Serializable()]
	[System.Diagnostics.DebuggerStepThrough()]
	[System.ComponentModel.DesignerCategory("code")]
	[XmlType(Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2016/05")]
	public class EndpointType
	{
		[XmlElement(DataType = "anyURI")]
		public string EndpointURI { get; set; }

		[System.ComponentModel.DefaultValue(false)]
		public bool RequireBusinessLevelSignature { get; set; } = false;

		public string MinimumAuthenticationLevel { get; set; }

		public System.DateTime ServiceActivationDate { get; set; }

		[XmlIgnore()]
		public bool ServiceActivationDateSpecified { get; set; }

		public System.DateTime ServiceExpirationDate { get; set; }

		[XmlIgnore()]
		public bool ServiceExpirationDateSpecified { get; set; }

		[XmlElement(DataType = "base64Binary")]
		public byte[] Certificate { get; set; }

		public string ServiceDescription { get; set; }

		[XmlElement(DataType = "anyURI")]
		public string TechnicalContactUrl { get; set; }


		[XmlElement(DataType = "anyURI")]
		public string TechnicalInformationUrl { get; set; }

		[XmlElement("Extension")]
		public ExtensionType[] Extension { get; set; }

		[XmlAttribute()]
		public string transportProfile { get; set; }
	}


	[System.Serializable()]
	[System.Diagnostics.DebuggerStepThrough()]
	[System.ComponentModel.DesignerCategory("code")]
	[XmlType(Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2016/05")]
	public class ProcessType
	{
		public ProcessIdentifierType ProcessIdentifier { get; set; }

		[XmlArrayItem("Endpoint", IsNullable = false)]
		public EndpointType[] ServiceEndpointList { get; set; }


		[XmlElement("Extension")]
		public ExtensionType[] Extension { get; set; }
	}


	[System.Serializable()]
	[System.Diagnostics.DebuggerStepThrough()]
	[System.ComponentModel.DesignerCategory("code")]
	[XmlType(Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2016/05")]
	[XmlRoot("ProcessIdentifier", Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2016/05", IsNullable = false)]
	public class ProcessIdentifierType
	{
		[XmlAttribute()]
		public string scheme { get; set; }

		[XmlText()]
		public string Value { get; set; }
	}


	[System.Serializable()]
	[System.Diagnostics.DebuggerStepThrough()]
	[System.ComponentModel.DesignerCategory("code")]
	[XmlType(Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2016/05")]
	public class ServiceInformationType
	{
		public ParticipantIdentifierType ParticipantIdentifier { get; set; }

		public DocumentIdentifierType DocumentIdentifier { get; set; }

		[XmlArrayItem("Process", IsNullable = false)]
		public ProcessType[] ProcessList { get; set; }

		[XmlElement("Extension")]
		public ExtensionType[] Extension { get; set; }
	}


	[System.Serializable()]
	[System.Diagnostics.DebuggerStepThrough()]
	[System.ComponentModel.DesignerCategory("code")]
	[XmlType(Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2016/05")]
	[XmlRoot("DocumentIdentifier", Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2016/05", IsNullable = false)]
	public class DocumentIdentifierType
	{
		[XmlAttribute()]
		public string scheme { get; set; }

		[XmlText()]
		public string Value { get; set; }
	}


	[System.Serializable()]
	[System.Diagnostics.DebuggerStepThrough()]
	[System.ComponentModel.DesignerCategory("code")]
	[XmlType(Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2016/05")]
	public class ServiceMetadataReferenceType
	{
		[XmlAttribute(DataType = "anyURI")]
		public string href { get; set; }
	}


	[System.Serializable()]
	[System.Diagnostics.DebuggerStepThrough()]
	[System.ComponentModel.DesignerCategory("code")]
	[XmlType(Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2016/05")]
	[XmlRoot("ServiceMetadata", Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2016/05", IsNullable = false)]
	public class ServiceMetadataType
	{
		[XmlElement("Redirect", typeof(RedirectType))]
		[XmlElement("ServiceInformation", typeof(ServiceInformationType))]
		public object Item { get; set; }
	}


	[System.Serializable()]
	[System.Diagnostics.DebuggerStepThrough()]
	[System.ComponentModel.DesignerCategory("code")]
	[XmlType(Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2016/05")]
	[XmlRoot("SignedServiceMetadata", Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2016/05", IsNullable = false)]
	public class SignedServiceMetadataType
	{
		public ServiceMetadataType ServiceMetadata { get; set; }

		[XmlElement(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
		public SignatureType Signature { get; set; }
	}
}