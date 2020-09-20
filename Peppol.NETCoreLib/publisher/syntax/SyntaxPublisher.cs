
using System;
using System.Xml;
using System.Xml.Serialization;
using VertSoft.Peppol.Publisher.Api;
using VertSoft.Peppol.Publisher.Model;


namespace VertSoft.Peppol.Publisher.Syntax
{
	/// <summary>
	/// Maps XML TO/FROM an Object
	/// </summary>
	public abstract class SyntaxPublisher : IPublisherSyntax
	{
		public virtual XmlSerializer ServiceGroupMarshaller { get; }

		public virtual XmlSerializer ServiceMetadataMarshaller { get; }

		public abstract XmlElement of(ServiceGroup serviceGroup, Uri rootUri);
		public abstract XmlElement of(PublisherServiceMetadata serviceMetadata, bool forSigning);
	}
}