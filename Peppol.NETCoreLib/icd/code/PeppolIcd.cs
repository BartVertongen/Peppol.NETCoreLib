
using System;
using System.Linq;
using VertSoft.Peppol.Common.Model;
using VertSoft.Peppol.Icd.Api;


namespace VertSoft.Peppol.Icd.Code
{
	public sealed class PeppolIcd : GenericIcd
	{
		/// <summary>
		/// Scheme for PeppolIcds
		/// </summary>
		private static readonly Scheme SCHEME = Scheme.of("iso6523-actorid-upis");

		static public GenericIcd[] PeppolIcdList = {
			// Internationally approved ICDs
			GenericIcd.of("FR:SIRENE", "0002", PeppolIcd.SCHEME, "Institut National de la Statistique et des Etudes Economiques, (I.N.S.E.E.)"),
			GenericIcd.of("SE:ORGNR", "0007", PeppolIcd.SCHEME, "The National Tax Board"),
			GenericIcd.of("SE:ORGNR", "0009", PeppolIcd.SCHEME, "DU PONT DE NEMOURS"),
			GenericIcd.of("FI:OVT", "0037", PeppolIcd.SCHEME, "National Board of Taxes, (Verohallitus)"),
			GenericIcd.of("DUNS", "0060", PeppolIcd.SCHEME, "Dun and Bradstreet Ltd"),
			GenericIcd.of("GLN", "0088", PeppolIcd.SCHEME, "GS1 GLN"),
			GenericIcd.of("DK:P", "0096", PeppolIcd.SCHEME, "Danish Chamber of Commerce"),
			GenericIcd.of("IT:FTI", "0097", PeppolIcd.SCHEME, "FTI - Ediforum Italia"),
			GenericIcd.of("NL:KVK", "0106", PeppolIcd.SCHEME, "Vereniging van Kamers van Koophandel en Fabrieken in Nederland, Scheme"),
			GenericIcd.of("NAL", "0130", PeppolIcd.SCHEME, "Directorates of the European Commission"),
			GenericIcd.of("IT:SIA", "0135", PeppolIcd.SCHEME, "SIA-Società Interbancaria per l'Automazione S.p.A."),
			GenericIcd.of("IT:SECETI", "0142", PeppolIcd.SCHEME, "Servizi Centralizzati SECETI S.p.A."),
			GenericIcd.of("DIGST", "0184", PeppolIcd.SCHEME, "The Danish Agency for Digitisation"),
			GenericIcd.of("NL:OINO", "0190", PeppolIcd.SCHEME, "Logius"),
			GenericIcd.of("EE:CC", "0191", PeppolIcd.SCHEME, "Estonian Company Code"),
			GenericIcd.of("NO:ORG", "0192", PeppolIcd.SCHEME, "Enhetsregisteret ved Bronnøysundregisterne"),
			GenericIcd.of("UBLBE", "0193", PeppolIcd.SCHEME, "UBL.BE"),
			GenericIcd.of("SG:UEN", "0195", PeppolIcd.SCHEME, "Infocomm Media Development Authority"),
			GenericIcd.of("IS:KTNR", "0196", PeppolIcd.SCHEME, "Directorate of Internal Revenue"),
			// ICDs created and maintained by OpenPEPPOL
			GenericIcd.of("DK:CPR", "9901", PeppolIcd.SCHEME, "Danish Ministry of the Interior and Health"),
			GenericIcd.of("DK:CVR", "9902", PeppolIcd.SCHEME, "The Danish Commerce and Companies Agency"),
			GenericIcd.of("DK:SE", "9904", PeppolIcd.SCHEME, "Danish Ministry of Taxation, Central Customs and Tax Administration"),
			GenericIcd.of("DK:VANS", "9905", PeppolIcd.SCHEME, "Danish VANS providers"),
			GenericIcd.of("IT:VAT", "9906", PeppolIcd.SCHEME, "Ufficio responsabile gestione partite IVA"),
			GenericIcd.of("IT:CF", "9907", PeppolIcd.SCHEME, "TAX Authority"),
			GenericIcd.of("NO:ORGNR", "9908", PeppolIcd.SCHEME, "Enhetsregisteret ved Bronnøysundregisterne"),
			GenericIcd.of("HU:VAT", "9910", PeppolIcd.SCHEME, "Hungarian VAT number"),
			GenericIcd.of("EU:REID", "9913", PeppolIcd.SCHEME, "Business Registers Network"),
			GenericIcd.of("AT:VAT", "9914", PeppolIcd.SCHEME, "Österreichische Umsatzsteuer-Identifikationsnummer"),
			GenericIcd.of("AT:GOV", "9915", PeppolIcd.SCHEME, "Österreichisches Verwaltungs bzw. Organisationskennzeichen"),
			GenericIcd.of("IS:KT", "9917", PeppolIcd.SCHEME, "Icelandic National Registry"),
			GenericIcd.of("IBAN", "9918", PeppolIcd.SCHEME, "SOCIETY FOR WORLDWIDE INTERBANK FINANCIAL, TELECOMMUNICATION S.W.I.F.T"),
			GenericIcd.of("AT:KUR", "9919", PeppolIcd.SCHEME, "Kennziffer des Unternehmensregisters"),
			GenericIcd.of("ES:VAT", "9920", PeppolIcd.SCHEME, "Agencia Española de Administración Tributaria"),
			GenericIcd.of("IT:IPA", "9921", PeppolIcd.SCHEME, "Indice delle Pubbliche Amministrazioni"),
			GenericIcd.of("AD:VAT", "9922", PeppolIcd.SCHEME, "Andorra VAT number"),
			GenericIcd.of("AL:VAT", "9923", PeppolIcd.SCHEME, "Albania VAT number"),
			GenericIcd.of("BA:VAT", "9924", PeppolIcd.SCHEME, "Bosnia and Herzegovina VAT number"),
			GenericIcd.of("BE:VAT", "9925", PeppolIcd.SCHEME, "Belgium VAT number"),
			GenericIcd.of("BG:VAT", "9926", PeppolIcd.SCHEME, "Bulgaria VAT number"),
			GenericIcd.of("CH:VAT", "9927", PeppolIcd.SCHEME, "Switzerland VAT number"),
			GenericIcd.of("CY:VAT", "9928", PeppolIcd.SCHEME, "Cyprus VAT number"),
			GenericIcd.of("CZ:VAT", "9929", PeppolIcd.SCHEME, "Czech Republic VAT number"),
			GenericIcd.of("DE:VAT", "9930", PeppolIcd.SCHEME, "Germany VAT number"),
			GenericIcd.of("EE:VAT", "9931", PeppolIcd.SCHEME, "Estonia VAT number"),
			GenericIcd.of("GB:VAT", "9932", PeppolIcd.SCHEME, "United Kingdom VAT number"),
			GenericIcd.of("GR:VAT", "9933", PeppolIcd.SCHEME, "Greece VAT number"),
			GenericIcd.of("HR:VAT", "9934", PeppolIcd.SCHEME, "Croatia VAT number"),
			GenericIcd.of("IE:VAT", "9935", PeppolIcd.SCHEME, "Ireland VAT number"),
			GenericIcd.of("LI:VAT", "9936", PeppolIcd.SCHEME, "Liechtenstein VAT number"),
			GenericIcd.of("LT:VAT", "9937", PeppolIcd.SCHEME, "Lithuania VAT number"),
			GenericIcd.of("LU:VAT", "9938", PeppolIcd.SCHEME, "Luxemburg VAT number"),
			GenericIcd.of("LV:VAT", "9939", PeppolIcd.SCHEME, "Latvia VAT number"),
			GenericIcd.of("MC:VAT", "9940", PeppolIcd.SCHEME, "Monaco VAT number"),
			GenericIcd.of("ME:VAT", "9941", PeppolIcd.SCHEME, "Montenegro VAT number"),
			GenericIcd.of("MK:VAT", "9942", PeppolIcd.SCHEME, "Macedonia, the former Yugoslav Republic of VAT number"),
			GenericIcd.of("MT:VAT", "9943", PeppolIcd.SCHEME, "Malta VAT number"),
			GenericIcd.of("NL:VAT", "9944", PeppolIcd.SCHEME, "Netherlands VAT number"),
			GenericIcd.of("PL:VAT", "9945", PeppolIcd.SCHEME, "Poland VAT number"),
			GenericIcd.of("PT:VAT", "9946", PeppolIcd.SCHEME, "Portugal VAT number"),
			GenericIcd.of("RO:VAT", "9947", PeppolIcd.SCHEME, "Romania VAT number"),
			GenericIcd.of("RS:VAT", "9948", PeppolIcd.SCHEME, "Serbia VAT number"),
			GenericIcd.of("SI:VAT", "9949", PeppolIcd.SCHEME, "Slovenia VAT number"),
			GenericIcd.of("SK:VAT", "9950", PeppolIcd.SCHEME, "Slovakia VAT number"),
			GenericIcd.of("SM:VAT", "9951", PeppolIcd.SCHEME, "San Marino VAT number"),
			GenericIcd.of("TR:VAT", "9952", PeppolIcd.SCHEME, "Turkey VAT number"),
			GenericIcd.of("VA:VAT", "9953", PeppolIcd.SCHEME, "Holy See (Vatican City State) VAT number"),
			GenericIcd.of("NL:OIN", "9954", PeppolIcd.SCHEME, "Dutch Originator's Identification Number"),
			GenericIcd.of("SE:VAT", "9955", PeppolIcd.SCHEME, "Swedish VAT number"),
			GenericIcd.of("BE:CBE", "9956", PeppolIcd.SCHEME, "Belgian Crossroad Bank of Enterprises"),
			GenericIcd.of("FR:VAT", "9957", PeppolIcd.SCHEME, "French VAT number"),
			GenericIcd.of("DE:LID", "9958", PeppolIcd.SCHEME, "German Leitweg ID")
		};


