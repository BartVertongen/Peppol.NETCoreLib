using System;


namespace VertSoft.Peppol.Common.Lang
{
	public class PeppolRuntimeException : Exception
	{
		public PeppolRuntimeException(string message, Exception cause) : base(message, cause)
		{
		}
	}
}