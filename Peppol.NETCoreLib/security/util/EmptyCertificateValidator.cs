
using VertSoft.Peppol.Security.Api;
using System;
using System.Security.Cryptography.X509Certificates;
using VertSoft.Peppol.Common.Code;


namespace VertSoft.Peppol.Security.Util
{

    //A validator needs to have a method validate with argument Service and certificate
/*	[Obsolete]
	public class EmptyCertificateValidator //: CertificateValidator
	{
        //We use this instance of Validator in the Validate method ?
		public static readonly CertificateValidator INSTANCE = CertificateValidators.EMPTY;


        //throws PeppolSecurityException
		public virtual void validate(Service service, X509Certificate2 certificate)
		{
			// No action
			//It should throw an exception if not Valid?
			INSTANCE(service, certificate);
		}
	}*/
}