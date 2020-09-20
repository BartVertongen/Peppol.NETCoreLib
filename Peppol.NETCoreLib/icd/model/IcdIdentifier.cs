
using System;
using VertSoft.Peppol.Common.Model;
using VertSoft.Peppol.Icd.Api;


namespace VertSoft.Peppol.Icd.Model
{
	/// <summary>
	///
	/// </summary>
	[Serializable]
	public class IcdIdentifier
	{

		//private readonly Icd icd;

		//private readonly string identifier;

		public static IcdIdentifier Of(IIcd icd, string identifier)
		{
			return new IcdIdentifier(icd, identifier);
		}

		private IcdIdentifier(IIcd icd, string identifier)
		{
			this.Icd = icd;
			this.Identifier = identifier;
		}

		public IIcd Icd { get; private set; }


		public string Identifier { get; private set; }

		public virtual ParticipantIdentifier ToParticipantIdentifier()
		{
			return ParticipantIdentifier.Of(string.Format("{0}:{1}", Icd.Code, this.Identifier), Icd.Scheme);
		}

		public override string ToString()
		{
			return string.Format("{0}::{1}:{2}", Icd.Scheme, Icd.Code, this.Identifier);
		}
	}
}