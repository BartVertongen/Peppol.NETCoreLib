
using VertSoft.Peppol.Types.Smp.BasicComponents;
using VertSoft.Peppol.Types.Smp.ExtensionComponents;
using VertSoft.Peppol.Types.Smp.UnqualifiedDataTypes;
using System.Xml.Serialization;


namespace VertSoft.Peppol.Types.Smp.CoreComponentTypeSchemaModule_2
{
    [XmlIncludeAttribute(typeof(CodeType1))]
    [XmlIncludeAttribute(typeof(ExtensionReasonCodeType))]
    [XmlIncludeAttribute(typeof(TypeCodeType))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.3081.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "urn:un:unece:uncefact:data:specification:CoreComponentTypeSchemaModule:2")]
    public class CodeType
    {
        [XmlAttributeAttribute(DataType = "normalizedString")]
		public string listID { get; set; }


        [XmlAttributeAttribute(DataType = "normalizedString")]
        public string listAgencyID { get; set; }


        [XmlAttributeAttribute()]
        public string listAgencyName { get; set; }


		[XmlAttributeAttribute()]
        public string listName { get; set; }


		[XmlAttributeAttribute(DataType = "normalizedString")]
        public string listVersionID { get; set; }


		[XmlAttributeAttribute()]
        public string name { get; set; }


		[XmlAttributeAttribute(DataType = "language")]
        public string languageID { get; set; }


		[XmlAttributeAttribute(DataType = "anyURI")]
        public string listURI { get; set; }


		[XmlAttributeAttribute(DataType = "anyURI")]
        public string listSchemeURI { get; set; }


		[XmlTextAttribute(DataType = "normalizedString")]
        public string Value { get; set; }
	} 


    [XmlIncludeAttribute(typeof(NameType))]
    [XmlIncludeAttribute(typeof(ExtensionAgencyNameType))]
    [XmlIncludeAttribute(typeof(NameType1))]
    [XmlIncludeAttribute(typeof(TextType1))]
    [XmlIncludeAttribute(typeof(ExtensionReasonType))]
    [XmlIncludeAttribute(typeof(DescriptionType))]
    [XmlIncludeAttribute(typeof(ContactType))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.3081.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "urn:un:unece:uncefact:data:specification:CoreComponentTypeSchemaModule:2")]
    public class TextType
    {
        [XmlAttributeAttribute(DataType = "language")]
        public string languageID { get; set; }


		[XmlAttributeAttribute(DataType = "normalizedString")]
        public string languageLocaleID { get; set; }


		[XmlTextAttribute()]
        public string Value { get; set; }
    }


    [XmlIncludeAttribute(typeof(VideoType))]
    [XmlIncludeAttribute(typeof(SoundType))]
    [XmlIncludeAttribute(typeof(PictureType))]
    [XmlIncludeAttribute(typeof(GraphicType))]
    [XmlIncludeAttribute(typeof(BinaryObjectType1))]
    [XmlIncludeAttribute(typeof(ContentBinaryObjectType))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.3081.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "urn:un:unece:uncefact:data:specification:CoreComponentTypeSchemaModule:2")]
    public partial class BinaryObjectType
    {
        [XmlAttributeAttribute()]
        public string format { get; set; }


		[XmlAttributeAttribute(DataType = "normalizedString")]
        public string mimeCode { get; set; }


		[XmlAttributeAttribute(DataType = "normalizedString")]
        public string encodingCode { get; set; }


		[XmlAttributeAttribute(DataType = "normalizedString")]
        public string characterSetCode { get; set; }


		[XmlAttributeAttribute(DataType = "anyURI")]
        public string uri { get; set; }


		[XmlAttributeAttribute()]
        public string filename { get; set; }


		[XmlTextAttribute(DataType = "base64Binary")]
		public byte[] Value { get; set; }
    }    
}