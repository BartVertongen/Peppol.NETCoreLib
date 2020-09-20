using System.Collections.Generic;

/// <summary>
/// The digest is the output of the hash function.
/// For example, sha256 has a digest of 256 bits, i.e.its digest has a length of 32 bytes.
/// A Digest is what the hash function returns
/// Here the DigestMethod is the Hash Function
/// </summary>

namespace VertSoft.Peppol.Common.Code
{
	public sealed class DigestMethod
	{

		public static readonly DigestMethod SHA1 = new DigestMethod("SHA1", InnerEnum.SHA1, "SHA-1", "http://www.w3.org/2000/09/xmldsig#sha1");
		public static readonly DigestMethod SHA256 = new DigestMethod("SHA256", InnerEnum.SHA256, "SHA-256", "http://www.w3.org/2001/04/xmlenc#sha256");
		public static readonly DigestMethod SHA512 = new DigestMethod("SHA512", InnerEnum.SHA512, "SHA-512", "http://www.w3.org/2001/04/xmlenc#sha512");

		private static readonly IList<DigestMethod> valueList = new List<DigestMethod>();

		static DigestMethod()
		{
			valueList.Add(SHA1);
			valueList.Add(SHA256);
			valueList.Add(SHA512);
		}

		public enum InnerEnum
		{
			SHA1,
			SHA256,
			SHA512
		}

		public readonly InnerEnum innerEnumValue;
		private readonly string nameValue;
		private readonly int ordinalValue;
		private static int nextOrdinal = 0;

		private readonly string identifier;

		private readonly string uri;

		internal DigestMethod(string name, InnerEnum innerEnum, string identifier, string uri)
		{
			this.identifier = identifier;
			this.uri = uri;

			nameValue = name;
			ordinalValue = nextOrdinal++;
			innerEnumValue = innerEnum;
		}

		public string Identifier
		{
			get
			{
				return identifier;
			}
		}

		public string Uri
		{
			get
			{
				return uri;
			}
		}

		public static DigestMethod fromUri(string uri)
		{
			foreach (DigestMethod digestMethod in values())
			{
				if (digestMethod.uri.Equals(uri))
				{
					return digestMethod;
				}
			}

			return null;
		}

		public static IList<DigestMethod> values()
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

		public static DigestMethod valueOf(string name)
		{
			foreach (DigestMethod enumInstance in DigestMethod.valueList)
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