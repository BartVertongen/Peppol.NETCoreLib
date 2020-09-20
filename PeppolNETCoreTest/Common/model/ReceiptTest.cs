
using System.Diagnostics;
using System.Linq;
using System.Text;


namespace VertSoft.Peppol.Common.Model
{
	public class ReceiptTest
	{

		public virtual void simple()
		{
			Receipt r1 = Receipt.of(Encoding.Unicode.GetBytes("Value"));
			Receipt r2 = Receipt.of("text/plain", Encoding.Unicode.GetBytes("Value"));

			Debug.Assert(r1.Value.SequenceEqual(Encoding.Unicode.GetBytes("Value")));
            Debug.Assert(r1.Type == null);
            Debug.Assert(r2.Type == "text/plain");

            Debug.Assert(r1.Equals(r1));
            Debug.Assert(!r1.Equals(null));
            Debug.Assert(!r1.Equals("Test"));
            Debug.Assert(r1.Equals(Receipt.of(Encoding.Unicode.GetBytes("Value"))));
            Debug.Assert(r2.Equals(Receipt.of("text/plain", Encoding.Unicode.GetBytes("Value"))));
            Debug.Assert(!r1.Equals(r2));
            Debug.Assert(!r2.Equals(r1));

            Debug.Assert(r1.GetHashCode() != null);
            Debug.Assert(r2.GetHashCode() != null);

            Debug.Assert(r2.ToString().Contains("text/plain"));
		}
	}
}