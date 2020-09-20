using System;
using System.Collections.Generic;

namespace no.difi.certvalidator.parser
{
	using ValidatorRule = no.difi.certvalidator.api.ValidatorRule;
	using ValidatorRuleParser = no.difi.certvalidator.api.ValidatorRuleParser;
	//using ValidatorReferenceType = no.difi.certvalidator.jaxb.ValidatorReferenceType;
	using ValidatorParsingException = no.difi.certvalidator.lang.ValidatorParsingException;


    //ORIGINAL LINE: @MetaInfServices public class ValidatorReferenceRuleParser implements ValidatorRuleParser
	public class ValidatorReferenceRuleParser : ValidatorRuleParser
	{
		public virtual bool supports(Type cls)
		{
			return typeof(ValidatorReferenceType).Equals(cls);
		}


        //ORIGINAL LINE: @Override public ValidatorRule parse(Object o, Map<String, Object> objectStorage) throws ValidatorParsingException
		public virtual ValidatorRule parse(object o, Dictionary<string, object> objectStorage)
		{
			ValidatorReferenceType rule = (ValidatorReferenceType) o;

			string identifier = string.Format("#validator::{0}", rule.Value);
			if (!objectStorage.ContainsKey(identifier))
			{
				throw new ValidatorParsingException(string.Format("Unable to find validator '{0}'.", rule.Value));
			}
			return (ValidatorRule) objectStorage[identifier];
		}
	}
}