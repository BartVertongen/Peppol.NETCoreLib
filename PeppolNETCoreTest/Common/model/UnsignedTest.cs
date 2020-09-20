
using System.Diagnostics;


namespace VertSoft.Peppol.Common.Model
{
	public class UnsignedTest
	{

		public virtual void simple()
		{
			Debug.Assert(Unsigned<string>.of("1").Content == "1");

            Debug.Assert(Unsigned<string>.of("1").Equals(Unsigned<string>.of("1")));
            Debug.Assert(!Unsigned<string>.of("1").Equals(Unsigned<string>.of("2")));
            Debug.Assert(!Unsigned<string>.of("1").Equals("1"));
            Debug.Assert(!Unsigned<string>.of("1").Equals(null));

			Unsigned<string> unsigned = Unsigned<string>.of("1");
            Debug.Assert(unsigned.Equals(unsigned));

			Unsigned<string> unsignedSubset = (Unsigned<string>)unsigned.ofSubset(unsigned.Content);
            Debug.Assert(unsigned.Equals(unsignedSubset));

            Debug.Assert(Unsigned<string>.of("1").GetHashCode() != null);

            Debug.Assert(Unsigned<string>.of("TEST").ToString().Contains("TEST"));
		}
	}
}