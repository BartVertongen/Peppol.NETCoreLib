namespace no.difi.certvalidator.api
{
	public interface CrlCache : CrlFetcher
	{
		void set(string url, /*X509CRL*/object crl);
	}
}