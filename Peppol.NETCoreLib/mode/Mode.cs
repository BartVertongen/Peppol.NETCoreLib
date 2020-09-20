
using System;
using System.Collections.Generic;
//using Config = com.typesafe.config.Config;
//using ConfigFactory = com.typesafe.config.ConfigFactory;
using PeppolLoadingException = no.difi.vefa.peppol.common.lang.PeppolLoadingException;


namespace no.difi.vefa.peppol.mode
{
	//REM: This is the java way for configuration files
	public class Mode
	{
		public const string PRODUCTION = "PRODUCTION";
		public const string TEST = "TEST";

		private Config config;
		private string identifier;

		public static Mode of(string identifier)
		{
			return of(ConfigFactory.empty(), identifier);
		}

		public static Mode of(Config config, string identifier)
		{
			Config referenceConfig = ConfigFactory.defaultReference();

			Config result = ConfigFactory.systemProperties().withFallback(config).withFallback(referenceConfig);

			// Loading configuration based on identifier.
			if (!string.ReferenceEquals(identifier, null))
			{
				if (referenceConfig.hasPath(string.Format("mode.{0}", identifier)))
				{
					result = result.withFallback(referenceConfig.getConfig(string.Format("mode.{0}", identifier)));
				}
			}

			// Load inherited configuration.
			if (result.hasPath("inherit"))
			{
				result = result.withFallback(referenceConfig.getConfig(string.Format("mode.{0}", result.getString("inherit"))));
			}

			// Load default configuration.
			if (referenceConfig.hasPath("mode.default"))
			{
				result = result.withFallback(referenceConfig.getConfig("mode.default"));
			}

			return new Mode(result, identifier);
		}

		private Mode(Config config, string identifier)
		{
			this.config = config;
			this.identifier = identifier;
		}

		public virtual string Identifier
		{
			get
			{
				return identifier;
			}
		}

		public virtual string getString(string key)
		{
			return config.getString(key);
		}

		public virtual Config Config
		{
			get
			{
				return config;
			}
		}


		//ORIGINAL LINE: @SuppressWarnings({"unchecked", "unused"}) 
		//	public <T> T initiate(String key, Class<T> type, java.util.Map<String, Object> objectStorage) throws PeppolLoadingException
		public virtual T initiate<T>(string key, System.Type type, IDictionary<string, object> objectStorage)
		{
				type = typeof(T);
			try
			{
				return (T) initiate(System.Type.GetType(getString(key)), objectStorage);
			}
			catch (ClassNotFoundException e)
			{
				throw new PeppolLoadingException(string.Format("Unable to initiate '{0}'", getString(key)), e);
			}
		}


		//ORIGINAL LINE: @SuppressWarnings({"unchecked", "unused"}) public <T> T initiate(String key, Class<T> type) throws PeppolLoadingException
		public virtual T initiate<T>(string key, System.Type type)
		{
				type = typeof(T);
			return initiate(key, type, null);
		}


		//ORIGINAL LINE: public <T> T initiate(Class<T> cls) throws PeppolLoadingException
		public virtual T initiate<T>(System.Type cls)
		{
				cls = typeof(T);
			return initiate(cls, null);
		}


		//ORIGINAL LINE: public <T> T initiate(Class<T> cls, java.util.Map<String, Object> objectStorage) throws PeppolLoadingException
		public virtual T initiate<T>(System.Type cls, IDictionary<string, object> objectStorage)
		{
				cls = typeof(T);
			try
			{
				try
				{
					return cls.GetConstructor(typeof(Mode), typeof(System.Collections.IDictionary)).newInstance(this, objectStorage);
				}
				catch (NoSuchMethodException)
				{
					// No action
				}

				try
				{
					return cls.GetConstructor(typeof(Mode)).newInstance(this);
				}
				catch (NoSuchMethodException)
				{
					// No action
				}

				return System.Activator.CreateInstance(cls);
			}
			catch (Exception e) when (e is InstantiationException || e is IllegalAccessException || e is InvocationTargetException)
			{
				throw new PeppolLoadingException(string.Format("Unable to initiate '{0}'", cls), e);
			}
		}
	}
}