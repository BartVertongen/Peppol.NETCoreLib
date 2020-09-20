using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using peppol.types.smp.xmldsig;

namespace peppol.types.certvalidator
{

    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://difi.no/xsd/certvalidator/1.0")]
    [XmlRoot(ElementName = "ValidatorRecipe")]
    public class ValidatorRecipeType
    {
        [XmlElement]
        public ValidatorType Validator { get; set; }

        [XmlElement]
        public CertificateBucketType CertificateBucket { get; set; }

        [XmlElement]
        public KeyStoreType KeyStore { get; set; }

        [XmlElement]
        public ExtensionType Extension { get; set; }

        [XmlElement]
        public SignatureType Signature { get; set; }

        [XmlAttribute]
        public string name { get; set; }

        [XmlAttribute]
        public string version { get; set; }
    }

    /*
      <xs:complexType name="ExtensibleType">
        <xs:choice minOccurs="0" maxOccurs="unbounded">
            <xs:element name="Blacklist" type="BlacklistType"/>
            <xs:element name="Cached" type="CachedType"/>
            <xs:element name="Chain" type="ChainType"/>
            <xs:element name="Class" type="ClassType"/>
            <xs:element name="CriticalExtensionRecognized" type="CriticalExtensionRecognizedType"/>
            <xs:element name="CriticalExtensionRequired" type="CriticalExtensionRequiredType"/>
            <xs:element name="CRL" type="CRLType"/>
            <xs:element name="Dummy" type="DummyType"/>
            <xs:element name="Expiration" type="ExpirationType"/>
            <xs:element name="HandleError" type="HandleErrorType"/>
            <xs:element name="Junction" type="JunctionType"/>
            <xs:element name="KeyUsage" type="KeyUsageType"/>
            <xs:element name="OCSP" type="OCSPType"/>
            <xs:element name="PrincipleName" type="PrincipleNameType"/>
            <xs:element name="RuleReference" type="RuleReferenceType"/>
            <xs:element name="Signing" type="SigningType"/>
            <xs:element name="Try" type="TryType"/>
            <xs:element name="ValidatorReference" type="ValidatorReferenceType"/>
            <xs:element name="Whitelist" type="WhitelistType"/>
            <xs:element name="Extension" type="ExtensionType"/>
        </xs:choice>
    </xs:complexType>
    */

    public class ExtensibleType
    {
        [XmlAttribute]
        public string name { get; set; }

        [XmlAttribute]
        public int timeout { get; set; }
    }


    [XmlTypeAttribute(IncludeInSchema = false)]
    public enum ExtensibleTypeEnum
    {
        Blacklist,
        Cached,
        Chain,
        Class,
        CriticalExtensionRecognized,
        CriticalExtensionRequired,
        CRL,
        Dummy,
        Expiration,
        HandleError,
        Junction,
        KeyUsage,
        OCSP,
        PrincipleName,
        RuleReference,
        Signing,
        Try,
        ValidatorReference,
        Whitelist,
        Extension
    }


    [XmlRootAttribute("Blacklist", DataType = "string", IsNullable = false)]
    public class BlacklistType
    { }


    /*<xs:complexType name="CachedType">
        <xs:complexContent>
            <xs:extension base="ExtensibleType">
                <xs:attribute name="timeout" type="xs:long" use="required"/>
            </xs:extension>
        </xs:complexContent>
    </xs:complexType>*/
    [XmlRootAttribute("Cached", DataType = "ExtensibleType")]
    public class CachedType : ExtensibleType
    {
    }


    [XmlRootAttribute("CertificateBucketReference", DataType = "string")]
    public class CertificateBucketReferenceType
    { }


    [XmlRootAttribute("Cached")]
    public class ChainType
    {
        [XmlElement]
        public CertificateBucketReferenceType RootBucketReference { get; set; }

        [XmlElement]
        public CertificateBucketReferenceType IntermediateBucketReference { get; set; }

        [XmlElement(IsNullable = true)]
        public string Policy { get; set; }

        [XmlElement(IsNullable = true)]
        public ExtensionType Extension { get; set; }
    }

    /*<xs:complexType name="ClassType">
        <xs:simpleContent>
            <xs:extension base="xs:string"/>
        </xs:simpleContent>
    </xs:complexType>*/
    [XmlRootAttribute("Class", DataType = "string", IsNullable = false)]
    public class ClassType
    { }

    /*<xs:complexType name="CriticalExtensionRecognizedType">
        <xs:sequence>
            <xs:element name="Value" type="xs:string" minOccurs="0" maxOccurs="unbounded"/>
            <xs:element name="Extension" type="ExtensionType" minOccurs="0" maxOccurs="unbounded"/>
        </xs:sequence>
    </xs:complexType>*/
    public class CriticalExtensionRecognizedType
    {
        public string Value { get; set; }

