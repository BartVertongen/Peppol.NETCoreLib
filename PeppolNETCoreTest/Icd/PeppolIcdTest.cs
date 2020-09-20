
using System.Diagnostics;
using System.Linq;


namespace VertSoft.Peppol.Icd.Code
{
	public class PeppolIcdTest
	{
		public virtual void simple()
		{
			Debug.Assert(PeppolIcd.PeppolIcdList.First(Icd => Icd.Identifier == "NO:ORGNR").Identifier == "NO:ORGNR");
			Debug.Assert(PeppolIcd.PeppolIcdList.First(Icd => Icd.Identifier == "NO:ORGNR").Code == "9908");

			Debug.Assert(PeppolIcd.PeppolIcdList.First(Icd => Icd.Identifier == "NO:ORGNR") != null);
			Debug.Assert(PeppolIcd.PeppolIcdList.First(Icd => Icd.Identifier == "NO:ORGNR").Scheme != null);

			Debug.Assert(PeppolIcd.PeppolIcdList.First(Icd => Icd.Code == "9908").Identifier == "NO:ORGNR");
		}

        //@Test(expectedExceptions = IllegalArgumentException.class)
		public virtual void exceptionOnUnknownCode()
		{
			if (PeppolIcd.PeppolIcdList.First(Icd => Icd.Code == "invalid") == null)
			{
				throw new System.Exception("This can not happen!");
			}
		}
	}
}