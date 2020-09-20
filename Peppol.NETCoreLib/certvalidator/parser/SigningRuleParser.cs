using System;
using System.Collections.Generic;
using ValidatorRule = no.difi.certvalidator.api.ValidatorRule;
using ValidatorRuleParser = no.difi.certvalidator.api.ValidatorRuleParser;
//using SigningEnum = no.difi.certvalidator.jaxb.SigningEnum;
//using SigningType = no.difi.certvalidator.jaxb.SigningType;
using SigningRule = no.difi.certvalidator.rule.SigningRule;


namespace no.difi.certvalidator.parser
{
	/// <summary>
	/// </summary>
    //ORIGINAL LINE: public class SigningRuleParser implements ValidatorRuleParser
	public class SigningRuleParser : ValidatorRuleParser
	{
		public virtual bool supports(Type cls)
		{
			return typeof(SigningType).Equals(cls);
		}

		public virtual ValidatorRule parse(object o, Dictionary<string, object> objectStorage)
		{
			SigningType signingType = (SigningType) o;

			if (signingType.Type.Equals(SigningEnum.SELF_SIGNED))
			{
				return SigningRule.SelfSignedOnly();
			}
			else
			{
				return SigningRule.PublicSignedOnly();
			}
		}
	}
}