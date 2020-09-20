
using System;
using VertSoft.Peppol.Common.Model;


namespace VertSoft.Peppol.Lookup.Api
{
	public interface IMetadataProvider
	{
		Uri resolveDocumentIdentifiers(Uri location, ParticipantIdentifier participantIdentifier);

		Uri resolveServiceMetadata(Uri location, ParticipantIdentifier participantIdentifier, DocumentTypeIdentifier documentTypeIdentifier);
	}
}