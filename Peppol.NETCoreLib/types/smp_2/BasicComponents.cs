
using VertSoft.Peppol.Types.Smp.UnqualifiedDataTypes;
using System.Xml.Serialization;


namespace VertSoft.Peppol.Types.Smp.BasicComponents
{
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2/BasicComponents")]
    [XmlRootAttribute("RoleID", Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2/BasicComponents", IsNullable = false)]
    public class RoleIDType : IdentifierType1
    {
    }


    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2/BasicComponents")]
    [XmlRoot("TypeCode", Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2/BasicComponents", IsNullable = false)]
    public class TypeCodeType : CodeType1
    {
    }


    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2/BasicComponents")]
    [XmlRoot("Description", Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2/BasicComponents", IsNullable = false)]
    public class DescriptionType : TextType1
    {
    }


    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2/BasicComponents")]
    [XmlRoot("Contact", Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2/BasicComponents", IsNullable = false)]
    public class ContactType : TextType1
    {
    }


    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2/BasicComponents")]
    [XmlRootAttribute("TransportProfileID", Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2/BasicComponents", IsNullable = false)]
    public class TransportProfileIDType : IdentifierType1
    {
    }


    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2/BasicComponents")]
    [XmlRoot("SMPVersionID", Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2/BasicComponents", IsNullable = false)]
    public class SMPVersionIDType : IdentifierType1
    {
    }


    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2/BasicComponents")]
    [XmlRoot("PublisherURI", Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2/BasicComponents", IsNullable = false)]
    public class PublisherURIType : IdentifierType1
    {
    }


    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2/BasicComponents")]
    [XmlRoot("ParticipantID", Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2/BasicComponents", IsNullable = false)]
    public class ParticipantIDType : IdentifierType1
    {
    }


    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2/BasicComponents")]
    [XmlRoot("AddressURI", Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2/BasicComponents", IsNullable = false)]
    public class AddressURIType : IdentifierType1
    {
    }


    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2/BasicComponents")]
    [XmlRoot("ActivationDate", Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2/BasicComponents", IsNullable = false)]
    public class ActivationDateType : DateType
    {
    }


    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2/BasicComponents")]
    [XmlRootAttribute("ContentBinaryObject", Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2/BasicComponents", IsNullable = false)]
    public class ContentBinaryObjectType : BinaryObjectType1
    {
    }


    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2/BasicComponents")]
    [XmlRootAttribute("ExpirationDate", Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2/BasicComponents", IsNullable = false)]
    public class ExpirationDateType : DateType
    {
    }
}