
using System;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Xml;
using System.Security.Cryptography;
using System.Xml.Serialization;
using System.IO;
using VertSoft.Peppol.Types.Smp.Xmldsig;
using VertSoft.Peppol.Security.Lang;


namespace VertSoft.Peppol.Security.Xmldsig
{	
	public class XmldsigVerifier
	{
		/// <summary>
		/// Will return a certificate used to sign the xml document if it was signed.
		/// </summary>
		/// <param name="xmldoc">The xml document to verify.</param>
		/// <returns>The certificate used to sign the xml.</returns>
		public static X509Certificate2 Verify(XmlDocument xmldoc)
		{
			try
			{
                SignedXml signedXml = new SignedXml(xmldoc);
                XmlNodeList nl = xmldoc.GetElementsByTagName("Signature");
				if (nl == null)
				{
					throw new PeppolSecurityException("Cannot find Signature element");
				}
                // Throw an exception if no signature was found.
                if (nl.Count == 0)
                {
                    throw new CryptographicException("Verification failed: No Signature was found in the document.");
                }
                // This only supports one signature for
                // the entire XML document.  Throw an exception 
                // if more than one signature was found.
                if (nl.Count >= 2)
                {
                    throw new CryptographicException("Verification failed: More that one signature was found for the document.");
                }

                XmlElement xmlSignature = (XmlElement)nl[0];
                signedXml.LoadXml(xmlSignature);

                XmlSerializer signSerializer = new XmlSerializer(typeof(SignatureType));
				StringReader stringReader = new StringReader(xmlSignature.OuterXml);
				SignatureType signature = (SignatureType)signSerializer.Deserialize(stringReader);

				if (!signedXml.CheckSignature())
				{
					throw new PeppolSecurityException("Signature failed.");
				}
				//We have to return the certificate
				KeyInfoType typeKeyInfo = signature.KeyInfo;
				X509DataType X509Data = (X509DataType)typeKeyInfo.Items[0];
				
				byte[] arRawData = (byte[])X509Data.Items[1];
				X509Certificate2 objCertificate = new X509Certificate2(arRawData);

				return objCertificate;       
			}

			catch (Exception e)
			{
				throw new PeppolSecurityException("Unable to verify document signature.", e);
			}
		}
	}
}