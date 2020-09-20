
using System;

namespace VertSoft.Peppol.Common.Lang
{
	public class PeppolExceptionTest
	{
		public virtual void simpleConstructors()
		{
			new PeppolException("Message");
			new PeppolException("Message", new Exception("dummy1"));
			new PeppolException(new Exception("dummy2"));
		}
	}
}