
using System.Collections.Generic;
using VertSoft.Peppol.Common.Model;
using VertSoft.Peppol.Common.Model.Lang;
using VertSoft.Peppol.Publisher.Model;


namespace VertSoft.Peppol.Publisher.Builder
{
	/// <summary>
	/// Creates a ServiceMetadata SMP1 object independent from the syntax (busdox, bdxr).
	/// </summary>
	public class ServiceMetadataBuilder
	{
		private ParticipantIdentifier _ParticipantIdentifier;

		private DocumentTypeIdentifier _DocumentTypeIdentifier;

		private List<ProcessMetadata/*<PublisherEndpoint>*/> _Processes = new List<ProcessMetadata/*<PublisherEndpoint>*/>();

		public static ServiceMetadataBuilder newInstance()
		{
			return new ServiceMetadataBuilder();
		}

        /// <summary>
        /// Private constructor can not be used directly
        /// </summary>
		private ServiceMetadataBuilder()
		{
		}

		public virtual ServiceMetadataBuilder participant(ParticipantIdentifier participantIdentifier)
		{
			this._ParticipantIdentifier = participantIdentifier;
			return this;
		}

		public virtual ServiceMetadataBuilder documentTypeIdentifier(DocumentTypeIdentifier documentTypeIdentifier)
		{
			this._DocumentTypeIdentifier= documentTypeIdentifier;
			return this;
		}

		public virtual ServiceMetadataBuilder add(ProcessIdentifier processIdentifier, params PublisherEndpoint[] endpoints)
		{
			this._Processes.Add(ProcessMetadata.of(processIdentifier, endpoints));
			return this;
		}

		public virtual PublisherServiceMetadata build()
		{
			return new PublisherServiceMetadata(this._ParticipantIdentifier, this._DocumentTypeIdentifier, this._Processes);
		}
	}
}