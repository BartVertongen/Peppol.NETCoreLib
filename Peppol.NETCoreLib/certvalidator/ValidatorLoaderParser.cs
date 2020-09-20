using System;
using System.Collections.Generic;
using System.IO;

namespace no.difi.certvalidator
{
	//using OcspClient = net.klakegg.pkix.ocsp.OcspClient;
	//using OcspFetcher = net.klakegg.pkix.ocsp.api.OcspFetcher;
	//using Builder = net.klakegg.pkix.ocsp.builder.Builder;
	using no.difi.certvalidator.api;
	//using no.difi.certvalidator.jaxb;
	using ValidatorParsingException = no.difi.certvalidator.lang.ValidatorParsingException;
	using no.difi.certvalidator.rule;
	using Junction = no.difi.certvalidator.structure.Junction;
	using CachedValidatorRule = no.difi.certvalidator.util.CachedValidatorRule;
    using peppol.types.certvalidator;

    internal class ValidatorLoaderParser
	{

		//private static JAXBContext jaxbContext;

		private static List<ValidatorRecipeParser> recipeParser = serviceLoader(typeof(ValidatorRecipeParser));

		private static List<ValidatorRuleParser> ruleParsers = serviceLoader(typeof(ValidatorRuleParser));

		static ValidatorLoaderParser()
		{
			try
			{
				//jaxbContext = JAXBContext.newInstance(typeof(ValidatorRecipe));
			}
			catch (/*JAXB*/Exception e)
			{
				throw new Exception(e.Message, e);
			}
		}

        //public static ValidatorGroup parse(Stream inputStream, Map<String, Object> objectStorage) throws ValidatorParsingException
		public static ValidatorGroup parse(Stream inputStream, Dictionary<string, object> objectStorage)
		{
			try
			{
				ValidatorRecipeType recipe = jaxbContext.createUnmarshaller().unmarshal(new StreamSource(inputStream), typeof(ValidatorRecipeType)).Value;

				foreach (ValidatorRecipeParser parser in recipeParser)
				{
					parser.parse(recipe, objectStorage);
				}

				Dictionary<string, ValidatorRule> rulesMap = new Dictionary<string, ValidatorRule>();

				foreach (ValidatorType validatorType in recipe.Validator)
				{
					ValidatorRule validatorRule = parse(validatorType.BlacklistOrCachedOrChain, objectStorage, JunctionEnum.AND);

					if (validatorType.timeout != null)
					{
						validatorRule = new CachedValidatorRule(validatorRule, validatorType.timeout);
					}

					string name = validatorType.Name == null ? "default" : validatorType.Name;
					rulesMap[name] = validatorRule;
					objectStorage[string.Format("#validator::{0}", name)] = validatorRule;
				}

				return new ValidatorGroup(rulesMap, recipe.Name, recipe.Version);
			}
			catch (Exception e) //when (e is JAXBException || e is CertificateValidationException)
			{
				throw new ValidatorParsingException(e.Message, e);
			}
		}


        //ORIGINAL LINE: private static ValidatorRule parse(List<Object> rules, Map<String, Object> objectStorage, JunctionEnum junctionEnum) 
        //throws CertificateValidationException
		private static ValidatorRule parse(IList<object> rules, Dictionary<string, object> objectStorage, JunctionEnum junctionEnum)
		{
			IList<ValidatorRule> ruleList = new List<ValidatorRule>();

			foreach (object rule in rules)
			{
				ruleList.Add(parse(rule, objectStorage));
			}

			if (junctionEnum == JunctionEnum.AND)
			{
				return Junction.and(ruleList.ToArray());
			}
			else if (junctionEnum == JunctionEnum.OR)
			{
				return Junction.or(ruleList.ToArray());
			}
			else // if (junctionEnum == JunctionEnum.XOR)
			{
				return Junction.xor(ruleList.ToArray());
			}
		}


        //ORIGINAL LINE: private static ValidatorRule parse(Object rule, Map<String, Object> objectStorage) 
        //throws CertificateValidationException
		private static ValidatorRule parse(object rule, Dictionary<string, object> objectStorage)
		{
			if (rule is BlacklistType)
			{
				return parse((BlacklistType) rule, objectStorage);
			}
			else if (rule is CachedType)
			{
				return parse((CachedType) rule, objectStorage);
			}
			else if (rule is ChainType)
			{
				return parse((ChainType) rule, objectStorage);
			}
			else if (rule is JunctionType)
			{
				return parse((JunctionType) rule, objectStorage);
			}
			else if (rule is OCSPType)
			{
				return parse((OCSPType) rule, objectStorage);
			}
			else if (rule is HandleErrorType)
			{
				return parse((HandleErrorType) rule, objectStorage);
			}
			else if (rule is TryType)
			{
				return parse((TryType) rule, objectStorage);
			}
			else if (rule is WhitelistType)
			{
				return parse((WhitelistType) rule, objectStorage);
			}
			else
			{
				foreach (ValidatorRuleParser parser in ruleParsers)
				{
					if (parser.supports(rule.GetType()))
					{
						return parser.parse(rule, objectStorage);
					}
				}
			}

			throw new ValidatorParsingException(string.Format("Unable to parse '{0}'", rule));
		}

