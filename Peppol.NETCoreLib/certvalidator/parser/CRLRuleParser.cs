using System;
using System.Collections.Generic;
using no.difi.certvalidator.api;
//using CRLType = no.difi.certvalidator.jaxb.CRLType;
using ValidatorParsingException = no.difi.certvalidator.lang.ValidatorParsingException;
using CRLRule = no.difi.certvalidator.rule.CRLRule;
using SimpleCachingCrlFetcher = no.difi.certvalidator.util.SimpleCachingCrlFetcher;
using SimpleCrlCache = no.difi.certvalidator.util.SimpleCrlCache;
//using MetaInfServices = org.kohsuke.MetaInfServices;
using peppol.types.certvalidator;


namespace no.difi.certvalidator.parser
{
	/// <summary>
	/// </summary>
    //ORIGINAL LINE: @MetaInfServices public class CRLRuleParser implements no.difi.certvalidator.api.ValidatorRuleParser
	public class CRLRuleParser : ValidatorRuleParser
	{
		public virtual bool supports(Type cls)
		{
			return typeof(CRLType).Equals(cls);
		}


        //ORIGINAL LINE: @Override public ValidatorRule parse(Object o, Map<String, Object> objectStorage) throws ValidatorParsingException
		public virtual ValidatorRule parse(object o, Dictionary<string, object> objectStorage)
		{
			if (!objectStorage.ContainsKey("crlFetcher") && !objectStorage.ContainsKey("crlCache"))
			{
				objectStorage["crlCache"] = new SimpleCrlCache();
			}

			if (!objectStorage.ContainsKey("crlFetcher"))
			{
				objectStorage["crlFetcher"] = new SimpleCachingCrlFetcher((CrlCache) objectStorage["crlCache"]);
			}
			return new CRLRule((CrlFetcher) objectStorage["crlFetcher"]);
		}
	}
}