namespace no.difi.certvalidator.rule
{
	using CertificateValidationException = no.difi.certvalidator.api.CertificateValidationException;
	using FailedValidationException = no.difi.certvalidator.api.FailedValidationException;
	using ValidatorRule = no.difi.certvalidator.api.ValidatorRule;
	using KeyStoreCertificateBucket = no.difi.certvalidator.util.KeyStoreCertificateBucket;
	using SimpleCertificateBucket = no.difi.certvalidator.util.SimpleCertificateBucket;
	using Mockito = org.mockito.Mockito;
	using Test = org.testng.annotations.Test;

	public class OCSPRuleTest
	{

		/// <summary>
		/// OCSP should be tested only for certificates containing such information, just like CRL.
		/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void certificateWithoutOCSP() throws no.difi.certvalidator.api.CertificateValidationException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void certificateWithoutOCSP()
		{
			X509Certificate certificate = Validator.getCertificate(this.GetType().getResourceAsStream("/selfsigned.cer"));
			ValidatorRule rule = new OCSPRule(new SimpleCertificateBucket(certificate));
			rule.validate(certificate);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void certificateWithOCSP() throws no.difi.certvalidator.api.CertificateValidationException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void certificateWithOCSP()
		{
			KeyStoreCertificateBucket keyStoreCertificateBucket = new KeyStoreCertificateBucket("JKS", this.GetType().getResourceAsStream("/peppol-test.jks"), "peppol");
			ValidatorRule rule = new OCSPRule(keyStoreCertificateBucket.toSimple("peppol-ap", "peppol-smp"));
			rule.validate(Validator.getCertificate(this.GetType().getResourceAsStream("/peppol-test-smp-difi.cer")));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test(expectedExceptions = no.difi.certvalidator.api.FailedValidationException.class) public void issuerNotFound() throws no.difi.certvalidator.api.CertificateValidationException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void issuerNotFound()
		{
			ValidatorRule validatorRule = new OCSPRule(new SimpleCertificateBucket());
			(new Validator(validatorRule)).validate(this.GetType().getResourceAsStream("/peppol-test-smp-difi.cer"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test(expectedExceptions = no.difi.certvalidator.api.CertificateValidationException.class) public void triggerException() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void triggerException()
		{
			X509Certificate certificate = Mockito.mock(typeof(X509Certificate));
			Mockito.doThrow(new System.NullReferenceException()).when(certificate).getExtensionValue(Mockito.anyString());

			ValidatorRule validatorRule = new OCSPRule(new SimpleCertificateBucket());
			validatorRule.validate(certificate);
		}
	}

}