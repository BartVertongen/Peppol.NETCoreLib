using System;
using System.Collections.Generic;
using no.difi.certvalidator.api;
//using ExpirationType = no.difi.certvalidator.jaxb.ExpirationType;
using no.difi.certvalidator.rule;


namespace no.difi.certvalidator.parser
{
	/// <summary>
	/// </summary>
    //ORIGINAL LINE: @MetaInfServices public class ExpirationRuleParser implements ValidatorRuleParser
	public class ExpirationRuleParser : ValidatorRuleParser
	{
		public virtual bool supports(Type cls)
		{
			return typeof(ExpirationType).Equals(cls);
		}

		public virtual ValidatorRule parse(object o, Dictionary<string, object> objectStorage)
		{
			ExpirationType expirationType = (ExpirationType) o;

			if (expirationType.Millis == null)
			{
				return new ExpirationRule();
			}
			else
			{
				return new ExpirationSoonRule(expirationType.Millis);
			}
		}
	}
}