using System.IO;

namespace no.difi.certvalidator
{
	using ByteStreams = com.google.common.io.ByteStreams;
	using FailedValidationException = no.difi.certvalidator.api.FailedValidationException;
	using DummyRule = no.difi.certvalidator.rule.DummyRule;
	using Assert = org.testng.Assert;
	using Test = org.testng.annotations.Test;


	public class ValidatorTest
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void simpleTrue()
		public virtual void simpleTrue()
		{
			Validator validatorHelper = ValidatorBuilder.newInstance().addRule(new DummyRule()).build();
			Assert.assertTrue(validatorHelper.isValid(this.GetType().getResourceAsStream("/peppol-test-ap-difi.cer")));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void simpleFalse()
		public virtual void simpleFalse()
		{
			Validator validatorHelper = new Validator(new DummyRule("FAIL!"));
			Assert.assertFalse(validatorHelper.isValid(this.GetType().getResourceAsStream("/peppol-test-ap-difi.cer")));
			Assert.assertFalse(validatorHelper.isValid((Stream) null));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void simpleByteArray() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void simpleByteArray()
		{
			MemoryStream byteArrayOutputStream = new MemoryStream();
			ByteStreams.copy(this.GetType().getResourceAsStream("/peppol-test-ap-difi.cer"), byteArrayOutputStream);

			Validator validatorHelper = new Validator(new DummyRule("FAIL!"));
			Assert.assertFalse(validatorHelper.isValid(byteArrayOutputStream.toByteArray()));
			Assert.assertFalse(validatorHelper.isValid(new sbyte[] {}));

			try
			{
				validatorHelper.validate(byteArrayOutputStream.toByteArray());
				Assert.fail("Exception expected.");
			}
			catch (FailedValidationException)
			{
				// Expected
			}

			validatorHelper = new Validator(new DummyRule());
			validatorHelper.validate(byteArrayOutputStream.toByteArray());
		}
	}

}