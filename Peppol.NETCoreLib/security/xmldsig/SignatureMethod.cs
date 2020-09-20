

namespace VertSoft.Peppol.Security.Xmldsig
{
    public static class SignatureMethod
    {
        public const string DSA_SHA1 = "http://www.w3.org/2001/04/xmldsig-more#dsa-sha1";

        public const string RSA_SHA1 = "http://www.w3.org/2001/04/xmldsig-more#rsa-sha1";

		//Extra
		public const string RSA_SHA256 = "http://www.w3.org/2001/04/xmldsig-more#rsa-sha256";

		public const string RSA_SHA512 = "http://www.w3.org/2001/04/xmldsig-more#rsa-sha512";
	}
}