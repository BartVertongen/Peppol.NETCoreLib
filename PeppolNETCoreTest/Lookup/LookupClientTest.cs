
using System;
using System.Collections.Generic;
using PeppolException = no.difi.vefa.peppol.common.lang.PeppolException;
using no.difi.vefa.peppol.common.model;
using LookupException = no.difi.vefa.peppol.lookup.api.LookupException;
using ApacheFetcher = no.difi.vefa.peppol.lookup.fetcher.ApacheFetcher;
using UrlFetcher = no.difi.vefa.peppol.lookup.fetcher.UrlFetcher;
using BusdoxLocator = no.difi.vefa.peppol.lookup.locator.BusdoxLocator;
using Mode = no.difi.vefa.peppol.mode.Mode;
using CertificateValidator = no.difi.vefa.peppol.security.api.CertificateValidator;


namespace no.difi.vefa.peppol.lookup
{


	public class LookupClientTest
	{

		private Mode testMode = Mode.of("TEST");

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void simple() throws no.difi.vefa.peppol.common.lang.PeppolException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void simple()
		{
			LookupClient client = LookupClientBuilder.forProduction().fetcher(typeof(ApacheFetcher)).build();

			IList<DocumentTypeIdentifier> documentTypeIdentifiers = client.getDocumentIdentifiers(ParticipantIdentifier.of("9908:810418052"));

			assertNotNull(documentTypeIdentifiers);
			assertNotEquals(documentTypeIdentifiers.Count, 0);

			ServiceMetadata serviceMetadata = client.getServiceMetadata(ParticipantIdentifier.of("9908:810418052"), DocumentTypeIdentifier.of("urn:oasis:names:specification:ubl:schema:xsd:Invoice-2::Invoice##" + "urn:www.cenbii.eu:transaction:biitrns010:ver2.0" + ":extended:urn:www.peppol.eu:bis:peppol4a:ver2.0::2.1"));
			assertNotNull(serviceMetadata);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void simpleHeader() throws no.difi.vefa.peppol.common.lang.PeppolException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void simpleHeader()
		{
			LookupClient client = LookupClientBuilder.forMode(testMode).fetcher(typeof(ApacheFetcher)).build();

			Endpoint endpoint = client.getEndpoint(Header.newInstance().receiver(ParticipantIdentifier.of("9908:810418052")).documentType(DocumentTypeIdentifier.of("urn:oasis:names:specification:ubl:schema:xsd:Invoice-2::Invoice##" + "urn:www.cenbii.eu:transaction:biitrns010:ver2.0" + ":extended:urn:www.peppol.eu:bis:peppol4a:ver2.0::2.1")).process(ProcessIdentifier.of("urn:www.cenbii.eu:profile:bii04:ver2.0")), TransportProfile.AS2_1_0);

			assertNotNull(endpoint);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void simpleEndpoint() throws no.difi.vefa.peppol.common.lang.PeppolException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void simpleEndpoint()
		{
			LookupClient client = LookupClientBuilder.forProduction().certificateValidator(no.difi.vefa.peppol.security.api.CertificateValidator_Fields.EMPTY).build();

			Endpoint endpoint = client.getEndpoint(ParticipantIdentifier.of("9908:991825827"), DocumentTypeIdentifier.of("urn:oasis:names:specification:ubl:schema:xsd:Invoice-2::Invoice##" + "urn:www.cenbii.eu:transaction:biitrns010:ver2.0" + ":extended:urn:www.peppol.eu:bis:peppol4a:ver2.0::2.1"), ProcessIdentifier.of("urn:www.cenbii.eu:profile:bii04:ver2.0"), TransportProfile.AS2_1_0);

			assertNotNull(endpoint);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void simpleEndpointWithHeader() throws no.difi.vefa.peppol.common.lang.PeppolException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void simpleEndpointWithHeader()
		{
			LookupClient client = LookupClientBuilder.forProduction().certificateValidator(no.difi.vefa.peppol.security.api.CertificateValidator_Fields.EMPTY).build();

			Header header = Header.newInstance().sender(ParticipantIdentifier.of("9908:invalid")).receiver(ParticipantIdentifier.of("9908:991825827")).process(ProcessIdentifier.of("urn:www.cenbii.eu:profile:bii04:ver2.0")).documentType(DocumentTypeIdentifier.of("urn:oasis:names:specification:ubl:schema:xsd:Invoice-2::Invoice##" + "urn:www.cenbii.eu:transaction:biitrns010:ver2.0" + ":extended:urn:www.peppol.eu:bis:peppol4a:ver2.0::2.1"));

			Endpoint endpoint = client.getEndpoint(header, TransportProfile.AS2_1_0);

			assertNotNull(endpoint);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test(enabled = false) public void simple9915() throws no.difi.vefa.peppol.common.lang.PeppolException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void simple9915()
		{
			LookupClient client = LookupClientBuilder.forTest().fetcher(typeof(UrlFetcher)).build();

			IList<DocumentTypeIdentifier> documentTypeIdentifiers = client.getDocumentIdentifiers(ParticipantIdentifier.of("9915:setcce-test"));

			assertNotNull(documentTypeIdentifiers);
			assertNotEquals(documentTypeIdentifiers.Count, 0);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test(enabled = false) public void simple9933() throws no.difi.vefa.peppol.common.lang.PeppolException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void simple9933()
		{
			LookupClient client = LookupClientBuilder.forProduction().fetcher(typeof(UrlFetcher)).build();

			IList<DocumentTypeIdentifier> documentTypeIdentifiers = client.getDocumentIdentifiers(ParticipantIdentifier.of("9933:061828591"));

			assertNotNull(documentTypeIdentifiers);
			assertNotEquals(documentTypeIdentifiers.Count, 0);

			ServiceMetadata serviceMetadata = client.getServiceMetadata(ParticipantIdentifier.of("9933:061828591"), DocumentTypeIdentifier.of("urn:oasis:names:specification:ubl:schema:xsd:Invoice-2::Invoice##" + "urn:www.cenbii.eu:transaction:biicoretrdm010:ver1.0" + ":#urn:www.peppol.eu:bis:peppol4a:ver1.0::2.0"));
			assertNotNull(serviceMetadata);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test(enabled = false, expectedExceptions = no.difi.vefa.peppol.lookup.api.LookupException.class) public void noSmp() throws no.difi.vefa.peppol.common.lang.PeppolException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void noSmp()
		{
			LookupClient client = LookupClientBuilder.forMode(testMode).locator(typeof(BusdoxLocator)).build();

			IList<DocumentTypeIdentifier> dti = client.getDocumentIdentifiers(ParticipantIdentifier.of("9908:no-smp"));
			Console.WriteLine(dti);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test(enabled = false, expectedExceptions = no.difi.vefa.peppol.lookup.api.LookupException.class) public void noSmpApache() throws no.difi.vefa.peppol.common.lang.PeppolException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void noSmpApache()
		{
			LookupClient client = LookupClientBuilder.forMode(testMode).fetcher(typeof(ApacheFetcher)).locator(typeof(BusdoxLocator)).build();

			client.getDocumentIdentifiers(ParticipantIdentifier.of("9908:no-smp"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test(expectedExceptions = no.difi.vefa.peppol.lookup.api.LookupException.class) public void noSml() throws no.difi.vefa.peppol.common.lang.PeppolException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void noSml()
		{
			LookupClient client = LookupClientBuilder.forMode(testMode).locator(typeof(BusdoxLocator)).build();

			client.getDocumentIdentifiers(ParticipantIdentifier.of("9908:no-sml"));
		}
	}

}