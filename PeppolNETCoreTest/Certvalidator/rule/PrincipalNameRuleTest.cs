namespace no.difi.certvalidator.rule
{
	using FailedValidationException = no.difi.certvalidator.api.FailedValidationException;
	using PrincipalNameProvider = no.difi.certvalidator.api.PrincipalNameProvider;
	using SimplePrincipalNameProvider = no.difi.certvalidator.util.SimplePrincipalNameProvider;
	using Mockito = org.mockito.Mockito;
	using Assert = org.testng.Assert;
	using Test = org.testng.annotations.Test;

	public class PrincipalNameRuleTest
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void onlyNoAllowed() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void onlyNoAllowed()
		{
			ValidatorBuilder.newInstance().addRule(new PrincipalNameRule("C", new SimplePrincipalNameProvider("NO"))).build().validate(this.GetType().getResourceAsStream("/peppol-test-ap-difi.cer"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test(expectedExceptions = no.difi.certvalidator.api.FailedValidationException.class) public void onlyDkAllowed() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void onlyDkAllowed()
		{
			ValidatorBuilder.newInstance().addRule(new PrincipalNameRule("C", new SimplePrincipalNameProvider("DK"))).build().validate(this.GetType().getResourceAsStream("/peppol-test-ap-difi.cer"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test(expectedExceptions = no.difi.certvalidator.api.FailedValidationException.class) public void fullName() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void fullName()
		{
			ValidatorBuilder.newInstance().addRule(new PrincipalNameRule((value) => value.contains("NORWAY"), PrincipalNameRule.Principal.SUBJECT)).build().validate(this.GetType().getResourceAsStream("/peppol-test-ap-difi.cer"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test(enabled = false, expectedExceptions = no.difi.certvalidator.api.FailedValidationException.class) public void triggerCertificateEncodingException() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void triggerCertificateEncodingException()
		{
			PrincipalNameProvider<string> provider = (PrincipalNameProvider<string>) Mockito.mock(typeof(PrincipalNameProvider));
			Mockito.doThrow(typeof(CertificateEncodingException)).when(provider).validate(Mockito.anyString());


			ValidatorBuilder.newInstance().addRule(new PrincipalNameRule(provider)).build().validate(this.GetType().getResourceAsStream("/peppol-test-ap-difi.cer"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void enumStuff()
		public virtual void enumStuff()
		{
			foreach (PrincipalNameRule.Principal principal in Enum.GetValues(typeof(PrincipalNameRule.Principal)))
			{
				Assert.assertNotNull(Enum.Parse(typeof(PrincipalNameRule.Principal), principal.name()));
			}
		}
	}

}