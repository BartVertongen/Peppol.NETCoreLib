using System;

namespace no.difi.certvalidator.api
{
	/// <summary>
	/// Exception thrown when validation failes.
	/// </summary>
	public class FailedValidationException : CertificateValidationException
	{
		public FailedValidationException(string reason, Exception cause) : base(reason, cause)
		{
		}

		public FailedValidationException(string message) : base(message)
		{
		}
	}
}