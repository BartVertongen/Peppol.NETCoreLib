
using System.Diagnostics;
using VertSoft.Peppol.Common.Lang;


namespace VertSoft.Peppol.Common.Model
{	
	public class DocumentTypeIdentifierTest
	{
		public virtual void simple()
		{
			string documentIdentifier = "urn:oasis:names:specification:ubl:schema:xsd:CreditNote-2::CreditNote##" 
                    + "urn:www.cenbii.eu:transaction:biitrns014:ver2.0" 
                    + ":extended:urn:www.peppol.eu:bis:peppol5a:ver2.0::2.1";
			Debug.Assert(DocumentTypeIdentifier.of(documentIdentifier).Identifier == documentIdentifier);

            Debug.Assert(Scheme.of("bdx-ubl").Equals(DocumentTypeIdentifier.of(documentIdentifier, Scheme.of("bdx-ubl")).Scheme) );

            Debug.Assert(DocumentTypeIdentifier.of(documentIdentifier).UrlEncoded().Contains("CreditNote"));

			DocumentTypeIdentifier documentTypeIdentifier = DocumentTypeIdentifier.of(documentIdentifier);

            Debug.Assert(documentTypeIdentifier.Equals(documentTypeIdentifier));
            Debug.Assert(!documentTypeIdentifier.Equals(documentIdentifier));
            Debug.Assert(!documentTypeIdentifier.Equals(null));
		}

        
        //ORIGINAL LINE: @Test public void simpleParse() throws Exception
		public virtual void simpleParse()
		{
			DocumentTypeIdentifier documentTypeIdentifier = DocumentTypeIdentifier.parse("qualifier::identifier");

            Debug.Assert(documentTypeIdentifier.Identifier == "identifier");
            Debug.Assert(documentTypeIdentifier.Scheme.Identifier == "qualifier");

			try
			{
				DocumentTypeIdentifier.parse("value");
                Debug.Assert(false);
			}
			catch (PeppolParsingException)
			{
				// Valid!
			}
		}
	}
}