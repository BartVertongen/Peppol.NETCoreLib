using System;

namespace no.difi.certvalidator.util
{
	using ChainRule = no.difi.certvalidator.rule.ChainRule;
	using CertificateBucket = no.difi.certvalidator.api.CertificateBucket;
	using Assert = org.testng.Assert;
	using Test = org.testng.annotations.Test;

	/// <summary>
	/// Test exists to show potential use.
	/// </summary>
	public class CertificateBucketWrapperTest
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void simple() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void simple()
		{
			// Load keystore
			KeyStoreCertificateBucket keyStoreCertificateBucket = new KeyStoreCertificateBucket(this.GetType().getResourceAsStream("/peppol-test.jks"), "peppol");
			// Fetch root certificate from keystore
			CertificateBucket rootCertificates = keyStoreCertificateBucket.toSimple("peppol-root");
			// Define a wrapper for intermediate certificates, currently empty
			CertificateBucketWrapper intermediateCertificates = new CertificateBucketWrapper(null);

			// Build the validator
			Validator validator = ValidatorBuilder.newInstance().addRule(new ChainRule(rootCertificates, intermediateCertificates)).build();

			// See, no certificates inside wrapper!
			Assert.assertNull(intermediateCertificates.CertificateBucket);

			// Set intermediate certificate
			intermediateCertificates.CertificateBucket = keyStoreCertificateBucket.toSimple("peppol-ap");
			// Validate!
			validator.validate(this.GetType().getResourceAsStream("/peppol-test-ap-difi.cer"));

			try
			{
				// Currently not valid
				validator.validate(this.GetType().getResourceAsStream("/peppol-test-smp-difi.cer"));
				Assert.fail("Exception expected!");
			}
			catch (Exception)
			{
				// No action
			}

			// Change intermediate certificate
			intermediateCertificates.CertificateBucket = keyStoreCertificateBucket.toSimple("peppol-smp");
			// Validate!
			validator.validate(this.GetType().getResourceAsStream("/peppol-test-smp-difi.cer"));

			try
			{
				// Currently not valid
				validator.validate(this.GetType().getResourceAsStream("/peppol-test-ap-difi.cer"));
				Assert.fail("Exception expected!");
			}
			catch (Exception)
			{
				// No action
			}

			// Add certificate to existing bucket inside wrapper
			keyStoreCertificateBucket.toSimple((SimpleCertificateBucket) intermediateCertificates.CertificateBucket, "peppol-ap");

			// Validate!
			validator.validate(this.GetType().getResourceAsStream("/peppol-test-ap-difi.cer"));
			// Validate!
			validator.validate(this.GetType().getResourceAsStream("/peppol-test-smp-difi.cer"));

			// Find issuer certificate
			Assert.assertNotNull(intermediateCertificates.findBySubject(Validator.getCertificate(this.GetType().getResourceAsStream("/peppol-test-ap-difi.cer")).IssuerX500Principal));
			Assert.assertNotNull(intermediateCertificates.findBySubject(Validator.getCertificate(this.GetType().getResourceAsStream("/peppol-test-smp-difi.cer")).IssuerX500Principal));
			Assert.assertNull(intermediateCertificates.findBySubject(Validator.getCertificate(this.GetType().getResourceAsStream("/peppol-prod-ap-difi.cer")).IssuerX500Principal));
			Assert.assertNull(intermediateCertificates.findBySubject(Validator.getCertificate(this.GetType().getResourceAsStream("/peppol-prod-smp-difi.cer")).IssuerX500Principal));
		}

	}

}