
using System.Xml.Serialization;
using VertSoft.Peppol.Types.Smp.BasicComponents;
using VertSoft.Peppol.Types.Smp.CoreComponentTypeSchemaModule;
using VertSoft.Peppol.Types.Smp.ExtensionComponents;


namespace VertSoft.Peppol.Types.Smp.UnqualifiedDataTypes
{
    [XmlInclude(typeof(ExtensionVersionIDType))]
    [XmlInclude(typeof(ExtensionURIType))]
    [XmlInclude(typeof(ExtensionAgencyURIType))]
    [XmlInclude(typeof(ExtensionAgencyIDType))]
    [XmlInclude(typeof(TransportProfileIDType))]
    [XmlInclude(typeof(SMPVersionIDType))]
    [XmlInclude(typeof(RoleIDType))]
    [XmlInclude(typeof(PublisherURIType))]
    [XmlInclude(typeof(ParticipantIDType))]
    [XmlInclude(typeof(IDType))]
    [XmlInclude(typeof(AddressURIType))]
    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(TypeName = "IdentifierType", Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2/UnqualifiedDataTypes")]
    public class IdentifierType1 : IdentifierType
    {
    }
}