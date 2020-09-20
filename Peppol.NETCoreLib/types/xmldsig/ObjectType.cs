
using System.Xml.Serialization;


namespace VertSoft.Peppol.Types.Smp.Xmldsig
{       
    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    [XmlRoot("Object", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
    public class ObjectType
    {
        [XmlText()]
        [XmlAnyElement()]
        public System.Xml.XmlNode[] Any { get; set; }


		[XmlAttribute(DataType = "ID")]
        public string Id { get; set; }


		[XmlAttribute()]
        public string MimeType { get; set; }


		[XmlAttribute(DataType = "anyURI")]
		public string Encoding { get; set; }
    }
}