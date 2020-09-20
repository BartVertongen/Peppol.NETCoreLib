using System.Collections.Generic;
using CertificateValidationException = no.difi.certvalidator.api.CertificateValidationException;
using Order = no.difi.certvalidator.api.Order;
using ValidatorRecipeParser = no.difi.certvalidator.api.ValidatorRecipeParser;
//using no.difi.certvalidator.jaxb;
using ValidatorParsingException = no.difi.certvalidator.lang.ValidatorParsingException;
using KeyStoreCertificateBucket = no.difi.certvalidator.util.KeyStoreCertificateBucket;
using no.difi.certvalidator.util;
using peppol.types.smp.AggregateComponents;
using peppol.types.certvalidator;
using System.Security.Cryptography.X509Certificates;


namespace no.difi.certvalidator.parser
{
    //ORIGINAL LINE: @Order(200) public class ValidatorBucketsLoader implements ValidatorRecipeParser
	[Order(200)]
	public class ValidatorBucketsLoader : ValidatorRecipeParser
	{
        //ORIGINAL LINE: public void parse(ValidatorRecipe recipe, Map<String, Object> objectStorage) throws ValidatorParsingException
		public virtual void parse(ValidatorRecipeType recipe, Dictionary<string, object> objectStorage)
		{
			try
			{
				foreach (CertificateBucketType certificateBucketType in recipe.CertificateBucket)
				{
					SimpleCertificateBucket certificateBucket = new SimpleCertificateBucket();

					foreach (object o in certificateBucketType.CertificateOrCertificateReferenceOrCertificateStartsWith)
					{
						if (o is CertificateType)
						{
							certificateBucket.add(Validator.getCertificate(((CertificateType) o).Value));
						}
						else if (o is CertificateReferenceType)
						{
							CertificateReferenceType c = (CertificateReferenceType) o;
							foreach (X509Certificate2 certificate in getKeyStore(c.KeyStore, objectStorage).toSimple(c.Value))
							{
								certificateBucket.add(certificate);
							}
						}
						else if (o is CertificateStartsWithType)
						{
							CertificateStartsWithType c = (CertificateStartsWithType) o;
							foreach (X509Certificate2 certificate in getKeyStore(c.KeyStore, objectStorage).startsWith(c.Value))
							{
								certificateBucket.add(certificate);
							}
						}
					}

					objectStorage[string.Format("#bucket::{0}", certificateBucketType.Name)] = certificateBucket;
				}
			}
			catch (CertificateValidationException e)
			{
				throw new ValidatorParsingException(e.Message, e);
			}
		}

		private static KeyStoreCertificateBucket getKeyStore(string name, Dictionary<string, object> objectStorage)
		{
			return (KeyStoreCertificateBucket) objectStorage[string.Format("#keyStore::{0}", string.ReferenceEquals(name, null) ? "default" : name)];
		}
	}
}