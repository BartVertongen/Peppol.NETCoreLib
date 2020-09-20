using System;


namespace VertSoft.Peppol.Security.Lang
{
	public class PeppolSecurityExceptionTest
	{
		public virtual void simple()
		{
			Exception ex1 = new PeppolSecurityException("Test");
			Exception ex2 = new PeppolSecurityException("Test2", ex1);
		}
	}
}