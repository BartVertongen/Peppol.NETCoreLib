
using System;
using System.Collections.Generic;
using VertSoft.Peppol.Common.Lang;
using VertSoft.Peppol.Common.Model.Lang;

namespace VertSoft.Peppol.Common.Model
{
	[Serializable]
	public abstract class AbstractServiceMetadata<ISimpleEndpoint> //where T : no.difi.vefa.peppol.common.api.SimpleEndpoint
	{

		protected internal AbstractServiceMetadata(ParticipantIdentifier participantIdentifier
						, DocumentTypeIdentifier documentTypeIdentifier, List<ProcessMetadata> processes)
		{
			this.ParticipantIdentifier = participantIdentifier;
			this.DocumentTypeIdentifier = documentTypeIdentifier;
			this.Processes = processes;
		}

		public virtual ParticipantIdentifier ParticipantIdentifier { get; }

		public virtual DocumentTypeIdentifier DocumentTypeIdentifier { get; }

		public virtual List<ProcessMetadata> Processes { get; }


        /// <summary>
        /// A combination of a ProcessIdentifier and TransportProfile gives an Endpoint.
        /// </summary>
        /// <param name="processIdentifier"></param>
        /// <param name="transportProfiles"></param>
        /// <returns></returns>
        //ORIGINAL LINE: public T getEndpoint(ProcessIdentifier processIdentifier, TransportProfile... transportProfiles) throws no.difi.vefa.peppol.common.lang.EndpointNotFoundException
		public virtual /*T*/Endpoint getEndpoint(ProcessIdentifier processIdentifier, params TransportProfile[] transportProfiles)
		{
			foreach (ProcessMetadata/*<T>*/ processMetadata in Processes)
			{
				if (processMetadata.ProcessIdentifiers.Contains(processIdentifier))
				{
					return processMetadata.getEndpoint(transportProfiles);
				}
			}
			throw new EndpointNotFoundException(string.Format("Combination of '{0}' and transport profile(s) not found.", processIdentifier));
		}
	}
}