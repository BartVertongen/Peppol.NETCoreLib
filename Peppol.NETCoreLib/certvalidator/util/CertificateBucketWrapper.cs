using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using no.difi.certvalidator.api;


namespace no.difi.certvalidator.util
{
	/// <summary>
	/// Wrapper for certificate bucket. May be used to switch or update certificate buckets on-fly.
	/// </summary>
	public class CertificateBucketWrapper : CertificateBucket
	{

		private CertificateBucket certificateBucket;

		public CertificateBucketWrapper(CertificateBucket certificateBucket)
		{
			this.certificateBucket = certificateBucket;
		}


//ORIGINAL LINE: @Override public java.security.cert.X509Certificate findBySubject(javax.security.auth.x500.X500Principal principal) throws no.difi.certvalidator.api.CertificateBucketException
		public virtual X509Certificate2 findBySubject(X500Principal principal)
		{
			return certificateBucket.findBySubject(principal);
		}

		/// <summary>
		/// {@inheritDoc}
		/// </summary>
		public override IEnumerator<X509Certificate2> iterator()
		{
			return certificateBucket.GetEnumerator();
		}

		public virtual CertificateBucket CertificateBucket
		{
			get
			{
				return certificateBucket;
			}
			set
			{
				this.certificateBucket = value;
			}
		}
	}
}