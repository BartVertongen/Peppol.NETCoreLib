
using System.Security.Cryptography.X509Certificates;


namespace VertSoft.Peppol.Security.Xmldsig
{
	internal class X509KeySelector //: KeySelector
	{
        public enum Purpose {SIGN, VERIFY, ENCRYPT, DECRYPT };

        public X509Certificate2 Certificate { get; private set; }

        public class KeySelectorResult/*AnonymousInnerClass*/ //: KeySelectorResult
        {
            private readonly X509KeySelector outerInstance;

            public PublicKey Key { get; private set; }

            public KeySelectorResult/*AnonymousInnerClass*/(X509KeySelector outerInstance, PublicKey key)
            {
                this.outerInstance = outerInstance;
                this.Key = key;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyInfo"></param>
        /// <param name="purpose"></param>
        /// <param name="method">can be xmldsig Canonocalization method, DigestMethod, SignatureMethod, Transform</param>
        /// <param name="context"></param>
        /// <returns></returns>
        //ORIGINAL LINE: public KeySelectorResult select(javax.xml.crypto.dsig.keyinfo.KeyInfo keyInfo
        //                  , KeySelector.Purpose purpose, AlgorithmMethod method, XMLCryptoContext context) throws KeySelectorException
  //      public virtual KeySelectorResult select(KeyInfo keyInfo, Purpose purpose, /*AlgorithmMethod*/object method, SignedXml context)
		//{
		//	System.Collections.IEnumerator ki = keyInfo.GetEnumerator();
		//	while (ki.MoveNext())
		//	{
		//		object info = ki.Current;
		//		if (!(ki.Current is X509DataType))
		//		{
		//			continue;
		//		}

		//		X509DataType x509Data = (X509DataType)info;
		//		System.Collections.IEnumerator xi = x509Data.Items.GetEnumerator();
		//		while (xi.MoveNext())
		//		{
		//			object o = xi.Current;
		//			if (!(xi.Current is X509Certificate))
		//			{
		//				continue;
		//			}
		//			this.Certificate = (X509Certificate2) o;
		//			PublicKey key = Certificate.PublicKey;

		//			// Make sure the algorithm is compatible with the method.
		//			if (algEquals(method.ToString(), key.ToString()))
		//			{
		//				return new KeySelectorResult(this, key);
		//			}
		//		}
		//	}
		//	throw new /*KeySelector*/Exception("No key found!");
		//}


		//private bool algEquals(string algURI, string algName)
		//{
		//	return ((algName.Equals("DSA", StringComparison.OrdinalIgnoreCase) 
  //                          && algURI.Equals(SignatureMethod.DSA_SHA1, StringComparison.OrdinalIgnoreCase)) 
  //                  || (algName.Equals("RSA", StringComparison.OrdinalIgnoreCase) 
  //                          && algURI.Equals(SignatureMethod.RSA_SHA1, StringComparison.OrdinalIgnoreCase)) 
  //                  || (algName.Equals("RSA", StringComparison.OrdinalIgnoreCase) 
  //                          && algURI.Equals(ExtraSignatureMethod.RSA_SHA256, StringComparison.OrdinalIgnoreCase)) 
  //                  || (algName.Equals("RSA", StringComparison.OrdinalIgnoreCase) 
  //                          && algURI.Equals(ExtraSignatureMethod.RSA_SHA512, StringComparison.OrdinalIgnoreCase)));
		//}
	}
}