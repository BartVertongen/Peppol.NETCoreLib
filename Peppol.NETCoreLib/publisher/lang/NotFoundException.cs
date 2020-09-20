using System;


namespace VertSoft.Peppol.Publisher.Lang
{
	public class NotFoundException : PublisherException
	{

		public NotFoundException(string message) : base(message)
		{
		}

		public NotFoundException(string message, Exception cause) : base(message, cause)
		{
		}
	}

}