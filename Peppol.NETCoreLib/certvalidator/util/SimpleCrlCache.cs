using System.Collections.Generic;
using no.difi.certvalidator.api;

namespace no.difi.certvalidator.util
{	
	/// <summary>
	/// In-memory implementation of CRL cache. Used as default implementation.
    /// Connects an Url with a Certificate Revocation List
    /// Inplace of CRL you can use OCSP
	/// </summary>
	public class SimpleCrlCache : CrlCache
	{

		private Dictionary<string, X509CRL> storage = new Dictionary<string, X509CRL>();

		public virtual X509CRL get(string url)
		{
			return storage[url];
		}

		public virtual void set(string url, X509CRL crl)
		{
			if (crl == null)
			{
				storage.Remove(url);
			}
			else
			{
				storage[url] = crl;
			}
		}
	}
}