
using System;


namespace VertSoft.Peppol.Lookup.Api
{
	public interface IMetadataFetcher
	{
        //ORIGINAL LINE: FetcherResponse fetch(java.net.URI uri) throws LookupException, java.io.FileNotFoundException;
		FetcherResponse Fetch(Uri uri);
	}
}