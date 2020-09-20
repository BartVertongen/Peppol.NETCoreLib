
using no.difi.certvalidator.api;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using no.difi.certvalidator.util;


namespace no.difi.certvalidator.structure
{
	public abstract class AbstractJunction : ValidatorRule
	{
		public abstract Report validate(X509Certificate2 certificate, no.difi.certvalidator.api.Report report);

		protected internal List<ValidatorRule> validatorRules = new List<ValidatorRule>();

		public AbstractJunction(params ValidatorRule[] validatorRules)
		{
			addRule(validatorRules);
		}

		public AbstractJunction(List<ValidatorRule> validatorRules)
		{
			addRule(validatorRules);
		}

		public virtual AbstractJunction addRule(params ValidatorRule[] validatorRules)
		{
			this.validatorRules.AddRange(new List<ValidatorRule>(validatorRules));
			return this;
		}

		public virtual AbstractJunction addRule(IList<ValidatorRule> validatorRules)
		{
			((List<ValidatorRule>)this.validatorRules).AddRange(validatorRules);
			return this;
		}


        //ORIGINAL LINE: @Override public void validate(X509Certificate certificate) throws CertificateValidationException
		public virtual void validate(X509Certificate2 certificate)
		{
			validate(certificate, DummyReport.INSTANCE);
		}
	}
}