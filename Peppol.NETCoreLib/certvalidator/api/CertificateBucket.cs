using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;


namespace no.difi.certvalidator.api
{
	/// <summary>
	/// Defines bucket for certificate allowing customized storage of certificates.
	/// </summary>
	public interface CertificateBucket : IEnumerable<X509Certificate2>
	{
		/// <summary>
		/// Find certificate by subject.
		/// </summary>
		/// <param name="principal"> Principal representing certificate to be found. </param>
		/// <returns> Certificate if found, otherwise null. </returns>
        /// <remarks>You can make a X500DistinguishedName from the Subject string</remarks>
		/// <exception cref="CertificateBucketException"> </exception>
		X509Certificate2 findBySubject(X500DistinguishedName principal);

        List<X509Certificate2> asList();
        /*{
            return StreamSupport.stream(spliterator(), false).collect(Collectors.toList());
        }*/
    }
}