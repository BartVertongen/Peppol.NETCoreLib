
using System;
using System.Diagnostics;
using VertSoft.Peppol.Common.Model;


namespace VertSoft.Peppol.Lookup.Locator
{

	public class BusdoxLocatorTest
	{
		private BusdoxLocator busdoxLocator = new BusdoxLocator(BusdoxLocator.enMode.Test);

		public virtual void simple()
		{
            //The uri object changes prefix 'B-' to 'b-'
            Debug.Assert(busdoxLocator.Lookup("9908:991825827").Host == "b-770c6f5843e9e302de47ae4026307076.iso6523-actorid-upis.edelivery.tech.ec.europa.eu");

            Console.WriteLine("The SMP Name for this Participant is {0}", busdoxLocator.LookupSMPName(ParticipantIdentifier.of("9908:991825827")).Host);
            Console.WriteLine("The SMP IP for this Participant is {0}", busdoxLocator.LookupSMPIP(ParticipantIdentifier.of("9908:991825827")).ToString());
			Console.WriteLine("The SMP Name for this Participant is {0}", busdoxLocator.LookupSMPName(ParticipantIdentifier.of("9956:0712405810")).Host);
		}
	}
}