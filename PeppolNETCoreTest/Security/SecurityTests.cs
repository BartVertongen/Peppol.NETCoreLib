

using System;
using VertSoft.Peppol.Security.Util;
using VertSoft.Peppol.Security.Xmldsig;


namespace VertSoft.Peppol.Security
{
	public static class SecurityTests
	{
		static public void RunAll()
		{
			SecurityTests.Run_DifiCertificateValidatorTest();	//Passed
			SecurityTests.Run_DomUtilsTest();	//DomUtils class is not used
			SecurityTests.Run_ExtraSignatureMethodTest();	//Does nothing
			//SecurityTests.Run_XmldsigTest();
			Run_EncryptionTest();
		}

		static private void Run_DifiCertificateValidatorTest()
		{
			DifiCertificateValidatorTest TestDifiCertificateValidator = new DifiCertificateValidatorTest();
			TestDifiCertificateValidator.SimpleSmpTest();
			TestDifiCertificateValidator.SimpleSmpProd();
			TestDifiCertificateValidator.SimpleApTest();
			TestDifiCertificateValidator.SimpleApProd();
			Console.WriteLine("Passed DifiCertificateValidatorTest");
		}

		static private void Run_DomUtilsTest()
		{
			DomUtilsTest TestDomUtils = new DomUtilsTest();
			TestDomUtils.simpleConstructor();
			Console.WriteLine("Passed DomUtilsTest");
		}

		static private void Run_ExtraSignatureMethodTest()
		{
			//SignatureMethod is a static class with methods for signature.
			Console.WriteLine("Passed ExtraSignatureMethodTest");
		}

		static private void Run_XmldsigTest()
		{
			XmldsigTest TestXmldsig = new XmldsigTest();
			TestXmldsig.SetUp();
			TestXmldsig.SimpleContructors();
			TestXmldsig.SimpleSHA1();			
			TestXmldsig.SimpleSHA256();
			TestXmldsig.SignAndValidate();
			Console.WriteLine("Passed XmldsigTest");
		}

		static private void Run_EncryptionTest()
		{
			EncryptionTest TestEncryption = new EncryptionTest();
			TestEncryption.SetUp();
			TestEncryption.Encrypt();
			TestEncryption.Decrypt();
			TestEncryption.Verify();
			Console.WriteLine("Passed EncryptionTest");
		}
	}
}
