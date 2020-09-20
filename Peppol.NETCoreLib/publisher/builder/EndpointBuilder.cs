
using System;
using System.Security.Cryptography.X509Certificates;
using VertSoft.Peppol.Common.Model;
using VertSoft.Peppol.Common.Model.Lang;
using VertSoft.Peppol.Publisher.Model;


namespace VertSoft.Peppol.Publisher.Builder
{
	/// <summary>
	/// Helps to build a n Endpoint object.
	/// </summary>
	public class EndpointBuilder
	{

		private TransportProfile _TransportProfile;

		private Uri _Address;

		private X509Certificate _Certificate;

		private DateTime _ActivationDate;

		private DateTime _ExpirationDate;

		private string _Description;

		private string _TechnicalContact;

		public static EndpointBuilder NewInstance()
		{
			return new EndpointBuilder();
		}

		public virtual EndpointBuilder TransportProfile(TransportProfile transportProfile)
		{
			this._TransportProfile = transportProfile;
			return this;
		}

		public virtual EndpointBuilder Address(Uri address)
		{
			this._Address = address;
			return this;
		}

		public virtual EndpointBuilder Certificate(X509Certificate2 certificate)
		{
			this._Certificate = certificate;
			return this;
		}

		public virtual EndpointBuilder ActivationDate(DateTime activationDate)
		{
			this._ActivationDate= activationDate;
			return this;
		}

		public virtual EndpointBuilder ExpirationDate(DateTime expirationDate)
		{
			this._ExpirationDate = expirationDate;
			return this;
		}

		public virtual EndpointBuilder Description(string description)
		{
			this._Description = description;
			return this;
		}

		public virtual EndpointBuilder TechnicalContact(string technicalContact)
		{
			this._TechnicalContact = technicalContact;
			return this;
		}

		public virtual PublisherEndpoint Build()
		{
			Period objPeriod = null;

			if (this._ActivationDate != null || this._ExpirationDate != null)
			{
				objPeriod = (Period)Period.Of(this._ActivationDate, this._ExpirationDate);
			}

			return new PublisherEndpoint(this._TransportProfile, this._Address
                        , this._Certificate, objPeriod, this._Description, this._TechnicalContact);
		}
	}
}