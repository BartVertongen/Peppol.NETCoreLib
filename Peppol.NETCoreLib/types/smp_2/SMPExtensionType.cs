
using System.Xml.Serialization;
using VertSoft.Peppol.Types.Smp.BasicComponents;


namespace VertSoft.Peppol.Types.Smp.ExtensionComponents
 {      
    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2/ExtensionComponents")]
    [XmlRoot("SMPExtension", Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2/ExtensionComponents", IsNullable = false)]
    public class SMPExtensionType
    {
        [XmlElement(Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2/BasicComponents")]
        public IDType ID { get; set; }

		public NameType1 Name { get; set; }

		public ExtensionAgencyIDType ExtensionAgencyID { get; set; }

		public ExtensionAgencyNameType ExtensionAgencyName { get; set; }

		public ExtensionVersionIDType ExtensionVersionID { get; set; }

		public ExtensionAgencyURIType ExtensionAgencyURI { get; set; }

		public ExtensionURIType ExtensionURI { get; set; }

		public ExtensionReasonCodeType ExtensionReasonCode { get; set; }

		public ExtensionReasonType ExtensionReason { get; set; }

		public System.Xml.XmlElement ExtensionContent { get; set; }
    }
 }