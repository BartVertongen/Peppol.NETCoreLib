
using System;
using System.Collections.Generic;
using VertSoft.Peppol.Common.Model;


namespace VertSoft.Peppol.Publisher.Model
{
	/// <summary>
	/// Represents a ServiceGroup independent of the syntax (bdxr(201605), busdox)
	/// </summary>
	[Serializable]
	public class ServiceGroup
	{
		private List<ServiceReference> _ServiceReferences;

		/// <summary>
		/// Static creator of ServiceGroups
		/// </summary>
		/// <param name="participantIdentifier"></param>
		/// <param name="serviceReferences"></param>
		/// <returns></returns>
		public static ServiceGroup of(ParticipantIdentifier participantIdentifier, List<ServiceReference> serviceReferences)
		{
			return new ServiceGroup(participantIdentifier, serviceReferences);
		}

		/// <summary>
		/// Private constructor
		/// </summary>
		/// <param name="participantIdentifier"></param>
		/// <param name="serviceReferences"></param>
		private ServiceGroup(ParticipantIdentifier participantIdentifier, List<ServiceReference> serviceReferences)
		{
			this.ParticipantIdentifier = participantIdentifier;
			this._ServiceReferences = serviceReferences;
		}

		public ParticipantIdentifier ParticipantIdentifier { get; private set; }

		/// <summary>
		/// Gives a readonly list of Service References.
		/// </summary>
		public virtual IReadOnlyCollection<ServiceReference> ServiceReferences
		{
			get
			{
				return _ServiceReferences.AsReadOnly();
			}
		}
	}
}