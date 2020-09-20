
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using VertSoft.Peppol.Common.Lang;
using VertSoft.Peppol.Common.Model;
using VertSoft.Peppol.Common.Model.Lang;
using VertSoft.Peppol.Lookup.Api;



namespace VertSoft.Peppol.Lookup.Reader
{
	public class BusdoxReaderTest
	{
		readonly private IMetadataReader reader = new BusdoxReader();


        //ORIGINAL LINE: @Test public void documentIdentifers() throws Exception
		public virtual void documentIdentifers()
		{
            FileStream fsXml = new FileStream("/busdox-servicegroup-9908-991825827.xml", FileMode.Open);
            List<ServiceReference> result = reader.ParseServiceGroup(new FetcherResponse(fsXml, null));
            Debug.Assert(result.Count == 7);
		}


        //throws Exception
		public virtual void serviceMetadata()
		{
            FileStream fsXml = new FileStream("/busdox-servicemetadata-9908-991825827.xml", FileMode.Open);
            ServiceMetadata result = reader.ParseServiceMetadata(new FetcherResponse(fsXml)).Content;

			ProcessIdentifier processIdentifier = ProcessIdentifier.of("urn:www.cenbii.eu:profile:bii05:ver2.0");

			try
			{
				result.getEndpoint(processIdentifier, TransportProfile.START);
				Debug.Assert(false, "Expected exception.");
			}
			catch (EndpointNotFoundException)
			{
				// Expected
			}

            Debug.Assert(result.getEndpoint(processIdentifier, TransportProfile.AS2_1_0) != null);
            Debug.Assert(((Endpoint)result.getEndpoint(processIdentifier, TransportProfile.AS2_1_0))
                                    .Certificate.Subject.ToString() == "O=EVRY AS, CN=APP_1000000025, C=NO");
		}


        //throws Exception
		public virtual void documentIdentifiersDocsLogistics()
		{
            FileStream fsXml = new FileStream("/busdox-servicegroup-docslogistics.xml", FileMode.Open);
            List<ServiceReference> result = reader.ParseServiceGroup(new FetcherResponse(fsXml, null));
            Debug.Assert(result.Count == 25);
		}
	}
}