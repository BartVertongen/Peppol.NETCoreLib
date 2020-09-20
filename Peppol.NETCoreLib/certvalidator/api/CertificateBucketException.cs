using System;

namespace no.difi.certvalidator.api
{
	/// <summary>
	/// Exception related to actions performed by certificate buckets.
	/// </summary>
	public class CertificateBucketException : CertificateValidationException
	{
		public CertificateBucketException(string reason, Exception cause) : base(reason, cause)
		{
		}
	}
}