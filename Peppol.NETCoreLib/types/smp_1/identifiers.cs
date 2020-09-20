
using System.Xml.Serialization;


namespace VertSoft.Types.Smp.Identifiers_1.Busdox
{
    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(Namespace="http://busdox.org/transport/identifiers/1.0/")]
    [XmlRoot("ParticipantIdentifier", Namespace="http://busdox.org/transport/identifiers/1.0/", IsNullable=false)]
    public class ParticipantIdentifierType
	{
        [XmlAttribute()]
        public string scheme { get; set; }

		[XmlText()]
        public string Value { get; set; }
	}


    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(Namespace="http://busdox.org/transport/identifiers/1.0/")]
    [XmlRoot("ProcessIdentifier", Namespace="http://busdox.org/transport/identifiers/1.0/", IsNullable=false)]
    public class ProcessIdentifierType 
	{       
        [XmlAttribute()]
        public string scheme { get; set; }


		[XmlText()]
        public string Value { get; set; }
	}


    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(Namespace="http://busdox.org/transport/identifiers/1.0/")]
    [XmlRoot("DocumentIdentifier", Namespace="http://busdox.org/transport/identifiers/1.0/", IsNullable=false)]
    public class DocumentIdentifierType
	{        
        [XmlAttribute()]
        public string scheme { get; set; }

		[XmlText()]
		public string Value { get; set; }
    }           
}