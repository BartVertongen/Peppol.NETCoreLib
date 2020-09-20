
using System;
using System.Net;
//using BaseEncoding = com.google.common.io.BaseEncoding;
using ParticipantIdentifier = no.difi.vefa.peppol.common.model.ParticipantIdentifier;
using LookupException = no.difi.vefa.peppol.lookup.api.LookupException;
using DynamicHostnameGenerator = no.difi.vefa.peppol.lookup.util.DynamicHostnameGenerator;
//using EncodingUtils = no.difi.vefa.peppol.lookup.util.EncodingUtils;
//using Mode = no.difi.vefa.peppol.mode.Mode;
//using org.xbill.DNS;
//using java.net;


namespace no.difi.vefa.peppol.lookup.locator
{
    /// <summary>
    /// Implementation of Business Document Metadata Service Location Version 1.0.
    /// </summary>
    /// <seealso cref= <a href="http://docs.oasis-open.org/bdxr/BDX-Location/v1.0/BDX-Location-v1.0.html">Specification</a> </seealso>
    /// <remarks>you need knowledge about DNS for this</remarks>
    public class BdxlLocator : AbstractLocator
	{

        private readonly string bdxl_prefix = "B-";// "" or "B-"?
        //Hostname of the SML
        private readonly string hostname_test = "acc.edelivery.tech.ec.europa.eu";
        private readonly string hostname_prod = "edelivery.tech.ec.europa.eu";
        private readonly string bdxl_algorithm = "SHA-256";
        private DynamicHostnameGenerator hostnameGenerator;



		/// <summary>
		/// Initiate a new instance of BDXL lookup functionality.
		/// </summary>
		/// <param name="prefix">          Value attached in front of calculated hash. </param>
		/// <param name="hostname">        Hostname used as base for lookup. </param>
		/// <param name="digestAlgorithm"> Algorithm used for generation of hostname. </param>
		/// <param name="encoding">        Encoding of hash for hostname. </param>
		public BdxlLocator(enMode mode = enMode.Test, string prefix ="", string digestAlgorithm = "SHA256")
		{
            string hostname;

            hostname = (mode == enMode.Test ? hostname_test : hostname_prod);
            hostnameGenerator = new DynamicHostnameGenerator(prefix, hostname, digestAlgorithm/*, encoding*/);
		}


        //ORIGINAL LINE: @Override public URI lookup(ParticipantIdentifier participantIdentifier) throws LookupException
		public override Uri Lookup(ParticipantIdentifier participantIdentifier)
		{
			// Create hostname for participant identifier.
			string hostname = hostnameGenerator.Generate(participantIdentifier).ReplaceAll("=*", "");

			try
			{
				// Fetch all records of type NAPTR registered on hostname.
				Record[] records = (new Lookup(hostname, Type.NAPTR)).run();
				if (records == null)
				{
					throw new LookupException(string.Format("Identifier '{0}' is not registered in SML.", participantIdentifier.ToString()));
				}

				// Loop records found.
				foreach (Record record in records)
				{
					// Simple cast.
					NAPTRRecord naptrRecord = (NAPTRRecord) record;

					// Handle only those having "Meta:SMP" as service.
					if ("Meta:SMP".Equals(naptrRecord.Service) && "U".Equals(naptrRecord.Flags, StringComparison.OrdinalIgnoreCase))
					{

						// Create URI and return.
						string result = handleRegex(naptrRecord.Regexp, hostname);
						if (!string.ReferenceEquals(result, null))
						{
							return new Uri(result);
						}
					}
				}
			}
			catch (/*TextParse*/Exception e)
			{
				throw new LookupException("Error when handling DNS lookup for BDXL.", e);
			}

			throw new LookupException("Record for SMP not found in SML.");
		}

		public static string handleRegex(string naptrRegex, string hostname)
		{
			string[] regexp = naptrRegex.Split("!", true);

			// Simple stupid
			if ("^.*$".Equals(regexp[1]))
			{
				return regexp[2];
			}

			// Using regex
			Pattern pattern = Pattern.compile(regexp[1]);
			Matcher matcher = pattern.matcher(hostname);
			if (matcher.matches())
			{
				return matcher.replaceAll(regexp[2].replaceAll("\\\\{2}", "\\$"));
			}
			// No match
			return null;
		}
	}
}