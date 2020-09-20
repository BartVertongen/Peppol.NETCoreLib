
using System.Diagnostics;
using VertSoft.Peppol.Common.Lang;
using VertSoft.Peppol.Common.Model.Lang;


namespace VertSoft.Peppol.Common.Model
{
	

	public class ProcessIdentifierTest
	{

		public virtual void simple()
		{
			ProcessIdentifier process04 = ProcessIdentifier.of("urn:www.cenbii.eu:profile:bii04:ver1.0", ProcessIdentifier.DEFAULT_SCHEME);
			ProcessIdentifier process05 = ProcessIdentifier.of("urn:www.cenbii.eu:profile:bii05:ver1.0");

			Debug.Assert(process04.Equals(process04));
            Debug.Assert(!process04.Equals(process04.Identifier));
            Debug.Assert(!process04.Equals(null));

            Debug.Assert(!process04.Equals(process05));
            Debug.Assert(process04.Scheme.Equals(process05.Scheme));
		}


        //ORIGINAL LINE: @Test public void simpleParse() throws Exception
		public virtual void simpleParse()
		{
			ProcessIdentifier processIdentifier = ProcessIdentifier.parse("qualifier::identifier");

            Debug.Assert(processIdentifier.Identifier == "identifier");
            Debug.Assert(processIdentifier.Scheme.Identifier == "qualifier");

			try
			{
				ProcessIdentifier.parse("value"); //this should go wrong
                Debug.Assert(false);
			}
			catch (PeppolParsingException)
			{
				// Valid!
			}
		}
	}
}