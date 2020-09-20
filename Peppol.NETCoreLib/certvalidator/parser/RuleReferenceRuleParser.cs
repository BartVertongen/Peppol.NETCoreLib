using System;
using System.Collections.Generic;
using ValidatorRule = no.difi.certvalidator.api.ValidatorRule;
using ValidatorRuleParser = no.difi.certvalidator.api.ValidatorRuleParser;
//using RuleReferenceType = no.difi.certvalidator.jaxb.RuleReferenceType;
using ValidatorParsingException = no.difi.certvalidator.lang.ValidatorParsingException;


namespace no.difi.certvalidator.parser
{
	/// <summary>
	/// </summary>
    //ORIGINAL LINE: public class RuleReferenceRuleParser implements ValidatorRuleParser
	public class RuleReferenceRuleParser : ValidatorRuleParser
	{
		public virtual bool supports(Type cls)
		{
			return typeof(RuleReferenceType).Equals(cls);
		}


        //ORIGINAL LINE: public ValidatorRule parse(Object o, Map<String, Object> objectStorage) throws ValidatorParsingException
		public virtual ValidatorRule parse(object o, Dictionary<string, object> objectStorage)
		{
			RuleReferenceType ruleReferenceType = (RuleReferenceType) o;

			if (!objectStorage.ContainsKey(ruleReferenceType.Value))
			{
				throw new ValidatorParsingException(string.Format("Rule for '{0}' not found.", ruleReferenceType.Value));
			}
			return (ValidatorRule) objectStorage[ruleReferenceType.Value];
		}
	}
}