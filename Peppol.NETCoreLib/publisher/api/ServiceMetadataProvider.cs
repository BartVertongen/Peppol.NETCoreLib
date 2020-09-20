
using VertSoft.Peppol.Common.Model;
using System.Collections.Generic;
using VertSoft.Peppol.Publisher.Model;


namespace VertSoft.Peppol.Publisher.Api
{
	/// <summary>
	/// </summary>
	public interface IServiceMetadataProvider
	{
        //throws PublisherException;
		PublisherServiceMetadata get(ParticipantIdentifier participantIdentifier, DocumentTypeIdentifier documentTypeIdentifier);
	}

    public class ServiceMetadataProvider: IServiceMetadataProvider
    {
		/// <summary>
		/// 
		/// </summary>
		/// <param name="participantid"></param>
		/// <param name="documentTypeid"></param>
		/// <returns></returns>
        //throws PublisherException;
        public PublisherServiceMetadata get(ParticipantIdentifier participantid, DocumentTypeIdentifier documentTypeid)
        {
            //to create ServiceMetadata we need a ParticipantIdentifier, a DocumentTypeIdentifier and Processes
            //The ProcessList depends on the DocumentTypeId.

            //TODO fill the list with ProcessMetadata
			//REM: The list with ProcessMetadata should not be Empty
            return new PublisherServiceMetadata(participantid, documentTypeid, new List<ProcessMetadata>());
        }
    }
}