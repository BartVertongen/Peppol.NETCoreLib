
using System;
using VertSoft.Peppol.Common.Lang;


namespace VertSoft.Peppol.Lookup.Api
{
	public class LookupException : PeppolException
	{
		public LookupException(string message) : base(message)
		{
		}

		public LookupException(string message, Exception cause) : base(message, cause)
		{
		}
	}
}