namespace no.difi.certvalidator.extra
{

	using CertificateValidationException = no.difi.certvalidator.api.CertificateValidationException;
	using FailedValidationException = no.difi.certvalidator.api.FailedValidationException;
	using PrincipalNameProvider = no.difi.certvalidator.api.PrincipalNameProvider;
	using CriticalExtensionRule = no.difi.certvalidator.rule.CriticalExtensionRule;
	using ExpirationRule = no.difi.certvalidator.rule.ExpirationRule;
	using SigningRule = no.difi.certvalidator.rule.SigningRule;
	using X509TestGenerator = no.difi.certvalidator.testutil.X509TestGenerator;
	using Assert = org.testng.Assert;
	using Test = org.testng.annotations.Test;

	public class NorwegianOrganizationNumberRuleTest : X509TestGenerator
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void shouldExtractOrgnumberFromCertBasedOnSerialnumber() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void shouldExtractOrgnumberFromCertBasedOnSerialnumber()
		{
			const string ORGNR = "123456789";
			X509Certificate cert = createX509Certificate("CN=name, OU=None, O=None L=None, C=None, serialNumber=" + ORGNR);

			new NorwegianOrganizationNumberRule(new PrincipalNameProviderAnonymousInnerClass(this, ORGNR))
		   .validate(cert);
		}

		private class PrincipalNameProviderAnonymousInnerClass : PrincipalNameProvider<string>
		{
			private readonly NorwegianOrganizationNumberRuleTest outerInstance;

			private string ORGNR;

			public PrincipalNameProviderAnonymousInnerClass(NorwegianOrganizationNumberRuleTest outerInstance, string ORGNR)
			{
				this.outerInstance = outerInstance;
				this.ORGNR = ORGNR;
			}

			public bool validate(string value)
			{
				Assert.assertEquals(ORGNR, value);
				return true;
			}
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test(expectedExceptions = no.difi.certvalidator.api.FailedValidationException.class) public void invalidOrgnumberFromCertBasedOnSerialnumber() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void invalidOrgnumberFromCertBasedOnSerialnumber()
		{
			const string ORGNR = "123 456 789";
			X509Certificate cert = createX509Certificate("CN=name, OU=None, O=None L=None, C=None, serialNumber=" + ORGNR);

			new NorwegianOrganizationNumberRule(new PrincipalNameProviderAnonymousInnerClass2(this))
		   .validate(cert);
		}

		private class PrincipalNameProviderAnonymousInnerClass2 : PrincipalNameProvider<string>
		{
			private readonly NorwegianOrganizationNumberRuleTest outerInstance;

			public PrincipalNameProviderAnonymousInnerClass2(NorwegianOrganizationNumberRuleTest outerInstance)
			{
				this.outerInstance = outerInstance;
			}

			public bool validate(string value)
			{
				Assert.fail("Number not expected.");
				return true;
			}
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void shouldExtractOrgnumberFromCertBasedOnOrgNumberInOrganiation() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void shouldExtractOrgnumberFromCertBasedOnOrgNumberInOrganiation()
		{
			const string ORGNR = "123456789";
			X509Certificate cert = createX509Certificate("CN=name, OU=None, O=organisasjon - " + ORGNR + ", L=None, C=None");

			new NorwegianOrganizationNumberRule(new PrincipalNameProviderAnonymousInnerClass3(this, ORGNR))
		   .validate(cert);
		}

		private class PrincipalNameProviderAnonymousInnerClass3 : PrincipalNameProvider<string>
		{
			private readonly NorwegianOrganizationNumberRuleTest outerInstance;

			private string ORGNR;

			public PrincipalNameProviderAnonymousInnerClass3(NorwegianOrganizationNumberRuleTest outerInstance, string ORGNR)
			{
				this.outerInstance = outerInstance;
				this.ORGNR = ORGNR;
			}

			public bool validate(string value)
			{
				Assert.assertEquals(ORGNR, value);
				return true;
			}
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void shouldExtractOrgnumberFromComfidesCert() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void shouldExtractOrgnumberFromComfidesCert()
		{
			const string ORGNR = "399573952";
			X509Certificate cert = createX509Certificate("C=NO,ST=AKERSHUS,L=FORNEBUVEIEN 1\\, 1366 LYSAKER,O=RF Commfides,SERIALNUMBER=399573952,CN=RF Commfides");

			new NorwegianOrganizationNumberRule(new PrincipalNameProviderAnonymousInnerClass4(this, ORGNR))
		   .validate(cert);
		}

