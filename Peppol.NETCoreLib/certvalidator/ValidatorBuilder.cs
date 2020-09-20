using System.Collections.Generic;
using ValidatorRule = no.difi.certvalidator.api.ValidatorRule;
using Junction = no.difi.certvalidator.structure.Junction;


namespace no.difi.certvalidator
{
	/// <summary>
	/// Builder for creation of validators.
	/// </summary>
	public class ValidatorBuilder
	{
		/// <summary>
		/// Point of entry.
		/// </summary>
		/// <returns> Builder instance. </returns>
		public static ValidatorBuilder newInstance()
		{
			return new ValidatorBuilder();
		}

		private List<ValidatorRule> validatorRules = new List<ValidatorRule>();

		private ValidatorBuilder()
		{
			// No action
		}

		/// <summary>
		/// Append validator instance to validator.
		/// </summary>
		/// <param name="validatorRule"> Configured validator. </param>
		/// <returns> Builder instance. </returns>
		public virtual ValidatorBuilder addRule(ValidatorRule validatorRule)
		{
			return add(validatorRule);
		}

		/// <summary>
		/// Append validator instance to validator.
		/// </summary>
		/// <param name="validatorRule"> Configured validator. </param>
		/// <returns> Builder instance. </returns>
		public virtual ValidatorBuilder add(ValidatorRule validatorRule)
		{
			validatorRules.Add(validatorRule);
			return this;
		}

		/// <summary>
		/// Generates a ValidatorHelper instance containing defined validator(s).
		/// </summary>
		/// <returns> Validator ready for use. </returns>
		public virtual Validator build()
		{
			if (validatorRules.Count == 1)
			{
				return new Validator(validatorRules[0]);
			}

			return new Validator(Junction.and(validatorRules));
		}
	}
}