		private static ValidatorRule parse(BlacklistType rule, IDictionary<string, object> objectStorage)
		{
			return new BlacklistRule(getBucket(rule.Value, objectStorage));
		}


        //ORIGINAL LINE: private static ValidatorRule parse(CachedType rule, Map<String, Object> objectStorage) throws CertificateValidationException
		private static ValidatorRule parse(CachedType rule, IDictionary<string, object> objectStorage)
		{
			return new CachedValidatorRule(parse(rule.BlacklistOrCachedOrChain, objectStorage, JunctionEnum.AND), rule.Timeout);
		}

		private static ValidatorRule parse(ChainType rule, IDictionary<string, object> objectStorage)
		{
			return new ChainRule(getBucket(rule.RootBucketReference.Value, objectStorage), getBucket(rule.IntermediateBucketReference.Value, objectStorage), rule.Policy.toArray(new string[rule.Policy.size()]));
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private static ValidatorRule parse(HandleErrorType optionalType, Map<String, Object> objectStorage) throws CertificateValidationException
		private static ValidatorRule parse(HandleErrorType optionalType, Dictionary<string, object> objectStorage)
		{
			IList<ValidatorRule> validatorRules = new List<ValidatorRule>();
			foreach (object o in optionalType.BlacklistOrCachedOrChain)
			{
				validatorRules.Add(parse(o, objectStorage));
			}

			string handlerKey = optionalType.Handler != null ? optionalType.Handler : "#errorhandler";

			if (objectStorage[handlerKey] != null)
			{
				return new HandleErrorRule((ErrorHandler) objectStorage[handlerKey], validatorRules);
			}
			else
			{
				return new HandleErrorRule(validatorRules);
			}
		}


        //ORIGINAL LINE: private static ValidatorRule parse(JunctionType junctionType, Map<String, Object> objectStorage) throws CertificateValidationException
		private static ValidatorRule parse(JunctionType junctionType, IDictionary<string, object> objectStorage)
		{
			return parse(junctionType.BlacklistOrCachedOrChain, objectStorage, junctionType.Type);
		}

		private static ValidatorRule parse(OCSPType ocspType, IDictionary<string, object> objectStorage)
		{
			Builder<OcspClient> builder = OcspClient.builder();

			builder = builder.set(OcspClient.INTERMEDIATES, getBucket(ocspType.IntermediateBucketReference.Value, objectStorage).asList());

			if (objectStorage.ContainsKey("ocsp_fetcher"))
			{
				builder = builder.set(OcspClient.FETCHER, (OcspFetcher) objectStorage["ocsp_fetcher"]);
			}

			return new OCSPRule(builder.build());
		}


        //ORIGINAL LINE: private static ValidatorRule parse(TryType tryType, Map<String, Object> objectStorage) throws CertificateValidationException
		private static ValidatorRule parse(TryType tryType, IDictionary<string, object> objectStorage)
		{
			foreach (object rule in tryType.BlacklistOrCachedOrChain)
			{
				try
				{
					return parse(rule, objectStorage);
				}
				catch (Exception)
				{
					// No action
				}
			}
			throw new CertificateValidationException("Unable to find valid rule in try.");
		}


        //ORIGINAL LINE: private static ValidatorRule parse(WhitelistType rule, Map<String, Object> objectStorage) throws CertificateValidationException
		private static ValidatorRule parse(WhitelistType rule, IDictionary<string, object> objectStorage)
		{
			return new WhitelistRule(getBucket(rule.Value, objectStorage));
		}

		// HELPERS
		private static CertificateBucket getBucket(string name, IDictionary<string, object> objectStorage)
		{
			return (CertificateBucket) objectStorage[string.Format("#bucket::{0}", name)];
		}

		public static List<T> serviceLoader<T>(Type cls)
		{
			cls = typeof(T);
			return StreamSupport.stream(ServiceLoader.load(cls).spliterator(), false).sorted((o1, o2) =>
			{
			    int v1 = o1.GetType().isAnnotationPresent(typeof(Order)) ? o1.GetType().getAnnotation(typeof(Order)).value() : 0;
			    int v2 = o2.GetType().isAnnotationPresent(typeof(Order)) ? o2.GetType().getAnnotation(typeof(Order)).value() : 0;
			    return Integer.compare(v1, v2);
			}).collect(Collectors.toList());
		}
	}
}