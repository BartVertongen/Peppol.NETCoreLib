using System;
using CertificateValidationException = no.difi.certvalidator.api.CertificateValidationException;


namespace no.difi.certvalidator.lang
{
	public class ValidatorParsingException : CertificateValidationException
	{
		public ValidatorParsingException(string message) : base(message)
		{
		}

		public ValidatorParsingException(string reason, Exception cause) : base(reason, cause)
		{
		}
	}
}