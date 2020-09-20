using System;


namespace VertSoft.Peppol.Publisher.Lang
{
	public class SigningException : PublisherException
	{

		public SigningException(string message, Exception cause) : base(message, cause)
		{
		}
	}
}