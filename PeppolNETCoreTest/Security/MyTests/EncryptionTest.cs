
using System.Security.Cryptography.X509Certificates;
using System.Xml;


namespace VertSoft.Peppol.Security
{
	public class EncryptionTest
	{
		private X509Certificate2 _Certificate = null;
		private XmlDocument _Original = null;
		private XmlDocument _Encrypted = null;
		private XmlDocument _Restored = null;


		public void SetUp()
		{
			//Load the certificate
			this._Certificate = new X509Certificate2("./keystore-self-signed.p12", "changeit", X509KeyStorageFlags.Exportable);
			_Original = new XmlDocument();
		}


		/// <summary>
		/// Encrypt an xml file
		/// </summary>
		public void Encrypt()
		{
			Encryptor objEncryptor = new Encryptor("./keystore-self-signed.p12", "changeit");

			_Original.Load("./xmldsig-test-input.xml");
			this._Encrypted = objEncryptor.Encrypt(_Original, "name");
		}


		/// <summary>
		/// Decrypt an xml file
		/// </summary>
		public void Decrypt()
		{
			Encryptor objEncryptor = new Encryptor();
			_Restored = objEncryptor.Decrypt(this._Encrypted);
		}

		public void Verify()
		{
			bool bEqual = _Restored.Equals(_Original);
		}
	}
}