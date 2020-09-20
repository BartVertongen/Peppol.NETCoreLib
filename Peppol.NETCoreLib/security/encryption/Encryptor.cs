
using System;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Xml;


namespace VertSoft.Peppol.Security
{
	public class Encryptor
	{
		private X509Certificate2 _Certificate = null;

		/// <summary>
		/// Constructs an Encryptor to Encrypt or Decrypt an xml document.
		/// </summary>
		/// <param name="certpath">full filename od the certificate in p12 format</param>
		/// <param name="password">password to open the certificate</param>
		public Encryptor(string certpath, string password)
		{
			_Certificate = new X509Certificate2(certpath, password, X509KeyStorageFlags.Exportable);
			if (!IsCertificateInStore(_Certificate))
			{
				this.AddCertificateToStore(_Certificate);
			}			
		}

		/// <summary>
		/// Constructs an Encryptor to only Decrypt an xml document.
		/// </summary>
		/// <remarks>Can only Decrypt because it has no certificate</remarks>
		public Encryptor()
		{
		}

		private bool IsCertificateInStore(X509Certificate2 cert)
		{
			X509Store store = new X509Store(StoreName.Root, StoreLocation.LocalMachine);
			store.Open(OpenFlags.ReadOnly);

			var certificates = store.Certificates.Find( X509FindType.FindBySubjectName, cert.Subject, false);

			if (certificates != null && certificates.Count > 0)
			{
				return true;
			}
			return false;
		}


		private void AddCertificateToStore(X509Certificate2 cert)
		{
			var store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
			store.Open(OpenFlags.ReadWrite);
			store.Add(cert);
			store.Close();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="toEncrypt">xmlDocument to Encrypt</param>
		/// <param name="tagToEncrypt">Tag that should be Encrypted</param>
		/// <returns>Encrypted XmlDocument.</returns>
		public XmlDocument Encrypt(XmlDocument toEncrypt, string tagToEncrypt)
		{
			if (toEncrypt == null)
				throw new ArgumentNullException("toEncrypt");
			if (tagToEncrypt == null || tagToEncrypt.Length == 0)
				throw new ArgumentNullException("tagToEncrypts");
			if (this._Certificate == null)
				throw new Exception("There was no certificate given in the constructor to decrypt!");

			XmlDocument xmlResult = (XmlDocument)toEncrypt.CloneNode(true);

			EncryptedXml Encryptor = new EncryptedXml();
			XmlNodeList ElemList = xmlResult.GetElementsByTagName(tagToEncrypt);
			XmlElement ElementToEncrypt = ElemList[0] as XmlElement;
			EncryptedData EncryptedElm = Encryptor.Encrypt(ElementToEncrypt, _Certificate);

			// Replace the element from the original XmlDocument
			// object with the EncryptedData element.
			EncryptedXml.ReplaceElement(ElementToEncrypt, EncryptedElm, false);
			return xmlResult;
		}


		/// <summary>
		/// Decrypts the given Encrypted XML document.
		/// </summary>
		/// <param name="toDecrypt"></param>
		/// <returns>The decrypted XML document</returns>
		/// <remarks>This only works if the needed certificate is in de Sture of the current user</remarks>
		public XmlDocument Decrypt(XmlDocument toDecrypt)
		{
			//REM: this should also work on linux and 
			//	the store is kept under ~/.dotnet/corefx/cryptography/x509stores/
			XmlDocument xmlResult = null;
			xmlResult = (XmlDocument)toDecrypt.CloneNode(true);
			EncryptedXml objXmlEncryptor = new EncryptedXml(xmlResult);
			// Decrypts the XML document associated with the EncryptedXml.
			objXmlEncryptor.DecryptDocument();
			return xmlResult;
		}
	}
}