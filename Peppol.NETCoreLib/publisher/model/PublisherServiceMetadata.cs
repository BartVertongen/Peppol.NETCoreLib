
using VertSoft.Peppol.Common.Model;
using System;
using System.Collections.Generic;


namespace VertSoft.Peppol.Publisher.Model
{
	/// <summary>
	/// Publishes ServiceMetadata without Subscriber
	/// </summary>
	[Serializable]
	public class PublisherServiceMetadata : AbstractServiceMetadata<PublisherEndpoint>
	{

		public PublisherServiceMetadata(ParticipantIdentifier participantIdentifier
                , DocumentTypeIdentifier documentTypeIdentifier
                , List<ProcessMetadata/*<PublisherEndpoint>*/> processes) : base(participantIdentifier, documentTypeIdentifier, processes)
		{
		}
	}
}