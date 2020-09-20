
using VertSoft.Peppol.Common.Model;

namespace VertSoft.Peppol.Icd.Api
{

	public interface IIcd
	{

		string Identifier { get;}

		string Code {get;}

		Scheme Scheme {get;}

		string IssuingAgency {get;}

	}

	public class GenericIcd : IIcd
	{
        public string Identifier { get; private set; }

        public string Code { get; private set; }

        /// <summary>
        /// The Scheme of the Icd Code
        /// </summary>
        public virtual Scheme Scheme { get; private set; }

        /// <summary>
        /// The Agency that can issue Identifiers using this Icd.
        /// </summary>
        public string IssuingAgency { get; private set; }

        protected GenericIcd()
        {
            this.Identifier = "";
            this.Code = "";
            this.Scheme = null;
            this.IssuingAgency = "";
        }
        /// <summary>
        /// The constructor but should not be used directly
        /// </summary>
        /// <param name="identifier"></param>
        /// <param name="code"></param>
        /// <param name="scheme"></param>
        /// <param name="issuingAgency"></param>
        private GenericIcd(string identifier, string code, Scheme scheme, string issuingAgency)
		{
			this.Identifier = identifier;
			this.Code = code;
			this.Scheme = scheme;
			this.IssuingAgency = issuingAgency;
		}

        public static GenericIcd of(string identifier, string code, Scheme scheme, string issuingAgency="")
        {
            return new GenericIcd(identifier, code, scheme, issuingAgency);
        }
    }
}