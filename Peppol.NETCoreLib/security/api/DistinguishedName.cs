
using System;
using System.Collections.Generic;
using System.Text;


namespace VertSoft.Peppol.Security.Api
{
	/// <summary>
	/// DistinguishedName(DN) is a sequence of Relative Distinguished Names(RDN).
	/// </summary>
	/// <remarks>Can be used for Subject or Issuer of X509 certificates.</remarks>
	public class DistinguishedName: Dictionary<string , string>
	{
		public enum RDNAttributes { 
			/// <summary>domainComponent</summary>
			DC,
			/// <summary>commonName</summary>
			CN,
			/// <summary>organizationalUnitName</summary>
			OU,
			/// <summary>organizationName</summary>
			O,
			/// <summary>streetAddress</summary>
			STREET,
			/// <summary>localityName</summary>
			L,
			/// <summary>statOrProvinceName</summary>
			ST,
			/// <summary>countryName</summary>
			C,
			/// <summary>userid</summary>
			UID
		};

		/// <summary>
		/// Default constructor. 
		/// </summary>
		public DistinguishedName()
		{
			foreach (var item in Enum.GetNames(typeof(RDNAttributes)))
			{
				base.Add(item.ToString(), "");
			}
		}

		/// <summary>
		/// Constructs a DistinguishedName from a string value.
		/// </summary>
		/// <param name="distinguishedname">The distinguished name to be parsed.</param>
		public DistinguishedName(string distinguishedname): this()
		{
			string[] arIssuerParts = distinguishedname.Split(',');
			foreach (string part in arIssuerParts)
			{
				string strPair = part.Trim();
				string[] arKeyValue = strPair.Split('=');
				arKeyValue[0] = arKeyValue[0].Trim();
				arKeyValue[1] = arKeyValue[1].Trim();
				this[arKeyValue[0]] = arKeyValue[1];
			}
		}
	}
}
