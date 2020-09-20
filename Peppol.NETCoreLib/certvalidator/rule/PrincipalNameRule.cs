using System.Collections.Generic;

namespace no.difi.certvalidator.rule
{
	using no.difi.certvalidator.api;
	using no.difi.certvalidator.util;
    using System;
    using System.Security.Cryptography.X509Certificates;

    //using AttributeTypeAndValue = org.bouncycastle.asn1.x500.AttributeTypeAndValue;
    //using RDN = org.bouncycastle.asn1.x500.RDN;
    //using X500Name = org.bouncycastle.asn1.x500.X500Name;
    //using RFC4519Style = org.bouncycastle.asn1.x500.style.RFC4519Style;
    //using JcaX509CertificateHolder = org.bouncycastle.cert.jcajce.JcaX509CertificateHolder;


    /// <summary>
    /// Validator using defined logic to validate content in principal name of subject or issuer.
    /// </summary>
    public class PrincipalNameRule : AbstractRule
	{

		public static readonly Property<string> NAME = SimpleProperty<string>.create();

		protected internal string field;

		protected internal PrincipalNameProvider<string> provider;

		protected internal Principal principal;

		public PrincipalNameRule(PrincipalNameProvider<string> provider) : this(null, provider, Principal.SUBJECT)
		{
		}

		public PrincipalNameRule(PrincipalNameProvider<string> provider, Principal principal) : this(null, provider, principal)
		{
		}

		public PrincipalNameRule(string field, PrincipalNameProvider<string> provider) : this(field, provider, Principal.SUBJECT)
		{
		}

		public PrincipalNameRule(string field, PrincipalNameProvider<string> provider, Principal principal)
		{
			this.field = field;
			this.provider = provider;
			this.principal = principal;
		}


        //ORIGINAL LINE: @Override public Report validate(X509Certificate certificate, Report report) throws CertificateValidationException
		public override Report validate(X509Certificate2 certificate, Report report)
		{
			try
			{
				X500Name current;
				if (principal.Equals(Principal.SUBJECT))
				{
					current = getSubject(certificate);
				}
				else
				{
					current = getIssuer(certificate);
				}

				foreach (string value in extract(current, field))
				{
					if (provider.validate(value))
					{
						report.set(NAME, value);

						return report;
					}
				}

				throw new FailedValidationException(string.Format("Validation of subject principal({0}) failed.", field));
			}
			catch (/*CertificateEncoding*/Exception e)
			{
				throw new FailedValidationException("Unable to fetch principal.", e);
			}
		}


        //ORIGINAL LINE: protected static org.bouncycastle.asn1.x500.X500Name getIssuer(java.security.cert.X509Certificate certificate) throws java.security.cert.CertificateEncodingException
		protected internal static X500DistinguishedName getIssuer(X509Certificate2 certificate)
		{
			return (null);
		}


        //ORIGINAL LINE: protected static org.bouncycastle.asn1.x500.X500Name getSubject(X509Certificate certificate) throws CertificateEncodingException
		protected internal static X500DistinguishedName getSubject(X509Certificate certificate)
		{
			return /*(new JcaX509CertificateHolder(*/certificate.;
		}


        //ORIGINAL LINE: @SuppressWarnings("all") protected static java.util.List<String> extract(org.bouncycastle.asn1.x500.X500Name principal, String field)
		protected internal static List<string> extract(X500DistinguishedName principal, string field)
		{
			if (string.ReferenceEquals(field, null))
			{
				return Arrays.asList(principal.ToString());
			}

			RFC4519Style.INSTANCE.attrNameToOID(field);

			List<string> values = new List<string>();
			foreach (RDN rdn in principal.getRDNs(RFC4519Style.INSTANCE.attrNameToOID(field)))
			{
				foreach (AttributeTypeAndValue value in rdn.TypesAndValues)
				{
					values.Add(value.Value.ToString());
				}
			}
			return values;
		}

		public enum Principal
		{
			SUBJECT,
			ISSUER
		}
	}
}