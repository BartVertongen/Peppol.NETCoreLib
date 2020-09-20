namespace no.difi.certvalidator.rule
{
	using FailedValidationException = no.difi.certvalidator.api.FailedValidationException;
	using KeyUsage = no.difi.certvalidator.util.KeyUsage;
	using Test = org.testng.annotations.Test;

	/// <summary>
	/// @author erlend
	/// </summary>
	public class KeyUsageRuleTest
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void simpleValid() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void simpleValid()
		{
			(new Validator(new KeyUsageRule(KeyUsage.NON_REPUDIATION))).validate(this.GetType().getResourceAsStream("/virksert-test-difi.cer"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test(expectedExceptions = no.difi.certvalidator.api.FailedValidationException.class) public void simpleFailed() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void simpleFailed()
		{
			(new Validator(new KeyUsageRule())).validate(this.GetType().getResourceAsStream("/virksert-test-difi.cer"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void simplePeppol() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void simplePeppol()
		{
			(new Validator(new KeyUsageRule(KeyUsage.DIGITAL_SIGNATURE, KeyUsage.KEY_ENCIPHERMENT, KeyUsage.DATA_ENCIPHERMENT, KeyUsage.KEY_AGREEMENT))).validate(this.GetType().getResourceAsStream("/peppol-prod-smp-difi.cer"));
		}
	}
}