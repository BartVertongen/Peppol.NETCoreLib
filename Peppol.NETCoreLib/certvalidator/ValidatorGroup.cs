using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using CertificateValidationException = no.difi.certvalidator.api.CertificateValidationException;
using Report = no.difi.certvalidator.api.Report;
using ValidatorRule = no.difi.certvalidator.api.ValidatorRule;
using DummyReport = no.difi.certvalidator.util.DummyReport;


namespace no.difi.certvalidator
{
	public class ValidatorGroup : Validator
	{

		private Dictionary<string, ValidatorRule> rulesMap;

		private string name;

		private string version;

		public ValidatorGroup(Dictionary<string, ValidatorRule> rulesMap) : base(null)
		{
			this.rulesMap = rulesMap;
		}

		public ValidatorGroup(Dictionary<string, ValidatorRule> rulesMap, string name, string version) : this(rulesMap)
		{
			this.name = name;
			this.version = version;
		}

		public virtual string Name
		{
			get
			{
				return name;
			}
		}

		public virtual string Version
		{
			get
			{
				return version;
			}
		}


        //throws CertificateValidationException
		public override void validate(X509Certificate2 certificate)
		{
			validate("default", certificate);
		}


        //throws CertificateValidationException
		public override Report validate(X509Certificate2 certificate, Report report)
		{
			return validate("default", certificate, report);
		}


        //throws CertificateValidationException
		public override X509Certificate2 validate(Stream inputStream)
		{
			return validate("default", inputStream);
		}


        //throws CertificateValidationException
		public override Report validate(Stream inputStream, Report report)
		{
			return validate("default", inputStream, report);
		}


        //throws CertificateValidationException
		public override X509Certificate2 validate(byte[] bytes)
		{
			return validate("default", bytes);
		}


        //throws CertificateValidationException
		public override Report validate(byte[] bytes, Report report)
		{
			return validate("default", bytes, report);
		}


        //throws CertificateValidationException
		public virtual void validate(string name, X509Certificate2 certificate)
		{
			validate(name, certificate, DummyReport.INSTANCE);
		}


        //throws CertificateValidationException
		public virtual Report validate(string name, X509Certificate2 certificate, Report report)
		{
			if (!this.rulesMap.ContainsKey(name))
			{
				throw new CertificateValidationException(string.Format("Unknown validator '{0}'.", name));
			}
			report.set(CERTIFICATE, certificate);
			return this.rulesMap[name].validate(certificate, report);
		}


        // throws CertificateValidationException
		public virtual X509Certificate2 validate(string name, Stream inputStream)
		{
			X509Certificate2 certificate = getCertificate(inputStream);
			validate(name, certificate, DummyReport.INSTANCE);
			return certificate;
		}


        //throws CertificateValidationException
		public virtual Report validate(string name, Stream inputStream, Report report)
		{
			X509Certificate2 certificate = getCertificate(inputStream);
			return validate(name, certificate, report);
		}


        // throws CertificateValidationException
		public virtual X509Certificate2 validate(string name, byte[] bytes)
		{
			X509Certificate2 certificate = getCertificate(bytes);
			validate(name, certificate, DummyReport.INSTANCE);
			return certificate;
		}


        //throws CertificateValidationException
		public virtual Report validate(string name, byte[] bytes, Report report)
		{
			X509Certificate2 certificate = getCertificate(bytes);
			return validate(name, certificate, report);
		}

		public virtual bool isValid(string name, X509Certificate2 certificate)
		{
			try
			{
				validate(name, certificate);
				return true;
			}
			catch (CertificateValidationException)
			{
				return false;
			}
		}

		public virtual bool isValid(string name, Stream inputStream)
		{
			try
			{
				return isValid(name, getCertificate(inputStream));
			}
			catch (CertificateValidationException)
			{
				return false;
			}
		}

		public virtual bool isValid(string name, byte[] bytes)
		{
			try
			{
				return isValid(name, getCertificate(bytes));
			}
			catch (CertificateValidationException)
			{
				return false;
			}
		}
	}
}