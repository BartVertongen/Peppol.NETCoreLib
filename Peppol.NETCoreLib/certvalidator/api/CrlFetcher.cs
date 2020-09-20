namespace no.difi.certvalidator.api
{
	public interface CrlFetcher
	{
        //Online certificate Revocation list
        //throws CertificateValidationException;
		/*X509CRL*/object get(string url);
	}
}