		/// <summary>
		/// Returns an Icd where the Identifier or code is equal to the id.
		/// Return null if nothing is found.
		/// </summary>
		/// <param name="id">The value for a SchemeId</param>
		static public GenericIcd FindPeppolIcd(string id)
		{
			GenericIcd objIcd = PeppolIcdList.Single(icd => icd.Identifier == id);
			if (objIcd == null)
			{
				objIcd = PeppolIcdList.Single(icd => icd.Code == id);	
			}
			return objIcd;
		}


		//static readonly List<PeppolIcd> ValueList = new List<PeppolIcd>();



		/*public readonly InnerEnum innerEnumValue;
		private readonly string nameValue;
		private readonly int ordinalValue;
		private static int nextOrdinal = 0;		

		private readonly string identifier;

		private readonly string code;

		private readonly string issuingAgency;*/

		/// <summary>
		/// An empty constructor is needed to construct a List of PeppolIcd
		/// </summary>
		/*private PeppolIcd()
        {
            this.identifier = "";
            this.code = "";
            this.issuingAgency = "";

            nameValue = "";
            ordinalValue = -1;
            innerEnumValue = 0;
        }*/

		/// <summary>
		/// A PeppolIcd is a GenericIcd with a fixed Schema and an extra Name and number for the Icd.
		/// </summary>
		/// <param name="name">Name for the PeppolIcd</param>
		/// <param name="innerEnum">Number corresponding with the Name of the PeppolIcd</param>
		/// <param name="identifier"></param>
		/// <param name="code"></param>
		/// <param name="issuingAgency"></param>
		/*private PeppolIcd(string name, InnerEnum innerEnum, string identifier=null, string code=null, string issuingAgency=null)
		{
			this.identifier = identifier;
			this.code = code;
			this.issuingAgency = issuingAgency;

			nameValue = name;
			ordinalValue = nextOrdinal++;
			innerEnumValue = innerEnum;
		}*/


		/*static public List<PeppolIcd> Values
        {
            get
            {
                if (PeppolIcd.ValueList.Count == 0)
                    PeppolIcd.FillValueList();
                return PeppolIcd.ValueList;
            }
        }*/
		/*public static Icd findByCode(string code)
		{
            Icd Result = Values.Find(v => v.code.Equals(code));
            if (Result == null)
                throw new ArgumentException(string.Format("Value '{0}' is not valid ICD.", code));
            return Result;
		}*/

		/*public static Icd findByIdentifier(string icd)
		{
			foreach (PeppolIcd v in Values)
			{
				if (v.identifier.Equals(icd))
				{
					return v;
				}
			}

			throw new System.ArgumentException(string.Format("Identifier '{0}' is not valid ICD.", icd));
		}*/

		/*public int ordinal()
		{
			return ordinalValue;
		}*/


		/*public static PeppolIcd valueOf(string name)
		{
			foreach (PeppolIcd enumInstance in PeppolIcd.ValueList)
			{
				if (enumInstance.nameValue == name)
				{
					return enumInstance;
				}
			}
			throw new System.ArgumentException(name);
		}*/
	}
}