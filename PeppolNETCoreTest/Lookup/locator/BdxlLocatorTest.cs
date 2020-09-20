
using ParticipantIdentifier = no.difi.vefa.peppol.common.model.ParticipantIdentifier;
using MetadataLocator = no.difi.vefa.peppol.lookup.api.MetadataLocator;
using System;
using System.Diagnostics;


namespace no.difi.vefa.peppol.lookup.locator
{

    //Look for this in SMP documentation!!
    //http://test-smp.difi.no.publisher.acc.edelivery.tech.ec.europa.eu
    //https://serviceprovider.peppol.eu/
    //documentation about this at https://ec.europa.eu/cefdigital/wiki/display/CEFDIGITAL/eDelivery+BDXL+1.6
    //busdoxLocator is the normal way with SML
    //BdxlLocator works with BDXL providers and uses U_NAPTR records

    public class BdxlLocatorTest
	{
        //ORIGINAL LINE: @Test public void simple() throws Exception
		public virtual void simple()
		{
			MetadataLocator locator = new BdxlLocator(/*mode test*/);
			Debug.Assert(locator.Lookup(ParticipantIdentifier.of("9908:810418052")) == new Uri("http://test-smp.difi.no/"));
		}


        //ORIGINAL LINE: @Test public void testRegexHandler()
		public virtual void testRegexHandler()
		{
			// BDXL Specification (modified)
			Debug.Assert(BdxlLocator.handleRegex("!^B-([0-9a-fA-F]+).sid.peppol.eu$!https://serviceprovider.peppol.eu/\\\\x0001!", "B-eacf0eecc06f3fe1cff9e0e674201d99fc73affaf5aa6eccd3a30565.sid.peppol.eu") == "https://serviceprovider.peppol.eu/eacf0eecc06f3fe1cff9e0e674201d99fc73affaf5aa6eccd3a30565");

			// Proper
			Debug.Assert(BdxlLocator.handleRegex("!^.*$!http://test-smp.difi.no.publisher.acc.edelivery.tech.ec.europa.eu!", "B-eacf0eecc06f3fe1cff9e0e674201d99fc73affaf5aa6eccd3a30565.iso6523-actorid-upis." + "acc.edelivery.tech.ec.europa.eu") == "http://test-smp.difi.no.publisher.acc.edelivery.tech.ec.europa.eu");
		}
	}
}