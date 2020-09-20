//By Bart Louis Robert Vertongen 2020 August

using System.Diagnostics;
using VertSoft.Peppol.Common.Model;
using VertSoft.Peppol.Icd.Api;
using VertSoft.Peppol.Icd.Code;
using VertSoft.Peppol.Icd.Model;


namespace VertSoft.Peppol.Icd
{

    public class IcdsTest
	{

		private static readonly IIcd ICD_TT_ORGNR = GenericIcd.of("TT:ORGNR", "9908", Scheme.of("iso6523-actorid-upis-test"));

		private static readonly IIcd ICD_TT_TEST = GenericIcd.of("TT:TEST", "9999", Scheme.of("iso6523-actorid-upis-test"));

		private Icds icds = Icds.of(PeppolIcd.PeppolIcdList);


        //ORIGINAL LINE: @Test public void simple() throws Exception
		public virtual void simple()
		{
			ParticipantIdentifier participantIdentifier = ParticipantIdentifier.of("9908:991825827");

			IcdIdentifier icdIdentifier = icds.Parse(participantIdentifier.ToString());

			Debug.Assert(icdIdentifier.Icd.Code == "NO:ORGNR");
            Debug.Assert(icdIdentifier.Identifier == "991825827");

            Debug.Assert(icdIdentifier.ToParticipantIdentifier() == participantIdentifier);
            Debug.Assert(icdIdentifier.ToString() == participantIdentifier.ToString());

            Debug.Assert(icds.Parse("NO:ORGNR", "991825827").ToParticipantIdentifier() == participantIdentifier);
		}


        //throws Exception
		public virtual void simpleUseOfGeneric()
		{
            Debug.Assert(icds.FindBySchemeAndCode(ICD_TT_ORGNR.Scheme, ICD_TT_ORGNR.Code) == ICD_TT_ORGNR);
		}


		//ORIGINAL LINE: @Test(expectedExceptions = PeppolParsingException) throws Exception
		public virtual void triggerExceptionInCode()
		{
			icds.Parse(ParticipantIdentifier.of("0000:123456789"));
		}


        //ORIGINAL LINE: @Test(expectedExceptions = PeppolParsingException.class)
		public virtual void triggerExceptionOnIdentifier()
		{
			icds.Parse("II:INVALID", "123456789");
		}


		public virtual void simpleGetCode()
		{
			Debug.Assert(icds.FindByCode("9908").Identifier == "NO:ORGNR");
		}


        //ORIGINAL LINE: @Test(expectedExceptions = IllegalArgumentException.class)
		public virtual void simpleGetCodeException()
		{
			icds.FindByCode("0000");
		}
	}
}