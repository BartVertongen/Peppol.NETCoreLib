using System;

namespace no.difi.certvalidator.util
{
	using CertificateValidationException = no.difi.certvalidator.api.CertificateValidationException;
	using CrlCache = no.difi.certvalidator.api.CrlCache;
	using CrlFetcher = no.difi.certvalidator.api.CrlFetcher;


	/// <summary>
	/// Simple implementation of CRL fetcher, which caches downloaded CRLs. If a CRL is not cached, or the Next update-
	/// field of a cached CRL indicates there is an updated CRL available, an updated CRL will immediately be downloaded.
	/// </summary>
	public class SimpleCachingCrlFetcher : CrlFetcher
	{

		protected internal CrlCache crlCache;

		public SimpleCachingCrlFetcher(CrlCache crlCache)
		{
			this.crlCache = crlCache;
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: @Override public java.security.cert.X509CRL get(String url) throws no.difi.certvalidator.api.CertificateValidationException
		public virtual X509CRL get(string url)
		{
			X509CRL crl = crlCache.get(url);
			if (crl == null)
			{
				// Not in cache
				crl = download(url);
			}
			else if (crl.NextUpdate != null && crl.NextUpdate.Time < DateTimeHelper.CurrentUnixTimeMillis())
			{
				// Outdated
				crl = download(url);
			}
			else if (crl.NextUpdate == null)
			{
				// No action.
			}
			return crl;
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: protected java.security.cert.X509CRL download(String url) throws no.difi.certvalidator.api.CertificateValidationException
		protected internal virtual X509CRL download(string url)
		{
			if (!string.ReferenceEquals(url, null) && url.matches("http[s]{0,1}://.*"))
			{
				X509CRL crl = httpDownload(url);
				crlCache.set(url, crl);
				return crl;
			}
			else if (!string.ReferenceEquals(url, null) && url.StartsWith("ldap://", StringComparison.Ordinal))
			{
				// Currently not supported.
				return null;
			}

			return null;
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: protected java.security.cert.X509CRL httpDownload(String url) throws no.difi.certvalidator.api.CertificateValidationException
		protected internal virtual X509CRL httpDownload(string url)
		{
			try
			{
				return CrlUtils.load(URI.create(url).toURL().openStream());
			}
			catch (Exception e) when (e is IOException || e is CRLException)
			{
				throw new CertificateValidationException(string.Format("Failed to download CRL '{0}' ({1})", url, e.Message), e);
			}
		}
	}

}