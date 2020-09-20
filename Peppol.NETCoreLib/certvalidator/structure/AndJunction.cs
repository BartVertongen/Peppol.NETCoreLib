using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace no.difi.certvalidator.structure
{
	using CertificateValidationException = no.difi.certvalidator.api.CertificateValidationException;
	using Report = no.difi.certvalidator.api.Report;
	using ValidatorRule = no.difi.certvalidator.api.ValidatorRule;


	/// <summary>
	/// Allows combining instances of validators using a limited set of logic.
	/// </summary>
	public class AndJunction : AbstractJunction
	{

		public AndJunction(params ValidatorRule[] validatorRules) : base(validatorRules)
		{
		}

		public AndJunction(List<ValidatorRule> validatorRules) : base(validatorRules)
		{
		}


//ORIGINAL LINE: @Override public no.difi.certvalidator.api.Report validate(java.security.cert.X509Certificate certificate, no.difi.certvalidator.api.Report report) throws no.difi.certvalidator.api.CertificateValidationException
		public override Report validate(X509Certificate2 certificate, Report report)
		{
			foreach (ValidatorRule validatorRule in validatorRules)
			{
				report = validatorRule.validate(certificate, report.copy());
			}

			return report;
		}
	}
}