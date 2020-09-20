
using no.difi.certvalidator.api;
using System.Collections.Generic;

namespace no.difi.certvalidator.structure
{

	/// <summary>
	/// Allows combining instances of validators using a limited set of logic.
	/// </summary>
	public interface IJunction
	{
        ValidatorRule and(params ValidatorRule[] validatorRules);

        ValidatorRule and(List<ValidatorRule> validatorRules);

        ValidatorRule or(params ValidatorRule[] validatorRules);

        ValidatorRule or(List<ValidatorRule> validatorRules);

        ValidatorRule xor(params ValidatorRule[] validatorRules);

        ValidatorRule xor(List<ValidatorRule> validatorRules);
	}


    public class Junction
    {
        public static ValidatorRule and(params ValidatorRule[] validatorRules)
        {
            return and(new List<ValidatorRule>(validatorRules));
        }


        public static ValidatorRule and(List<ValidatorRule> validatorRules)
        {
        	if (validatorRules.Count == 1)
        		return validatorRules[0];
        	return new AndJunction(validatorRules);
        }


        public static ValidatorRule or(params ValidatorRule[] validatorRules)
        {
            return or(new List<ValidatorRule>(validatorRules));
        }


        public static ValidatorRule or(List<ValidatorRule> validatorRules)
        {
            if (validatorRules.Count == 1)
                return validatorRules[0];
            return new OrJunction(validatorRules);
        }

        public static ValidatorRule xor(params ValidatorRule[] validatorRules)
        {
            return xor(new List<ValidatorRule>(validatorRules));
        }


        public static ValidatorRule xor(List<ValidatorRule> validatorRules)
        {
            if (validatorRules.Count == 1)
                return validatorRules[0];
            return new XorJunction(validatorRules);
        }
    }
}