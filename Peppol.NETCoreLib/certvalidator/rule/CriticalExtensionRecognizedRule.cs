using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace no.difi.certvalidator.rule
{
	using CertificateValidationException = no.difi.certvalidator.api.CertificateValidationException;
	using FailedValidationException = no.difi.certvalidator.api.FailedValidationException;


	public class CriticalExtensionRecognizedRule : AbstractRule
	{

		private readonly List<string> recognizedExtensions;

		public CriticalExtensionRecognizedRule(params string[] recognizedExtensions)
		{
			this.recognizedExtensions = Array.asList(recognizedExtensions);
		}


//ORIGINAL LINE: @Override public void validate(java.security.cert.X509Certificate certificate) throws no.difi.certvalidator.api.CertificateValidationException
		public override void validate(X509Certificate2 certificate)
		{
			ISet<string> oids = certificate.CriticalExtensionOIDs;

			if (oids == null)
			{
				return;
			}

			foreach (string oid in oids)
			{
				if (!recognizedExtensions.Contains(oid))
				{
					throw new FailedValidationException(string.Format("X509 certificate {0} specifies a critical extension {1} which is not recognized", certificate.SerialNumber, oid));
				}
			}
		}
	}
}