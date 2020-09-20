
using System;
using System.Xml;
using System.Xml.Serialization;
using VertSoft.Peppol.Publisher.Model;


//WHAT IS THE PURPOSE OF THIS?????????????
namespace VertSoft.Peppol.Publisher.Api
{
    /// <summary>
    /// Solutions use XSDObjectGen.exe or xsd.exe
    ///  Linq can serialize and deserialize classes to/from xml files
    ///  Look into Typed DataSets
    ///  
    /// Implementations of this interface can use the Syntax attribute
    /// </summary>

    public interface IPublisherSyntax
	{
        //ORIGINAL LINE: javax.xml.bind.JAXBElement<?> of(ServiceGroup serviceGroup, Uri rootUri);
        //Will it convert a ServiceGroup to an XmlElement?
		XmlElement of(ServiceGroup serviceGroup, Uri rootUri);

        //ORIGINAL LINE: javax.xml.bind.JAXBElement<?> of(PublisherServiceMetadata serviceMetadata, boolean forSigning);
        //Will it convert a ServiceMetadata to an XmlElement?
        XmlElement of(PublisherServiceMetadata serviceMetadata, bool forSigning);

        //Is this a serializer???YES
        //ORIGINAL LINE: javax.xml.bind.Marshaller getMarshaller() throws javax.xml.bind.JAXBException;
		//REM we need a Different serializer for Metadata, servocegroup, version and syntax
		XmlSerializer ServiceGroupMarshaller {get;}

		XmlSerializer ServiceMetadataMarshaller { get; }
	}
}