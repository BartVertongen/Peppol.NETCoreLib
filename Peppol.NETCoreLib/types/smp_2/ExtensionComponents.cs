
using System.Xml.Serialization;
using VertSoft.Peppol.Types.Smp.UnqualifiedDataTypes;


namespace VertSoft.Peppol.Types.Smp.ExtensionComponents
{ 
    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2/ExtensionComponents")]
    [XmlRoot("ExtensionReasonCode", Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2/ExtensionComponents", IsNullable = false)]
    public class ExtensionReasonCodeType : CodeType1
    {
    }


    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2/ExtensionComponents")]
    [XmlRoot("ExtensionAgencyName", Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2/ExtensionComponents", IsNullable = false)]
    public class ExtensionAgencyNameType : NameType
    {
    }


    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(TypeName = "NameType", Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2/ExtensionComponents")]
    [XmlRoot("Name", Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2/ExtensionComponents", IsNullable = false)]
    public partial class NameType1 : NameType
    {
    }


    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2/ExtensionComponents")]
    [XmlRootAttribute("ExtensionReason", Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2/ExtensionComponents", IsNullable = false)]
    public class ExtensionReasonType : TextType1
    {
    }


    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2/ExtensionComponents")]
    [XmlRoot("ExtensionVersionID", Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2/ExtensionComponents", IsNullable = false)]
    public class ExtensionVersionIDType : IdentifierType1
    {
    }


    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2/ExtensionComponents")]
    [XmlRoot("ExtensionURI", Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2/ExtensionComponents", IsNullable = false)]
    public class ExtensionURIType : IdentifierType1
    {
    }


    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2/ExtensionComponents")]
    [XmlRoot("ExtensionAgencyURI", Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2/ExtensionComponents", IsNullable = false)]
    public class ExtensionAgencyURIType : IdentifierType1
    {
    }


    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2/ExtensionComponents")]
    [XmlRoot("ExtensionAgencyID", Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2/ExtensionComponents", IsNullable = false)]
    public class ExtensionAgencyIDType : IdentifierType1
    {
    }


    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2/ExtensionComponents")]
    [XmlRoot("SMPExtensions", Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2/ExtensionComponents", IsNullable = false)]
    public class SMPExtensionsType
    {
        [XmlElement("SMPExtension")]
		public SMPExtensionType[] SMPExtension { get; set; }
    }
}