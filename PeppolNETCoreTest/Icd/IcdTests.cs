
using System;
using System.Collections.Generic;
using System.Text;
using VertSoft.Peppol.Icd.Code;

namespace VertSoft.Peppol.Icd
{
	static public class IcdTests
	{
		static public void RunAll()
		{
			IcdTests.Run_PeppolIcdTest();
			IcdTests.Run_IcdsTest();
		}

		static private void Run_PeppolIcdTest()
		{
			PeppolIcdTest TestPeppolIcd = new PeppolIcdTest();
			TestPeppolIcd.simple();
			TestPeppolIcd.exceptionOnUnknownCode();
			Console.WriteLine("Passed PeppolIcdTest");
		}

		static private void Run_IcdsTest()
		{
			IcdsTest TestIcds = new IcdsTest();
			TestIcds.simple();
			TestIcds.simpleGetCode();
			TestIcds.simpleGetCodeException();
			TestIcds.simpleUseOfGeneric();
			TestIcds.triggerExceptionInCode();
			TestIcds.triggerExceptionOnIdentifier();
			Console.WriteLine("IcdsTest");
		}
	}          
}