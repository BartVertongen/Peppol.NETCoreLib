using System;


namespace VertSoft.Peppol.Evidence.Lang
{

	public class RemEvidenceException : PeppolEvidenceException
	{

		public RemEvidenceException(string message) : base(message)
		{
		}

		public RemEvidenceException(string message, Exception ex) : base(message, ex)
		{
		}
	}
}