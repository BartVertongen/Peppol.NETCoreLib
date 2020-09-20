
using System;
using VertSoft.Peppol.Common.Model;


namespace VertSoft.Peppol.Lookup.Model
{
	[Serializable]
	public class DocumentTypeIdentifierWithUri : DocumentTypeIdentifier
	{
		public static DocumentTypeIdentifierWithUri of(string identifier, Scheme scheme, Uri uri)
		{
			return new DocumentTypeIdentifierWithUri(identifier, scheme, uri);
		}

		private DocumentTypeIdentifierWithUri(string identifier, Scheme scheme, Uri uri) : base(identifier, scheme)
		{
			this.Uri = uri;
		}

		public Uri Uri { get; private set; }
	}
}