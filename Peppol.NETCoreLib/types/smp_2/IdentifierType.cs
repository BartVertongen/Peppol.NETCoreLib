
using VertSoft.Peppol.Types.Smp.BasicComponents;
using VertSoft.Peppol.Types.Smp.ExtensionComponents;
using VertSoft.Peppol.Types.Smp.UnqualifiedDataTypes;
using System.Xml.Serialization;


namespace VertSoft.Peppol.Types.Smp.CoreComponentTypeSchemaModule
{
    [XmlIncludeAttribute(typeof(IdentifierType1))]
    [XmlIncludeAttribute(typeof(ExtensionVersionIDType))]
    [XmlIncludeAttribute(typeof(ExtensionURIType))]
    [XmlIncludeAttribute(typeof(ExtensionAgencyURIType))]
    [XmlIncludeAttribute(typeof(ExtensionAgencyIDType))]
    [XmlIncludeAttribute(typeof(TransportProfileIDType))]
    [XmlIncludeAttribute(typeof(SMPVersionIDType))]
    [XmlIncludeAttribute(typeof(RoleIDType))]
    [XmlIncludeAttribute(typeof(PublisherURIType))]
    [XmlIncludeAttribute(typeof(ParticipantIDType))]
    [XmlIncludeAttribute(typeof(IDType))]
    [XmlIncludeAttribute(typeof(AddressURIType))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.3081.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "urn:un:unece:uncefact:data:specification:CoreComponentTypeSchemaModule:2")]
    public class IdentifierType
    {
        [XmlAttributeAttribute(DataType = "normalizedString")]
        public string schemeID { get; set; }


        [XmlAttributeAttribute()]
        public string schemeName { get; set; }


		[XmlAttributeAttribute(DataType = "normalizedString")]
        public string schemeAgencyID { get; set; }


		[XmlAttributeAttribute()]
        public string schemeAgencyName { get; set; }


		[XmlAttributeAttribute(DataType = "normalizedString")]
        public string schemeVersionID { get; set; }


		[XmlAttributeAttribute(DataType = "anyURI")]
        public string schemeDataURI { get; set; }


		[XmlAttributeAttribute(DataType = "anyURI")]
        public string schemeURI { get; set; }


		[XmlTextAttribute(DataType = "normalizedString")]
        public string Value { get; set; }
	}
}