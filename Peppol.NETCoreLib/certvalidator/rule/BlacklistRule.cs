namespace no.difi.certvalidator.rule
{
    using System.Security.Cryptography.X509Certificates;
    using CertificateBucket = no.difi.certvalidator.api.CertificateBucket;
	using CertificateValidationException = no.difi.certvalidator.api.CertificateValidationException;
	using FailedValidationException = no.difi.certvalidator.api.FailedValidationException;

	/// <summary>
	/// </summary>
	public class BlacklistRule : AbstractRule
	{
		private readonly CertificateBucket certificates;

		public BlacklistRule(CertificateBucket certificates)
		{
			this.certificates = certificates;
		}


        //ORIGINAL LINE: @Override public void validate(X509Certificate certificate) throws CertificateValidationException
		public override void validate(X509Certificate2 certificate)
		{
			foreach (X509Certificate2 cert in certificates)
			{
				if (cert.Equals(certificate))
				{
					throw new FailedValidationException("Certificate is blacklisted.");
				}
			}
		}
	}
}