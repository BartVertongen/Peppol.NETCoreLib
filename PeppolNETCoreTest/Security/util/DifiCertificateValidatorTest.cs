

using System.Security.Cryptography.X509Certificates;
using System.IO;
using System.Diagnostics;


namespace VertSoft.Peppol.Security.Util
{
	public class DifiCertificateValidatorTest
	{
		/// <summary>
		/// Check the Certificate for Service AP in PROD mode
		/// </summary>
		//ORIGINAL LINE: public void simpleApProd() throws PeppolLoadingException, CertificateValidationException, PeppolSecurityException
		public virtual void SimpleApProd()
		{
			PeppolCertificateValidator objCertValidator = new PeppolCertificateValidator();

			//REM: a cer-file has no password
			FileStream objFileStream = new FileStream("./ap-difi-prod.cer", FileMode.Open);
			MemoryStream objMemoryStream = new MemoryStream();
			objFileStream.CopyTo(objMemoryStream);
			X509Certificate2 objCertificate = new X509Certificate2(objMemoryStream.ToArray());
			objCertValidator.Validate(objCertificate, null);
			Debug.Assert(objCertValidator.IsAPCertificate, "This is not a AP certificate");
			Debug.Assert(objCertValidator.IsPeppolCertificate, "This is not a PEPPOL certificate");
		}

		/// <summary>
		/// Check the Certificate for Service AP in TEST mode
		/// </summary>
		// throws PeppolLoadingException, no.difi.certvalidator.api.CertificateValidationException, PeppolSecurityException
		public virtual void SimpleApTest()
		{
			PeppolCertificateValidator objCertValidator = new PeppolCertificateValidator();

			//REM: a cer-file has no password
			FileStream objFileStream = new FileStream("./ap-difi-test.cer", FileMode.Open);
			MemoryStream objMemoryStream = new MemoryStream();
			objFileStream.CopyTo(objMemoryStream);
			X509Certificate2 objCertificate = new X509Certificate2(objMemoryStream.ToArray());
			objCertValidator.Validate(objCertificate, null);
			Debug.Assert(objCertValidator.IsAPCertificate, "This is not a AP certificate");
			Debug.Assert(objCertValidator.IsPeppolCertificate, "This is not a PEPPOL certificate");
		}

		/// <summary>
		/// Check the Certificate for Service SMP in PROD mode
		/// </summary>
		// throws PeppolLoadingException, no.difi.certvalidator.api.CertificateValidationException, PeppolSecurityException
		public virtual void SimpleSmpProd()
		{
			PeppolCertificateValidator objCertValidator = new PeppolCertificateValidator();

			//REM: a cer-file has no password
			FileStream objFileStream = new FileStream("./smp-difi-prod.cer", FileMode.Open);
			MemoryStream objMemoryStream = new MemoryStream();
			objFileStream.CopyTo(objMemoryStream);
			X509Certificate2 objCertificate = new X509Certificate2(objMemoryStream.ToArray());
			objCertValidator.Validate(objCertificate, null);
			Debug.Assert(objCertValidator.IsSMPCertificate, "This is not a SMP certificate");
			Debug.Assert(objCertValidator.IsPeppolCertificate, "This is not a PEPPOL certificate");
			Debug.Assert(objCertValidator.IsPRODCertificate, "This is not a PROD certificate");
		}

		/// <summary>
		/// Check the Certificate for Service SMP in TEST mode
		/// </summary>
		// throws PeppolLoadingException, no.difi.certvalidator.api.CertificateValidationException, PeppolSecurityException
		public virtual void SimpleSmpTest()
		{
			PeppolCertificateValidator objCertValidator = new PeppolCertificateValidator();

			//REM: a cer-file has no password
			FileStream objFileStream = new FileStream("./smp-difi-test.cer", FileMode.Open);
			MemoryStream objMemoryStream = new MemoryStream();
			objFileStream.CopyTo(objMemoryStream);
			X509Certificate2 objCertificate = new X509Certificate2(objMemoryStream.ToArray());
			objCertValidator.Validate(objCertificate, null);
			Debug.Assert(objCertValidator.IsSMPCertificate, "This is not a SMP certificate");
			Debug.Assert(objCertValidator.IsPeppolCertificate, "This is not a PEPPOL certificate");
			Debug.Assert(objCertValidator.IsTESTCertificate, "This is not a TEST certificate");
		}
	}
}