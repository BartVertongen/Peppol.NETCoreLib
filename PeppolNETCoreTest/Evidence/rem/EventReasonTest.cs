
using System.Diagnostics;


namespace VertSoft.Peppol.Evidence.Rem
{
	public class EventReasonTest
	{

        //ORIGINAL LINE: @Test public void testValueForCode() throws Exception
		public virtual void testValueForCode()
		{
			string code = EventReason.INVALID_USER_SIGNATURE.Code;
			EventReason eventReason = EventReason.valueForCode(code);
			Debug.Assert(EventReason.INVALID_USER_SIGNATURE == eventReason);
		}

		public virtual void testValueOf()
		{
            Debug.Assert(EventReason.OTHER == EventReason.valueOf("OTHER"));
		}

		public virtual void valueForCodeException()
		{
			EventReason.valueForCode("Test...");
		}
	}
}