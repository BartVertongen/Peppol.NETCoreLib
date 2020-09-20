using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace no.difi.certvalidator.rule
{
	using CertificateValidationException = no.difi.certvalidator.api.CertificateValidationException;
	using FailedValidationException = no.difi.certvalidator.api.FailedValidationException;
	using KeyUsage = no.difi.certvalidator.util.KeyUsage;


	/// <summary>
	/// </summary>
	public class KeyUsageRule : AbstractRule
	{

		private KeyUsage[] expectedKeyUsages;

		private bool[] expected = new bool[9];

		public KeyUsageRule(params KeyUsage[] keyUsages)
		{
			this.expectedKeyUsages = keyUsages;

			foreach (KeyUsage keyUsage in keyUsages)
			{
				this.expected[keyUsage.Bit] = true;
			}
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: @Override public void validate(java.security.cert.X509Certificate certificate) throws no.difi.certvalidator.api.CertificateValidationException
		public override void validate(X509Certificate2 certificate)
		{
			bool[] found = certificate.KeyUsage;

			if (!Array.Equals(expected, found))
			{
				throw new FailedValidationException(string.Format("Expected {0}, found {1}.", Array.ToString(this.expectedKeyUsages), Array.ToString(prettyprint(found))));
			}
		}

		private KeyUsage[] prettyprint(bool[] ku)
		{
			List<KeyUsage> keyUsages = new List<KeyUsage>();

			for (int i = 0; i < ku.Length; i++)
			{
				if (ku[i])
				{
					keyUsages.Add(KeyUsage.of(i));
				}
			}
			return keyUsages.ToArray();
		}
	}
}