
using System;
using System.Diagnostics;
using VertSoft.Peppol.Common.Model;


namespace VertSoft.Peppol.Lookup.Model
{
	public class DocumentTypeIdentifierWithUriTest
	{
		public virtual void simple()
		{
			DocumentTypeIdentifierWithUri documentTypeIdentifierWithUri 
                    = DocumentTypeIdentifierWithUri.of("9908:991825827", DocumentTypeIdentifier.DEFAULT_SCHEME, new Uri("http://difi.no/"));

			Debug.Assert(documentTypeIdentifierWithUri.Identifier != null);
            Debug.Assert(documentTypeIdentifierWithUri.Scheme != null);
            Debug.Assert(documentTypeIdentifierWithUri.Uri != null);
		}
	}
}