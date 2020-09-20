namespace no.difi.certvalidator.util
{
	using Assert = org.testng.Assert;
	using Test = org.testng.annotations.Test;

	/// <summary>
	/// @author erlend
	/// </summary>
	public class KeyUsageTest
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void simple()
		public virtual void simple()
		{
			Assert.assertEquals(KeyUsage.of(5), KeyUsage.KEY_CERT_SIGN);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test(expectedExceptions = IllegalArgumentException.class) public void simpleException()
		public virtual void simpleException()
		{
			KeyUsage.of(10);
		}
	}

}