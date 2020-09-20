
using System;
using System.Text.RegularExpressions;
using VertSoft.Peppol.Common.Lang;


namespace VertSoft.Peppol.Common.Model
{
	[Serializable]
	public class TransportProtocol : AbstractSimpleIdentifier
	{

        private static Regex rx = new Regex(@"(^AS2$)|(^AS4$)|(^INTERNAL$)|(^FUTURE$)", RegexOptions.Compiled); //is a compiled pattern
        //private static Regex rx = new Regex(@"[\\p{Upper}\\d]+", /*RegexOptions.IgnoreCase |*/ RegexOptions.Compiled); //is a compiled pattern

		public static readonly TransportProtocol AS2 = new TransportProtocol("AS2");

		public static readonly TransportProtocol AS4 = new TransportProtocol("AS4");

		public static readonly TransportProtocol INTERNAL = new TransportProtocol("INTERNAL");

        /// <summary>
        /// Constructs a TransportProtocol
        /// </summary>
        /// <param name="value">The identifier for the Protocol</param>
        /// <returns>The constructed object</returns>
        /// <exception cref="PeppolException"/>
        public static TransportProtocol of(string value)
		{
            MatchCollection matches = rx.Matches(value);

            if (matches.Count == 0)
			{
				throw new PeppolException("Identifier not according to pattern.");
			}
			return new TransportProtocol(value);
		}

		private TransportProtocol(string identifier) : base(identifier)
		{
		}

		public override string ToString()
		{
			return "TransportProtocol{" + this.Identifier + '}';
		}
	}
}