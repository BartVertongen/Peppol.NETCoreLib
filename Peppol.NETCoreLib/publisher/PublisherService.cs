
using System;
using System.IO;
using System.Xml;
using VertSoft.Peppol.Common.Model;
using VertSoft.Peppol.Publisher.Api;
using VertSoft.Peppol.Publisher.Model;
using System.Text;


namespace VertSoft.Peppol.Publisher
{
    /// <summary>
	/// The PublisherService gives a ServiceGroup for the given Participant or
	/// a ServiceMetadata for the given Participant and DocumentIdentifier.
	/// It could be signed or unsigned.
    /// </summary>
    public class PublisherService
	{
		private ServiceGroupProvider _ServiceGroupProvider;

		private ServiceMetadataProvider _ServiceMetadataProvider;

		private PublisherSyntaxProvider _PublisherSyntaxProvider;

		private Signer _Signer;


		public PublisherService(ServiceGroupProvider serviceGroupProvider
                , ServiceMetadataProvider serviceMetadataProvider, PublisherSyntaxProvider publisherSyntaxProvider, Signer signer = null)
		{
			this._ServiceGroupProvider = serviceGroupProvider;
			this._ServiceMetadataProvider = serviceMetadataProvider;
			this._PublisherSyntaxProvider = publisherSyntaxProvider;
			this._Signer = signer;
		}


		/// <summary>
		/// Serializes the ServiceGroup of the given Participant in the Stream using the given syntax.
		/// </summary>
		/// <param name="outputStream">Stream with the ServiceGroup data</param>
		/// <param name="version">smp1 or smp2</param>/// 
		/// <param name="syntax">busdox or bdxr</param>
		/// <param name="rootUri"></param>
		/// <param name="participantid">The Participant of the ServiceGroup</param>
		/// <exception cref="PublisherException"></exception>
		public void ServiceGroup(out MemoryStream outputStream, Uri rootUri
					, ParticipantIdentifier participantid, SMPVersion version = SMPVersion.SMP1
							, SMPSyntax syntax= SMPSyntax.BUSDOX)
		{
			//REM: Creates a new Empty ServiceGroup for the given Participant.
			//REM: but it should not be empty
			//The Provider should find the complete ServiceGroup for this Participant in his Repository
			ServiceGroup objServiceGroup = _ServiceGroupProvider.get(participantid);

			//Get a Publisher for the given Syntax
			IPublisherSyntax objSyntaxPublisher = _PublisherSyntaxProvider.GetSyntax(version, syntax);

			XmlElement xmlServiceGroup = objSyntaxPublisher.of(objServiceGroup, rootUri);
			outputStream = new MemoryStream(Encoding.UTF8.GetBytes(xmlServiceGroup.OuterXml));
		}


		/// <summary>
		/// Serialize the Metadata object to an output stream for the given Participant and documenttype
		/// into the stream using a certain syntax.
		/// </summary>
		/// <param name="outputStream"></param>
		/// <param name="syntax"></param>
		/// <param name="participantIdentifier"></param>
		/// <param name="documentTypeIdentifier"></param>
		/// <exception cref="PublisherException"></exception>
		public void MetadataProvider(out MemoryStream outputStream
                , ParticipantIdentifier participantIdentifier, DocumentTypeIdentifier documentTypeIdentifier
						, SMPVersion version = SMPVersion.SMP1, SMPSyntax syntax = SMPSyntax.BUSDOX)
		{
			//TODO: the Provider should give real ServiceMetadata for the given participant and documentIdentifier
			PublisherServiceMetadata serviceMetadata = _ServiceMetadataProvider.get(participantIdentifier, documentTypeIdentifier);

			IPublisherSyntax objSyntaxPublisher = _PublisherSyntaxProvider.GetSyntax(version, syntax);
			
			XmlElement xmlMetadata;

			if (_Signer == null)
			{
				xmlMetadata = objSyntaxPublisher.of(serviceMetadata, false);
				outputStream = new MemoryStream(Encoding.UTF8.GetBytes(xmlMetadata.OuterXml));
			}
			else
			{
				xmlMetadata = objSyntaxPublisher.of(serviceMetadata, true);
				//TODO do this when we have more knowledge
				outputStream = new MemoryStream(Encoding.UTF8.GetBytes(xmlMetadata.OuterXml));
				//signer.Sign(xmlMetadata, outputStream);
			}
		}
	}
}