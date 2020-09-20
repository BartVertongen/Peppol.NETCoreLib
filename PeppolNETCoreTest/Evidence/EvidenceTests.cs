
using System;
using VertSoft.Peppol.Evidence.Rem;


namespace VertSoft.Peppol.Evidence
{
	public static class EvidenceTests
	{
		static public void RunAll()
		{
			EvidenceTests.Run_EventCodeTest();
			EvidenceTests.Run_EventReasonTest();
		}

		static private void Run_EventCodeTest()
		{
			EventCodeTest TestEventCode = new EventCodeTest();
			TestEventCode.testValueFor();
			TestEventCode.testValueOf();
			TestEventCode.valueForException();
			Console.WriteLine("Passed EventCodeTest");
		}

		static private void Run_EventReasonTest()
		{
			EventReasonTest TestEventReason = new EventReasonTest();
			TestEventReason.testValueForCode();
			TestEventReason.testValueOf();
			TestEventReason.valueForCodeException();
			Console.WriteLine("Passed EventReasonTest");
		}
	}
}
