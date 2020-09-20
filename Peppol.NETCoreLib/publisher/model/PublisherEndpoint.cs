
using VertSoft.Peppol.Common.Api;
using VertSoft.Peppol.Common.Model;
using System;
using System.Security.Cryptography.X509Certificates;
using VertSoft.Peppol.Common.Model.Lang;


namespace VertSoft.Peppol.Publisher.Model
{
    /// <summary>
    /// </summary>
    public class PublisherEndpoint : Endpoint
	{


		public PublisherEndpoint(TransportProfile transportProfile, Uri address, X509Certificate certificate
                                            , Period period = null, string description="", string technicalContact="")
								: base(transportProfile, address, certificate, period)			
		{
			base.TransportProfile = transportProfile;
			base.Address = address;
			base.Certificate = certificate;
			base.Period = period;
			this.Description = description;
			this.TechnicalContact = technicalContact;
		}

		public virtual string Description { get; private set; }

		public string TechnicalContact { get; private set; }
	}
}