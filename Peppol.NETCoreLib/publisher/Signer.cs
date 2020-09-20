
using System.IO;
using VertSoft.Peppol.Security.Lang;
using System.Xml;
using System.Security.Cryptography;
using VertSoft.Peppol.Security.Xmldsig;
using System;


namespace VertSoft.Peppol.Publisher
{
	/// <summary>
	/// </summary>
	public class Signer
	{
		private XmldsigSigner xmldsigSigner;

		private AsymmetricAlgorithm privateKeyEntry;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="xmldsigSigner"></param>
		/// <param name="privateKeyEntry"></param>
		public Signer(XmldsigSigner xmldsigSigner, AsymmetricAlgorithm privateKeyEntry)
		{
			this.xmldsigSigner = xmldsigSigner;
			this.privateKeyEntry = privateKeyEntry;
		}

        //throws SigningException
		public virtual void Sign(XmlDocument document, Stream outputStream)
		{
			try
			{
				XmlDocument xmlResult = new XmlDocument();
				xmlResult.Load(outputStream);
				//TODO xmldsigSigner.sign(document.DocumentElement, privateKeyEntry, xmlResult);
			}
			catch (PeppolSecurityException e)
			{
				throw new /*Signing*/Exception(e.Message, e);
			}
		}
	}
}