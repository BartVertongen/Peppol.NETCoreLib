namespace no.difi.certvalidator.rule
{
    using System.Security.Cryptography.X509Certificates;
    using CertificateBucket = no.difi.certvalidator.api.CertificateBucket;
	using CertificateValidationException = no.difi.certvalidator.api.CertificateValidationException;
	using FailedValidationException = no.difi.certvalidator.api.FailedValidationException;

	/// <summary>
	/// </summary>
	public class WhitelistRule : AbstractRule
	{
		private readonly CertificateBucket certificates;

		public WhitelistRule(CertificateBucket certificates)
		{
			this.certificates = certificates;
		}


//ORIGINAL LINE: @Override public void validate(java.security.cert.X509Certificate certificate) throws no.difi.certvalidator.api.CertificateValidationException
		public override void validate(X509Certificate2 certificate)
		{
			foreach (X509Certificate2 cert in certificates)
			{
				if (cert.Equals(certificate))
				{
					return;
				}
			}

			throw new FailedValidationException("Certificate is not in whitelist.");
		}
	}
}