namespace no.difi.certvalidator.rule
{
    using System.Security.Cryptography.X509Certificates;
    using CertificateValidationException = no.difi.certvalidator.api.CertificateValidationException;
	using FailedValidationException = no.difi.certvalidator.api.FailedValidationException;

	/// <summary>
	/// Validation making sure certificate doesn't expire in n milliseconds.
	/// </summary>
	public class ExpirationSoonRule : AbstractRule
	{

		private long millis;

		public ExpirationSoonRule(long millis)
		{
			this.millis = millis;
		}


        //ORIGINAL LINE: public void validate(X509Certificate certificate) throws CertificateValidationException
		public override void validate(X509Certificate2 certificate)
		{
			if (certificate.NotAfter.Time < (DateTimeHelper.CurrentUnixTimeMillis() + millis))
			{
				throw new FailedValidationException(string.Format("Certificate expires in less than {0} milliseconds.", millis));
			}
		}
	}
}