using System;
using System.Collections.Generic;
using ValidatorRule = no.difi.certvalidator.api.ValidatorRule;
using ValidatorRuleParser = no.difi.certvalidator.api.ValidatorRuleParser;
//using CriticalExtensionRequiredType = no.difi.certvalidator.jaxb.CriticalExtensionRequiredType;
using ValidatorParsingException = no.difi.certvalidator.lang.ValidatorParsingException;
using CriticalExtensionRequiredRule = no.difi.certvalidator.rule.CriticalExtensionRequiredRule;
//using MetaInfServices = org.kohsuke.MetaInfServices;


namespace no.difi.certvalidator.parser
{
	/// <summary>
	/// </summary>
    //ORIGINAL LINE: @MetaInfServices public class CriticalExtensionRequiredRuleParser implements ValidatorRuleParser
	public class CriticalExtensionRequiredRuleParser : ValidatorRuleParser
	{
		public virtual bool supports(Type cls)
		{
			return typeof(CriticalExtensionRequiredType).Equals(cls);
		}


        //ORIGINAL LINE: @Override public ValidatorRule parse(Object o, Map<String, Object> objectStorage) throws ValidatorParsingException
		public virtual ValidatorRule parse(object o, Dictionary<string, object> objectStorage)
		{
			CriticalExtensionRequiredType rule = (CriticalExtensionRequiredType) o;

			return new CriticalExtensionRequiredRule(rule.Value.toArray(new string[rule.Value.size()]));
		}
	}
}