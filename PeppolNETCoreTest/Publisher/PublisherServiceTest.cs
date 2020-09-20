
using System;
using System.Collections.Generic;
using System.IO;
using VertSoft.Peppol.Publisher.Api;
using VertSoft.Peppol.Publisher.Builder;
using VertSoft.Peppol.Publisher.Model;
using System.Diagnostics;
using VertSoft.Peppol.Common.Model;
using VertSoft.Peppol.Common.Model.Lang;
using VertSoft.Peppol.Lookup.Api;
using VertSoft.Peppol.Lookup.Reader;


namespace VertSoft.Peppol.Publisher
{
	/// <summary>
	/// A PublisherService should be used in a ApiController that acts as an SMP
	/// </summary>
	public class PublisherServiceTest
	{
		private bool _bInstanceFieldsInitialized = false;

		private static readonly DocumentTypeIdentifier DTI_INVOICE =
				DocumentTypeIdentifier.of("urn:oasis:names:specification:ubl:schema:xsd:Invoice-2::Invoice"
						+ "##urn:www.cenbii.eu:transaction:biitrns010:ver2.0"
								+ ":extended:urn:www.peppol.eu:bis:peppol4a:ver2.0::2.1");

		private static readonly ProcessIdentifier PI_INVOICE = ProcessIdentifier.of("urn:www.cenbii.eu:profile:bii04:ver2.0");


		private ServiceGroupProvider _ServiceGroupProvider = new ServiceGroupProvider();

		private ServiceMetadataProvider _ServiceMetadataProvider = new ServiceMetadataProvider();

		private PublisherSyntaxProvider _PublisherSyntaxProvider = new PublisherSyntaxProvider();

		private PublisherService _PublisherService;

		private IMetadataReader _MetadataReader = (IMetadataReader)new MultiReader();


		public PublisherServiceTest()
		{
			if (!this._bInstanceFieldsInitialized)
			{
				this.InitializeInstanceFields();
				this._bInstanceFieldsInitialized = true;
			}
		}


		private void InitializeInstanceFields()
		{
			//TODO: add a signer ?
			this._PublisherService = new PublisherService(_ServiceGroupProvider, _ServiceMetadataProvider, _PublisherSyntaxProvider, null);
		}


		//REM: What is the purpose of this test ??
        //ORIGINAL LINE: @Test public void simpleServiceGroup() throws Exception
		public virtual void SimpleServiceGroup()
		{
			ServiceGroup objServiceGroup = ServiceGroupBuilder.newInstance(ParticipantIdentifier.of("9908:999999999"))
                    .add(ServiceReference.of(DTI_INVOICE)).build();

			//REM: This makes sure when the provider asks a ServiceGroup for a Participant it will return the one above.
			//Mockito.when(serviceGroupProvider.get(Mockito.any(typeof(ParticipantIdentifier)))).thenReturn(objServiceGroup);
			//TODO: how can we mimic this?

			MemoryStream byteArrayOutputStream;
			this._PublisherService.ServiceGroup(out byteArrayOutputStream
                        , new Uri("http://localhost:8080/"), ParticipantIdentifier.of("9908:999999999"));

			List<ServiceReference> result = this._MetadataReader.ParseServiceGroup(
					new FetcherResponse(new MemoryStream(byteArrayOutputStream.ToArray()), null));

			Debug.Assert(result.Count == 1, "There should be one Service Reference in this ServiceGroup!");
            Debug.Assert(result[0].DocumentTypeIdentifier.ToString() == DTI_INVOICE.ToString());
		}


        //ORIGINAL LINE: @Test public void simpleServiceMetadata() throws Exception
		public virtual void SimpleServiceMetadata()
		{
			//TODO: We should use a real certificate, not a string "Test"
			PublisherServiceMetadata serviceMetadata = ServiceMetadataBuilder.newInstance()
                    .participant(ParticipantIdentifier.of("9908:999888777"))
                    .documentTypeIdentifier(DTI_INVOICE)
                    .add(PI_INVOICE, EndpointBuilder.NewInstance()
							.TransportProfile(TransportProfile.PEPPOL_AS2_2_0).Address(new Uri("http://localhost:8080/as2"))
                    .ActivationDate(DateTime.Now).ExpirationDate(DateTime.Now)
							/*.Certificate(new X509Certificate2(Encoding.ASCII.GetBytes("Test")))*/.Build()).build();

			//REM: This makes sure when the provider should give a ServiceMetadata for a Participant and doc it will return the one above.
			//REM: However it is not implemented.
			//Mockito.when(serviceMetadataProvider.get(Mockito.any(typeof(ParticipantIdentifier))
			//	, Mockito.any(typeof(DocumentTypeIdentifier)))).thenReturn(serviceMetadata);

			MemoryStream byteArrayOutputStream = new MemoryStream();
			//REM: The Provider should return the ServiceMetadata Build above from its repository
			this._PublisherService.MetadataProvider(out byteArrayOutputStream, ParticipantIdentifier.of("9908:999888777"), DTI_INVOICE);
			byteArrayOutputStream.Position = 0;
			StreamReader objStreamReader = new StreamReader(byteArrayOutputStream);
			string strContent = objStreamReader.ReadToEnd();
			Console.WriteLine(strContent);
		}
	}
}