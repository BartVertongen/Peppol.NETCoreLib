
using System;


namespace VertSoft.Peppol.Evidence.Lang
{
	public class RemEvidenceExceptionTest
	{

		public virtual void simple()
		{
			new RemEvidenceException("Text...");
			new RemEvidenceException("Text...", new Exception());
		}
	}
}