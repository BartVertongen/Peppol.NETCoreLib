
using System;
using VertSoft.Peppol.Common.Lang;


namespace VertSoft.Peppol.Security.Lang
{	
	public class PeppolSecurityException : PeppolException
	{
		public PeppolSecurityException(string message) : base(message)
		{
		}

		public PeppolSecurityException(string message, Exception cause) : base(message, cause)
		{
		}
	}
}