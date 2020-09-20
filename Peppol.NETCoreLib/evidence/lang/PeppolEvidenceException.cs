using System;
using VertSoft.Peppol.Common.Lang;


namespace VertSoft.Peppol.Evidence.Lang
{

	public class PeppolEvidenceException : PeppolException
	{

		public PeppolEvidenceException(string message) : base(message)
		{
		}

		public PeppolEvidenceException(string message, Exception cause) : base(message, cause)
		{
		}
	}
}