
using System;
using System.Diagnostics;
using VertSoft.Peppol.Common.Lang;


namespace VertSoft.Peppol.Common.Model
{
	public class ParticipantIdentifierTest
	{
		public virtual void simple()
		{
            Debug.Assert(ParticipantIdentifier.of("9908:991825827").ToString() == "iso6523-actorid-upis::9908:991825827");
            Debug.Assert(ParticipantIdentifier.of("9908:difi").ToString() == "iso6523-actorid-upis::9908:difi");
            Debug.Assert(ParticipantIdentifier.of(" 9908:DIFI ").ToString() == "iso6523-actorid-upis::9908:difi");
            Debug.Assert(ParticipantIdentifier.of("9908:991825827").ToString() == "iso6523-actorid-upis::9908:991825827");

            Debug.Assert( (ParticipantIdentifier.of("9908:991825827").Scheme).Equals(Scheme.of("iso6523-actorid-upis")) );
            /*Scheme lhs = ParticipantIdentifier.of("9908:991825827").Scheme;
            Scheme rhs = Scheme.of("iso6523-actorid-upis");
            if (lhs.Equals(rhs))
                Debug.Assert(true);
            else
                Debug.Assert(false);*/
            Debug.Assert(ParticipantIdentifier.Of("else", Scheme.of("something")).ToString() == "something::else");

            Debug.Assert(ParticipantIdentifier.of("9908:991825827").Identifier == "9908:991825827");
            Debug.Assert(ParticipantIdentifier.of("9908:991825827").UrlEncoded().Contains("991825827"));

			ParticipantIdentifier participantIdentifier = ParticipantIdentifier.of("9908:991825827");

            //Debug.Assert(participantIdentifier.Equals(participantIdentifier)); evidently
            //Debug.Assert(participantIdentifier != "9908:991825827"); //evidently other type
            Debug.Assert(participantIdentifier != null);

            Debug.Assert(participantIdentifier != ParticipantIdentifier.Of("9908:991825827", Scheme.of("Other")) );
		}


		public virtual void simpleParse()
		{
			ParticipantIdentifier participantIdentifier = ParticipantIdentifier.Parse("qualifier::identifier");

            Debug.Assert(participantIdentifier.Identifier == "identifier");
            Debug.Assert(participantIdentifier.Scheme.Identifier == "qualifier");

			try
			{
				ParticipantIdentifier.Parse("value");
				Debug.Assert(false);
			}
			catch (PeppolParsingException)
			{
                Debug.Assert(true);
            }
		}
	}
}