namespace no.difi.certvalidator.rule
{
	using FailedValidationException = no.difi.certvalidator.api.FailedValidationException;
	using Test = org.testng.annotations.Test;

	public class CriticalExtensionRecognizedRuleTest
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test(expectedExceptions = no.difi.certvalidator.api.FailedValidationException.class) public void certificateHasOidsNotRecognized() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void certificateHasOidsNotRecognized()
		{
			Validator validator = new Validator(new CriticalExtensionRecognizedRule("12.0"));
			validator.validate(this.GetType().getResourceAsStream("/difi-move-test.cer"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void triggerNoExceptionsWhenCertHasNoCriticalOids() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void triggerNoExceptionsWhenCertHasNoCriticalOids()
		{
			ValidatorBuilder.newInstance().addRule(CriticalExtensionRule.recognizes("12.0")).build().validate(this.GetType().getResourceAsStream("/nooids.cer"));
		}
	}

}