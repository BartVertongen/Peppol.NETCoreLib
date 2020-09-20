
//It is a reader that can read a ServiceGroup and ServiceMetadata and get the namespace
//IT is an implementation of MetaReader

using System.Collections.Generic;
using System.IO;
//using ByteStreams = com.google.common.io.ByteStreams;
using no.difi.vefa.peppol.common.api;
using no.difi.vefa.peppol.lookup.api;
using no.difi.vefa.peppol.lookup.util;
using no.difi.vefa.peppol.security.lang;
using no.difi.vefa.peppol.common.model;

namespace no.difi.vefa.peppol.lookup.reader
{
    //It is a reader that can read a ServiceGroup and ServiceMetadata and get the namespace
    public class MultiReader : MetadataReader
	{

		private static readonly List<MetadataReader> METADATA_READERS = Lists.newArrayList(ServiceLoader.load(typeof(MetadataReader)));

        //ORIGINAL LINE: @Override public List<ServiceReference> parseServiceGroup(FetcherResponse fetcherResponse)
        //throws no.difi.vefa.peppol.lookup.api.LookupException
		public virtual List<ServiceReference> parseServiceGroup(FetcherResponse fetcherResponse)
		{
			FetcherResponse response = fetcherResponse;

			if (string.ReferenceEquals(response.Namespace, null))
			{
				response = detect(response);
			}

			foreach (MetadataReader metadataReader in METADATA_READERS)
			{
				if (metadataReader.GetType().getAnnotation(typeof(Namespace)).value().equalsIgnoreCase(response.Namespace))
				{
					return metadataReader.parseServiceGroup(response);
				}
			}
			throw new LookupException(string.Format("Unknown namespace: {0}", response.Namespace));
		}


        //ORIGINAL LINE: @Override public PotentiallySigned<ServiceMetadata> parseServiceMetadata(FetcherResponse fetcherResponse) 
        //throws no.difi.vefa.peppol.lookup.api.LookupException, no.difi.vefa.peppol.security.lang.PeppolSecurityException
		public virtual PotentiallySigned<ServiceMetadata,object> parseServiceMetadata(FetcherResponse fetcherResponse)
		{
			FetcherResponse response = fetcherResponse;

			if (string.ReferenceEquals(response.Namespace, null))
			{
				response = detect(response);
			}

			foreach (MetadataReader metadataReader in METADATA_READERS)
			{
				if (metadataReader.GetType().getAnnotation(typeof(Namespace)).value().equalsIgnoreCase(response.Namespace))
				{
					return metadataReader.parseServiceMetadata(response);
				}
			}
			throw new LookupException(string.Format("Unknown namespace: {0}", response.Namespace));
		}


        //ORIGINAL LINE: public FetcherResponse detect(FetcherResponse fetcherResponse) 
        //throws no.difi.vefa.peppol.lookup.api.LookupException
		public virtual FetcherResponse detect(FetcherResponse fetcherResponse)
		{
			try
			{
				byte[] fileContent = ByteStreams.toByteArray(fetcherResponse.InputStream);

				string @namespace = XmlUtils.extractRootNamespace(StringHelper.NewString(fileContent));
				if (!string.ReferenceEquals(@namespace, null))
				{
					return new FetcherResponse(new MemoryStream(fileContent), @namespace);
				}

				throw new LookupException("Unable to detect namespace.");
			}
			catch (IOException e)
			{
				throw new LookupException(e.Message, e);
			}
		}

        PotentiallySigned<ServiceMetadata, object> MetadataReader.parseServiceMetadata(FetcherResponse fetcherResponse)
        {
            throw new System.NotImplementedException();
        }
    }
}