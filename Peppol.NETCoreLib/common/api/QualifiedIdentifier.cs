
using VertSoft.Peppol.Common.Model;


namespace VertSoft.Peppol.Common.Api
{
	public interface QualifiedIdentifier
	{
		Scheme Scheme {get;}

		/// <summary>
		/// Identifier of participant.
		/// </summary>
		/// <returns> Identifier. </returns>
		string Identifier {get;}

		string UrlEncoded();
	}
}