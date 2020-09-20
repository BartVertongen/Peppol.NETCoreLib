using System;

namespace VertSoft.Peppol.Common.Lang
{
	public class PeppolParsingExceptionTest
	{
		public virtual void simpleConstructors()
		{
			new PeppolParsingException("Message");
			new PeppolParsingException("Message", new Exception("innerdummy"));
		}
	}
}