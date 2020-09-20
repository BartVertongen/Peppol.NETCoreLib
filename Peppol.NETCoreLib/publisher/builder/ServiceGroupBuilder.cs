
using System.Collections.Generic;
using VertSoft.Peppol.Common.Model;
using VertSoft.Peppol.Publisher.Model;


namespace VertSoft.Peppol.Publisher.Builder
{
	/// <summary>
	/// Is used to create a ServiceGroup smp1 independent of the syntax
	/// </summary>
	public class ServiceGroupBuilder
	{

		private ParticipantIdentifier participantIdentifier;
		private List<ServiceReference> serviceReferences = new List<ServiceReference>();

		public static ServiceGroupBuilder newInstance(ParticipantIdentifier participantIdentifier)
		{
			return new ServiceGroupBuilder(participantIdentifier);
		}

		private ServiceGroupBuilder(ParticipantIdentifier participantIdentifier)
		{
			this.participantIdentifier = participantIdentifier;
		}

		public virtual ServiceGroupBuilder add(ServiceReference serviceReference)
		{
			this.serviceReferences.Add(serviceReference);
			return this;
		}

		public virtual ServiceGroup build()
		{
			return ServiceGroup.of(participantIdentifier, serviceReferences);
		}
	}
}