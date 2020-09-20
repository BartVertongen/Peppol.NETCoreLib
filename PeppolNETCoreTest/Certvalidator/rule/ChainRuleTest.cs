namespace no.difi.certvalidator.rule
{
	using CertificateBucket = no.difi.certvalidator.api.CertificateBucket;
	using FailedValidationException = no.difi.certvalidator.api.FailedValidationException;
	using KeyStoreCertificateBucket = no.difi.certvalidator.util.KeyStoreCertificateBucket;
	using SimpleReport = no.difi.certvalidator.util.SimpleReport;
	using Assert = org.testng.Assert;
	using Test = org.testng.annotations.Test;

	public class ChainRuleTest
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void simple() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void simple()
		{
			KeyStoreCertificateBucket keyStoreCertificateBucket = new KeyStoreCertificateBucket("JKS", this.GetType().getResourceAsStream("/peppol-test.jks"), "peppol");
			CertificateBucket rootCertificates = keyStoreCertificateBucket.toSimple("peppol-root");
			CertificateBucket intermediateCertificates = keyStoreCertificateBucket.toSimple("peppol-ap", "peppol-smp");

			Validator validator = ValidatorBuilder.newInstance().addRule(new ChainRule(rootCertificates, intermediateCertificates)).build();

			validator.validate(this.GetType().getResourceAsStream("/peppol-test-ap-difi.cer"), SimpleReport.newInstance());
			validator.validate(this.GetType().getResourceAsStream("/peppol-test-smp-difi.cer"));

			try
			{
				validator.validate(this.GetType().getResourceAsStream("/peppol-prod-smp-difi.cer"));
				Assert.fail("Exception expected.");
			}
			catch (FailedValidationException)
			{
				// No action.
			}
		}

	}

}