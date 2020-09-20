namespace no.difi.certvalidator.rule
{
	using no.difi.certvalidator.api;
	using Test = org.testng.annotations.Test;

	public class HandleErrorRuleTest
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void simpleOk() throws CertificateValidationException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void simpleOk()
		{
			(new Validator(new HandleErrorRule(new DummyRule()))).validate(this.GetType().getResourceAsStream("/selfsigned.cer"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test(expectedExceptions = FailedValidationException.class) public void simpleFailed() throws CertificateValidationException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void simpleFailed()
		{
			(new Validator(new HandleErrorRule(new DummyRule("Trigger me!")))).validate(this.GetType().getResourceAsStream("/selfsigned.cer"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void simpleUnknown() throws CertificateValidationException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void simpleUnknown()
		{
			new Validator(new HandleErrorRule(new ValidatorRuleAnonymousInnerClass(this)))
		   .validate(this.GetType().getResourceAsStream("/selfsigned.cer"));
		}

		private class ValidatorRuleAnonymousInnerClass : ValidatorRule
		{
			private readonly HandleErrorRuleTest outerInstance;

			public ValidatorRuleAnonymousInnerClass(HandleErrorRuleTest outerInstance)
			{
				this.outerInstance = outerInstance;
			}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void validate(java.security.cert.X509Certificate certificate) throws CertificateValidationException
			public void validate(X509Certificate certificate)
			{
				throw new CertificateValidationException("Unable to load something...");
			}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public Report validate(java.security.cert.X509Certificate certificate, Report report) throws CertificateValidationException
			public Report validate(X509Certificate certificate, Report report)
			{
				throw new CertificateValidationException("Unable to load something...");
			}
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test(expectedExceptions = FailedValidationException.class) public void triggerException() throws CertificateValidationException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void triggerException()
		{
			new Validator(new HandleErrorRule(new ErrorHandlerAnonymousInnerClass(this)
		   , new ValidatorRuleAnonymousInnerClass2(this)
		   )).validate(this.GetType().getResourceAsStream("/selfsigned.cer"));
		}

		private class ErrorHandlerAnonymousInnerClass : ErrorHandler
		{
			private readonly HandleErrorRuleTest outerInstance;

			public ErrorHandlerAnonymousInnerClass(HandleErrorRuleTest outerInstance)
			{
				this.outerInstance = outerInstance;
			}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void handle(CertificateValidationException e) throws FailedValidationException
			public void handle(CertificateValidationException e)
			{
				throw new FailedValidationException(e.Message, e);
			}
		}

		private class ValidatorRuleAnonymousInnerClass2 : ValidatorRule
		{
			private readonly HandleErrorRuleTest outerInstance;

			public ValidatorRuleAnonymousInnerClass2(HandleErrorRuleTest outerInstance)
			{
				this.outerInstance = outerInstance;
			}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void validate(java.security.cert.X509Certificate certificate) throws CertificateValidationException
			public void validate(X509Certificate certificate)
			{
				throw new CertificateValidationException("Test");
			}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public Report validate(java.security.cert.X509Certificate certificate, Report report) throws CertificateValidationException
			public Report validate(X509Certificate certificate, Report report)
			{
				throw new CertificateValidationException("Test");
			}
		}
	}

}