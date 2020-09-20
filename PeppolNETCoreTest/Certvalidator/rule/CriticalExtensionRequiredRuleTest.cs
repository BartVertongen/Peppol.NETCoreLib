namespace no.difi.certvalidator.rule
{

	using FailedValidationException = no.difi.certvalidator.api.FailedValidationException;
	using X509ExtensionCustom = no.difi.certvalidator.testutil.X509ExtensionCustom;
	using X509TestGenerator = no.difi.certvalidator.testutil.X509TestGenerator;
	using ASN1ObjectIdentifier = org.bouncycastle.asn1.ASN1ObjectIdentifier;
	using CertIOException = org.bouncycastle.cert.CertIOException;
	using X509v3CertificateBuilder = org.bouncycastle.cert.X509v3CertificateBuilder;
	using Test = org.testng.annotations.Test;

	public class CriticalExtensionRequiredRuleTest : X509TestGenerator
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test(enabled = false) public void shouldValidateCertWithOutAnyCriticalExtentions() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void shouldValidateCertWithOutAnyCriticalExtentions()
		{
			CriticalExtensionRequiredRule validator = new CriticalExtensionRequiredRule("2");
			X509Certificate cert = createX509Certificate();
			validator.validate(cert);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void shouldValidateCertWithApprovedCriticalExtentions() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void shouldValidateCertWithApprovedCriticalExtentions()
		{
			CriticalExtensionRequiredRule validator = CriticalExtensionRule.requires("2.10.2");
			X509Certificate cert = createX509Certificate(new X509ExtensionCustomAnonymousInnerClass(this));
			validator.validate(cert);
		}

		private class X509ExtensionCustomAnonymousInnerClass : X509ExtensionCustom
		{
			private readonly CriticalExtensionRequiredRuleTest outerInstance;

			public X509ExtensionCustomAnonymousInnerClass(CriticalExtensionRequiredRuleTest outerInstance)
			{
				this.outerInstance = outerInstance;
			}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void setup(org.bouncycastle.cert.X509v3CertificateBuilder v3CertGen) throws org.bouncycastle.cert.CertIOException
			public void setup(X509v3CertificateBuilder v3CertGen)
			{
				v3CertGen.addExtension(new ASN1ObjectIdentifier("2.10.2"), true, new sbyte[3]);
			}

		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test(expectedExceptions = no.difi.certvalidator.api.FailedValidationException.class) public void shouldInvalidateCertWithACriticalExtentionsThatIsNotApproved() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void shouldInvalidateCertWithACriticalExtentionsThatIsNotApproved()
		{
			string approvedExtentionList = "2.10.2";
			CriticalExtensionRequiredRule validator = CriticalExtensionRule.requires(approvedExtentionList);
			X509Certificate cert = createX509Certificate(new X509ExtensionCustomAnonymousInnerClass2(this));
			validator.validate(cert);
		}

		private class X509ExtensionCustomAnonymousInnerClass2 : X509ExtensionCustom
		{
			private readonly CriticalExtensionRequiredRuleTest outerInstance;

			public X509ExtensionCustomAnonymousInnerClass2(CriticalExtensionRequiredRuleTest outerInstance)
			{
				this.outerInstance = outerInstance;
			}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void setup(org.bouncycastle.cert.X509v3CertificateBuilder v3CertGen) throws org.bouncycastle.cert.CertIOException
			public void setup(X509v3CertificateBuilder v3CertGen)
			{
				string notApprovedExtention = "2.10.6";
				v3CertGen.addExtension(new ASN1ObjectIdentifier(notApprovedExtention), true, new sbyte[3]);
			}
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test(expectedExceptions = no.difi.certvalidator.api.FailedValidationException.class) public void triggerExceptionWhenCertHasNoCriticalOids() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void triggerExceptionWhenCertHasNoCriticalOids()
		{
			ValidatorBuilder.newInstance().addRule(CriticalExtensionRule.requires("12.0")).build().validate(this.GetType().getResourceAsStream("/nooids.cer"));
		}
	}

}