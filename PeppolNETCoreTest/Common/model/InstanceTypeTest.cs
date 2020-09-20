
using System.Diagnostics;


namespace VertSoft.Peppol.Common.Model
{
	public class InstanceTypeTest
	{
		public virtual void simple()
		{
			InstanceType instanceType = InstanceType.of("urn:oasis:names:specification:ubl:schema:xsd:Invoice-2", "Invoice", "2.0");

			Debug.Assert(instanceType.Standard == "urn:oasis:names:specification:ubl:schema:xsd:Invoice-2");
            Debug.Assert(instanceType.Type == "Invoice");
            Debug.Assert(instanceType.Version == "2.0");

            Debug.Assert(instanceType.Equals(instanceType));
            Debug.Assert(!instanceType.Equals("Invoice"));
            Debug.Assert(!instanceType.Equals(null));

            Debug.Assert(!instanceType.Equals(InstanceType.of("urn:oasis:names:specification:ubl:schema:xsd:Invoice-3", "Invoice", "2.0")));
            Debug.Assert(!instanceType.Equals(InstanceType.of("urn:oasis:names:specification:ubl:schema:xsd:Invoice-2", "CreditNote", "2.0")));
            Debug.Assert(!instanceType.Equals(InstanceType.of("urn:oasis:names:specification:ubl:schema:xsd:Invoice-2", "Invoice", "3.0")));
		}
	}
}