
using VertSoft.Peppol.Common.Model;
using VertSoft.Peppol.Lookup.Util;
using System;
using System.Net;


namespace VertSoft.Peppol.Lookup.Locator
{
    /// <summary>
    /// BUSDOX SML -- Service Metadata discovery interface.
    /// </summary>
    public class BusdoxLocator : AbstractLocator
	{
        //Configuration
        private readonly string busdox_prefix = "B-";
        //Hostname of the SML
        private readonly string hostname_test = "acc.edelivery.tech.ec.europa.eu";
        private readonly string hostname_prod = "edelivery.tech.ec.europa.eu";
        private readonly string busdox_algorithm = "MD5";

        private DynamicHostnameGenerator hostnameGenerator;

		public BusdoxLocator(enMode mode = enMode.Test, string prefix= "B-", string algorithm= "MD5")
		{
            string hostname;

            hostname = (mode == enMode.Test ? hostname_test : hostname_prod);
            hostnameGenerator = new DynamicHostnameGenerator(prefix, hostname, algorithm);
		}

		public override Uri Lookup(ParticipantIdentifier participantIdentifier)
		{
			// Create hostname for participant identifier.
			string hostname = hostnameGenerator.Generate(participantIdentifier);

            //When we convert the string to an Uri, then "B-" becomes "b-" !
			return new Uri(string.Format("http://{0}", hostname));
		}

        public Uri LookupSMPName(ParticipantIdentifier participantIdentifier)
        {
            // Create hostname for participant identifier.
            string hostname = hostnameGenerator.Generate(participantIdentifier);
            IPHostEntry HostEntry = Dns.GetHostEntry(hostname);

            //When we convert the string to an Uri, then "B-" becomes "b-" !
            return new Uri(string.Format("http://{0}", HostEntry.HostName));
        }


        public IPAddress LookupSMPIP(ParticipantIdentifier participantIdentifier)
        {
            // Create hostname for participant identifier.
            string hostname = hostnameGenerator.Generate(participantIdentifier);
            IPHostEntry HostEntry = Dns.GetHostEntry(hostname);

            return HostEntry.AddressList[0];
        }
    }
}