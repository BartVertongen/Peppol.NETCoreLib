
using System.Diagnostics;


namespace VertSoft.Peppol.Common.Model
{

	public class TransportProfileTest
	{

		public virtual void simple()
		{
			Debug.Assert(TransportProfile.AS2_1_0.ToString().Contains("as2"));
            Debug.Assert(TransportProfile.AS2_1_0.ToString().Contains(TransportProfile.AS2_1_0.Identifier));

            Debug.Assert(TransportProfile.AS2_1_0.Equals(TransportProfile.AS2_1_0));
            Debug.Assert(!TransportProfile.AS2_1_0.Equals(TransportProfile.AS4));
            Debug.Assert(!TransportProfile.AS2_1_0.Equals(TransportProtocol.AS2));
            Debug.Assert(!TransportProfile.AS2_1_0.Equals(null));

            Debug.Assert(TransportProfile.AS2_1_0.GetHashCode() != null); //This is always true
		}
	}
}