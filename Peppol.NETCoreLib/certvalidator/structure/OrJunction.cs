using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using no.difi.certvalidator.api;


namespace no.difi.certvalidator.structure
{	
	/// <summary>
	/// Allows combining instances of validators using a limited set of logic.
	/// </summary>
	public class OrJunction : AbstractJunction
	{

		public OrJunction(params ValidatorRule[] validatorRules) : base(validatorRules)
		{
		}

		public OrJunction(List<ValidatorRule> validatorRules) : base(validatorRules)
		{
		}


        //ORIGINAL LINE: @Override public Report validate(X509Certificate certificate, Report report) 
        //throws CertificateValidationException
		public override Report validate(X509Certificate2 certificate, Report report)
		{
			List<CertificateValidationException> exceptions = new List<CertificateValidationException>();

			foreach (ValidatorRule validatorRule in validatorRules)
			{
				try
				{
					return validatorRule.validate(certificate, report.copy());
				}
				catch (CertificateValidationException e)
				{
					exceptions.Add(e);
				}
			}

			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Or-junction failed with results:");
			foreach (Exception e in exceptions)
			{
				stringBuilder.Append("\n* ").Append(e.Message);
			}
			throw new FailedValidationException(stringBuilder.ToString());
		}
	}
}