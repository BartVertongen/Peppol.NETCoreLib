
using System.Diagnostics;


namespace VertSoft.Peppol.Common.Model
{

	public class InstanceIdentifierTest
	{

		public virtual void simple()
		{
			Debug.Assert(InstanceIdentifier.generateUUID().Identifier != null);

			InstanceIdentifier identifier = InstanceIdentifier.of("TEST");

            Debug.Assert(identifier.Identifier == "TEST");
            Debug.Assert(identifier.ToString() == "TEST");

            Debug.Assert(identifier.Equals(identifier));
            Debug.Assert(!identifier.Equals("TEST"));
            Debug.Assert(!identifier.Equals(null));
		}
	}
}