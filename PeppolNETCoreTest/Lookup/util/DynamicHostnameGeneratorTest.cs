
using VertSoft.Peppol.Common.Model;
using System.Diagnostics;
using System;


namespace VertSoft.Peppol.Lookup.Util
{
	public class DynamicHostnameGeneratorTest
	{
        //throws LookupException
		public virtual void simpleMd5()
		{
			DynamicHostnameGenerator generator = new DynamicHostnameGenerator("B-", "edelivery.tech.ec.europa.eu", "MD5");

			Debug.Assert(generator.Generate(ParticipantIdentifier.of("9908:difi")) == "B-42fabff13df16391dbd1f01b7c05d0e7.iso6523-actorid-upis." + "edelivery.tech.ec.europa.eu");
			Debug.Assert(generator.Generate(ParticipantIdentifier.of("9908:DIFI")) == "B-42fabff13df16391dbd1f01b7c05d0e7.iso6523-actorid-upis." + "edelivery.tech.ec.europa.eu");
			string strTest = generator.Generate(ParticipantIdentifier.of("9956:0712405810"));
		}

        //throws no.difi.vefa.peppol.lookup.api.LookupException
		public virtual void simpleSHA224()
		{
			DynamicHostnameGenerator generator = new DynamicHostnameGenerator("B-", "acc.edelivery.tech.ec.europa.eu", "SHA-224");

            string strHash = generator.Generate(ParticipantIdentifier.of("0088:5798000000001"));
            Debug.Assert(strHash == ("B-fc932ca4494194a43ebb039cefe51a6c1d8c771afd2039bfb7f76e7f.iso6523-actorid-upis." + "acc.edelivery.tech.ec.europa.eu"));
		}


		public virtual void triggerException()
		{
            try
            {
                (new DynamicHostnameGenerator("B-", "acc.edelivery.tech.ec.europa.eu", "SHA-224")).Generate(null);
            }
			catch (Exception ex)
            {
                ; //valid
            }
		}
	}
}