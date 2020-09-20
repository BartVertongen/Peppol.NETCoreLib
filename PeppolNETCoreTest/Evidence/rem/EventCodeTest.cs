
using System.Diagnostics;


namespace VertSoft.Peppol.Evidence.Rem
{

	public class EventCodeTest
	{

        //ORIGINAL LINE: @Test public void testValueFor() throws Exception
		public virtual void testValueFor()
		{
			string value = EventCode.DELIVERY_EXPIRATION.Value;

			EventCode eventCode = EventCode.valueFor(value);
            Debug.Assert(eventCode == EventCode.DELIVERY_EXPIRATION);
		}

		public virtual void testValueOf()
		{
			Debug.Assert(EventCode.valueOf("ACCEPTANCE") == EventCode.ACCEPTANCE);
		}


        //ORIGINAL LINE: @Test(expectedExceptions = IllegalArgumentException.class) public void valueForException()
		public virtual void valueForException()
		{
			EventCode.valueFor("Test...");
		}
	}
}