using System;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;


namespace VertSoft.Peppol.Common.Model
{

	public class SignedTest
	{
		public virtual void simple()
		{
			X509Certificate certificate = new X509Certificate();
			DateTime date = DateTime.Now;

			Signed<string, X509Certificate> signed = Signed<string, X509Certificate>.of("1", certificate);

			Debug.Assert(signed.Content == "1");
            Debug.Assert(signed.Certificate != null);
            Debug.Assert(signed.Timestamp == null);

            Debug.Assert(signed.Equals(signed));
            Debug.Assert(signed.Equals(Signed<string, X509Certificate>.of("1", certificate)));
            Debug.Assert(!signed.Equals(Signed<string, X509Certificate>.of("1", certificate, date)));
            Debug.Assert(!signed.Equals(Signed<string, X509Certificate>.of("2", certificate)));
            Debug.Assert(!signed.Equals(null));
            Debug.Assert(!signed.Equals("1"));
            Debug.Assert(signed.Equals(Signed<string, X509Certificate>.of("1", new X509Certificate())));
            Debug.Assert(!Signed<string, X509Certificate>.of("1", new X509Certificate(), date).Equals(signed));
            Debug.Assert(!Signed<string, X509Certificate>.of("1", new X509Certificate(), date).Equals(signed));
            Debug.Assert(Signed<string, X509Certificate>.of("1", certificate, date).Equals(Signed<string, X509Certificate>.of("1", certificate, date)));
            DateTime date2 = DateTime.Now;
            Debug.Assert(!Signed<string, X509Certificate>.of("1", certificate, date).Equals(Signed<string, X509Certificate>.of("1", certificate, date2)));

            Debug.Assert(signed.GetHashCode() != null);
            Debug.Assert(Signed<string, X509Certificate>.of("1", certificate, date).GetHashCode() != null);

            Debug.Assert(signed.ToString().Contains("1"));
		}


		public virtual void simpleSubset()
		{
			X509Certificate certificate = new X509Certificate();

			Signed<string, X509Certificate> signed = Signed<string, X509Certificate>.of("Text", certificate);

            Debug.Assert(signed.Certificate == certificate);

			signed = signed.ofSubset(signed.Content.Substring(1));

            Debug.Assert(signed.Certificate == certificate);
		}
	}
}