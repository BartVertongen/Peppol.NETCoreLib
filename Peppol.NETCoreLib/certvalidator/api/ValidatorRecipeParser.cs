using System.Collections.Generic;
//using ValidatorRecipe = no.difi.certvalidator.jaxb.ValidatorRecipe;
using ValidatorParsingException = no.difi.certvalidator.lang.ValidatorParsingException;
using peppol.types.certvalidator;

namespace no.difi.certvalidator.api
{
	/// <summary>
	/// </summary>
	public interface ValidatorRecipeParser
	{
        //ORIGINAL LINE: void parse(jaxb.ValidatorRecipe validatorRecipe, Map<String, Object> objectStorage) throws ValidatorParsingException;
		void parse(ValidatorRecipeType validatorRecipe, Dictionary<string, object> objectStorage);
	}
}