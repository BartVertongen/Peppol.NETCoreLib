
using System.Xml.Serialization;
using VertSoft.Types.Smp.Identifiers_1.Busdox;
using VertSoft.Peppol.Types.Smp.Xmldsig;
using VertSoft.Types.Smp_1.Addressing;


namespace VertSoft.Types.Smp.Publishing.Busdox
{
    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(Namespace="http://busdox.org/serviceMetadata/publishing/1.0/")]
    [XmlRoot("ServiceGroup", Namespace="http://busdox.org/serviceMetadata/publishing/1.0/", IsNullable=false)]
    public class ServiceGroupType 
    {      
        [XmlElement(Namespace = "http://busdox.org/transport/identifiers/1.0/")]
		public ParticipantIdentifierType ParticipantIdentifier { get; set; }
        
        [XmlArrayItem("ServiceMetadataReference", IsNullable=false)]
        public ServiceMetadataReferenceType[] ServiceMetadataReferenceCollection { get; set; }

		public System.Xml.XmlElement Extension { get; set; }
	}


    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(Namespace="http://busdox.org/serviceMetadata/publishing/1.0/")]
    public class RedirectType 
    {        
        public string CertificateUID { get; set; }


		public System.Xml.XmlElement Extension { get; set; }


		[XmlAttribute(DataType="anyURI")]
        public string href { get; set; }
	}



    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(Namespace="http://busdox.org/serviceMetadata/publishing/1.0/")]
    public class EndpointType 
    {       
        [XmlElement(Namespace="http://www.w3.org/2005/08/addressing")]
        public EndpointReferenceType EndpointReference { get; set; }


		public bool RequireBusinessLevelSignature { get; set; }


		public string MinimumAuthenticationLevel { get; set; }


		public System.DateTime ServiceActivationDate { get; set; }


		[XmlIgnore()]
        public bool ServiceActivationDateSpecified { get; set; }


		public System.DateTime ServiceExpirationDate { get; set; }


		[XmlIgnore()]
        public bool ServiceExpirationDateSpecified { get; set; }


		public string Certificate { get; set; }


		public string ServiceDescription { get; set; }


		[XmlElement(DataType="anyURI")]
        public string TechnicalContactUrl { get; set; }


		[XmlElement(DataType="anyURI")]
        public string TechnicalInformationUrl { get; set; }


		public System.Xml.XmlElement Extension { get; set; }


		[XmlAttribute()]
        public string transportProfile { get; set; }
	}




    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(Namespace="http://busdox.org/serviceMetadata/publishing/1.0/")]
    public class ProcessType 
    {
        [XmlElement(Namespace="http://busdox.org/transport/identifiers/1.0/")]
        public ProcessIdentifierType ProcessIdentifier { get; set; }

		[XmlArrayItem("Endpoint", IsNullable=false)]
        public EndpointType[] ServiceEndpointList { get; set; }

		public System.Xml.XmlElement Extension { get; set; }
	}


    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(Namespace="http://busdox.org/serviceMetadata/publishing/1.0/")]
    public class ServiceInformationType 
    {        
        [XmlElement(Namespace="http://busdox.org/transport/identifiers/1.0/")]
        public ParticipantIdentifierType ParticipantIdentifier { get; set; }


		[XmlElement(Namespace="http://busdox.org/transport/identifiers/1.0/")]
        public DocumentIdentifierType DocumentIdentifier { get; set; }


		[XmlArrayItem("Process", IsNullable=false)]
        public ProcessType[] ProcessList { get; set; }


		public System.Xml.XmlElement Extension { get; set; }
	}


    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(Namespace="http://busdox.org/serviceMetadata/publishing/1.0/")]
    public class ServiceMetadataReferenceType 
    {        
        [XmlAttribute(DataType="anyURI")]
        public string href { get; set; }
	}


    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(Namespace="http://busdox.org/serviceMetadata/publishing/1.0/")]
    [XmlRoot("ServiceMetadata", Namespace="http://busdox.org/serviceMetadata/publishing/1.0/", IsNullable=false)]
    public class ServiceMetadataType 
    {        
        [XmlElement("Redirect", typeof(RedirectType))]
        [XmlElement("ServiceInformation", typeof(ServiceInformationType))]
        public object Item { get; set; }
	}


    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(Namespace="http://busdox.org/serviceMetadata/publishing/1.0/")]
    [XmlRoot("SignedServiceMetadata", Namespace="http://busdox.org/serviceMetadata/publishing/1.0/", IsNullable=false)]
    public class SignedServiceMetadataType 
    {                
        public ServiceMetadataType ServiceMetadata { get; set; }

		[XmlElement(Namespace="http://www.w3.org/2000/09/xmldsig#")]
        public SignatureType Signature { get; set; }
	}
}