
using System;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;
using VertSoft.Peppol.Security.Api;
using VertSoft.Peppol.Security.Lang;


namespace VertSoft.Peppol.Security.Util
{
    public interface ICertificateValidator
    {
        void Validate(X509Certificate2 certificate, string password);
    }


    //This is the default validator
    public class PeppolCertificateValidator : ICertificateValidator
	{
		public  List<string> ChainStatuses { get; private set; }

		public bool IsPeppolCertificate { get; private set; }

		public bool IsSMPCertificate { get; private set; }

		public bool IsTESTCertificate { get; private set; }

		public bool IsPRODCertificate { get; private set; }

		public bool IsAPCertificate { get; private set; }

		public bool IsValidNow { get; private set; }

		public bool IsChainValid { get; private set; }


		//readonly string PRODUCTION_security_pki = "/pki/peppol-production.xml";
		//readonly string PRODUCTION_security_truststore_password = "changeit";
		//readonly string TEST_security_pki = "/pki/peppol-test.xml";
		//readonly string TEST_security_truststore_password = "changeit";


		/// <summary>
		/// Constructs a validator for the specified service.
		/// </summary>
		public PeppolCertificateValidator()
        {
			this.ChainStatuses = new List<string>();
		}

		/// <summary>
		/// Gets the Chain information about the given Certificate
		/// </summary>
		private void GetChainInfo(X509Certificate2 certificate)
		{
			//Output chain information of the selected certificate.
			X509Chain ch = new X509Chain();
			//REM: This the place where we change the ChainPolicy
			//REM: Here we can use X509VerificationFlags Enum to adapt the checks
			//standard Policy should be like in https://tools.ietf.org/html/rfc3280
			//Builds a Chain using the known ChainPolicy
			ch.Build(certificate);
			//Console.WriteLine("Chain Information");
			//Console.WriteLine("Chain revocation flag: {0}", ch.ChainPolicy.RevocationFlag);
			Console.WriteLine("Chain revocation mode: {0}", ch.ChainPolicy.RevocationMode);
			Console.WriteLine("Chain verification flag: {0}", ch.ChainPolicy.VerificationFlags);
			Console.WriteLine("Chain verification time: {0}", ch.ChainPolicy.VerificationTime);
			Console.WriteLine("Chain status length: {0}", ch.ChainStatus.Length);
			Console.WriteLine("Chain application policy count: {0}", ch.ChainPolicy.ApplicationPolicy.Count);
			Console.WriteLine("Chain certificate policy count: {0} {1}", ch.ChainPolicy.CertificatePolicy.Count, Environment.NewLine);

			//Output chain element information.
			Console.WriteLine("Number of chain elements: {0}", ch.ChainElements.Count);
			Console.WriteLine("Chain elements synchronized? {0} {1}", ch.ChainElements.IsSynchronized, Environment.NewLine);

			foreach (X509ChainElement element in ch.ChainElements)
			{
				Console.WriteLine("Element error status length: {0}", element.ChainElementStatus.Length);
				Console.WriteLine("Element information: {0}", element.Information);
				//TODO: check extensions, what should we do with it ?
				Console.WriteLine("Number of element extensions: {0}{1}", element.Certificate.Extensions.Count, Environment.NewLine);

				if (ch.ChainStatus.Length > 1)
				{
					for (int index = 0; index < element.ChainElementStatus.Length; index++)
					{
						Console.WriteLine(element.ChainElementStatus[index].Status);
						//REM: Status Information is the most important
						ChainStatuses.Add(element.ChainElementStatus[index].StatusInformation);
					}
				}
			}
		}

		/// <summary>
		/// Does the validation based on the Service(SMP, AP, ALL)
		/// </summary>
		/// <param name="certificate">The certificate to validate</param>
		/// <param name="password">the password of the certificate</param>
		/// <exception cref="PeppolSecurityException"></exception>
		public void Validate(X509Certificate2 certificate, string password = null)
		{
			try
			{
				//Contains CN=common name, OU=organizational unit, O=organization, C=country
				//REM: is there a structure to handle them ?
				DistinguishedName objIssuer = new DistinguishedName(certificate.IssuerName.Name);
				DistinguishedName objSubject = new DistinguishedName(certificate.SubjectName.Name);

				this.IsPeppolCertificate = false;
				this.IsAPCertificate = false;
				this.IsSMPCertificate = false;
				this.IsAPCertificate = false;
				this.IsValidNow = false;
				this.IsPRODCertificate = false;
				this.IsTESTCertificate = false;
				//Check if the certificate is still Valid now
				if (DateTime.Now <= certificate.NotAfter && DateTime.Now >= certificate.NotBefore)
					this.IsValidNow = true;
				
				if (objSubject.ContainsKey("OU"))
				{
					//Check if it is a Peppol certificate
					if (objSubject["OU"].Contains("PEPPOL"))
						this.IsPeppolCertificate = true;
					if (objSubject["OU"].Contains("TEST"))
						this.IsTESTCertificate = true;
					if (objSubject["OU"].Contains("PRODUCTION"))
						this.IsPRODCertificate = true;
					if (objSubject["OU"].Contains("SMP"))
						this.IsSMPCertificate = true;
					if (objSubject["OU"].Contains("AP"))
						this.IsAPCertificate = true;
				}
				//Do the Common Chain Validation
				this.IsChainValid = certificate.Verify();

				//REM: If you need more info about failure you need to use X509Chain object
				//REM:  builds a simple chain for the certificate and applies the base policy to that chain.
				//REM: the default engine conforms to the specification described in https://tools.ietf.org/html/rfc3280
				//REM: default chaining engine can be overridden using the CryptoConfig
				if (!this.IsChainValid)
				{
					this.GetChainInfo(certificate);
				}
			}

			catch (Exception e)
			{
				throw new PeppolSecurityException(e.Message, e);
			}
		}
	}
}