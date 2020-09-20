using System;



namespace VertSoft.Peppol.Publisher
{
	public static class PublisherTests
	{
		//REM: To DO the tests well we need an implementation of an SMP in C#.NET Core
		static public void RunAll()
		{
			PublisherTests.Run_MyPublisherTests();
			PublisherTests.Run_PublisherServiceTest();						
		}

		static private void Run_MyPublisherTests()
		{
			MyPublisherTests MyTests = new MyPublisherTests();
			MyTests.Run_CreatePublisherServiceGroupTest();
			MyTests.Run_CreateServiceGroupBusdoxTest();
			MyTests.Run_CreateServiceGroupBDXR2014Test();
			MyTests.Run_CreateServiceGroupBDXR2016Test();
			Console.WriteLine("Passed MyPublisherTests");
		}

		static private void Run_PublisherServiceTest()
		{
			PublisherServiceTest TestPublisherService = new PublisherServiceTest();
			TestPublisherService.SimpleServiceGroup();
			TestPublisherService.SimpleServiceMetadata();
			Console.WriteLine("Passed PublisherServiceTest");
		}
	}
}
