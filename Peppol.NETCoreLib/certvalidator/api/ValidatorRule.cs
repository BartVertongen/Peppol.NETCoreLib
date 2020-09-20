
using System.Security.Cryptography.X509Certificates;


namespace no.difi.certvalidator.api
{
	/// <summary>
	/// Defines a validator rule. Made as simple as possible by purpose.
	/// </summary>
	public interface ValidatorRule
	{
		/// <summary>
		/// Validate certificate. </summary>
		/// <param name="certificate"> Certificate subject to validation. </param>
		/// <exception cref="CertificateValidationException"> </exception>
        //throws CertificateValidationException;
		void validate(X509Certificate2 certificate);

		/// <summary>
		/// Validate certificate. </summary>
		/// <param name="certificate"> Certificate subject to validation. </param>
		/// <param name="report"> Report to be filled during validation. </param>
		/// <exception cref="CertificateValidationException"> </exception>
        //throws CertificateValidationException;
		Report validate(X509Certificate2 certificate, Report report);
	}
}