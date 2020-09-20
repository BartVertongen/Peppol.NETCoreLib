using System;
using System.Collections.Generic;
using ValidatorRule = no.difi.certvalidator.api.ValidatorRule;
using ValidatorRuleParser = no.difi.certvalidator.api.ValidatorRuleParser;
//using CriticalExtensionRecognizedType = no.difi.certvalidator.jaxb.CriticalExtensionRecognizedType;
using ValidatorParsingException = no.difi.certvalidator.lang.ValidatorParsingException;
using CriticalExtensionRecognizedRule = no.difi.certvalidator.rule.CriticalExtensionRecognizedRule;
//using MetaInfServices = org.kohsuke.MetaInfServices;


namespace no.difi.certvalidator.parser
{

	public class CriticalExtensionRecognizedRuleParser : ValidatorRuleParser
	{
		public virtual bool supports(Type cls)
		{
			return typeof(CriticalExtensionRecognizedType).Equals(cls);
		}


        //throws ValidatorParsingException
		public virtual ValidatorRule parse(object o, Dictionary<string, object> objectStorage)
		{
			CriticalExtensionRecognizedType rule = (CriticalExtensionRecognizedType) o;

			return new CriticalExtensionRecognizedRule(rule.Value.toArray(new string[rule.Value.size()]));
		}
	}
}