namespace no.difi.certvalidator.rule
{
    using System.Security.Cryptography.X509Certificates;
    using CertificateValidationException = no.difi.certvalidator.api.CertificateValidationException;
	using FailedValidationException = no.difi.certvalidator.api.FailedValidationException;

	/// <summary>
	/// Throws an exception on validation if message is set.
	/// </summary>
	public class DummyRule : AbstractRule
	{

		public static DummyRule alwaysSuccess()
		{
			return new DummyRule();
		}

		public static DummyRule alwaysFail(string message)
		{
			return new DummyRule(message);
		}

		private string message;

		/// <summary>
		/// Defines an instance always having successful validations.
		/// </summary>
		public DummyRule() : this(null)
		{
		}

		/// <summary>
		/// Defines as instance always having failing validations, given message is not null. </summary>
		/// <param name="message"> Message used when failing validation. </param>
		public DummyRule(string message)
		{
			this.message = message;
		}


        //ORIGINAL LINE: public void validate(X509Certificate certificate) throws CertificateValidationException
		public override void validate(X509Certificate2 certificate)
		{
			if (!string.ReferenceEquals(message, null))
			{
				throw new FailedValidationException(message);
			}
		}
	}
}