namespace no.difi.certvalidator.testutil
{

	using CertIOException = org.bouncycastle.cert.CertIOException;
	using X509v3CertificateBuilder = org.bouncycastle.cert.X509v3CertificateBuilder;

	public interface X509ExtensionCustom
	{
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: void setup(org.bouncycastle.cert.X509v3CertificateBuilder v3CertGen) throws org.bouncycastle.cert.CertIOException;
		void setup(X509v3CertificateBuilder v3CertGen);
	}

}