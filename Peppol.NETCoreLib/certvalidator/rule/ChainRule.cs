
using System.Collections.Generic;
using no.difi.certvalidator.api;
using System.Security.Cryptography.X509Certificates;
using no.difi.certvalidator.util;
using System;


namespace no.difi.certvalidator.rule
{
    /// <summary>
    /// Validator checking validity of chain using root certificates and intermediate certificates.
    /// </summary>
    public class ChainRule : AbstractRule
	{

        //ORIGINAL LINE: public static final Property<java.util.List<? extends Certificate>> PATH = no.difi.certvalidator.util.SimpleProperty.create();
		public static readonly Property<List<X509Certificate2>> PATH = SimpleProperty<List<X509Certificate2>>.create();

		public static readonly Property<X509Certificate2> ANCHOR = SimpleProperty<X509Certificate2>.create();

		private CertificateBucket rootCertificates;

		private CertificateBucket intermediateCertificates;

		private ISet<string> policies = new HashSet<string>();

		/// <param name="rootCertificates">         Trusted root certificates. </param>
		/// <param name="intermediateCertificates"> Trusted intermediate certificates. </param>
		public ChainRule(CertificateBucket rootCertificates, CertificateBucket intermediateCertificates, params string[] policies)
		{
			this.rootCertificates = rootCertificates;
			this.intermediateCertificates = intermediateCertificates;
			this.policies.addAll(new List<string>(policies));
		}


        //ORIGINAL LINE: @Override public Report validate(X509Certificate certificate, Report report) throws CertificateValidationException
		public virtual Report validate(X509Certificate2 certificate, Report report)
		{
			try
			{
				PKIXCertPathBuilderResult result = verifyCertificate(certificate);

				report.set(ANCHOR, result.TrustAnchor.TrustedCert);
				report.set(PATH, result.CertPath.Certificates);

				return report;
			}
			catch (/*GeneralSecurity*/Exception e)
			{
				throw new FailedValidationException(e.Message, e);
			}
		}

		/// <summary>
		/// Source: http://www.nakov.com/blog/2009/12/01/x509-certificate-validation-in-java-build-and-verify-chain-and-verify-clr-with-bouncy-castle/
		/// </summary>
        //ORIGINAL LINE: private PKIXCertPathBuilderResult verifyCertificate(X509Certificate cert) throws GeneralSecurityException
		private PKIXCertPathBuilderResult verifyCertificate(X509Certificate2 cert)
		{
			// Create the selector that specifies the starting certificate
			X509CertSelector selector = new X509CertSelector();
			selector.Certificate = cert;

			// Create the trust anchors (set of root CA certificates)
			ISet<TrustAnchor> trustAnchors = new HashSet<TrustAnchor>();
			foreach (X509Certificate2 trustedRootCert in rootCertificates)
			{
				trustAnchors.Add(new TrustAnchor(trustedRootCert, null));
			}

			// Configure the PKIX certificate builder algorithm parameters
			PKIXBuilderParameters pkixParams = new PKIXBuilderParameters(trustAnchors, selector);

			// Setting explicit policy
			if (policies.Count > 0)
			{
				pkixParams.InitialPolicies = policies;
				pkixParams.ExplicitPolicyRequired = true;
			}

			// Disable CRL checks (this is done manually as additional step)
			pkixParams.RevocationEnabled = false;

			// Specify a list of intermediate certificates
			ISet<X509Certificate2> trustedIntermediateCert = new HashSet<X509Certificate2>();
			foreach (X509Certificate2 certificate in intermediateCertificates)
			{
				trustedIntermediateCert.Add(certificate);
			}
			trustedIntermediateCert.Add(cert);

			pkixParams.addCertStore(CertStore.getInstance("Collection", new CollectionCertStoreParameters(trustedIntermediateCert), BCHelper.PROVIDER));

			// Build and verify the certification chain
			CertPathBuilder builder = CertPathBuilder.getInstance("PKIX", BCHelper.PROVIDER);
			return (PKIXCertPathBuilderResult) builder.build(pkixParams);
		}
	}
}