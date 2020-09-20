using System;


namespace VertSoft.Peppol.Common.Lang
{

	public class PeppolRuntimeExceptionTest
	{
		public virtual void simpleConstructors()
		{
			new PeppolRuntimeException("Message", new Exception("innerdummy"));
		}
	}
}