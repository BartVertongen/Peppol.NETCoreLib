namespace no.difi.certvalidator.rule
{
	using CertificateValidationException = no.difi.certvalidator.api.CertificateValidationException;
	using CrlCache = no.difi.certvalidator.api.CrlCache;
	using CrlFetcher = no.difi.certvalidator.api.CrlFetcher;
	using FailedValidationException = no.difi.certvalidator.api.FailedValidationException;
	using SimpleCrlCache = no.difi.certvalidator.util.SimpleCrlCache;
	using Mockito = org.mockito.Mockito;
	using Assert = org.testng.Assert;
	using Test = org.testng.annotations.Test;


	public class CRLRuleTest
	{

		private CrlCache crlCache = new SimpleCrlCache();

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void simple() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void simple()
		{
			ValidatorBuilder.newInstance().addRule(new CRLRule()).build().validate((this.GetType().getResourceAsStream("/peppol-test-ap-difi.cer")));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void updateCrl() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void updateCrl()
		{
			string crlUrl = "http://pilotonsitecrl.verisign.com/DigitaliseringsstyrelsenPilotOpenPEPPOLACCESSPOINTCA/LatestCRL.crl";

			crlCache.set(crlUrl, (X509CRL) CertificateFactory.getInstance("X509").generateCRL(this.GetType().getResourceAsStream("/peppol-test-ap.crl")));

			Validator validatorHelper = ValidatorBuilder.newInstance().addRule(new CRLRule(crlCache)).build();

			Assert.assertTrue(crlCache.get(crlUrl).NextUpdate.Time < DateTimeHelper.CurrentUnixTimeMillis());

			validatorHelper.validate((this.GetType().getResourceAsStream("/peppol-test-ap-difi.cer")));

			Assert.assertTrue(crlCache.get(crlUrl).NextUpdate.Time > DateTimeHelper.CurrentUnixTimeMillis());

			crlCache.set(crlUrl, null);
			Assert.assertNull(crlCache.get(crlUrl));

			validatorHelper.validate((this.GetType().getResourceAsStream("/peppol-test-ap-difi.cer")));

			Assert.assertNotNull(crlCache.get(crlUrl));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test(expectedExceptions = no.difi.certvalidator.api.CertificateValidationException.class) public void noUrlsSet() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void noUrlsSet()
		{
			Assert.assertEquals(CRLRule.getCrlDistributionPoints(Validator.getCertificate(this.GetType().getResourceAsStream("/nooids.cer"))).Count, 0);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void noUrlsInSet() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void noUrlsInSet()
		{
			X509Certificate certificate = Mockito.mock(typeof(X509Certificate));
			Mockito.doReturn(Collections.emptySet()).when(certificate).NonCriticalExtensionOIDs;

			Assert.assertEquals(CRLRule.getCrlDistributionPoints(certificate).Count, 0);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test(expectedExceptions = no.difi.certvalidator.api.FailedValidationException.class) public void revoked() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void revoked()
		{
			X509Certificate certificate = Validator.getCertificate(this.GetType().getResourceAsStream("/peppol-test-ap-difi.cer"));

			X509CRL x509CRL = Mockito.mock(typeof(X509CRL));
			Mockito.doReturn(true).when(x509CRL).isRevoked(certificate);

			CrlCache crlCache = new SimpleCrlCache();
			crlCache.set("http://pilotonsitecrl.verisign.com/DigitaliseringsstyrelsenPilotOpenPEPPOLACCESSPOINTCA/LatestCRL.crl", x509CRL);

			CRLRule rule = new CRLRule(crlCache);
			rule.validate(certificate);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void crlIsNull() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void crlIsNull()
		{
			X509Certificate certificate = Validator.getCertificate(this.GetType().getResourceAsStream("/peppol-test-ap-difi.cer"));

			CRLRule rule = new CRLRule(new CrlFetcherAnonymousInnerClass(this));
			rule.validate(certificate);
		}

		private class CrlFetcherAnonymousInnerClass : CrlFetcher
		{
			private readonly CRLRuleTest outerInstance;

			public CrlFetcherAnonymousInnerClass(CRLRuleTest outerInstance)
			{
				this.outerInstance = outerInstance;
			}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public java.security.cert.X509CRL get(String url) throws no.difi.certvalidator.api.CertificateValidationException
			public X509CRL get(string url)
			{
				return null;
			}
		}
	}

}