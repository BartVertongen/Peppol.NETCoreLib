
using VertSoft.Peppol.Types.Smp.BasicComponents;
using VertSoft.Peppol.Types.Smp.CoreComponentTypeSchemaModule_2;
using VertSoft.Peppol.Types.Smp.ExtensionComponents;
using System.Xml.Serialization;


namespace VertSoft.Peppol.Types.Smp.UnqualifiedDataTypes
{
    [XmlIncludeAttribute(typeof(ExtensionReasonCodeType))]
    [XmlIncludeAttribute(typeof(TypeCodeType))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.3081.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(TypeName = "CodeType", Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2/UnqualifiedDataTypes")]
    public class CodeType1 : CodeType
    {
    }


    [XmlIncludeAttribute(typeof(ExtensionAgencyNameType))]
    [XmlIncludeAttribute(typeof(NameType1))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.3081.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2/UnqualifiedDataTypes")]
    public class NameType : TextType
    {
    }


    [XmlIncludeAttribute(typeof(ExtensionReasonType))]
    [XmlIncludeAttribute(typeof(DescriptionType))]
    [XmlIncludeAttribute(typeof(ContactType))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.3081.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(TypeName = "TextType", Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2/UnqualifiedDataTypes")]
    public class TextType1 : TextType
    {
    }


    [XmlIncludeAttribute(typeof(ExpirationDateType))]
    [XmlIncludeAttribute(typeof(ActivationDateType))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.3081.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2/UnqualifiedDataTypes")]
    public class DateType
    {
        [XmlTextAttribute(DataType = "date")]
		public System.DateTime Value { get; set; }
    }


    [XmlInclude(typeof(ContentBinaryObjectType))]
    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(TypeName = "BinaryObjectType", Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2/UnqualifiedDataTypes")]
    public class BinaryObjectType1 : BinaryObjectType
    {
    }


    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2/UnqualifiedDataTypes")]
    public class VideoType : BinaryObjectType
    {
    }


    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2/UnqualifiedDataTypes")]
    public class SoundType : BinaryObjectType
    {
    }


    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2/UnqualifiedDataTypes")]
    public class PictureType : BinaryObjectType
    {
    }


    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2/UnqualifiedDataTypes")]
    public class GraphicType : BinaryObjectType
    {
    }
}