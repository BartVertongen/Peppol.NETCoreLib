
using System;
using VertSoft.Peppol.Security.Lang;
using System.Xml;
using System.Security.Cryptography.Xml;
using System.Security.Cryptography.X509Certificates;
using Microsoft.IdentityModel.Tokens;


namespace VertSoft.Peppol.Security.Xmldsig
{
	/// <summary>
	/// Sign an xml using xmldsig
	/// </summary>
	/// <see cref="https://www.w3.org/TR/xmldsig-core/"/>
	/// <see cref="https://docs.microsoft.com/en-us/dotnet/standard/security/cryptography-model"/>
	public class XmldsigSigner
	{
		private string _strSignatureMethod;

		static XmldsigSigner()
		{
		}

		public static XmldsigSigner SHA1()
		{
			return new XmldsigSigner(SignatureMethod.RSA_SHA1);
		}

		public static XmldsigSigner SHA256()
		{
			return new XmldsigSigner(SignatureMethod.RSA_SHA256);
		}

		private XmldsigSigner(string signatureMethod)
		{
			this._strSignatureMethod = signatureMethod;
		}

       
		public virtual void Sign(XmlDocument input, X509Certificate2 signcert, ref XmlDocument result)
		{
			try
			{
				//Copy input to result, after we change result.
				result = (XmlDocument)input.CloneNode(true);

				// Create a SignedXml object.
				SignedXml   objSignedXml = new SignedXml(result);
				if (signcert.HasPrivateKey)
				{
					//objSignedXml.SigningKey = signcert.PrivateKey;
					objSignedXml.SigningKey = signcert.GetRSAPrivateKey();
				}
				else
					throw new Exception("A certificate with private key is needed to sign!");
				
				//KeyInfo is used to add info about the used Certificate
				KeyInfo objKeyInfo = new KeyInfo();
				KeyInfoX509Data KeyData = new KeyInfoX509Data(signcert);
				KeyData.AddSubjectName(signcert.Subject);
				objKeyInfo.AddClause(KeyData);
				objSignedXml.KeyInfo = objKeyInfo;

				// Get the signature object from the SignedXml object.
				Signature XMLSignature = objSignedXml.Signature;

				// Create a reference to be signe, there is no Uri or stream
				Reference objReference = new Reference("");

				if (this._strSignatureMethod == SignatureMethod.RSA_SHA1)
				{
					XMLSignature.SignedInfo.SignatureMethod = SignedXml.XmlDsigRSASHA1Url;
					//XMLSignature.SignedInfo.SignatureMethod = this._strSignatureMethod;
					//REM SecurityAlgorithms does not have SHA1
					objReference.DigestMethod = "http://www.w3.org/2000/09/xmldsig#sha1"; //needs to be an URL
				}					
				else
				{
					//REM SignedXml.XmlDsigRSASHA256Url did not work, we need SecurityAlgorithms
					XMLSignature.SignedInfo.SignatureMethod = SecurityAlgorithms.RsaSha256Signature;
					objReference.DigestMethod = SecurityAlgorithms.Sha256Digest;
				}									

				// Add an enveloped transformation to the reference.
				XmlDsigEnvelopedSignatureTransform objEnvelop = new XmlDsigEnvelopedSignatureTransform(true);
				XmlDsigC14NTransform objEnvelop2 = new XmlDsigC14NTransform(true); //Enveloping signature
                objReference.AddTransform(objEnvelop);

                // Add the reference to the SignedXml object.
                objSignedXml.AddReference(objReference);

				//If you sign  at the root level of the document, then making an enveloping signature.
				//Enveloped signature= used to sign some part of its containing document
				//If the XML signature contains signed data within itself it is called an enveloping signature
				//An XML signature used to sign a resource outside its containing XML document is called a detached signature
				objSignedXml.ComputeSignature();

                // Get the XML representation of the signature and save
                // it to an XmlElement object.
                XmlElement  xmlDigitalSignature = objSignedXml.GetXml();

                // Append the element to the XML document.
                result.DocumentElement.AppendChild(xmlDigitalSignature);
			}
			catch (Exception e)
			{
				throw new PeppolSecurityException(e.Message, e);
			}
		}
	}
}