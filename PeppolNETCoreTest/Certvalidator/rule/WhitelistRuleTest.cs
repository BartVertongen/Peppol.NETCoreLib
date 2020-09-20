using System.IO;

namespace no.difi.certvalidator.rule
{
	using SimpleCertificateBucket = no.difi.certvalidator.util.SimpleCertificateBucket;
	using Assert = org.testng.Assert;
	using Test = org.testng.annotations.Test;


	/// <summary>
	/// @author erlend
	/// </summary>
	public class WhitelistRuleTest
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void simple() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void simple()
		{
			X509Certificate certificate;

			using (Stream inputStream = this.GetType().getResourceAsStream("/selfsigned.cer"))
			{
				certificate = Validator.getCertificate(inputStream);
			}

			Assert.assertTrue((new Validator(new WhitelistRule(SimpleCertificateBucket.with(certificate)))).isValid(certificate));
			Assert.assertFalse((new Validator(new WhitelistRule(SimpleCertificateBucket.with()))).isValid(certificate));
		}

	}

}