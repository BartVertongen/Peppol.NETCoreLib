
using VertSoft.Peppol.Types.Smp.UnqualifiedDataTypes;
using System.Xml.Serialization;


namespace VertSoft.Peppol.Types.Smp.BasicComponents
{     
    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2/BasicComponents")]
    [XmlRoot("ID", Namespace = "http://docs.oasis-open.org/bdxr/ns/SMP/2/BasicComponents", IsNullable = false)]
    public class IDType : IdentifierType1
    {
    }
}