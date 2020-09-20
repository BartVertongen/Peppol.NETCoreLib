
using System;
using System.Collections.Generic;
using no.difi.certvalidator.api;
//using DummyType = no.difi.certvalidator.jaxb.DummyType;
using no.difi.certvalidator.rule;


namespace no.difi.certvalidator.parser
{


	public class DummyRuleParser : ValidatorRuleParser
	{
		public virtual bool supports(Type cls)
		{
			return typeof(DummyType).Equals(cls);
		}

		public virtual ValidatorRule parse(object o, Dictionary<string, object> objectStorage)
		{
			DummyType dummyType = (DummyType) o;

			return new DummyRule(dummyType.Value);
		}
	}
}