        public ExtensionType Extension { get; set; }
    }

    /*<xs:complexType name="CriticalExtensionRequiredType">
        <xs:sequence>
            <xs:element name="Value" type="xs:string" minOccurs="0" maxOccurs="unbounded"/>
            <xs:element name="Extension" type="ExtensionType" minOccurs="0" maxOccurs="unbounded"/>
        </xs:sequence>
    </xs:complexType>*/
    public class CriticalExtensionRequiredType
    {
        public string Value { get; set; }

        public ExtensionType Extension { get; set; }
    }

    /*<xs:complexType name="CRLType">
        <xs:sequence>
            <xs:element name="Extension" type="ExtensionType" minOccurs="0" maxOccurs="unbounded"/>
        </xs:sequence>
    </xs:complexType>*/
    public class CRLType
    {
        public ExtensionType Extension { get; set; }
    }

    /*<xs:complexType name="DummyType">
        <xs:simpleContent>
            <xs:extension base="xs:string"/>
        </xs:simpleContent>
    </xs:complexType>*/
    [XmlRootAttribute("Dummy", DataType = "string", IsNullable = false)]
    public class DummyType
    { }


    /*<xs:complexType name="ExpirationType">
        <xs:sequence>
            <xs:element name="Extension" type="ExtensionType" minOccurs="0" maxOccurs="unbounded"/>
        </xs:sequence>
        <xs:attribute name="millis" type="xs:long"/>
    </xs:complexType>*/
    [XmlRoot("Expiration")]
    public class ExpirationType
    {
        [XmlAttribute]
        public long millis { get; set; }

        [XmlElement("Extension", IsNullable = true)]
        public ExtensionType Extension { get; set; }
    }


    /*<xs:complexType name="HandleErrorType">
        <xs:complexContent>
            <xs:extension base="ExtensibleType">
                <xs:attribute name="handler" type="xs:string"/>
            </xs:extension>
        </xs:complexContent>
    </xs:complexType>*/
    [XmlRootAttribute("HandleError", DataType = "ExtensibleType")]
    public class HandleErrorType
    {
        [XmlAttribute]
        public string handler { get; set; }
    }


    /*<xs:complexType name="JunctionType">
        <xs:complexContent>
            <xs:extension base="ExtensibleType">
                <xs:attribute name="type" type="JunctionEnum" use="required"/>
            </xs:extension>
        </xs:complexContent>
    </xs:complexType>*/
    [XmlRootAttribute("Junction", DataType = "ExtensibleType")]
    public class JunctionType
    {
        [XmlAttribute]
        public JunctionEnum type { get; set; }
    }

    /*<xs:complexType name="KeyUsageType">
        <xs:sequence>
            <xs:element name="Identifier" type="KeyUsageEnum" minOccurs="0" maxOccurs="unbounded"/>
            <xs:element name="Extension" type="ExtensionType" minOccurs="0" maxOccurs="unbounded"/>
        </xs:sequence>
    </xs:complexType>*/
    public class KeyUsageType
    {
        public KeyUsageEnum Identifier { get; set; }

        public ExtensionType Extension { get; set; }
    }


    [XmlTypeAttribute(IncludeInSchema = false)]
    public enum OCSPTypeEnum
    {
        IntermediateBucketReference,
        Extension
    }

    /*<xs:complexType name="OCSPType">
        <xs:choice>
            <xs:element name="IntermediateBucketReference" type="CertificateBucketReferenceType"/>
            <xs:element name="Extension" type="ExtensionType" minOccurs="0" maxOccurs="unbounded"/>
        </xs:choice>
    </xs:complexType>*/
    public class OCSPType
    {
        [System.Xml.Serialization.XmlElementAttribute("IntermediateBucketReference", typeof(IntermediateBucketReferenceType))]
        [System.Xml.Serialization.XmlElementAttribute("Extension", typeof(ExtensionType))]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemOCSPType")]
        public object Item { get; set; }

        //Connect a member with the enumeration
        [System.Xml.Serialization.XmlElementAttribute("ItemOCSPType")]
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public OCSPTypeEnum ItemOCSPType { get; set; }
    }

    /*    <xs:complexType name="ReferenceType">
        <xs:simpleContent>
            <xs:extension base="xs:string"/>
        </xs:simpleContent>
    </xs:complexType>*/
    [XmlRootAttribute("Reference", DataType = "string")]
    public class ReferenceType: string
    { }


