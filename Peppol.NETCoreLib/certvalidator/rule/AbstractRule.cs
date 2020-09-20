namespace no.difi.certvalidator.rule
{
	using CertificateValidationException = no.difi.certvalidator.api.CertificateValidationException;
	using Report = no.difi.certvalidator.api.Report;
	using ValidatorRule = no.difi.certvalidator.api.ValidatorRule;
	using DummyReport = no.difi.certvalidator.util.DummyReport;
    using System.Security.Cryptography.X509Certificates;

    /// <summary>
    /// @author erlend
    /// </summary>
    public abstract class AbstractRule : ValidatorRule
	{

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: @Override public no.difi.certvalidator.api.Report validate(java.security.cert.X509Certificate certificate, no.difi.certvalidator.api.Report report) throws no.difi.certvalidator.api.CertificateValidationException
		public virtual Report validate(X509Certificate2 certificate, Report report)
		{
			validate(certificate);

			return report;
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: @Override public void validate(java.security.cert.X509Certificate certificate) throws no.difi.certvalidator.api.CertificateValidationException
		public virtual void validate(X509Certificate2 certificate)
		{
			validate(certificate, DummyReport.INSTANCE);
		}
	}

}