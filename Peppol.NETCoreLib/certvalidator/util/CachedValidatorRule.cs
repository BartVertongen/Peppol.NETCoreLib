
using System.Security.Cryptography.X509Certificates;
//using CacheBuilder = com.google.common.cache.CacheBuilder;
//using CacheLoader = com.google.common.cache.CacheLoader;
//using LoadingCache = com.google.common.cache.LoadingCache;
using CertificateValidationException = no.difi.certvalidator.api.CertificateValidationException;
using Report = no.difi.certvalidator.api.Report;
using ValidatorRule = no.difi.certvalidator.api.ValidatorRule;


namespace no.difi.certvalidator.util
{

	public class CachedValidatorRule : CacheLoader<X509Certificate2, CachedValidatorRule.Result>, ValidatorRule
	{

		private ValidatorRule validatorRule;

		private LoadingCache<X509Certificate2, Result> cache;

		public CachedValidatorRule(ValidatorRule validatorRule, long timeout)
		{
			this.validatorRule = validatorRule;

			cache = CacheBuilder.newBuilder().expireAfterWrite(timeout, TimeUnit.SECONDS).build(this);
		}


//ORIGINAL LINE: @Override public void validate(java.security.cert.X509Certificate certificate) throws no.difi.certvalidator.api.CertificateValidationException
		public virtual void validate(X509Certificate2 certificate)
		{
			cache.getUnchecked(certificate).trigger();
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: @Override public no.difi.certvalidator.api.Report validate(java.security.cert.X509Certificate certificate, no.difi.certvalidator.api.Report report) throws no.difi.certvalidator.api.CertificateValidationException
		public virtual Report validate(X509Certificate2 certificate, Report report)
		{
			validate(certificate);

			return report;
		}


        //ORIGINAL LINE: @Override public Result load(java.security.cert.X509Certificate certificate) throws Exception
		public override Result load(X509Certificate2 certificate)
		{
			try
			{
				validatorRule.validate(certificate);
				return new Result(this);
			}
			catch (CertificateValidationException e)
			{
				return new Result(this, e);
			}
		}

		protected internal class Result
		{
			private readonly CachedValidatorRule outerInstance;


			internal CertificateValidationException exception;

			public Result(CachedValidatorRule outerInstance)
			{
				this.outerInstance = outerInstance;
				// No action.
			}

			public Result(CachedValidatorRule outerInstance, CertificateValidationException e)
			{
				this.outerInstance = outerInstance;
				this.exception = e;
			}


            //ORIGINAL LINE: void trigger() throws CertificateValidationException
			public virtual void trigger()
			{
				if (exception != null)
				{
					throw exception;
				}
			}
		}
	}
}