
using System.Collections.Generic;
using VertSoft.Peppol.Common.Api;
using VertSoft.Peppol.Common.Model;
using VertSoft.Peppol.Security.Lang;


namespace VertSoft.Peppol.Lookup.Api
{
	/// <summary>
	/// Parse SMP1 data from a HttpResponse.
	/// </summary>
	public interface IMetadataReader
	{
		/// <summary>
		/// Parse a service group from a Response
		/// </summary>
		/// <param name="fetcherResponse"></param>
		/// <returns>Only the list of ServiceReferences</returns>
		List<ServiceReference> ParseServiceGroup(FetcherResponse fetcherResponse);  //throws LookupException;


		//ORIGINAL LINE: PotentiallySigned<ServiceMetadata> parseServiceMetadata(FetcherResponse fetcherResponse) 
		//throws LookupException, PeppolSecurityException;
		PotentiallySigned<ServiceMetadata, object> ParseServiceMetadata(FetcherResponse fetcherResponse);
	}
}