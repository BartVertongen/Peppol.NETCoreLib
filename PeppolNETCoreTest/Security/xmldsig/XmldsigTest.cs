
using System;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Xml;
using Vertsoft.Tools.Extension.Xml;


namespace VertSoft.Peppol.Security.Xmldsig
{
	public class XmldsigTest
	{
		private X509Certificate2 _CertificateToSign = null;


		/// <summary>
		/// Just selects the private key from the certificate if there is one.
		/// </summary>
		/// <exception cref="ArgumentNullException"></exception>
		/// <exception cref="NotSupportedException"></exception>
		/// <exception cref="ArgumentException"></exception>
		/// <exception cref="CryptographicException"></exception>
		/// <exception cref="CryptographicUnexpectedOperationException"></exception>
		public virtual void SetUp()
		{
			//Load the certificate
			this._CertificateToSign = new X509Certificate2("./keystore-self-signed.p12", "changeit");
		}

		/// <summary>
		/// Signs a simple XML using sha1
		/// </summary>
		public virtual void SimpleSHA1()
		{
			XmlDocument xmlResult = null;
			XmlDocument xmlInput = new XmlDocument();
			XmlDocument xmlToExpect = new XmlDocument();

			//REM: xmldsig-test-input.xml is an unsigned XML
			xmlInput.Load("./xmldsig-test-input.xml");
			XmldsigSigner.SHA1().Sign(xmlInput, this._CertificateToSign, ref xmlResult);

			//REM: xmldsig-test-output.xml is an signed XML == signed of xmldsig-test-input.xml with keystore-self-signed certificate
			xmlToExpect.Load("./xmldsig-test-output.xml");
			bool bEqual = xmlResult.Equals(xmlToExpect);
			//Debug.Assert(xmlResult.Equals(xmlToExpect));

			X509Certificate2 objCertificate = XmldsigVerifier.Verify(xmlResult);

			Debug.Assert(objCertificate.SubjectName.Name == "CN=VEFA Validator self-signed, OU=Unknown, O=Unknown, L=Unknown, S=Unknown, C=Unknown");
		}


		/// <summary>
		/// Signs a simple XML using sha256
		/// </summary>
		public virtual void SimpleSHA256()
		{
			XmlDocument xmlInput = new XmlDocument();
			XmlDocument xmlResult = null;
			XmlDocument xmlToExpect = new XmlDocument();

			//REM: xmldsig-test-input.xml is an unsigned XML
			xmlInput.Load("./xmldsig-test-input.xml");
			MemoryStream generatedStream = new MemoryStream();
			XmldsigSigner.SHA256().Sign(xmlInput, this._CertificateToSign, ref xmlResult);

			//REM: xmldsig-test-output.xml is an signed XML == signed of xmldsig-test-input.xml with keystore-self-signed certificate
			xmlToExpect.Load("./xmldsig-test-output-sha256.xml");
			bool bEqual = xmlResult.Equals(xmlToExpect);
			//Debug.Assert(xmlResult.Equals(xmlToExpect));

			X509Certificate2 x509Certificate = XmldsigVerifier.Verify(xmlResult);
			Debug.Assert(x509Certificate.SubjectName.Name == "CN=VEFA Validator self-signed, OU=Unknown, O=Unknown, L=Unknown, S=Unknown, C=Unknown");
		}

		/// <summary>
		/// Just constructs an XmldsigVerifier
		/// </summary>
		public virtual void SimpleContructors()
		{
			XmldsigVerifier objVerifier = new XmldsigVerifier();
		}

		/// <summary>
		/// Verifies that a simple class can be signed and validated.
		/// </summary>
		/// <exception cref="Exception"> </exception>
		public virtual void SignAndValidate()
		{
			XmlDocument xmlInput = new XmlDocument();
			XmlDocument xmlResult = null;

			Sample sample = new Sample();
			sample.Info = "The quick brown fox";

			//Convert Sample object to XML
			string strXml = sample.XmlSerialize();
			xmlInput.LoadXml(strXml);

			XmldsigSigner.SHA1().Sign(xmlInput, this._CertificateToSign, ref xmlResult);

			// Verify the signature from the signed DOM document
			X509Certificate certVerify = XmldsigVerifier.Verify(xmlResult);
			Debug.Assert(certVerify != null);

		}

		//TODO we should also test Encrypt and Decrypt

	}
}