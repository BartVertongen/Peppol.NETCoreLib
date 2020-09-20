using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace no.difi.certvalidator.util
{
	using CertificateBucket = no.difi.certvalidator.api.CertificateBucket;


	/// <summary>
	/// Lightweight implementation using ArrayList to keep certificates in memory.
	/// </summary>
	public class SimpleCertificateBucket : CertificateBucket
	{

		private List<X509Certificate2> certificates = new List<X509Certificate2>();

		public static CertificateBucket with(params X509Certificate2[] certificates)
		{
			return new SimpleCertificateBucket(certificates);
		}

		public SimpleCertificateBucket(params X509Certificate2[] certificates)
		{
			add(certificates);
		}

		/// <summary>
		/// Append certificate(s) to bucket.
		/// </summary>
		/// <param name="certificates"> Certificate(s) to be added. </param>
		public virtual void add(params X509Certificate2[] certificates)
		{
			((List<X509Certificate2>)this.certificates).AddRange(new List<X509Certificate2>(certificates));
		}


		public virtual X509Certificate2 findBySubject(X500Principal principal)
		{
			foreach (X509Certificate2 certificate in certificates)
			{
				if (certificate.SubjectX500Principal.Equals(principal))
				{
					return certificate;
				}
			}
			return null;
		}


		public override IEnumerator<X509Certificate2> iterator()
		{
			return certificates.GetEnumerator();
		}
	}
}