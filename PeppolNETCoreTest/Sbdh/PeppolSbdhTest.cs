
using System;
using System.Diagnostics;
using System.IO;
using VertSoft.Peppol.Common.Model;
using VertSoft.Peppol.Common.Model.Lang;
using VertSoft.Peppol.Sbdh.Lang;


namespace VertSoft.Peppol.Sbdh
{
	public class PeppolSbdhTest
	{
		//throws java.io.IOException, SbdhException
		public virtual void version100()
		{
			using (FileStream inputStream = new FileStream("./peppol-sbdh-1.00.xml", FileMode.Open))
			{
				Header header = SbdhReader.Read(inputStream);

				Debug.Assert(header.getSender().Equals(ParticipantIdentifier.Of("9908:810418052", ParticipantIdentifier.DEFAULT_SCHEME)));
				Debug.Assert(header.getReceiver().Equals(ParticipantIdentifier.Of("9908:810418052", ParticipantIdentifier.DEFAULT_SCHEME)));
				Debug.Assert(header.getDocumentType().Equals(
                        DocumentTypeIdentifier
                            .of("urn:oasis:names:specification:ubl:schema:xsd:Invoice-2::Invoice##urn:www.cenbii.eu:transaction:biitrns010:ver2.0:extended:urn:www.peppol.eu:bis:peppol4a:ver2.0::2.1", DocumentTypeIdentifier.DEFAULT_SCHEME)));
				Debug.Assert(header.getProcess().Equals(ProcessIdentifier.of("urn:www.cenbii.eu:profile:bii04:ver2.0", ProcessIdentifier.DEFAULT_SCHEME)));
                Debug.Assert(header.getCreationTimestamp() == new DateTime(2017, 12, 6, 10, 17, 5, 734) );
				Debug.Assert(header.getIdentifier().Equals( InstanceIdentifier.of("7f58475e-a9cc-4386-904c-cf09c2662c19") ));
				Debug.Assert(header.getInstanceType().Standard == "urn:oasis:names:specification:ubl:schema:xsd:Invoice-2");
				Debug.Assert(header.getInstanceType().Type == "Invoice");
				Debug.Assert(header.getInstanceType().Version == "2.1");
			}
		}

        //throws IOException, SbdhException
		public virtual void version101()
		{
			using (FileStream inputStream = new FileStream("./peppol-sbdh-1.01.xml", FileMode.Open))
			{
				Header header = SbdhReader.Read(inputStream);

				Debug.Assert(header.getSender().Equals( ParticipantIdentifier.Of("9908:810418052", ParticipantIdentifier.DEFAULT_SCHEME)));
				Debug.Assert(header.getReceiver().Equals(ParticipantIdentifier.Of("9908:810418052", ParticipantIdentifier.DEFAULT_SCHEME)));
				Debug.Assert(header.getDocumentType().Equals(DocumentTypeIdentifier.of("urn:cen.eu:en16931:2017", Scheme.of("busdox-docid-edifact"))));
				Debug.Assert(header.getProcess().Equals(ProcessIdentifier.NO_PROCESS));
				Debug.Assert(header.getCreationTimestamp() == new DateTime(2017, 12, 6, 10, 17, 5, 734));
                Debug.Assert(header.getIdentifier().Equals(InstanceIdentifier.of("7f58475e-a9cc-4386-904c-cf09c2662c19")));
				Debug.Assert(header.getInstanceType().Standard == "EDIFACT");
				Debug.Assert(header.getInstanceType().Type == "INVOIC");
				Debug.Assert(header.getInstanceType().Version == "D.14B");
			}
		}
	}
}