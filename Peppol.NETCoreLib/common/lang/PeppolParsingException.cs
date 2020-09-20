using System;


namespace VertSoft.Peppol.Common.Lang
{
	/// <summary>
	/// @author erlend
	/// </summary>
	public class PeppolParsingException : PeppolException
	{

		public PeppolParsingException(string message) : base(message)
		{
		}

		public PeppolParsingException(string message, Exception cause) : base(message, cause)
		{
		}
	}
}