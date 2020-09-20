using System;
using System.Threading;

namespace no.difi.certvalidator.util
{
	using CertificateValidationException = no.difi.certvalidator.api.CertificateValidationException;
	using CrlCache = no.difi.certvalidator.api.CrlCache;
	using CrlFetcher = no.difi.certvalidator.api.CrlFetcher;
	using Mockito = org.mockito.Mockito;
	using Assert = org.testng.Assert;
	using Test = org.testng.annotations.Test;


	public class SimpleCachingCrlFetcherTest
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void ldapNotSupported() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void ldapNotSupported()
		{
			CrlFetcher crlFetcher = new SimpleCachingCrlFetcher(new SimpleCrlCache());

			Assert.assertNull(crlFetcher.get("ldap://something..."));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void returnSameIfNoNextUpdate() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void returnSameIfNoNextUpdate()
		{
			CrlCache crlCache = new SimpleCrlCache();
			CrlFetcher crlFetcher = new SimpleCachingCrlFetcher(crlCache);

			X509CRL x509CRL = Mockito.mock(typeof(X509CRL));
			Mockito.doReturn(null).when(x509CRL).NextUpdate;

			crlCache.set("url", x509CRL);

			Assert.assertEquals(crlFetcher.get("url"), x509CRL);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void returnNullIfNotValidAndProtocolNotSupported() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void returnNullIfNotValidAndProtocolNotSupported()
		{
			CrlCache crlCache = new SimpleCrlCache();
			CrlFetcher crlFetcher = new SimpleCachingCrlFetcher(crlCache);

			X509CRL x509CRL = Mockito.mock(typeof(X509CRL));
			Mockito.doReturn(DateTime.Now).when(x509CRL).NextUpdate;

			Thread.Sleep(25);

			crlCache.set("url", x509CRL);

			Assert.assertNull(crlFetcher.get("url"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test(enabled = false, expectedExceptions = no.difi.certvalidator.api.CertificateValidationException.class) public void triggerExceptionWithoutMessage() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void triggerExceptionWithoutMessage()
		{
			CrlCache crlCache = Mockito.mock(typeof(CrlCache));
			CrlFetcher crlFetcher = new SimpleCachingCrlFetcher(crlCache);

			crlFetcher.get(null);
		}
	}

}