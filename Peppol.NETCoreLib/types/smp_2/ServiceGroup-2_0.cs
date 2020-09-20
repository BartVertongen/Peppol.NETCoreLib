
using System.Xml.Serialization;
using VertSoft.Peppol.Types.Smp.ExtensionComponents;
using VertSoft.Peppol.Types.Smp.BasicComponents;
using VertSoft.Peppol.Types.Smp.AggregateComponents;
using VertSoft.Peppol.Types.Smp.Xmldsig;


namespace VertSoft.Peppol.Types.Smp.ServiceGroup_2
{
    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2/ServiceGroup")]
    [XmlRoot("ServiceGroup", Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2/ServiceGroup", IsNullable = false)]
    public class ServiceGroupType
    {
        [XmlArray(Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2/ExtensionComponents")]
        [XmlArrayItem("SMPExtension", IsNullable = false)]
        public SMPExtensionType[] SMPExtensions { get; set; }


		[XmlElement(Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2/BasicComponents")]
        public SMPVersionIDType SMPVersionID { get; set; }


		[XmlElement(Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2/BasicComponents")]
        public ParticipantIDType ParticipantID { get; set; }


		[XmlElement("ServiceReference", Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2/AggregateComponents")]
        public ServiceReferenceType[] ServiceReference { get; set; }


		[XmlElement("Signature", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
		public SignatureType[] Signature { get; set; }
    }
}