
using System;
using VertSoft.Peppol.Common.Code;
using VertSoft.Peppol.Common.Lang;
using VertSoft.Peppol.Common.Model;
using VertSoft.Peppol.Common.Util;


namespace VertSoft.Peppol.Common
{
	static public class CommonTests
	{
		static public void RunAll()
		{
			CommonTests.Run_DigestMethodTest();
			CommonTests.Run_ServiceTest();
			CommonTests.Run_PeppolExceptionTest();
			CommonTests.Run_PeppolParsingExceptionTest();
			CommonTests.Run_PeppolRuntimeExceptionTest();
			CommonTests.Run_DigestTest();
			CommonTests.Run_SchemeTest();
			CommonTests.Run_DigestTest();
			CommonTests.Run_ParticipantIdentifierTest();
			CommonTests.Run_ProcessIdentifierTest();
			CommonTests.Run_InstanceIdentifierTest();
			CommonTests.Run_InstanceTypeTest();
			CommonTests.Run_DocumentTypeIdentifierTest();
			CommonTests.Run_TransportProtocolTest();
			CommonTests.Run_TransportProfileTest();
			CommonTests.Run_EndpointTest();
			CommonTests.Run_ServiceMetadataTest();
			CommonTests.Run_ProcessMetadataTest();
			CommonTests.Run_ReceiptTest();
			CommonTests.Run_HeaderTest();
			CommonTests.Run_UnsignedTest();
			CommonTests.Run_SignedTest();
			CommonTests.Run_ModelUtilsTest();
		}

		static private void Run_DigestMethodTest()
		{
			DigestMethodTest TestDigestMethod = new DigestMethodTest();
			TestDigestMethod.simple();
			Console.WriteLine("Passed DigestMethodTest");
		}

		static private void Run_ServiceTest()
		{
			ServiceTest TestService = new ServiceTest();
			TestService.simple();
			Console.WriteLine("Passed ServiceTest");
		}

		/// <summary>
		/// 
		/// </summary>
		static private void Run_PeppolExceptionTest()
		{
			PeppolExceptionTest TestException = new PeppolExceptionTest();
			TestException.simpleConstructors();
			Console.WriteLine("Passed PeppolExceptionTest");
		}

		static private void Run_PeppolParsingExceptionTest()
		{
			PeppolParsingExceptionTest TestPeppolParsingException = new PeppolParsingExceptionTest();
			TestPeppolParsingException.simpleConstructors();
			Console.WriteLine("Passed PeppolParsingExceptionTest");
		}

		static private void Run_PeppolRuntimeExceptionTest()
		{
			PeppolRuntimeExceptionTest TestPeppolRuntimeException = new PeppolRuntimeExceptionTest();
			TestPeppolRuntimeException.simpleConstructors();
			Console.WriteLine("Passed PeppolRuntimeExceptionTest");
		}


		static private void Run_DigestTest()
		{
			DigestTest TestDigest = new DigestTest();
			TestDigest.simple();
			Console.WriteLine("Passed DigestTest");
		}

		static private void Run_SchemeTest()
		{
			SchemeTest TestScheme = new SchemeTest();
			TestScheme.simple();
			Console.WriteLine("Passed SchemaTest");
		}

		static private void Run_ParticipantIdentifierTest()
		{
			ParticipantIdentifierTest TestParticipantIdentifier = new ParticipantIdentifierTest();
			TestParticipantIdentifier.simple();
			TestParticipantIdentifier.simpleParse();
			Console.WriteLine("Passed ParticipantIdentifierTest");
		}

		static private void Run_ProcessIdentifierTest()
		{
			ProcessIdentifierTest TestProcessIndentifier = new ProcessIdentifierTest();
			TestProcessIndentifier.simple();
			TestProcessIndentifier.simpleParse();
			Console.WriteLine("Passed ProcessIdentifierTest");
		}

		static private void Run_InstanceIdentifierTest()
		{
			InstanceIdentifierTest TestInstanceIdentifier = new InstanceIdentifierTest();
			TestInstanceIdentifier.simple();
			Console.WriteLine("Passed InstanceIdentifierTest");
		}

		static private void Run_InstanceTypeTest()
		{
			InstanceTypeTest TestInstanceType = new InstanceTypeTest();
			TestInstanceType.simple();
			Console.WriteLine("Passed InstanceTypeTest");
		}


		static private void Run_DocumentTypeIdentifierTest()
		{
			DocumentTypeIdentifierTest TestDocumentTypeIdentifier = new DocumentTypeIdentifierTest();
			TestDocumentTypeIdentifier.simple();
			TestDocumentTypeIdentifier.simpleParse();
			Console.WriteLine("Passed DocumentTypeIdentifierTest");
		}

		static private void Run_TransportProtocolTest()
		{
			TransportProtocolTest TestTransportProtocol = new TransportProtocolTest();
			TestTransportProtocol.simple();
			Console.WriteLine("Passed TransportProtocolTest");
		}

		static private void Run_TransportProfileTest()
		{
			TransportProfileTest TestTransportProfile = new TransportProfileTest();
			TestTransportProfile.simple();
			Console.WriteLine("Passed TransportProfileTest");
		}

		static private void Run_EndpointTest()
		{
			EndpointTest TestEndPoint = new EndpointTest();
			TestEndPoint.simple();
			Console.WriteLine("Passed EndpointTest");
		}

		static private void Run_ServiceMetadataTest()
		{
			ServiceMetadataTest TestServiceMetadata = new ServiceMetadataTest();
			TestServiceMetadata.simple();
			Console.WriteLine("Passed ServiceMetadataTest");
		}


		static private void Run_ProcessMetadataTest()
		{
			ProcessMetadataTest TestProcessMetadata = new ProcessMetadataTest();
			TestProcessMetadata.simple();
			Console.WriteLine("Passed ProcessMetadataTest");
		}

		static private void Run_ReceiptTest()
		{
			ReceiptTest TestReceipt = new ReceiptTest();
			TestReceipt.simple();
			Console.WriteLine("Passed ReceiptTest");
		}

		static private void Run_HeaderTest()
		{
			HeaderTest TestHeader = new HeaderTest();
			TestHeader.simple();
			TestHeader.shortOfMethod();
			Console.WriteLine("Passed HeaderTest");
		}

		static private void Run_UnsignedTest()
		{
			UnsignedTest TestUnsigned = new UnsignedTest();
			TestUnsigned.simple();
			Console.WriteLine("Passed UnsignedTest");
		}

		static private void Run_SignedTest()
		{
			SignedTest TestSigned = new SignedTest();
			TestSigned.simple();
			TestSigned.simpleSubset();
			Console.WriteLine("Passed SignedTest");
		}

		static private void Run_ModelUtilsTest()
		{
			ModelUtilsTest TestModelUtils = new ModelUtilsTest();
			TestModelUtils.simpleConstructor();
			TestModelUtils.simpleDecoderNullPointer();
			TestModelUtils.simpleEncoderNullPointer();
			TestModelUtils.simple();
			Console.WriteLine("Passed ModelUtilsTest");
		}
	}
}
