
using VertSoft.Peppol.Common.Model;
using VertSoft.Peppol.Lookup.Api;
using System;


namespace VertSoft.Peppol.lookup.provider
{
    public class DefaultProvider : IMetadataProvider
	{

		public virtual Uri resolveDocumentIdentifiers(Uri location, ParticipantIdentifier participant)
		{
            //What does URI.resolve do?
            string strLocation = location.ToString() + string.Format("/{0}", participant.UrlEncoded());
            return new Uri(strLocation);
            //return location.resolve(string.Format("/{0}", participant.urlencoded()));
		}

		public virtual Uri resolveServiceMetadata(Uri location, ParticipantIdentifier participant, DocumentTypeIdentifier documentType)
		{
            string strLocation = location.ToString() + string.Format("/{0}", participant.UrlEncoded());
            strLocation += string.Format("/{0}/services/{1}", participant.UrlEncoded(), documentType.UrlEncoded());
            return new Uri(strLocation);
            //return location.resolve(string.Format("/{0}/services/{1}", participantIdentifier.urlencoded(), documentTypeIdentifier.urlencoded()));
		}
	}
}