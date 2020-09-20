using System;
using System.Security.Cryptography.X509Certificates;

namespace no.difi.certvalidator.rule
{
	using FailedValidationException = no.difi.certvalidator.api.FailedValidationException;


	/// <summary>
	/// Validate validity of certificate.
	/// </summary>
	public class ExpirationRule : AbstractRule
	{
        //ORIGINAL LINE: @Override public void validate(X509Certificate certificate) throws FailedValidationException
		public override void validate(X509Certificate2 certificate)
		{
			try
			{
				certificate.checkValidity(DateTime.Now);
			}
			catch (Exception e) //when (e is CertificateNotYetValidException || e is CertificateExpiredException)
			{
				throw new FailedValidationException("Certificate does not have a valid expiration date.");
			}
		}
	}
}