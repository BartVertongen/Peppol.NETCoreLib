using System;


namespace VertSoft.Peppol.Common.Model
{
	[Serializable]
	public class TransportProfile : AbstractSimpleIdentifier
	{

		public static readonly TransportProfile PEPPOL_START = of("busdox-transport-start");

		[Obsolete]
		public static readonly TransportProfile START = PEPPOL_START;

		public static readonly TransportProfile PEPPOL_AS2_1_0 = of("busdox-transport-as2-ver1p0");

		[Obsolete]
		public static readonly TransportProfile AS2_1_0 = PEPPOL_AS2_1_0;

		public static readonly TransportProfile PEPPOL_AS2_2_0 = of("busdox-transport-as2-ver2p0");

		public static readonly TransportProfile PEPPOL_AS4_2_0 = of("peppol-transport-as4-v2_0");

		public static readonly TransportProfile ESENS_AS4 = of("bdxr-transport-ebms3-as4-v1p0");

		public static readonly TransportProfile AS4 = ESENS_AS4;

		public static TransportProfile of(string value)
		{
			return new TransportProfile(value);
		}

		private TransportProfile(string value) : base(value)
		{
		}

		public override string ToString()
		{
			return "TransportProfile{" + this.Identifier + '}';
		}
	}
}