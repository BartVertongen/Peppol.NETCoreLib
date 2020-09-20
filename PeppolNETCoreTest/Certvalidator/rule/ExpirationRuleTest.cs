namespace no.difi.certvalidator.rule
{
	using CertificateValidationException = no.difi.certvalidator.api.CertificateValidationException;
	using FailedValidationException = no.difi.certvalidator.api.FailedValidationException;
	using X509TestGenerator = no.difi.certvalidator.testutil.X509TestGenerator;
	using CertIOException = org.bouncycastle.cert.CertIOException;
	using OperatorCreationException = org.bouncycastle.@operator.OperatorCreationException;
	using DateTime = org.joda.time.DateTime;
	using Test = org.testng.annotations.Test;




	public class ExpirationRuleTest : X509TestGenerator
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void shouldValidateAValidCertificate() throws no.difi.certvalidator.api.CertificateValidationException, java.security.NoSuchAlgorithmException, java.security.SignatureException, java.security.InvalidKeyException, java.security.cert.CertificateException, org.bouncycastle.cert.CertIOException, org.bouncycastle.operator.OperatorCreationException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void shouldValidateAValidCertificate()
		{
			ExpirationRule validator = new ExpirationRule();

			X509Certificate cert = createX509Certificate(DateTime.now().minusDays(10).toDate(), DateTime.now().plusDays(10).toDate());

			validator.validate(cert);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test(expectedExceptions = no.difi.certvalidator.api.FailedValidationException.class) public void shouldInvalidateAExpiredCertificate() throws no.difi.certvalidator.api.CertificateValidationException, java.security.NoSuchAlgorithmException, java.security.SignatureException, java.security.InvalidKeyException, java.security.cert.CertificateException, org.bouncycastle.cert.CertIOException, org.bouncycastle.operator.OperatorCreationException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void shouldInvalidateAExpiredCertificate()
		{
			ExpirationRule validator = new ExpirationRule();

			X509Certificate cert = createX509Certificate(DateTime.now().minusDays(10).toDate(), DateTime.now().minusDays(2).toDate());

			validator.validate(cert);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test(expectedExceptions = no.difi.certvalidator.api.FailedValidationException.class) public void shouldInvalidateANotNotbeforeCertificate() throws no.difi.certvalidator.api.CertificateValidationException, java.security.NoSuchAlgorithmException, java.security.SignatureException, java.security.InvalidKeyException, java.security.cert.CertificateException, org.bouncycastle.cert.CertIOException, org.bouncycastle.operator.OperatorCreationException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void shouldInvalidateANotNotbeforeCertificate()
		{
			ExpirationRule validator = new ExpirationRule();

			X509Certificate cert = createX509Certificate(DateTime.now().plusDays(10).toDate(), DateTime.now().plusDays(20).toDate());

			validator.validate(cert);
		}
	}

}