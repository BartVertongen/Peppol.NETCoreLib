
using System;
using System.Collections.Generic;
using ValidatorParsingException = no.difi.certvalidator.lang.ValidatorParsingException;


namespace no.difi.certvalidator.api
{	
	/// <summary>
	/// </summary>
	public interface ValidatorRuleParser
	{
		bool supports(Type cls);

        //throws ValidatorParsingException;
		ValidatorRule parse(object o, Dictionary<string, object> objectStorage);
	}
}