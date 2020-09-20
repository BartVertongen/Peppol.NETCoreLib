
using System.Xml.Serialization;
using VertSoft.Peppol.Types.Smp.BasicComponents;
using VertSoft.Peppol.Types.Smp.ExtensionComponents;


namespace VertSoft.Peppol.Types.Smp.AggregateComponents
{
    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2/AggregateComponents")]
    [XmlRoot("Process", Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2/AggregateComponents", IsNullable = false)]
    public class ProcessType
    {
        [XmlArray(Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2/ExtensionComponents")]
        [XmlArrayItem("SMPExtension", IsNullable = false)]
        public SMPExtensionType[] SMPExtensions { get; set; }


		[XmlElement(Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2/BasicComponents")]
        public IDType ID { get; set; }


		[XmlElement("RoleID", Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2/BasicComponents")]
		public RoleIDType[] RoleID { get; set; }
    }


    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2/AggregateComponents")]
    [XmlRoot("ServiceReference", Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2/AggregateComponents", IsNullable = false)]
    public class ServiceReferenceType
    {
        [XmlArray(Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2/ExtensionComponents")]
        [XmlArrayItem("SMPExtension", IsNullable = false)]
        public SMPExtensionType[] SMPExtensions { get; set; }


		[XmlElement(Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2/BasicComponents")]
        public IDType ID { get; set; }


		[XmlElement("Process")]
        public ProcessType[] Process { get; set; }
	}


    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2/AggregateComponents")]
    [XmlRoot("Certificate", Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2/AggregateComponents", IsNullable = false)]
    public class CertificateType
    {
        [XmlArray(Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2/ExtensionComponents")]
        [XmlArrayItem("SMPExtension", IsNullable = false)]
        public SMPExtensionType[] SMPExtensions { get; set; }


		[XmlElement(Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2/BasicComponents")]
        public TypeCodeType TypeCode { get; set; }


		[XmlElement(Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2/BasicComponents")]
        public DescriptionType Description { get; set; }


		[XmlElement(Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2/BasicComponents")]
        public ActivationDateType ActivationDate { get; set; }


		[XmlElement(Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2/BasicComponents")]
        public ExpirationDateType ExpirationDate { get; set; }


		[XmlElement(Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2/BasicComponents")]
		public ContentBinaryObjectType ContentBinaryObject { get; set; }
    }


    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2/AggregateComponents")]
    [XmlRoot("Endpoint", Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2/AggregateComponents", IsNullable = false)]
    public class EndpointType
    {
        [XmlArray(Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2/ExtensionComponents")]
		[XmlArrayItem("SMPExtension", IsNullable = false)]
		public SMPExtensionType[] SMPExtensions { get; set; }


        [XmlElement(Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2/BasicComponents")]
        public TransportProfileIDType TransportProfileID { get; set; }


		[XmlElement(Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2/BasicComponents")]
        public DescriptionType Description { get; set; }


		[XmlElement(Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2/BasicComponents")]
        public ContactType Contact { get; set; }


		[XmlElement(Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2/BasicComponents")]
        public AddressURIType AddressURI { get; set; }


		[XmlElement(Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2/BasicComponents")]
        public ActivationDateType ActivationDate { get; set; }


		[XmlElement(Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2/BasicComponents")]
        public ExpirationDateType ExpirationDate { get; set; }


		[XmlElement("Certificate")]
        public CertificateType[] Certificate { get; set; }
	}


    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2/AggregateComponents")]
    [XmlRoot("ProcessMetadata", Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2/AggregateComponents", IsNullable = false)]
    public class ProcessMetadataType
    {
        [XmlArray(Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2/ExtensionComponents")]
        [XmlArrayItem("SMPExtension", IsNullable = false)]
        public SMPExtensionType[] SMPExtensions { get; set; }


		[XmlElement("Process")]
        public ProcessType[] Process { get; set; }


		[XmlElement("Endpoint")]
        public EndpointType[] Endpoint { get; set; }


		public RedirectType Redirect { get; set; }
	}


    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2/AggregateComponents")]
    [XmlRoot("Redirect", Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2/AggregateComponents", IsNullable = false)]
    public class RedirectType
    {
        [XmlArray(Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2/ExtensionComponents")]
        [XmlArrayItem("SMPExtension", IsNullable = false)]
        public SMPExtensionType[] SMPExtensions { get; set; }


		[XmlElement(Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2/BasicComponents")]
        public PublisherURIType PublisherURI { get; set; }


		[XmlElement("Certificate")]
        public CertificateType[] Certificate { get; set; }
	}    
}