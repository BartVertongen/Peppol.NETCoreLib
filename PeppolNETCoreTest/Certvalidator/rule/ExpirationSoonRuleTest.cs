namespace no.difi.certvalidator.rule
{
	using X509TestGenerator = no.difi.certvalidator.testutil.X509TestGenerator;
	using DateTime = org.joda.time.DateTime;
	using Assert = org.testng.Assert;
	using Test = org.testng.annotations.Test;

	public class ExpirationSoonRuleTest : X509TestGenerator
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void simple() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void simple()
		{
			Validator validatorHelper = new Validator(new ExpirationSoonRule(5 * 24 * 60 * 60 * 1000));

			Assert.assertTrue(validatorHelper.isValid(createX509Certificate(DateTime.now().plusDays(1).toDate(), DateTime.now().plusDays(10).toDate())));
			Assert.assertTrue(validatorHelper.isValid(createX509Certificate(DateTime.now().plusDays(1).toDate(), DateTime.now().plusDays(6).toDate())));
			Assert.assertTrue(validatorHelper.isValid(createX509Certificate(DateTime.now().plusDays(1).toDate(), DateTime.now().plusDays(5).plusMinutes(1).toDate())));
			Assert.assertFalse(validatorHelper.isValid(createX509Certificate(DateTime.now().plusDays(1).toDate(), DateTime.now().plusDays(5).minusMinutes(1).toDate())));
			Assert.assertFalse(validatorHelper.isValid(createX509Certificate(DateTime.now().plusDays(1).toDate(), DateTime.now().plusDays(4).toDate())));
		}

	}

}