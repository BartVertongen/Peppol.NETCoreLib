using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace no.difi.certvalidator.rule
{
	using CertificateValidationException = no.difi.certvalidator.api.CertificateValidationException;
	using ErrorHandler = no.difi.certvalidator.api.ErrorHandler;
	using FailedValidationException = no.difi.certvalidator.api.FailedValidationException;
	using ValidatorRule = no.difi.certvalidator.api.ValidatorRule;


	/// <summary>
	/// Allows encapsulation of other validations rule, allowing errors to occur but not failed validation. May be useful
	/// for encapsulation of CRLRule and other rules where use of external resources may cause validation to fail due to
	/// unavailability of services.
	/// </summary>
	public class HandleErrorRule : AbstractRule
	{

		private ErrorHandler errorHandler;

		private readonly IList<ValidatorRule> validatorRules;

		public HandleErrorRule(params ValidatorRule[] validatorRules) : this(null, new List<ValidatorRule>(validatorRules))
		{
		}

		public HandleErrorRule(ErrorHandler errorHandler, params ValidatorRule[] validatorRules) : this(errorHandler, new List<ValidatorRule>(validatorRules))
		{
		}

		public HandleErrorRule(List<ValidatorRule> validatorRules) : this(null, validatorRules)
		{
		}

		public HandleErrorRule(ErrorHandler errorHandler, List<ValidatorRule> validatorRules)
		{
			this.errorHandler = errorHandler;
			this.validatorRules = validatorRules;
		}


        //ORIGINAL LINE: public void validate(X509Certificate certificate) throws CertificateValidationException
		public override void validate(X509Certificate2 certificate)
		{
			foreach (ValidatorRule validatorRule in validatorRules)
			{
				try
				{
					validatorRule.validate(certificate);
				}
				catch (FailedValidationException e)
				{
					throw e;
				}
				catch (CertificateValidationException e)
				{
					// Allow handling exceptions.
					if (errorHandler != null)
					{
						errorHandler.handle(e);
					}
				}
			}
		}
	}
}