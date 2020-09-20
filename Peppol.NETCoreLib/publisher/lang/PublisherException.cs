
using System;


namespace VertSoft.Peppol.Publisher.Lang
{
	public abstract class PublisherException : Exception
	{

		public PublisherException(string message) : base(message)
		{
		}

		public PublisherException(string message, Exception cause) : base(message, cause)
		{
		}
	}
}