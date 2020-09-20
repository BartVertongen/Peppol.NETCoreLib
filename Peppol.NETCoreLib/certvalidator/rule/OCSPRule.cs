using System;

namespace no.difi.certvalidator.rule
{
	//using CertificateResult = net.klakegg.pkix.ocsp.CertificateResult;
	//using OcspClient = net.klakegg.pkix.ocsp.OcspClient;
	//using OcspException = net.klakegg.pkix.ocsp.OcspException;
	using no.difi.certvalidator.api;
    using System.Security.Cryptography.X509Certificates;
    using no.difi.certvalidator.util;


	/// <summary>
	/// </summary>
	public class OCSPRule : AbstractRule
	{

		public static readonly Property<CertificateResult> RESULT = SimpleProperty<CertificateResult>.create();

		protected internal OcspClient ocspClient;

		public OCSPRule(CertificateBucket intermediateCertificates)
		{
			ocspClient = OcspClient.builder().set(OcspClient.INTERMEDIATES, intermediateCertificates.asList()).build();
		}

		public OCSPRule(OcspClient ocspClient)
		{
			this.ocspClient = ocspClient;
		}


//ORIGINAL LINE: @Override public Report validate(java.security.cert.X509Certificate certificate, Report report) throws CertificateValidationException
		public override Report validate(X509Certificate2 certificate, Report report)
		{
			try
			{
				report.set(RESULT, ocspClient.verify(certificate));

				return report;
			}
			catch (/*Ocsp*/Exception e)
			{
				/*if (e.InnerException is UnknownHostException)
				{
					throw new CertificateValidationException(e.Message, e);
				}
				else*/
				{
					throw new FailedValidationException(e.Message, e);
				}
			}
			/*catch (Exception e)
			{
				throw new CertificateValidationException(e.Message, e);
			}*/
		}
	}

}