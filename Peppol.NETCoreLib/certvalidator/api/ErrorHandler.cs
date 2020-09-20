namespace no.difi.certvalidator.api
{
	/// <summary>
	/// </summary>
	public interface ErrorHandler
	{
        //throws FailedValidationException;
		void handle(CertificateValidationException e);
	}
}