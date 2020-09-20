//By Bart Louis Robert Vertongen 2020 August

using System.Diagnostics;
using VertSoft.Peppol.Common.Lang;


namespace VertSoft.Peppol.Common.Model
{

	public class TransportProtocolTest
	{
        //ORIGINAL LINE: @Test public void simple() throws no.difi.vefa.peppol.common.lang.PeppolException
		public virtual void simple()
		{
			Debug.Assert(TransportProtocol.AS2.Equals(TransportProtocol.of(TransportProtocol.AS2.Identifier)));

            Debug.Assert(throwsException("As2"));
            Debug.Assert(throwsException("as2"));
            Debug.Assert(throwsException("as-2"));
            Debug.Assert(throwsException("AS2 "));
            Debug.Assert(throwsException("AS2-PEPPOL"));
            Debug.Assert(throwsException("AS2_1"));

            Debug.Assert(!throwsException(TransportProtocol.AS2.Identifier));
            Debug.Assert(!throwsException(TransportProtocol.AS4.Identifier));
            Debug.Assert(!throwsException(TransportProtocol.INTERNAL.Identifier));
            Debug.Assert(!throwsException("FUTURE"));

            Debug.Assert(TransportProtocol.AS2.ToString() != null);
            Debug.Assert(TransportProtocol.AS2.GetHashCode() != null);  //This is always true

            Debug.Assert(TransportProtocol.AS2.Equals(TransportProtocol.AS2));
            Debug.Assert(!TransportProtocol.AS2.Equals(TransportProfile.AS2_1_0));
            Debug.Assert(!TransportProtocol.AS2.Equals(null));
		}

		private bool throwsException(string identifier)
		{
			try
			{
				TransportProtocol.of(identifier);
				return false;
			}
			catch (PeppolException)
			{
				return true;
			}
		}
	}
}