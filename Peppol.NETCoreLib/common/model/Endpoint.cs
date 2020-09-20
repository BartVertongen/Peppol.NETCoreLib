
using System;
using System.Security.Cryptography.X509Certificates;
using VertSoft.Peppol.Common.Api;
using VertSoft.Peppol.Common.Model.Lang;


namespace VertSoft.Peppol.Common.Model
{	
	/// <summary>
	/// This class has a TransportProfile, Adress, Certificate and a Period
	/// </summary>
	[Serializable]
	public class Endpoint : ISimpleEndpoint
	{
		//private readonly TransportProfile transportProfile;

		//private readonly Uri address;

		//private readonly X509Certificate certificate;

		//private readonly Period period;

		/*public static Endpoint of(TransportProfile transportProfile, Uri address, X509Certificate certificate)
		{
			return new Endpoint(transportProfile, address, certificate, null);
		}

		public static Endpoint of(TransportProfile transportProfile, Uri address, X509Certificate certificate, Period period)
		{
			return new Endpoint(transportProfile, address, certificate, period);
		}*/

		public Endpoint(TransportProfile transportProfile, Uri address, X509Certificate certificate, Period period = null)
		{
			this.TransportProfile = transportProfile;
			this.Address = address;
			this.Certificate = certificate;
			this.Period = period;
		}

		public virtual TransportProfile TransportProfile { get; set; }


		public virtual Uri Address { get; set; }

		public virtual X509Certificate Certificate { get; set; }

		public virtual Period Period { get; set; }


		public override bool Equals(object o)
		{
			if (this == o)
			{
				return true;
			}
			if (o == null || this.GetType() != o.GetType())
			{
				return false;
			}
			Endpoint that = (Endpoint) o;
            if (!this.TransportProfile.Equals(that.TransportProfile)
                        || !this.Address.Equals(that.Address))
            {
                return false;
            }
            bool bSameRefCertificate = false;
            bool bSameRefPeriod = false; 
            //Same reference or both null
            if (this.Certificate == that.Certificate)
            {
                bSameRefCertificate = true;
            }
            if (this.Period == that.Period)
            {
                bSameRefPeriod = true;
            }
            if (bSameRefPeriod && bSameRefCertificate)
                return true;
            else if (bSameRefPeriod && !bSameRefCertificate)
                return false;
            else if (!bSameRefCertificate && (this.Certificate == null || that.Certificate == null))
                return false;
            else if (!bSameRefPeriod && (this.Period == null || that.Period == null))
                return false;
            else if (bSameRefPeriod)
                return (this.Certificate.Equals(that.Certificate));
            else if (bSameRefCertificate)
                return this.Period.Equals(that.Period);
            else return (this.Certificate.Equals(that.Certificate)
                        && this.Period.Equals(that.Period));
		}

		public override int GetHashCode()
		{
            int h1 = TransportProfile.GetHashCode();
            int h2 = Address.GetHashCode();
            int h12 = ((h1 << 5) + h1) ^ h2;
            int h3 = Certificate.GetHashCode();
            int h4 = (Period == null ? 0: Period.GetHashCode());
            int h34 = ((h3 << 5) + h3) ^ h4;
            int h = ((h12 << 5) + h12) ^ h34;
            return h;
		}

		public override string ToString()
		{
			return "Endpoint{" +
					"transportProfile=" + TransportProfile +
					", address=" + Address +
					", certificate=" + Certificate +
					", period=" + Period +
					'}';
		}
	}
}