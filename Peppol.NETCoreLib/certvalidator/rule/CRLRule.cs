using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace no.difi.certvalidator.rule
{
	using CertificateValidationException = no.difi.certvalidator.api.CertificateValidationException;
	using CrlCache = no.difi.certvalidator.api.CrlCache;
	using CrlFetcher = no.difi.certvalidator.api.CrlFetcher;
	using FailedValidationException = no.difi.certvalidator.api.FailedValidationException;
	using SimpleCachingCrlFetcher = no.difi.certvalidator.util.SimpleCachingCrlFetcher;
	using SimpleCrlCache = no.difi.certvalidator.util.SimpleCrlCache;
	//using DERIA5String = org.bouncycastle.asn1.DERIA5String;
	//using CRLDistPoint = org.bouncycastle.asn1.x509.CRLDistPoint;
	//using DistributionPoint = org.bouncycastle.asn1.x509.DistributionPoint;
	//using GeneralName = org.bouncycastle.asn1.x509.GeneralName;
	//using GeneralNames = org.bouncycastle.asn1.x509.GeneralNames;
	//using X509ExtensionUtil = org.bouncycastle.x509.extension.X509ExtensionUtil;


	public class CRLRule : AbstractRule
	{

		private const string CRL_EXTENSION = "2.5.29.31";

		private CrlFetcher crlFetcher;

		public CRLRule(CrlFetcher crlFetcher)
		{
			this.crlFetcher = crlFetcher;
		}

		public CRLRule(CrlCache crlCache) : this(new SimpleCachingCrlFetcher(crlCache))
		{
		}

		public CRLRule()
		{
			this.crlFetcher = new SimpleCachingCrlFetcher(new SimpleCrlCache());
		}

		/// <summary>
		/// {@inheritDoc}
		/// </summary>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: @Override public void validate(java.security.cert.X509Certificate certificate) throws no.difi.certvalidator.api.CertificateValidationException
		public override void validate(X509Certificate2 certificate)
		{
			IList<string> urls = getCrlDistributionPoints(certificate);
			foreach (string url in urls)
			{
				X509CRL crl = crlFetcher.get(url);
				if (crl != null)
				{
					if (crl.isRevoked(certificate))
					{
						throw new FailedValidationException("Certificate is revoked.");
					}
				}
			}
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static java.util.List<String> getCrlDistributionPoints(java.security.cert.X509Certificate certificate) throws no.difi.certvalidator.api.CertificateValidationException
		public static IList<string> getCrlDistributionPoints(X509Certificate2 certificate)
		{
			try
			{
				List<string> urls = new List<string>();

				if (!certificate.NonCriticalExtensionOIDs.contains(CRL_EXTENSION))
				{
					return urls;
				}

				CRLDistPoint distPoint = CRLDistPoint.getInstance(X509ExtensionUtil.fromExtensionValue(certificate.getExtensionValue(CRL_EXTENSION)));
				foreach (DistributionPoint dp in distPoint.DistributionPoints)
				{
					foreach (GeneralName name in ((GeneralNames) dp.DistributionPoint.Name).Names)
					{
						if (name.TagNo == GeneralName.uniformResourceIdentifier)
						{
							urls.Add(((DERIA5String) name.Name).String);
						}
					}
				}

				return urls;
			}
			catch (Exception e) //when (e is IOException || e is System.NullReferenceException)
			{
				throw new CertificateValidationException(e.Message, e);
			}
		}
	}

}