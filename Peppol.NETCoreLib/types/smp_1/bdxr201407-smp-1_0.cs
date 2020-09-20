
using System.Xml.Serialization;
using VertSoft.Peppol.Types.Smp.Xmldsig;


namespace VertSoft.Types.Smp.Publishing.Bdxr201407
{
	[System.Serializable()]
	[System.Diagnostics.DebuggerStepThrough()]
	[System.ComponentModel.DesignerCategory("code")]
	[XmlType(Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2014/07")]
	[XmlRoot("ServiceGroup", Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2014/07", IsNullable = false)]
	public class ServiceGroupType
	{
		public ParticipantIdentifierType ParticipantIdentifier { get; set; }

		[XmlArrayItem("ServiceMetadataReference", IsNullable = false)]
		public ServiceMetadataReferenceType[] ServiceMetadataReferenceCollection { get; set; }

		public System.Xml.XmlElement Extension { get; set; }
	}


	[System.Serializable()]
	[System.Diagnostics.DebuggerStepThrough()]
	[System.ComponentModel.DesignerCategory("code")]
	[XmlType(Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2014/07")]
	[XmlRoot("ParticipantIdentifier", Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2014/07", IsNullable = false)]
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
	[XmlType(Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2014/07")]
	public class RedirectType
	{
		public string CertificateUID { get; set; }

		public System.Xml.XmlElement Extension { get; set; }

		[XmlAttribute(DataType = "anyURI")]
		public string href { get; set; }
	}


	[System.Serializable()]
	[System.Diagnostics.DebuggerStepThrough()]
	[System.ComponentModel.DesignerCategory("code")]
	[XmlType(Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2014/07")]
	public class EndpointType
	{
		[XmlElement(DataType = "anyURI")]
		public string EndpointURI { get; set; }

		public bool RequireBusinessLevelSignature { get; set; }

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


		public System.Xml.XmlElement Extension { get; set; }


		[XmlAttribute()]
		public string transportProfile { get; set; }
	}


	[System.Serializable()]
	[System.Diagnostics.DebuggerStepThrough()]
	[System.ComponentModel.DesignerCategory("code")]
	[XmlType(Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2014/07")]
	public class ProcessType
	{
		public ProcessIdentifierType ProcessIdentifier { get; set; }


		[XmlArrayItem("Endpoint", IsNullable = false)]
		public EndpointType[] ServiceEndpointList { get; set; }


		public System.Xml.XmlElement Extension { get; set; }
	}


	[System.Serializable()]
	[System.Diagnostics.DebuggerStepThrough()]
	[System.ComponentModel.DesignerCategory("code")]
	[XmlType(Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2014/07")]
	[XmlRoot("ProcessIdentifier", Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2014/07", IsNullable = false)]
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
	[XmlType(Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2014/07")]
	public class ServiceInformationType
	{
		public ParticipantIdentifierType ParticipantIdentifier { get; set; }

		public DocumentIdentifierType DocumentIdentifier { get; set; }

		[XmlArrayItem("Process", IsNullable = false)]
		public ProcessType[] ProcessList { get; set; }

		public System.Xml.XmlElement Extension { get; set; }
	}


	[System.Serializable()]
	[System.Diagnostics.DebuggerStepThrough()]
	[System.ComponentModel.DesignerCategory("code")]
	[XmlType(Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2014/07")]
	[XmlRoot("DocumentIdentifier", Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2014/07", IsNullable = false)]
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
	[XmlType(Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2014/07")]
	public class ServiceMetadataReferenceType
	{
		[XmlAttribute(DataType = "anyURI")]
		public string href { get; set; }
	}


	[System.Serializable()]
	[System.Diagnostics.DebuggerStepThrough()]
	[System.ComponentModel.DesignerCategory("code")]
	[XmlType(Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2014/07")]
	[XmlRoot("ServiceMetadata", Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2014/07", IsNullable = false)]
	public class ServiceMetadataType
	{
		[XmlElement("Redirect", typeof(RedirectType))]
		[XmlElement("ServiceInformation", typeof(ServiceInformationType))]
		public object Item { get; set; }
	}


	[System.Serializable()]
	[System.Diagnostics.DebuggerStepThrough()]
	[System.ComponentModel.DesignerCategory("code")]
	[XmlType(Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2014/07")]
	[XmlRoot("SignedServiceMetadata", Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2014/07", IsNullable = false)]
	public class SignedServiceMetadataType
	{
		public ServiceMetadataType ServiceMetadata { get; set; }


		[XmlElement(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
		public SignatureType Signature { get; set; }
	}
}