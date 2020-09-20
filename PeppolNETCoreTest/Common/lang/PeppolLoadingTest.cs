using System;


namespace VertSoft.Peppol.Common.Lang
{

	public class PeppolLoadingTest
	{
		public virtual void simpleConstructors()
		{
			new PeppolLoadingException("Message");
			new PeppolLoadingException("Message", new Exception("dummy1"));
		}
	}
}