using System;
using System.IO;

namespace no.difi.certvalidator.util
{

	public class CrlUtils
	{
		//private static CertificateFactory certificateFactory;

		static CrlUtils()
		{
			try
			{
				//certificateFactory = CertificateFactory.getInstance("X.509");
			}
			catch (/*Certificate*/Exception e)
			{
				throw new System.InvalidOperationException(e.Message, e);
			}
		}


        //ORIGINAL LINE: public static X509CRL load(java.io.InputStream inputStream) throws CRLException
		public static /*X509CRL*/object load(Stream inputStream)
		{
            return (/*X509CRL*/object)null;// certificateFactory.generateCRL(inputStream);
		}


        //ORIGINAL LINE: public static void save(java.io.OutputStream outputStream, X509CRL crl) throws CRLException, java.io.IOException
		public static void save(Stream outputStream, /*X509CRL*/object crl)
		{
			outputStream.WriteByte(/*crl.Encoded*/(byte)1);
		}
	}
}