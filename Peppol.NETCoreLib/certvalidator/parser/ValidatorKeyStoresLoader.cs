
using System.Collections.Generic;
using System.IO;
using CertificateBucketException = no.difi.certvalidator.api.CertificateBucketException;
using Order = no.difi.certvalidator.api.Order;
using ValidatorRecipeParser = no.difi.certvalidator.api.ValidatorRecipeParser;
//using KeyStoreType = no.difi.certvalidator.jaxb.KeyStoreType;
//using ValidatorRecipe = no.difi.certvalidator.jaxb.ValidatorRecipe;
using ValidatorParsingException = no.difi.certvalidator.lang.ValidatorParsingException;
using KeyStoreCertificateBucket = no.difi.certvalidator.util.KeyStoreCertificateBucket;
using peppol.types.certvalidator;


namespace no.difi.certvalidator.parser
{
	/// <summary>
	/// </summary>
    //ORIGINAL LINE: @Order(100) public class ValidatorKeyStoresLoader implements ValidatorRecipeParser
	[Order(100)]
	public class ValidatorKeyStoresLoader : ValidatorRecipeParser
	{
        //throws ValidatorParsingException
		public virtual void parse(ValidatorRecipeType recipe, Dictionary<string, object> objectStorage)
		{
			try
			{
				foreach (KeyStoreType keyStoreType in recipe.KeyStore)
				{
					objectStorage.Add(
                            string.Format("#keyStore::{0}", keyStoreType.Name == null ? "default" : keyStoreType.Name)
                                    , new KeyStoreCertificateBucket(new MemoryStream(keyStoreType.Value), keyStoreType.Password) );
				}
			}
			catch (CertificateBucketException e)
			{
				throw new ValidatorParsingException(e.Message, e);
			}
		}
	}
}