		private class PrincipalNameProviderAnonymousInnerClass4 : PrincipalNameProvider<string>
		{
			private readonly NorwegianOrganizationNumberRuleTest outerInstance;

			private string ORGNR;

			public PrincipalNameProviderAnonymousInnerClass4(NorwegianOrganizationNumberRuleTest outerInstance, string ORGNR)
			{
				this.outerInstance = outerInstance;
				this.ORGNR = ORGNR;
			}

			public bool validate(string value)
			{
				Assert.assertEquals(ORGNR, value);
				return true;
			}
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test(expectedExceptions = no.difi.certvalidator.api.FailedValidationException.class) public void attributesNotFound() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void attributesNotFound()
		{
			X509Certificate cert = createX509Certificate("CN=name");

			new NorwegianOrganizationNumberRule(new PrincipalNameProviderAnonymousInnerClass5(this))
		   .validate(cert);
		}

		private class PrincipalNameProviderAnonymousInnerClass5 : PrincipalNameProvider<string>
		{
			private readonly NorwegianOrganizationNumberRuleTest outerInstance;

			public PrincipalNameProviderAnonymousInnerClass5(NorwegianOrganizationNumberRuleTest outerInstance)
			{
				this.outerInstance = outerInstance;
			}

			public bool validate(string value)
			{
				Assert.fail("Number not expected.");
				return true;
			}
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test(expectedExceptions = no.difi.certvalidator.api.FailedValidationException.class) public void notAcceptedOrgnumberFromCertBasedOnSerialnumber() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void notAcceptedOrgnumberFromCertBasedOnSerialnumber()
		{
			const string ORGNR = "123456789";
			X509Certificate cert = createX509Certificate("CN=name, OU=None, O=None L=None, C=None, serialNumber=" + ORGNR);

			new NorwegianOrganizationNumberRule(new PrincipalNameProviderAnonymousInnerClass6(this))
		   .validate(cert);
		}

		private class PrincipalNameProviderAnonymousInnerClass6 : PrincipalNameProvider<string>
		{
			private readonly NorwegianOrganizationNumberRuleTest outerInstance;

			public PrincipalNameProviderAnonymousInnerClass6(NorwegianOrganizationNumberRuleTest outerInstance)
			{
				this.outerInstance = outerInstance;
			}

			public bool validate(string value)
			{
				return false;
			}
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test(expectedExceptions = no.difi.certvalidator.api.CertificateValidationException.class) public void triggerExceptionInExtractNumber() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void triggerExceptionInExtractNumber()
		{
			NorwegianOrganizationNumberRule.extractNumber(null);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test(enabled = false) public void testingMoveCertificate() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void testingMoveCertificate()
		{
			X509Certificate certificate = Validator.getCertificate(this.GetType().getResourceAsStream("/difi-move-test.cer"));

			Validator validator = ValidatorBuilder.newInstance().addRule(new ExpirationRule()).addRule(SigningRule.PublicSignedOnly()).addRule(CriticalExtensionRule.recognizes("2.5.29.15", "2.5.29.19")).addRule(CriticalExtensionRule.requires("2.5.29.15")).addRule(new NorwegianOrganizationNumberRule(new PrincipalNameProviderAnonymousInnerClass7(this)))
				   .build();

			validator.validate(certificate);
		}

		private class PrincipalNameProviderAnonymousInnerClass7 : PrincipalNameProvider<string>
		{
			private readonly NorwegianOrganizationNumberRuleTest outerInstance;

			public PrincipalNameProviderAnonymousInnerClass7(NorwegianOrganizationNumberRuleTest outerInstance)
			{
				this.outerInstance = outerInstance;
			}

			public bool validate(string s)
			{
				// Accept all organization numbers.
				return true;
			}
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void simpleObjectTest()
		public virtual void simpleObjectTest()
		{
			NorwegianOrganizationNumberRule.NorwegianOrganization no = new NorwegianOrganizationNumberRule.NorwegianOrganization("123456789", "Test");
			Assert.assertEquals(no.Number, "123456789");
			Assert.assertEquals(no.Name, "Test");
		}
	}

}