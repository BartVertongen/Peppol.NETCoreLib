namespace no.difi.certvalidator.util
{
	using CrlCache = no.difi.certvalidator.api.CrlCache;
	using Mockito = org.mockito.Mockito;
	using Assert = org.testng.Assert;
	using Test = org.testng.annotations.Test;

	public class SimpleCrlCacheTest
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void simple() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void simple()
		{
			CrlCache crlCache = new SimpleCrlCache();
			Assert.assertNull(crlCache.get("http://none/"));

			crlCache.set("http://none/", Mockito.mock(typeof(X509CRL)));
			Assert.assertNotNull(crlCache.get("http://none/"));

			crlCache.set("http://none/", null);
			Assert.assertNull(crlCache.get("http://none/"));
		}

	}

}