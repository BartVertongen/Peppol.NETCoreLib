namespace no.difi.certvalidator.usage
{
	using no.difi.certvalidator;
	using CertificateBucket = no.difi.certvalidator.api.CertificateBucket;
	using CrlCache = no.difi.certvalidator.api.CrlCache;
	using no.difi.certvalidator.rule;
	using KeyStoreCertificateBucket = no.difi.certvalidator.util.KeyStoreCertificateBucket;
	using SimpleCrlCache = no.difi.certvalidator.util.SimpleCrlCache;
	using SimplePrincipalNameProvider = no.difi.certvalidator.util.SimplePrincipalNameProvider;
	using Test = org.testng.annotations.Test;

	public class PeppolTest
	{

		private CrlCache crlCache = new SimpleCrlCache();

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void simpleTestAp() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void simpleTestAp()
		{
			KeyStoreCertificateBucket keyStoreCertificateBucket = new KeyStoreCertificateBucket(this.GetType().getResourceAsStream("/peppol-test.jks"), "peppol");
			CertificateBucket rootCertificates = keyStoreCertificateBucket.toSimple("peppol-root");
			CertificateBucket intermediateCertificates = keyStoreCertificateBucket.toSimple("peppol-ap", "peppol-smp");

			Validator valvalidatordatorHelper = ValidatorBuilder.newInstance().addRule(new ExpirationRule()).addRule(new SigningRule()).addRule(new PrincipalNameRule("CN", new SimplePrincipalNameProvider("PEPPOL ACCESS POINT TEST CA"), PrincipalNameRule.Principal.ISSUER)).addRule(new ChainRule(rootCertificates, intermediateCertificates)).addRule(new CRLRule(crlCache)).addRule(new OCSPRule(intermediateCertificates)).build();

			valvalidatordatorHelper.validate(this.GetType().getResourceAsStream("/peppol-test-ap-difi.cer"));
			valvalidatordatorHelper.validate(this.GetType().getResourceAsStream("/peppol-test-ap-difi.cer"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void simpleTestSmp() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void simpleTestSmp()
		{
			KeyStoreCertificateBucket keyStoreCertificateBucket = new KeyStoreCertificateBucket(this.GetType().getResourceAsStream("/peppol-test.jks"), "peppol");
			CertificateBucket rootCertificates = keyStoreCertificateBucket.toSimple("peppol-root");
			CertificateBucket intermediateCertificates = keyStoreCertificateBucket.toSimple("peppol-ap", "peppol-smp");

			ValidatorBuilder.newInstance().addRule(new ExpirationRule()).addRule(new SigningRule()).addRule(new PrincipalNameRule("CN", new SimplePrincipalNameProvider("PEPPOL SERVICE METADATA PUBLISHER TEST CA"), PrincipalNameRule.Principal.ISSUER)).addRule(new ChainRule(rootCertificates, intermediateCertificates)).addRule(new CRLRule(crlCache)).addRule(new OCSPRule(intermediateCertificates)).build().validate(this.GetType().getResourceAsStream("/peppol-test-smp-difi.cer"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test(enabled = false) public void simpleProdAp() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void simpleProdAp()
		{
			KeyStoreCertificateBucket keyStoreCertificateBucket = new KeyStoreCertificateBucket(this.GetType().getResourceAsStream("/peppol-prod.jks"), "peppol");
			CertificateBucket rootCertificates = keyStoreCertificateBucket.toSimple("peppol-root");
			CertificateBucket intermediateCertificates = keyStoreCertificateBucket.toSimple("peppol-ap", "peppol-smp");

			ValidatorBuilder.newInstance().addRule(new ExpirationRule()).addRule(new SigningRule()).addRule(new PrincipalNameRule("CN", new SimplePrincipalNameProvider("PEPPOL ACCESS POINT CA"), PrincipalNameRule.Principal.ISSUER)).addRule(new ChainRule(rootCertificates, intermediateCertificates)).addRule(new CRLRule(crlCache)).addRule(new OCSPRule(intermediateCertificates)).build().validate(this.GetType().getResourceAsStream("/peppol-prod-ap-difi.cer"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void simpleProdSmp() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void simpleProdSmp()
		{
			KeyStoreCertificateBucket keyStoreCertificateBucket = new KeyStoreCertificateBucket(this.GetType().getResourceAsStream("/peppol-prod.jks"), "peppol");
			CertificateBucket rootCertificates = keyStoreCertificateBucket.toSimple("peppol-root");
			CertificateBucket intermediateCertificates = keyStoreCertificateBucket.toSimple("peppol-ap", "peppol-smp");

			ValidatorBuilder.newInstance().addRule(new ExpirationRule()).addRule(new SigningRule()).addRule(new PrincipalNameRule("CN", new SimplePrincipalNameProvider("PEPPOL SERVICE METADATA PUBLISHER CA"), PrincipalNameRule.Principal.ISSUER)).addRule(new ChainRule(rootCertificates, intermediateCertificates)).addRule(new CRLRule(crlCache)).addRule(new OCSPRule(intermediateCertificates)).build().validate(this.GetType().getResourceAsStream("/peppol-prod-smp-difi.cer"));
		}
	}

}