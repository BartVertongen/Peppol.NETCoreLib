
using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using CertificateValidationException = no.difi.certvalidator.api.CertificateValidationException;
using no.difi.certvalidator.api;
using Report = no.difi.certvalidator.api.Report;
using ValidatorRule = no.difi.certvalidator.api.ValidatorRule;
using DummyReport = no.difi.certvalidator.util.DummyReport;
using no.difi.certvalidator.util;


namespace no.difi.certvalidator
{
	/// <summary>
	/// Encapsulate validator for a more extensive API.
	/// </summary>
	public class Validator : ValidatorRule
	{

		public static readonly Property<X509Certificate2> CERTIFICATE = SimpleProperty<X509Certificate2>.create();

		//private static CertificateFactory certFactory;

        //ORIGINAL LINE: public static X509Certificate getCertificate(byte[] cert) throws CertificateValidationException
		public static X509Certificate2 getCertificate(byte[] cert)
		{
			return getCertificate(new MemoryStream(cert));
		}

        //ORIGINAL LINE: public static X509Certificate getCertificate(Stream inputStream) throws CertificateValidationException
		public static X509Certificate2 getCertificate(Stream inputStream)
		{
			try
			{
                byte[] arBytes;

                using (BinaryReader br = new BinaryReader(inputStream))
                {
                    arBytes = br.ReadBytes((int)inputStream.Length);
                }
                return (X509Certificate2) new X509Certificate2(arBytes);
			}
			catch (/*Certificate*/Exception e)
			{
				throw new CertificateValidationException(e.Message, e);
			}
		}

		private ValidatorRule validatorRule;

		public Validator(ValidatorRule validatorRule)
		{
			this.validatorRule = validatorRule;
		}


        //throws CertificateValidationException
		public virtual void validate(X509Certificate2 certificate)
		{
			validate(certificate, DummyReport.INSTANCE);
		}


        //throws CertificateValidationException
		public virtual Report validate(X509Certificate2 certificate, Report report)
		{
			return validatorRule.validate(certificate, report);
		}


        //throws CertificateValidationException
		public virtual X509Certificate2 validate(Stream inputStream)
		{
			X509Certificate2 certificate = getCertificate(inputStream);
			validate(certificate);
			return certificate;
		}


        //ORIGINAL LINE: public Report validate(Stream inputStream, Report report) throws CertificateValidationException
		public virtual Report validate(Stream inputStream, Report report)
		{
			X509Certificate2 certificate = getCertificate(inputStream);
			validate(certificate, report);

			report.set(CERTIFICATE, certificate);

			return report;
		}


        //throws CertificateValidationException
		public virtual X509Certificate2 validate(byte[] bytes)
		{
			X509Certificate2 certificate = getCertificate(bytes);
			validate(certificate);
			return certificate;
		}


        //throws CertificateValidationException
		public virtual Report validate(byte[] bytes, Report report)
		{
			X509Certificate2 certificate = getCertificate(bytes);
			validate(certificate, report);

			report.set(CERTIFICATE, certificate);

			return report;
		}

		public virtual bool isValid(X509Certificate2 certificate)
		{
			try
			{
				validate(certificate, DummyReport.INSTANCE);
				return true;
			}
			catch (CertificateValidationException)
			{
				return false;
			}
		}

		public virtual bool isValid(Stream inputStream)
		{
			try
			{
				return isValid(getCertificate(inputStream));
			}
			catch (CertificateValidationException)
			{
				return false;
			}
		}

		public virtual bool isValid(byte[] bytes)
		{
			try
			{
				return isValid(getCertificate(bytes));
			}
			catch (CertificateValidationException)
			{
				return false;
			}
		}
	}
}