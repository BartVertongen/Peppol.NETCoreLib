
using System.Diagnostics;


namespace VertSoft.Peppol.Common.Model
{
	public class SchemeTest
	{
		public virtual void simple()
		{
			Scheme schema = Scheme.of("SCHEME");
			Debug.Assert(schema.Identifier == "SCHEME");
			Debug.Assert(schema.ToString() == "SCHEME");
            //Debug.Assert(schema.GetHashCode() != null); always true

            //Debug.Assert(schema.Equals(schema)); evidently
            //Debug.Assert(schema != "SCHEME"); different types
            Debug.Assert(schema != null);
		}
	}
}