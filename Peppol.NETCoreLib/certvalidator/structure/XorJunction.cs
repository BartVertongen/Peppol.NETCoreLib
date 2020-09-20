using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace no.difi.certvalidator.structure
{
	using CertificateValidationException = no.difi.certvalidator.api.CertificateValidationException;
	using FailedValidationException = no.difi.certvalidator.api.FailedValidationException;
	using Report = no.difi.certvalidator.api.Report;
	using ValidatorRule = no.difi.certvalidator.api.ValidatorRule;


	/// <summary>
	/// Allows combining instances of validators using a limited set of logic.
	/// </summary>
	public class XorJunction : AbstractJunction
	{

		public XorJunction(params ValidatorRule[] validatorRules) : base(validatorRules)
		{
		}

		public XorJunction(List<ValidatorRule> validatorRules) : base(validatorRules)
		{
		}


//ORIGINAL LINE: @Override public no.difi.certvalidator.api.Report validate(java.security.cert.X509Certificate certificate, no.difi.certvalidator.api.Report report) throws no.difi.certvalidator.api.CertificateValidationException
		public override Report validate(X509Certificate2 certificate, Report report)
		{
			IList<CertificateValidationException> exceptions = new List<CertificateValidationException>();

			foreach (ValidatorRule validatorRule in validatorRules)
			{
				try
				{
					report = validatorRule.validate(certificate, report.copy());
				}
				catch (CertificateValidationException e)
				{
					exceptions.Add(e);
				}
			}

			if (exceptions.Count != validatorRules.Count - 1)
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append(string.Format("Xor-junction failed with results ({0} of {1}):", exceptions.Count, validatorRules.Count));
				foreach (Exception e in exceptions)
				{
					stringBuilder.Append("\n* ").Append(e.Message);
				}

				throw new FailedValidationException(stringBuilder.ToString());
			}
			return report;
		}
	}
}