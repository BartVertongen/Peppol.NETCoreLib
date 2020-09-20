using System.Collections.Generic;

namespace no.difi.certvalidator.util
{
	/// <summary>
	/// From <a href="https://tools.ietf.org/html/rfc5280#section-4.2.1.3">RFC5280 4.2.1.3</a>.
	/// 
	/// </summary>
	public sealed class KeyUsage
	{

		public static readonly KeyUsage DIGITAL_SIGNATURE = new KeyUsage("DIGITAL_SIGNATURE", InnerEnum.DIGITAL_SIGNATURE, 0);

		public static readonly KeyUsage NON_REPUDIATION = new KeyUsage("NON_REPUDIATION", InnerEnum.NON_REPUDIATION, 1);

		public static readonly KeyUsage KEY_ENCIPHERMENT = new KeyUsage("KEY_ENCIPHERMENT", InnerEnum.KEY_ENCIPHERMENT, 2);

		public static readonly KeyUsage DATA_ENCIPHERMENT = new KeyUsage("DATA_ENCIPHERMENT", InnerEnum.DATA_ENCIPHERMENT, 3);

		public static readonly KeyUsage KEY_AGREEMENT = new KeyUsage("KEY_AGREEMENT", InnerEnum.KEY_AGREEMENT, 4);

		public static readonly KeyUsage KEY_CERT_SIGN = new KeyUsage("KEY_CERT_SIGN", InnerEnum.KEY_CERT_SIGN, 5);

		public static readonly KeyUsage CRL_SIGN = new KeyUsage("CRL_SIGN", InnerEnum.CRL_SIGN, 6);

		public static readonly KeyUsage ENCIPHER_ONLY = new KeyUsage("ENCIPHER_ONLY", InnerEnum.ENCIPHER_ONLY, 7);

		public static readonly KeyUsage DECIPHER_ONLY = new KeyUsage("DECIPHER_ONLY", InnerEnum.DECIPHER_ONLY, 8);

		private static readonly List<KeyUsage> valueList = new List<KeyUsage>();

		static KeyUsage()
		{
			valueList.Add(DIGITAL_SIGNATURE);
			valueList.Add(NON_REPUDIATION);
			valueList.Add(KEY_ENCIPHERMENT);
			valueList.Add(DATA_ENCIPHERMENT);
			valueList.Add(KEY_AGREEMENT);
			valueList.Add(KEY_CERT_SIGN);
			valueList.Add(CRL_SIGN);
			valueList.Add(ENCIPHER_ONLY);
			valueList.Add(DECIPHER_ONLY);
		}

		public enum InnerEnum
		{
			DIGITAL_SIGNATURE,
			NON_REPUDIATION,
			KEY_ENCIPHERMENT,
			DATA_ENCIPHERMENT,
			KEY_AGREEMENT,
			KEY_CERT_SIGN,
			CRL_SIGN,
			ENCIPHER_ONLY,
			DECIPHER_ONLY
		}

		public readonly InnerEnum innerEnumValue;
		private readonly string nameValue;
		private readonly int ordinalValue;
		private static int nextOrdinal = 0;

		private readonly int bit;

		public static KeyUsage of(int bit)
		{
			foreach (KeyUsage keyUsage in values())
			{
				if (keyUsage.bit == bit)
				{
					return keyUsage;
				}
			}

			throw new System.ArgumentException(string.Format("Bit '{0}' is not known.", bit));
		}

		internal KeyUsage(string name, InnerEnum innerEnum, int bit)
		{
			this.bit = bit;

			nameValue = name;
			ordinalValue = nextOrdinal++;
			innerEnumValue = innerEnum;
		}

		public int Bit
		{
			get
			{
				return bit;
			}
		}

		public static List<KeyUsage> values()
		{
			return valueList;
		}

		public int ordinal()
		{
			return ordinalValue;
		}

		public override string ToString()
		{
			return nameValue;
		}

		public static KeyUsage valueOf(string name)
		{
			foreach (KeyUsage enumInstance in KeyUsage.valueList)
			{
				if (enumInstance.nameValue == name)
				{
					return enumInstance;
				}
			}
			throw new System.ArgumentException(name);
		}
	}
}