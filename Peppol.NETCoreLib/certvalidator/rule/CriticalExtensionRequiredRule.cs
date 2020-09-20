using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace no.difi.certvalidator.rule
{
	using CertificateValidationException = no.difi.certvalidator.api.CertificateValidationException;
	using FailedValidationException = no.difi.certvalidator.api.FailedValidationException;



	public class CriticalExtensionRequiredRule : AbstractRule
	{

		private List<string> requiredExtensions;

		public CriticalExtensionRequiredRule(params string[] requiredExtensions)
		{
			this.requiredExtensions = new List<string>(requiredExtensions);
		}


//ORIGINAL LINE: @Override public void validate(java.security.cert.X509Certificate certificate) throws no.difi.certvalidator.api.CertificateValidationException
		public override void validate(X509Certificate2 certificate)
		{
			ISet<string> oids = certificate.CriticalExtensionOIDs;

			if (oids == null)
			{
				throw new FailedValidationException("Certificate doesn't contain critical OIDs.");
			}

			foreach (string oid in requiredExtensions)
			{
				if (!oids.Contains(oid))
				{
					throw new FailedValidationException(string.Format("Certificate doesn't contain critical OID '{0}'.", oid));
				}
			}
		}
	}
}