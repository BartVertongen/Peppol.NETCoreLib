using System;
using System.Collections.Generic;
using PrincipalNameProvider = no.difi.certvalidator.api.PrincipalNameProvider;
using ValidatorRule = no.difi.certvalidator.api.ValidatorRule;
using ValidatorRuleParser = no.difi.certvalidator.api.ValidatorRuleParser;
//using PrincipleNameType = no.difi.certvalidator.jaxb.PrincipleNameType;
using ValidatorParsingException = no.difi.certvalidator.lang.ValidatorParsingException;
using PrincipalNameRule = no.difi.certvalidator.rule.PrincipalNameRule;
using SimplePrincipalNameProvider = no.difi.certvalidator.util.SimplePrincipalNameProvider;
//using MetaInfServices = org.kohsuke.MetaInfServices;


namespace no.difi.certvalidator.parser
{
	/// <summary>
	/// </summary>
    //ORIGINAL LINE: public class PrincipleNameRuleParser implements ValidatorRuleParser
	public class PrincipleNameRuleParser : ValidatorRuleParser
	{
		public virtual bool supports(Type cls)
		{
			return typeof(PrincipleNameType).Equals(cls);
		}


        //ORIGINAL LINE: @Override public ValidatorRule parse(Object o, java.util.Map<String, Object> objectStorage) throws ValidatorParsingException
		public virtual ValidatorRule parse(object o, Dictionary<string, object> objectStorage)
		{
			PrincipleNameType principleNameType = (PrincipleNameType) o;

			PrincipalNameProvider<string> principalNameProvider;
			if (principleNameType.Reference != null)
			{
				principalNameProvider = (PrincipalNameProvider<string>) objectStorage[principleNameType.Reference.Value];
			}
			else
			{
				principalNameProvider = new SimplePrincipalNameProvider(principleNameType.Value);
			}

			return new PrincipalNameRule(principleNameType.Field, principalNameProvider, principleNameType.Principal != null 
                            ? Enum.Parse(typeof(PrincipalNameRule.Principal), principleNameType.Principal.ToString()) 
                            : PrincipalNameRule.Principal.SUBJECT);
		}
	}
}