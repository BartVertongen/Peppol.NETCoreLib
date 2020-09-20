using System;
using System.Collections.Generic;


namespace VertSoft.Peppol.Common.Model
{

	[Serializable]
	public class ServiceMetadata : AbstractServiceMetadata<Endpoint>
	{

		private const long serialVersionUID = -7523336374349545534L;

		public static ServiceMetadata of(ParticipantIdentifier participantIdentifier
                        , DocumentTypeIdentifier documentTypeIdentifier, List<ProcessMetadata> processes)
		{
			return new ServiceMetadata(participantIdentifier, documentTypeIdentifier, processes);
		}

		private ServiceMetadata(ParticipantIdentifier participantIdentifier, DocumentTypeIdentifier documentTypeIdentifier
                , List<ProcessMetadata> processes) : base(participantIdentifier, documentTypeIdentifier, processes)
		{
		}
	}
}