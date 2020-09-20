
using System.Diagnostics;
using VertSoft.Peppol.Common.Model;
using VertSoft.Peppol.Lookup.Api;


namespace VertSoft.Peppol.Lookup.Locator
{
	public class StaticLocatorTest
	{
        //ORIGINAL LINE: @Test public void simple() throws Exception
		public virtual void simple()
		{
			string uri = "http://smp-test.belgium.be/";

			IMetadataLocator locator = (IMetadataLocator)new StaticLocator(uri);

			Debug.Assert(locator.Lookup(ParticipantIdentifier.of("9956:0712405810")).ToString() == uri);
		}
	}
}