
using System;
using System.Collections.Generic;
using no.difi.certvalidator.api;
using no.difi.certvalidator.rule;
using no.difi.certvalidator.util;
using peppol.types.certvalidator;


namespace no.difi.certvalidator.parser
{

	public class KeyUsageRuleParser : ValidatorRuleParser
	{
		public virtual bool supports(Type cls)
		{
			return typeof(KeyUsageType).Equals(cls);
		}

		public virtual ValidatorRule parse(object o, Dictionary<string, object> objectStorage)
		{
			KeyUsageType keyUsageType = (KeyUsageType) o;

			List<KeyUsageEnum> keyUsages = keyUsageType.Identifier;
			KeyUsage[] result = new KeyUsage[keyUsages.Count];

			for (int i = 0; i < result.Length; i++)
			{
				result[i] = KeyUsage.valueOf(keyUsages[i].name());
			}

			return new KeyUsageRule(result);
		}
	}
}