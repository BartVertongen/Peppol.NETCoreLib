using System.Collections.Generic;

namespace no.difi.certvalidator.util
{
	using Lists = com.google.common.collect.Lists;
	using CertificateBucketException = no.difi.certvalidator.api.CertificateBucketException;
	using Assert = org.testng.Assert;
	using Test = org.testng.annotations.Test;


	public class KeyStoreCertificateBucketTest
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void simple() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void simple()
		{
			KeyStoreCertificateBucket certificateBucket = new KeyStoreCertificateBucket(this.GetType().getResourceAsStream("/peppol-test.jks"), "peppol");

			Assert.assertNotNull(certificateBucket.findBySubject(Validator.getCertificate(this.GetType().getResourceAsStream("/peppol-test-ap-difi.cer")).IssuerX500Principal));
			Assert.assertNotNull(certificateBucket.findBySubject(Validator.getCertificate(this.GetType().getResourceAsStream("/peppol-test-smp-difi.cer")).IssuerX500Principal));
			Assert.assertNull(certificateBucket.findBySubject(Validator.getCertificate(this.GetType().getResourceAsStream("/peppol-prod-ap-difi.cer")).IssuerX500Principal));
			Assert.assertNull(certificateBucket.findBySubject(Validator.getCertificate(this.GetType().getResourceAsStream("/peppol-prod-smp-difi.cer")).IssuerX500Principal));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void startsWithTest() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void startsWithTest()
		{
			KeyStoreCertificateBucket certificateBucket = new KeyStoreCertificateBucket(this.GetType().getResourceAsStream("/peppol-test.jks"), "peppol");

			Assert.assertEquals(Lists.newArrayList(certificateBucket.startsWith("PEPPOL-", "peppol-").GetEnumerator()).size(), 4);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test(expectedExceptions = IllegalStateException.class) public void triggerNullPointerInIterator() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void triggerNullPointerInIterator()
		{
			(new KeyStoreCertificateBucket(null)).GetEnumerator();
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test(expectedExceptions = no.difi.certvalidator.api.CertificateBucketException.class) public void triggerNullPointerInToSimple() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void triggerNullPointerInToSimple()
		{
			(new KeyStoreCertificateBucket(null)).toSimple();
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test(expectedExceptions = no.difi.certvalidator.api.CertificateBucketException.class) public void triggerNullPointerInConstructor() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void triggerNullPointerInConstructor()
		{
			new KeyStoreCertificateBucket(null, "password");
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test(expectedExceptions = no.difi.certvalidator.api.CertificateBucketException.class) @SuppressWarnings("all") public void triggerNullPointerInStartsWith() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void triggerNullPointerInStartsWith()
		{
			(new KeyStoreCertificateBucket(null)).startsWith((string) null);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test(expectedExceptions = IllegalStateException.class) public void testingIterator() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void testingIterator()
		{
			KeyStoreCertificateBucket certificateBucket = new KeyStoreCertificateBucket(this.GetType().getResourceAsStream("/peppol-test.jks"), "peppol");

			IEnumerator<X509Certificate> iterator = certificateBucket.GetEnumerator();

//JAVA TO C# CONVERTER TODO TASK: Java iterators are only converted within the context of 'while' and 'for' loops:
			Assert.assertTrue(iterator.hasNext());
//JAVA TO C# CONVERTER TODO TASK: Java iterators are only converted within the context of 'while' and 'for' loops:
			Assert.assertNotNull(iterator.next());
//JAVA TO C# CONVERTER TODO TASK: .NET enumerators are read-only:
			iterator.remove(); // No action

//JAVA TO C# CONVERTER TODO TASK: Java iterators are only converted within the context of 'while' and 'for' loops:
			Assert.assertTrue(iterator.hasNext());
//JAVA TO C# CONVERTER TODO TASK: Java iterators are only converted within the context of 'while' and 'for' loops:
			Assert.assertNotNull(iterator.next());
//JAVA TO C# CONVERTER TODO TASK: .NET enumerators are read-only:
			iterator.remove(); // No action

//JAVA TO C# CONVERTER TODO TASK: Java iterators are only converted within the context of 'while' and 'for' loops:
			Assert.assertTrue(iterator.hasNext());
//JAVA TO C# CONVERTER TODO TASK: Java iterators are only converted within the context of 'while' and 'for' loops:
			Assert.assertNotNull(iterator.next());
//JAVA TO C# CONVERTER TODO TASK: .NET enumerators are read-only:
			iterator.remove(); // No action

//JAVA TO C# CONVERTER TODO TASK: Java iterators are only converted within the context of 'while' and 'for' loops:
			Assert.assertTrue(iterator.hasNext());
//JAVA TO C# CONVERTER TODO TASK: Java iterators are only converted within the context of 'while' and 'for' loops:
			Assert.assertNotNull(iterator.next());
//JAVA TO C# CONVERTER TODO TASK: .NET enumerators are read-only:
			iterator.remove(); // No action

//JAVA TO C# CONVERTER TODO TASK: Java iterators are only converted within the context of 'while' and 'for' loops:
			Assert.assertFalse(iterator.hasNext());
//JAVA TO C# CONVERTER TODO TASK: Java iterators are only converted within the context of 'while' and 'for' loops:
			Assert.assertNotNull(iterator.next());
		}
	}

}