
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using VertSoft.Peppol.Lookup.Api;
using VertSoft.Peppol.Common.Model.Lang;
using VertSoft.Peppol.Common.Model;
using VertSoft.Peppol.Common.Lang;



namespace VertSoft.Peppol.Lookup.Reader
{
	public class MultiReaderTest
	{
		private IMetadataReader reader = new MultiReader();

        //throws Exception
		public virtual void busdoxDocumentIdentifers()
		{
            FileStream fsXml = new FileStream("/busdox-servicegroup-9908-991825827.xml", FileMode.Open);
			List<ServiceReference> result = reader.ParseServiceGroup(new FetcherResponse(fsXml, null));
			Debug.Assert(result.Count == 7);
		}


        //throws Exception
		public virtual void bdxr201407DocumentIdentifers()
		{
            FileStream fsXml = new FileStream("/bdxr201407-servicegroup-9908-991825827.xml", FileMode.Open);
            List<ServiceReference> result = reader.ParseServiceGroup(new FetcherResponse(fsXml, null));
            Debug.Assert(result.Count == 7);
		}


        //throws Exception
		public virtual void bdxr201605DocumentIdentifers()
		{
            FileStream fsXml = new FileStream("/bdxr201605-servicegroup-9908-991825827.xml", FileMode.Open);
            List<ServiceReference> result = reader.ParseServiceGroup(new FetcherResponse(fsXml, null));
            Debug.Assert(result.Count == 7);
		}


        //ORIGINAL LINE: @Test public void busdoxServiceMetadata() throws Exception
		public virtual void busdoxServiceMetadata()
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


        //ORIGINAL LINE: @Test public void busdoxServiceMetadataMultiProcess() throws Exception
		public virtual void busdoxServiceMetadataMultiProcess()
		{
            FileStream fsXml = new FileStream("/busdox-servicemetadata-9933-061828591.xml", FileMode.Open);
            ServiceMetadata result = reader.ParseServiceMetadata(new FetcherResponse(fsXml)).Content;

			ProcessIdentifier processIdentifier1 = ProcessIdentifier.of("urn:www.cenbii.eu:profile:bii04:ver1.0");
			ProcessIdentifier processIdentifier2 = ProcessIdentifier.of("urn:www.cenbii.eu:profile:bii46:ver1.0");

			try
			{
				result.getEndpoint(processIdentifier1, TransportProfile.START);
                Debug.Assert(false, "Expected exception.");
            }
			catch (EndpointNotFoundException)
			{
				// Expected
			}
            Debug.Assert(result.getEndpoint(processIdentifier1, TransportProfile.AS2_1_0) != null);
            Debug.Assert(((Endpoint)result.getEndpoint(processIdentifier1, TransportProfile.AS2_1_0))
                        .Certificate.Subject.ToString() == "O=University of Piraeus Research Center, CN=APP_1000000088, C=GR");

			try
			{
				result.getEndpoint(processIdentifier2, TransportProfile.START);
                Debug.Assert(false, "Expected exception.");
			}
			catch (EndpointNotFoundException)
			{
				// Expected
			}

            Debug.Assert(result.getEndpoint(processIdentifier2, TransportProfile.AS2_1_0) != null);

            Debug.Assert(((Endpoint)result.getEndpoint(processIdentifier2, TransportProfile.AS2_1_0))
                        .Certificate.Subject.ToString() == "O=University of Piraeus Research Center, CN=APP_1000000088, C=GR");
		}

        //ORIGINAL LINE: @Test public void bdxrServiceMetadata() throws Exception
		public virtual void bdxrServiceMetadata()
		{
            FileStream fsXml = new FileStream("/bdxr201407-servicemetadata-9908-810418052.xml", FileMode.Open);
            ServiceMetadata result = reader.ParseServiceMetadata(new FetcherResponse(fsXml)).Content;

			ProcessIdentifier processIdentifier = ProcessIdentifier.of("urn:www.cenbii.eu:profile:bii04:ver1.0");

			try
			{
				result.getEndpoint(processIdentifier, TransportProfile.START);
                Debug.Assert(false, "Expected exception.");
            }
			catch (EndpointNotFoundException)
			{
				// Expected
			}

            Debug.Assert(result.getEndpoint(processIdentifier, TransportProfile.AS2_1_0)!=null);

            Debug.Assert(((Endpoint)result.getEndpoint(processIdentifier, TransportProfile.AS2_1_0))
                                .Certificate.Subject.ToString() == "CN=APP_1000000005, O=DIFI, C=NO");
		}


        //throws Exception
		public virtual void busdoxServiceGroup()
		{
            FileStream fsXml = new FileStream("/busdox-servicegroup-9915-setcce-test.xml", FileMode.Open);
            List<ServiceReference> serviceReferences = reader.ParseServiceGroup(new FetcherResponse(fsXml, null));
            Debug.Assert(serviceReferences.Count == 1);
		}
	}
}