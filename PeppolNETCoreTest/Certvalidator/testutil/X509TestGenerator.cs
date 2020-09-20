using System;
using System.Numerics;

namespace no.difi.certvalidator.testutil
{
	using ASN1ObjectIdentifier = org.bouncycastle.asn1.ASN1ObjectIdentifier;
	using ASN1Sequence = org.bouncycastle.asn1.ASN1Sequence;
	using X500Name = org.bouncycastle.asn1.x500.X500Name;
	using CertificatePolicies = org.bouncycastle.asn1.x509.CertificatePolicies;
	using Extension = org.bouncycastle.asn1.x509.Extension;
	using PolicyInformation = org.bouncycastle.asn1.x509.PolicyInformation;
	using SubjectPublicKeyInfo = org.bouncycastle.asn1.x509.SubjectPublicKeyInfo;
	using CertIOException = org.bouncycastle.cert.CertIOException;
	using X509v3CertificateBuilder = org.bouncycastle.cert.X509v3CertificateBuilder;
	using JcaX509CertificateConverter = org.bouncycastle.cert.jcajce.JcaX509CertificateConverter;
	using BouncyCastleProvider = org.bouncycastle.jce.provider.BouncyCastleProvider;
	using ContentSigner = org.bouncycastle.@operator.ContentSigner;
	using OperatorCreationException = org.bouncycastle.@operator.OperatorCreationException;
	using JcaContentSignerBuilder = org.bouncycastle.@operator.jcajce.JcaContentSignerBuilder;
	using DateTime = org.joda.time.DateTime;