    /*<xs:complexType name="RuleReferenceType">
        <xs:complexContent>
            <xs:extension base="ReferenceType"/>
        </xs:complexContent>
    </xs:complexType>*/
    [XmlRootAttribute("RuleReference", DataType = "ReferenceType")]
    public class RuleReferenceType: ReferenceType
    {}



    public class ValidatorType : ExtensibleType
    {
        //[XmlAttribute]
        //public string name { get; set; }
        
        [XmlAttribute]
        public string version { get; set; }


        [System.Xml.Serialization.XmlElementAttribute("Blacklist", typeof(BlacklistType))]
        [System.Xml.Serialization.XmlElementAttribute("Cached", typeof(CachedType))]
        [System.Xml.Serialization.XmlElementAttribute("Chain", typeof(ChainType))]
        [System.Xml.Serialization.XmlElementAttribute("Class", typeof(ClassType))]
        [System.Xml.Serialization.XmlElementAttribute("CriticalExtensionRecognized", typeof(CriticalExtensionRecognizedType))]
        [System.Xml.Serialization.XmlElementAttribute("CriticalExtensionRequired", typeof(CriticalExtensionRequiredType))]
        [System.Xml.Serialization.XmlElementAttribute("CRL", typeof(CRLType))]
        [System.Xml.Serialization.XmlElementAttribute("Dummy", typeof(DummyType))]
        [System.Xml.Serialization.XmlElementAttribute("Expiration", typeof(ExpirationType))]
        [System.Xml.Serialization.XmlElementAttribute("HandleError", typeof(HandleErrorType))]
        [System.Xml.Serialization.XmlElementAttribute("Junction", typeof(JunctionType))]
        [System.Xml.Serialization.XmlElementAttribute("KeyUsage", typeof(KeyUsageType))]
        [System.Xml.Serialization.XmlElementAttribute("OCSP", typeof(OCSPType))]
        [System.Xml.Serialization.XmlElementAttribute("PrincipleName", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("RuleReference", typeof(RuleReferenceType))]
        [System.Xml.Serialization.XmlElementAttribute("Signing", typeof(Signing))]
        [System.Xml.Serialization.XmlElementAttribute("Try", typeof(TryType))]
        [System.Xml.Serialization.XmlElementAttribute("ValidatorReference", typeof(ValidatorReferenceType))]
        [System.Xml.Serialization.XmlElementAttribute("Whitelist", typeof(WhitelistType))]
        [System.Xml.Serialization.XmlElementAttribute("Extension", typeof(ExtensionType))]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemExtensibleType")]
        public object Item { get; set; }

        //Connect a member with the enumeration
        [System.Xml.Serialization.XmlElementAttribute("ItemExtensibleType")]
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public ExtensibleTypeEnum ItemExtensibleType { get; set; }
    }



    public class CertificateBucketType
    {

    }


    public class KeyStoreType
    {
    }


    public class ExtensionType
    {
        [XmlAttribute]
        public string type { get; set; }
    }


    /*[XmlAttribute]
    public string ReferenceType { get; set; }*/

    public enum JunctionEnum
    {
        [XmlEnum("AND")]
        AND,
        [XmlEnum("OR")]
        OR,
        [XmlEnum("XOR")]
        XOR
    }

    public enum PrincipalEnum
    {
        [XmlEnum("SUBJECT")]
        SUBJECT,
        [XmlEnum("ISSUER")]
        ISSUER
    }

    public enum SigningEnum
    {
        [XmlEnum("PUBLIC_SIGNED")]
        PUBLIC_SIGNED,
        [XmlEnum("SELF_SIGNED")]
        SELF_SIGNED
    }

    public enum KeyUsageEnum
    {
        [XmlEnum("DIGITAL_SIGNATURE")]
        DIGITAL_SIGNATURE,
        [XmlEnum("NON_REPUDIATION")]
        NON_REPUDIATION,
        [XmlEnum("KEY_ENCIPHERMENT")]
        KEY_ENCIPHERMENT,
        [XmlEnum("DATA_ENCIPHERMENT")]
        DATA_ENCIPHERMENT,
        [XmlEnum("KEY_AGREEMENT")]
        KEY_AGREEMENT,
        [XmlEnum("KEY_CERT_SIGN")]
        KEY_CERT_SIGN,
        [XmlEnum("CRL_SIGN")]
        CRL_SIGN,
        [XmlEnum("ENCIPHER_ONLY")]
        ENCIPHER_ONLY,
        [XmlEnum("DECIPHER_ONLY")]
        DECIPHER_ONLY,     
    }
}
