using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using no.difi.certvalidator.api;
using PrincipalNameRule = no.difi.certvalidator.rule.PrincipalNameRule;
using no.difi.certvalidator.util;


namespace no.difi.certvalidator.extra
{
	/// <summary>
	/// Implementation of fetching of Norwegian organization number from certificates.
	/// <p/>
	/// Use of organization numbers in certificates is defines here:
	/// http://www.regjeringen.no/upload/FAD/Vedlegg/IKT-politikk/SEID_Leveranse_1_-_v1.02.pdf (page 24)
	/// </summary>
	public class NorwegianOrganizationNumberRule : PrincipalNameRule
	{
		public static readonly Property<NorwegianOrganization> ORGANIZATION = SimpleProperty.create();

		private static readonly Pattern patternSerialNumber = Pattern.compile("^[0-9]{9}$");

		private static readonly Pattern patternOrganizationName = Pattern.compile("^.+\\-\\W*([0-9]{9})$");

		public NorwegianOrganizationNumberRule() : this(new PrincipalNameProviderAnonymousInnerClass(this))
		{
		}

		private class PrincipalNameProviderAnonymousInnerClass : PrincipalNameProvider<string>
		{
			private readonly NorwegianOrganizationNumberRule outerInstance;

			public PrincipalNameProviderAnonymousInnerClass(NorwegianOrganizationNumberRule outerInstance)
			{
				this.outerInstance = outerInstance;
			}

			public bool validate(string value)
			{
				return true;
			}
		}

		public NorwegianOrganizationNumberRule(PrincipalNameProvider<string> provider) : base(provider)
		{
		}


        //ORIGINAL LINE: public Report validate(X509Certificate certificate, Report report) throws CertificateValidationException
		public override Report validate(X509Certificate2 certificate, Report report)
		{
			NorwegianOrganization organization = extractNumber(certificate);
			if (organization != null)
			{
				if (provider.validate(organization.Number))
				{
					report.set(ORGANIZATION, organization);

					return report;
				}
			}
			throw new FailedValidationException("Organization number not detected.");
		}

		/// <summary>
		/// Extracts organization number using functionality provided by PrincipalNameValidator.
		/// </summary>
		/// <param name="certificate"> Certificate subject to validation. </param>
		/// <returns> Organization number found in certificate, null if not found. </returns>
		/// <exception cref="CertificateValidationException"> </exception>
        //throws CertificateValidationException
		public static NorwegianOrganization extractNumber(X509Certificate2 certificate)
		{
			try
			{
				// Fetch organization name.
				List<string> name = extract(getSubject(certificate), "O");

				//matches "C=NO,ST=AKERSHUS,L=FORNEBUVEIEN 1\\, 1366 LYSAKER,O=RF Commfides,SERIALNUMBER=399573952,CN=RF Commfides"
				foreach (string value in extract(getSubject(certificate), "SERIALNUMBER"))
				{
					if (patternSerialNumber.matcher(value).matches())
					{
						return new NorwegianOrganization(value, name.Count == 0 ? null : name[0]);
					}
				}

				//matches "CN=name, OU=None, O=organisasjon - 123456789, L=None, C=None"
				foreach (string value in extract(getSubject(certificate), "O"))
				{
					Matcher matcher = patternOrganizationName.matcher(value);
					if (matcher.matches())
					{
						return new NorwegianOrganization(matcher.group(1), name[0]);
					}
				}

				return null;
			}
			catch (Exception e) //when (e is CertificateEncodingException || e is System.NullReferenceException)
			{
				throw new CertificateValidationException(e.Message, e);
			}
		}

		public class NorwegianOrganization
		{

			internal string number;

			internal string name;

			public NorwegianOrganization(string number, string name)
			{
				this.number = number;
				this.name = name;
			}

			public virtual string Number
			{
				get
				{
					return number;
				}
			}

			public virtual string Name
			{
				get
				{
					return name;
				}
			}
		}
	}
}