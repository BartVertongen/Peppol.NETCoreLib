
using System;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;


namespace VertSoft.Peppol.Common.Model
{
	public class EndpointTest
	{
		public virtual void simple()
		{
			Endpoint endpoint1 = new Endpoint(TransportProfile.PEPPOL_AS2_1_0, new Uri("https://ap.example.com/as2"), new X509Certificate2());
			Endpoint endpoint2 = new Endpoint(TransportProfile.PEPPOL_AS2_1_0, new Uri("https://ap.example.com/as2"), null);
			Endpoint endpoint3 = new Endpoint(TransportProfile.PEPPOL_AS2_1_0, new Uri("https://ap.example.com/as2"), null);

			Debug.Assert(endpoint1.TransportProfile == TransportProfile.AS2_1_0);
            Debug.Assert(endpoint1.Address == new Uri("https://ap.example.com/as2"));
            Debug.Assert(endpoint1.Certificate != null);

            Debug.Assert(endpoint1.Equals(endpoint1));
            Debug.Assert(!endpoint1.Equals("Endpoint"));
            Debug.Assert(!endpoint1.Equals(null));

            Debug.Assert(endpoint1.GetHashCode() != null);

            Debug.Assert(!endpoint1.Equals(new Endpoint(TransportProfile.PEPPOL_AS2_1_0, new Uri("https://ap.example.com/as2"), new X509Certificate2())));

            Debug.Assert(!endpoint1.Equals(new Endpoint(TransportProfile.AS4, new Uri("https://ap.example.com/as2"), new X509Certificate2())));

            Debug.Assert(!endpoint1.Equals(new Endpoint(TransportProfile.PEPPOL_AS2_1_0, new Uri("https://ap.example.com/as"), new X509Certificate2())));

            Debug.Assert(!endpoint1.Equals(new Endpoint(TransportProfile.PEPPOL_AS2_1_0, new Uri("https://ap.example.com/as2"), new X509Certificate2())));

            Debug.Assert(!endpoint1.Equals(endpoint2));
            Debug.Assert(!endpoint2.Equals(endpoint1));
            Debug.Assert(endpoint2.Equals(endpoint3));

            Debug.Assert(endpoint1.ToString() != null);
		}
	}
}