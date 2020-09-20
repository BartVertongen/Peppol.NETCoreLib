
using System.Xml.Serialization;


namespace VertSoft.Peppol.Types.Smp.Xmldsig
{
    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(Namespace = "http://www.w3.org/2009/xmldsig11#")]
    [XmlRoot("ECKeyValue", Namespace = "http://www.w3.org/2009/xmldsig11#", IsNullable = false)]
    public class ECKeyValueType
    {
        [XmlElement("ECParameters", typeof(ECParametersType))]
        [XmlElement("NamedCurve", typeof(NamedCurveType))]
        public object Item { get; set; }


		[XmlElement(DataType = "base64Binary")]
        public byte[] PublicKey { get; set; }


		[XmlAttribute(DataType = "ID")]
        public string Id { get; set; }
	}


    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(Namespace = "http://www.w3.org/2009/xmldsig11#")]
    public class ECParametersType
    {
        public FieldIDType FieldID { get; set; }


		public CurveType Curve { get; set; }


		[XmlElement(DataType = "base64Binary")]
        public byte[] Base { get; set; }


		[XmlElement(DataType = "base64Binary")]
        public byte[] Order { get; set; }


		[XmlElement(DataType = "integer")]
        public string CoFactor { get; set; }


		public ECValidationDataType ValidationData { get; set; }
	}


    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    [XmlRoot("PGPData", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
    public class PGPDataType
    {
        [XmlAnyElement()]
        [XmlElement("PGPKeyID", typeof(byte[]), DataType = "base64Binary")]
        [XmlElement("PGPKeyPacket", typeof(byte[]), DataType = "base64Binary")]
        [XmlChoiceIdentifier("ItemsElementName")]
        public object[] Items { get; set; }


		[XmlElement("ItemsElementName")]
        [XmlIgnore()]
        public ItemsChoiceType1[] ItemsElementName { get; set; }
	}


    [System.Serializable()]
    [XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#", IncludeInSchema = false)]
    public enum ItemsChoiceType1
    {
        [XmlEnum("##any:")]
        Item,
        PGPKeyID,
        PGPKeyPacket,
    }


    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public class X509IssuerSerialType
    {
        public string X509IssuerName { get; set; }


		[XmlElementAttribute(DataType = "integer")]
        public string X509SerialNumber { get; set; }
	}


    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    [XmlRoot("X509Data", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
    public class X509DataType
    {
        [XmlAnyElement()]
        [XmlElement("X509CRL", typeof(byte[]), DataType = "base64Binary")]
        [XmlElement("X509Certificate", typeof(byte[]), DataType = "base64Binary")]
        [XmlElement("X509IssuerSerial", typeof(X509IssuerSerialType))]
        [XmlElement("X509SKI", typeof(byte[]), DataType = "base64Binary")]
        [XmlElement("X509SubjectName", typeof(string))]
        [XmlChoiceIdentifier("ItemsElementName")]
        public object[] Items { get; set; }


		[XmlElement("ItemsElementName")]
        [XmlIgnore()]
        public ItemsChoiceType[] ItemsElementName { get; set; }
	}


    [System.Serializable()]
    [XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#", IncludeInSchema = false)]
    public enum ItemsChoiceType
    {
        [XmlEnum("##any:")]
        Item,
        X509CRL,
        X509Certificate,
        X509IssuerSerial,
        X509SKI,
        X509SubjectName,
    }


    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    [XmlRoot("RetrievalMethod", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
    public class RetrievalMethodType
    {
        [XmlArrayItem("Transform", IsNullable = false)]
        public TransformType[] Transforms { get; set; }


		[XmlAttribute(DataType = "anyURI")]
        public string URI { get; set; }


		[XmlAttribute(DataType = "anyURI")]
        public string Type { get; set; }
	}


    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    [XmlRoot("Transform", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
    public class TransformType
    {
        [XmlAnyElement()]
        [XmlElement("XPath", typeof(string))]
        public object[] Items { get; set; }


		[XmlText()]
        public string[] Text { get; set; }


		[XmlAttribute(DataType = "anyURI")]
        public string Algorithm { get; set; }
	}


    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    [XmlRoot("RSAKeyValue", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
    public class RSAKeyValueType
    {
        [XmlElement(DataType = "base64Binary")]
        public byte[] Modulus { get; set; }


		[XmlElement(DataType = "base64Binary")]
        public byte[] Exponent { get; set; }
	}


    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    [XmlRoot("DSAKeyValue", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
    public class DSAKeyValueType
    {
        [XmlElement(DataType = "base64Binary")]
        public byte[] P { get; set; }


		[XmlElement(DataType = "base64Binary")]
        public byte[] Q { get; set; }


		[XmlElementAttribute(DataType = "base64Binary")]
        public byte[] G { get; set; }


		[XmlElement(DataType = "base64Binary")]
        public byte[] Y { get; set; }


		[XmlElement(DataType = "base64Binary")]
        public byte[] J { get; set; }


		[XmlElement(DataType = "base64Binary")]
        public byte[] Seed { get; set; }


		[XmlElement(DataType = "base64Binary")]
        public byte[] PgenCounter { get; set; }
	}


    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    [XmlRoot("KeyValue", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
    public class KeyValueType
    {
        [XmlAnyElement()]
        [XmlElement("DSAKeyValue", typeof(DSAKeyValueType))]
        [XmlElement("RSAKeyValue", typeof(RSAKeyValueType))]
        public object Item { get; set; }


		[XmlText()]
        public string[] Text { get; set; }
	}


    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    [XmlRoot("KeyInfo", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
    public class KeyInfoType
    {
        [XmlAnyElement()]
        [XmlElement("KeyName", typeof(string))]
        [XmlElement("KeyValue", typeof(KeyValueType))]
        [XmlElement("MgmtData", typeof(string))]
        [XmlElement("PGPData", typeof(PGPDataType))]
        [XmlElement("RetrievalMethod", typeof(RetrievalMethodType))]
        [XmlElement("SPKIData", typeof(SPKIDataType))]
        [XmlElement("X509Data", typeof(X509DataType))]
        [XmlChoiceIdentifier("ItemsElementName")]
        public object[] Items { get; set; }


		[XmlElement("ItemsElementName")]
        [XmlIgnore()]
        public ItemsChoiceType2[] ItemsElementName { get; set; }


		[XmlText()]
        public string[] Text { get; set; }


		[XmlAttribute(DataType = "ID")]
        public string Id { get; set; }
	}


    [System.Serializable()]
    [XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#", IncludeInSchema = false)]
    public enum ItemsChoiceType2
    {

        [XmlEnum("##any:")]
        Item,
        KeyName,
        KeyValue,
        MgmtData,
        PGPData,
        RetrievalMethod,
        SPKIData,
        X509Data,
    }


    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    [XmlRoot("SignatureValue", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
    public partial class SignatureValueType
    {
        [XmlAttribute(DataType = "ID")]
        public string Id { get; set; }


		[XmlText(DataType = "base64Binary")]
        public byte[] Value { get; set; }
	}


    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    [XmlRoot("DigestMethod", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
    public class DigestMethodType
    {
        [XmlText()]
        [XmlAnyElement()]
        public System.Xml.XmlNode[] Any { get; set; }


		[XmlAttribute(DataType = "anyURI")]
        public string Algorithm { get; set; }
	}


    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    [XmlRoot("Reference", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
    public class ReferenceType
    {
        [XmlArrayItem("Transform", IsNullable = false)]
        public TransformType[] Transforms { get; set; }


		public DigestMethodType DigestMethod { get; set; }


		[XmlElement(DataType = "base64Binary")]
        public byte[] DigestValue { get; set; }


		[XmlAttribute(DataType = "ID")]
        public string Id { get; set; }


		[XmlAttribute(DataType = "anyURI")]
        public string URI { get; set; }


		[XmlAttribute(DataType = "anyURI")]
        public string Type { get; set; }
	}


    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    [XmlRoot("SignatureMethod", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
    public class SignatureMethodType
    {
        [XmlElement(DataType = "integer")]
        public string HMACOutputLength { get; set; }


		[XmlText()]
        [XmlAnyElement()]
        public System.Xml.XmlNode[] Any { get; set; }


		[XmlAttribute(DataType = "anyURI")]
        public string Algorithm { get; set; }
	}


    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    [XmlRoot("CanonicalizationMethod", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
    public class CanonicalizationMethodType
    {
        [XmlText()]
        [XmlAnyElement()]
        public System.Xml.XmlNode[] Any { get; set; }


		[XmlAttribute(DataType = "anyURI")]
        public string Algorithm { get; set; }
	}


    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    [XmlRoot("SignedInfo", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
    public class SignedInfoType
    {
        public CanonicalizationMethodType CanonicalizationMethod { get; set; }


		public SignatureMethodType SignatureMethod { get; set; }


		[XmlElement("Reference")]
        public ReferenceType[] Reference { get; set; }


		[XmlAttribute(DataType = "ID")]
        public string Id { get; set; }
	}


    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    [XmlRoot("Signature", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
    public class SignatureType
    {
        public SignedInfoType SignedInfo { get; set; }


		public SignatureValueType SignatureValue { get; set; }


		public KeyInfoType KeyInfo { get; set; }


		[XmlElement("Object")]
        public ObjectType[] Object { get; set; }


		[XmlAttribute(DataType = "ID")]
        public string Id { get; set; }
	}


    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(Namespace = "http://www.w3.org/2009/xmldsig11#")]
    public class FieldIDType
    {
        [XmlAnyElement()]
        [XmlElement("GnB", typeof(CharTwoFieldParamsType))]
        [XmlElement("PnB", typeof(PnBFieldParamsType))]
        [XmlElement("Prime", typeof(PrimeFieldParamsType))]
        [XmlElement("TnB", typeof(TnBFieldParamsType))]
        public object Item { get; set; }
	}


    [XmlIncludeAttribute(typeof(PnBFieldParamsType))]
    [XmlIncludeAttribute(typeof(TnBFieldParamsType))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.3081.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(Namespace = "http://www.w3.org/2009/xmldsig11#")]
    [XmlRoot("GnB", Namespace = "http://www.w3.org/2009/xmldsig11#", IsNullable = false)]
    public class CharTwoFieldParamsType
    {
        [XmlElement(DataType = "positiveInteger")]
        public string M { get; set; }
	}


    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(Namespace = "http://www.w3.org/2009/xmldsig11#")]
    [XmlRoot("PnB", Namespace = "http://www.w3.org/2009/xmldsig11#", IsNullable = false)]
    public class PnBFieldParamsType : CharTwoFieldParamsType
    {
        [XmlElement(DataType = "positiveInteger")]
        public string K1 { get; set; }


		[XmlElement(DataType = "positiveInteger")]
        public string K2 { get; set; }


		[XmlElement(DataType = "positiveInteger")]
        public string K3 { get; set; }
	}


    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(Namespace = "http://www.w3.org/2009/xmldsig11#")]
    [XmlRoot("Prime", Namespace = "http://www.w3.org/2009/xmldsig11#", IsNullable = false)]
    public class PrimeFieldParamsType
    {
        [XmlElement(DataType = "base64Binary")]
        public byte[] P { get; set; }
	}


    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(Namespace = "http://www.w3.org/2009/xmldsig11#")]
    [XmlRoot("TnB", Namespace = "http://www.w3.org/2009/xmldsig11#", IsNullable = false)]
    public partial class TnBFieldParamsType : CharTwoFieldParamsType
    {
        [XmlElement(DataType = "positiveInteger")]
        public string K { get; set; }
	}


    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(Namespace = "http://www.w3.org/2009/xmldsig11#")]
    public partial class CurveType
    {
        [XmlElement(DataType = "base64Binary")]
        public byte[] A { get; set; }


		[XmlElement(DataType = "base64Binary")]
        public byte[] B { get; set; }
	}


    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(Namespace = "http://www.w3.org/2009/xmldsig11#")]
    public class ECValidationDataType
    {
        [XmlElement(DataType = "base64Binary")]
        public byte[] seed { get; set; }


		[XmlAttribute(DataType = "anyURI")]
        public string hashAlgorithm { get; set; }
	}


    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(Namespace = "http://www.w3.org/2009/xmldsig11#")]
    public class NamedCurveType
    {
        [XmlAttribute(DataType = "anyURI")]
        public string URI { get; set; }
	}


    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(Namespace = "http://www.w3.org/2009/xmldsig11#")]
    [XmlRoot("DEREncodedKeyValue", Namespace = "http://www.w3.org/2009/xmldsig11#", IsNullable = false)]
    public class DEREncodedKeyValueType
    {
        [XmlAttribute(DataType = "ID")]
        public string Id { get; set; }


		[XmlText(DataType = "base64Binary")]
        public byte[] Value { get; set; }
	}


    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(Namespace = "http://www.w3.org/2009/xmldsig11#")]
    [XmlRoot("KeyInfoReference", Namespace = "http://www.w3.org/2009/xmldsig11#", IsNullable = false)]
    public class KeyInfoReferenceType
    {
        [XmlAttribute(DataType = "anyURI")]
        public string URI { get; set; }


		[XmlAttribute(DataType = "ID")]
        public string Id { get; set; }
	}


    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(Namespace = "http://www.w3.org/2009/xmldsig11#")]
    [XmlRoot("X509Digest", Namespace = "http://www.w3.org/2009/xmldsig11#", IsNullable = false)]
    public class X509DigestType
    {
        [XmlAttribute(DataType = "anyURI")]
        public string Algorithm { get; set; }


		[XmlText(DataType = "base64Binary")]
        public byte[] Value { get; set; }
	}


    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    [XmlRoot("Transforms", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
    public partial class TransformsType
    {
        [XmlElement("Transform")]
		public TransformType[] Transform { get; set; }
    }


    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    [XmlRoot("Manifest", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
    public class ManifestType
    {
        [XmlElement("Reference")]
        public ReferenceType[] Reference { get; set; }


		[XmlAttribute(DataType = "ID")]
        public string Id { get; set; }
	}


    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    [XmlRoot("SignatureProperties", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
    public class SignaturePropertiesType
    {
        [XmlElement("SignatureProperty")]
        public SignaturePropertyType[] SignatureProperty { get; set; }


		[XmlAttribute(DataType = "ID")]
        public string Id { get; set; }
	}


    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    [XmlRoot("SignatureProperty", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
    public class SignaturePropertyType
    {
        [XmlAnyElement()]
        public System.Xml.XmlElement[] Items { get; set; }


		[XmlText()]
        public string[] Text { get; set; }


		[XmlAttribute(DataType = "anyURI")]
        public string Target { get; set; }


		[XmlAttribute(DataType = "ID")]
		public string Id { get; set; }
    }
}