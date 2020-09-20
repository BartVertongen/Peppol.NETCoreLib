
using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using no.difi.certvalidator.api;
using no.difi.certvalidator.util;


namespace no.difi.certvalidator.rule
{
	public class SigningRule : AbstractRule
	{
		public static readonly Property<Kind> KIND = SimpleProperty<Kind>.create();

		private readonly Kind kind;

		public static SigningRule PublicSignedOnly()
		{
			return new SigningRule(Kind.PUBLIC_SIGNED_ONLY);
		}

		public static SigningRule SelfSignedOnly()
		{
			return new SigningRule(Kind.SELF_SIGNED_ONLY);
		}

		public SigningRule() : this(Kind.PUBLIC_SIGNED_ONLY)
		{
		}

		public SigningRule(Kind kind)
		{
			this.kind = kind;
		}


        //throws CertificateValidationException
		public override Report validate(X509Certificate2 certificate, Report report)
		{
			try
			{
				if (isSelfSigned(certificate))
				{
					// Self signed
					if (kind.Equals(Kind.PUBLIC_SIGNED_ONLY))
					{
						throw new FailedValidationException("Certificate should be publicly signed.");
					}
				}
				else
				{
					// Publicly signed
					if (kind.Equals(Kind.SELF_SIGNED_ONLY))
					{
						throw new FailedValidationException("Certificate should be self-signed.");
					}
				}
				report.set(KIND, kind);
				return report;
			}
			catch (FailedValidationException e)
			{
				throw e;
			}
			catch (Exception e)
			{
				throw new CertificateValidationException(e.Message, e);
			}
		}


		public static bool isSelfSigned(X509Certificate2 cert)
		{
            //A certificate is selfsigned if Issuer and subject are the same
            return cert.SubjectName.RawData.SequenceEqual(cert.IssuerName.RawData);
		}

		public enum Kind
		{
			PUBLIC_SIGNED_ONLY,
			SELF_SIGNED_ONLY
		}
	}
}