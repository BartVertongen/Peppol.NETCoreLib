using System;
using System.Collections.Generic;
using no.difi.certvalidator.api;
//using ClassType = no.difi.certvalidator.jaxb.ClassType;
using ValidatorParsingException = no.difi.certvalidator.lang.ValidatorParsingException;
//using MetaInfServices = org.kohsuke.MetaInfServices;
using peppol.types.certvalidator;


namespace no.difi.certvalidator.parser
{
	/// <summary>
	/// </summary>
    //ORIGINAL LINE:  public class ClassRuleParser implements ValidatorRuleParser
	public class ClassRuleParser : ValidatorRuleParser
	{
		public virtual bool supports(Type cls)
		{
			return typeof(ClassType).Equals(cls);
		}


        //ORIGINAL LINE: @Override public ValidatorRule parse(Object o, Map<String, Object> objectStorage) throws ValidatorParsingException
		public virtual ValidatorRule parse(object o, Dictionary<string, object> objectStorage)
		{
			ClassType classType = (ClassType) o;

			try
			{
				return (ValidatorRule)System.Activator.CreateInstance(Type.GetType(classType.Value));
			}
			catch (Exception e) //when (e is ClassNotFoundException || e is InstantiationException || e is IllegalAccessException)
			{
				throw new ValidatorParsingException(string.Format("Unable to load rule '{0}'.", classType.Value), e);
			}
		}
	}
}