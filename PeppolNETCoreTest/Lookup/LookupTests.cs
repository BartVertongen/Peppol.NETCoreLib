
using System;
using VertSoft.Peppol.Lookup.Fetcher;
using VertSoft.Peppol.Lookup.Locator;
using VertSoft.Peppol.Lookup.Model;
using VertSoft.Peppol.Lookup.Reader;
using VertSoft.Peppol.Lookup.Util;


namespace VertSoft.Peppol.Lookup
{
	public static class LookupTests
	{
		static public void RunAll()
		{
			// OK LookupTests.Run_ApacheFetcherTest();
			// OK LookupTests.Run_StaticLocatorTest();
			// OK LookupTests.Run_DynamicHostnameGeneratorTest();
			LookupTests.Run_BusdoxLocatorTest();
			LookupTests.Bdxr201605ReaderTest();
			LookupTests.BusdoxReaderTest();
			LookupTests.MultiReaderTest();
		}

		static private void Run_ApacheFetcherTest()
		{
			ApacheFetcherTest TestApacheFetcher = new ApacheFetcherTest();
			TestApacheFetcher.simpleNullPointer();
			TestApacheFetcher.simple404();
			TestApacheFetcher.simple500();
			TestApacheFetcher.simpleTimeoutAsync();
			Console.WriteLine("Passed ApacheFetcherTest");
		}

		static private void Run_StaticLocatorTest()
		{
			StaticLocatorTest TestStaticLocator = new StaticLocatorTest();
			TestStaticLocator.simple();
			Console.WriteLine("Passed StaticLocatorTest");
		}

		static private void Run_DynamicHostnameGeneratorTest()
		{
			DynamicHostnameGeneratorTest TestDynamicHostGenerator = new DynamicHostnameGeneratorTest();
			TestDynamicHostGenerator.simpleMd5();
			//TestDynamicHostGenerator.simpleSHA224();
			TestDynamicHostGenerator.triggerException();
			Console.WriteLine("Passed DynamicHostnameGeneratorTest");
		}

		static private void Run_BusdoxLocatorTest()
		{
			BusdoxLocatorTest TestBusdoxLocator = new BusdoxLocatorTest();
			TestBusdoxLocator.simple();
			Console.WriteLine("Passed BusdoxLocatorTest");

			DocumentTypeIdentifierWithUriTest TestDocTypeIdWithUri = new DocumentTypeIdentifierWithUriTest();
			TestDocTypeIdWithUri.simple();
			Console.WriteLine("Passed DocumentTypeIdentifierWithUriTest");
		}

		static private void Bdxr201605ReaderTest()
		{
			Bdxr201605ReaderTest TestBdxr201605Reader = new Bdxr201605ReaderTest();
			TestBdxr201605Reader.documentIdentifers();
			TestBdxr201605Reader.serviceMetadata();
			Console.WriteLine("Passed Bdxr201605ReaderTest");
		}

		static private void BusdoxReaderTest()
		{
			BusdoxReaderTest TestBusdoxReader = new BusdoxReaderTest();
			TestBusdoxReader.documentIdentifers();
			TestBusdoxReader.documentIdentifiersDocsLogistics();
			TestBusdoxReader.serviceMetadata();
			Console.WriteLine("Passed BusdoxReaderTest");
		}


		static private void MultiReaderTest()
		{
			MultiReaderTest TestMultiReader = new MultiReaderTest();
			TestMultiReader.busdoxDocumentIdentifers();
			TestMultiReader.busdoxServiceGroup();
			TestMultiReader.busdoxServiceMetadata();
			TestMultiReader.busdoxServiceMetadataMultiProcess();
			TestMultiReader.bdxr201407DocumentIdentifers();
			TestMultiReader.bdxr201605DocumentIdentifers();
			TestMultiReader.bdxrServiceMetadata();
			Console.WriteLine("Passed MultiReaderTest");
		}
	}
}