	public abstract class X509TestGenerator
	{
		static X509TestGenerator()
		{
			Security.addProvider(new BouncyCastleProvider());
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: protected java.security.cert.X509Certificate createX509Certificate(java.util.Date from, java.util.Date to) throws NoSuchAlgorithmException, SignatureException, InvalidKeyException, java.security.cert.CertificateException, org.bouncycastle.operator.OperatorCreationException, org.bouncycastle.cert.CertIOException
		protected internal virtual X509Certificate createX509Certificate(DateTime from, DateTime to)
		{
			string domainName = "test";
			return createX509Certificate(null, "CN=" + domainName + ", OU=None, O=None L=None, C=None", null, from, to);
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: protected java.security.cert.X509Certificate createX509Certificate(String subject, X509ExtensionCustom custom, java.util.Date from, java.util.Date to) throws NoSuchAlgorithmException, SignatureException, InvalidKeyException, java.security.cert.CertificateException, org.bouncycastle.operator.OperatorCreationException, org.bouncycastle.cert.CertIOException
		protected internal virtual X509Certificate createX509Certificate(string subject, X509ExtensionCustom custom, DateTime from, DateTime to)
		{
			X509Certificate issuer = createX509Certificate();
			return createX509Certificate(issuer, subject, custom, from, to);
		}


//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: protected java.security.cert.X509Certificate createX509Certificate(java.security.cert.X509Certificate issuer, String subject, X509ExtensionCustom custom, java.util.Date from, java.util.Date to) throws NoSuchAlgorithmException, SignatureException, InvalidKeyException, java.security.cert.CertificateException, org.bouncycastle.operator.OperatorCreationException, org.bouncycastle.cert.CertIOException
		protected internal virtual X509Certificate createX509Certificate(X509Certificate issuer, string subject, X509ExtensionCustom custom, DateTime from, DateTime to)
		{
			SecureRandom random = SecureRandom.getInstance("SHA1PRNG");
			KeyPairGenerator kpGen = KeyPairGenerator.getInstance("RSA");
			kpGen.initialize(2048, random);
			KeyPair keyPair = kpGen.generateKeyPair();
			PublicKey RSAPubKey = keyPair.Public;
			PrivateKey RSAPrivateKey = keyPair.Private;

			X500Name issuerName;
			if (issuer != null)
			{
				issuerName = new X500Name(issuer.SubjectX500Principal.Name);
			}
			else
			{
				issuerName = new X500Name("CN=" + "test" + ", OU=None, O=None L=None, C=None");
			}

			SubjectPublicKeyInfo subjPubKeyInfo = new SubjectPublicKeyInfo(ASN1Sequence.getInstance(RSAPubKey.Encoded));


			X509v3CertificateBuilder v3CertGen = new X509v3CertificateBuilder(issuerName, BigInteger.valueOf(Math.Abs((new SecureRandom()).Next())), from, to, new X500Name(subject), subjPubKeyInfo);

			if (custom != null)
			{
				custom.setup(v3CertGen);
			}


			//Content Signer
			ContentSigner sigGen = (new JcaContentSignerBuilder("SHA1WithRSAEncryption")).setProvider("BC").build(RSAPrivateKey);


			return (new JcaX509CertificateConverter()).setProvider("BC").getCertificate(v3CertGen.build(sigGen));
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: protected java.security.cert.X509Certificate createX509Certificate(X509ExtensionCustom x509ExtensionCustom) throws NoSuchAlgorithmException, SignatureException, InvalidKeyException, java.security.cert.CertificateException, org.bouncycastle.operator.OperatorCreationException, org.bouncycastle.cert.CertIOException
		protected internal virtual X509Certificate createX509Certificate(X509ExtensionCustom x509ExtensionCustom)
		{
			string domainName = "test";
			return createX509Certificate("CN=" + domainName + ", OU=None, O=None L=None, C=None", x509ExtensionCustom, DateTime.now().minusYears(1).toDate(), DateTime.now().plusYears(1).toDate());
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: protected java.security.cert.X509Certificate createX509Certificate() throws NoSuchAlgorithmException, SignatureException, InvalidKeyException, java.security.cert.CertificateException, org.bouncycastle.operator.OperatorCreationException, org.bouncycastle.cert.CertIOException
		protected internal virtual X509Certificate createX509Certificate()
		{
			return createX509Certificate(DateTime.now().minusYears(1).toDate(), DateTime.now().plusYears(1).toDate());
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: protected java.security.cert.X509Certificate createX509Certificate(String s) throws NoSuchAlgorithmException, SignatureException, InvalidKeyException, java.security.cert.CertificateException, org.bouncycastle.operator.OperatorCreationException, org.bouncycastle.cert.CertIOException
		protected internal virtual X509Certificate createX509Certificate(string s)
		{
			return createX509Certificate(s, null, DateTime.now().minusYears(1).toDate(), DateTime.now().plusYears(1).toDate());
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: protected java.security.cert.X509Certificate constructCertWithCertificatePolicie(final String policie) throws NoSuchAlgorithmException, SignatureException, InvalidKeyException, java.security.cert.CertificateException, org.bouncycastle.cert.CertIOException, org.bouncycastle.operator.OperatorCreationException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are ignored unless the option to convert to C# 7.2 'in' parameters is selected:
		protected internal virtual X509Certificate constructCertWithCertificatePolicie(string policie)
		{
			return createX509Certificate(new X509ExtensionCustomAnonymousInnerClass(this, policie));
		}

		private class X509ExtensionCustomAnonymousInnerClass : X509ExtensionCustom
		{
			private readonly X509TestGenerator outerInstance;

			private string policie;

			public X509ExtensionCustomAnonymousInnerClass(X509TestGenerator outerInstance, string policie)
			{
				this.outerInstance = outerInstance;
				this.policie = policie;
			}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void setup(org.bouncycastle.cert.X509v3CertificateBuilder v3CertGen) throws org.bouncycastle.cert.CertIOException
			public void setup(X509v3CertificateBuilder v3CertGen)
			{
				v3CertGen.addExtension(Extension.certificatePolicies, true, new CertificatePolicies(new PolicyInformation(new ASN1ObjectIdentifier(policie))));
			}
		}
	}

}