namespace no.difi.certvalidator.rule
{

	using CertificateValidationException = no.difi.certvalidator.api.CertificateValidationException;
	using FailedValidationException = no.difi.certvalidator.api.FailedValidationException;
	using Assert = org.testng.Assert;
	using Test = org.testng.annotations.Test;

	public class SigningRuleTest
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void publiclySignedExpectedWithPubliclySigned() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void publiclySignedExpectedWithPubliclySigned()
		{
			SigningRule.PublicSignedOnly().validate(Validator.getCertificate(this.GetType().getResourceAsStream("/peppol-test-ap-difi.cer")));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test(expectedExceptions = no.difi.certvalidator.api.FailedValidationException.class) public void selfSignedExpectedWithPubliclySigned() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void selfSignedExpectedWithPubliclySigned()
		{
			SigningRule.SelfSignedOnly().validate(Validator.getCertificate(this.GetType().getResourceAsStream("/peppol-test-ap-difi.cer")));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test(expectedExceptions = no.difi.certvalidator.api.FailedValidationException.class) public void publiclySignedExpectedWithSelfSigned() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void publiclySignedExpectedWithSelfSigned()
		{
			SigningRule.PublicSignedOnly().validate(Validator.getCertificate(this.GetType().getResourceAsStream("/selfsigned.cer")));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void selfSignedExpectedWithSelfSigned() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void selfSignedExpectedWithSelfSigned()
		{
			SigningRule.SelfSignedOnly().validate(Validator.getCertificate(this.GetType().getResourceAsStream("/selfsigned.cer")));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test(expectedExceptions = no.difi.certvalidator.api.CertificateValidationException.class) public void triggerException() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void triggerException()
		{
			SigningRule.PublicSignedOnly().validate(null);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void enumStuff()
		public virtual void enumStuff()
		{
			foreach (SigningRule.Kind kind in Enum.GetValues(typeof(SigningRule.Kind)))
			{
				Assert.assertNotNull(Enum.Parse(typeof(SigningRule.Kind), kind.name()));
			}
		}
	}

}