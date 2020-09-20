
using VertSoft.Peppol.Common.Model;
using System.Collections.Generic;
using VertSoft.Peppol.Publisher.Model;


namespace VertSoft.Peppol.Publisher.Api
{
	/// <summary>
    /// Creates a ServiceGroup from a participantid
	/// </summary>
	public interface IServiceGroupProvider
	{
		ServiceGroup get(ParticipantIdentifier participantIdentifier);
	}

	/// <summary>
	/// Creates a ServiceGroup smp1 from a participantid independant from the syntax (busdox, bdxr)
	/// </summary>
	/// <remarks>These is an incomplete implementation, we need a repository of ServiceGroups and ServiceMetadata.</remarks>
	public class ServiceGroupProvider: IServiceGroupProvider
    {
		/// <summary>
		/// Gives the new and empty ServiceGroup for a given Participant
		/// </summary>
		/// <param name="participantid"></param>
		/// <returns></returns>
		/// <remarks>It should not return an Empty but Full Servicegroup with all services.</remarks>
        //throws PublisherException;
        public ServiceGroup get(ParticipantIdentifier participantid)
        {
            return ServiceGroup.of(participantid, new List<ServiceReference>());
        }
    }
}