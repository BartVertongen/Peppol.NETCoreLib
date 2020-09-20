using System.IO;

namespace no.difi.certvalidator
{
	using ByteStreams = com.google.common.io.ByteStreams;
	using Assert = org.testng.Assert;
	using Test = org.testng.annotations.Test;

	public class ValidatorGroupTest
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void simple() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void simple()
		{
			ValidatorGroup validator = ValidatorLoader.newInstance().build(this.GetType().getResourceAsStream("/recipe-selfsigned.xml"));

			sbyte[] cert = ByteStreams.toByteArray(this.GetType().getResourceAsStream("/selfsigned.cer"));

			Assert.assertTrue(validator.isValid("default", cert));
			Assert.assertFalse(validator.isValid("default", new sbyte[]{}));

			Assert.assertTrue(validator.isValid("default", new MemoryStream(cert)));
			Assert.assertFalse(validator.isValid("default", new MemoryStream(new sbyte[]{})));

			validator.validate("default", cert);
			validator.validate("default", new MemoryStream(cert));
		}
	}

}