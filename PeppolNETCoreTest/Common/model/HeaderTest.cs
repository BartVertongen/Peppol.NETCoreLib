
using System;
using System.Diagnostics;
using VertSoft.Peppol.Common.Model.Lang;


namespace VertSoft.Peppol.Common.Model
{
	public class HeaderTest
	{
		public virtual void simple()
		{
			Header header = Header.newInstance().Sender(ParticipantIdentifier.of("9908:987654325"))
                                    .Receiver(ParticipantIdentifier.of("9908:123456785"))
                                    .Process(ProcessIdentifier.of("urn:www.cenbii.eu:profile:bii04:ver1.0"))
                                    .DocumentType(DocumentTypeIdentifier.of("urn:oasis:names:specification:ubl:schema:xsd:Invoice-2::Invoice" 
                                                + "##urn:www.cenbii.eu:transaction:biicoretrdm010:ver1.0:#urn:www.peppol.eu:bis:peppol4a:ver1.0::2.0"))
                                    .InstanceType(InstanceType.of("urn:oasis:names:specification:ubl:schema:xsd:Invoice-2", "Invoice", "2.0"))
                                    .CreationTimestamp(DateTime.Now).Identifier(InstanceIdentifier.generateUUID());

			Header header2 = Header.newInstance().Sender(ParticipantIdentifier.of("9908:987654325"))
                                    .Receiver(ParticipantIdentifier.of("9908:123456785"))
                                    .Process(ProcessIdentifier.of("urn:www.cenbii.eu:profile:bii04:ver1.0"))
                                    .DocumentType(DocumentTypeIdentifier.of("urn:oasis:names:specification:ubl:schema:xsd:Invoice-2::Invoice" 
                                                + "##urn:www.cenbii.eu:transaction:biicoretrdm010:ver1.0:#urn:www.peppol.eu:bis:peppol4a:ver1.0::2.0"))
                                    .InstanceType(InstanceType.of("urn:oasis:names:specification:ubl:schema:xsd:Invoice-2", "Invoice", "2.0"))
                                    .CreationTimestamp(DateTime.Now).Identifier(InstanceIdentifier.generateUUID());

            Debug.Assert(header.Equals(header2));
            Debug.Assert(header.GetHashCode() != null);
            Debug.Assert(header.ToString() != null);

            Debug.Assert(header.Equals(header));
            Debug.Assert(!header.Equals("Header"));
            Debug.Assert(!header.Equals(null));

            Debug.Assert(header.getSender().Equals(header2.getSender()));
            Debug.Assert(header.getReceiver().Equals(header2.getReceiver()));
            Debug.Assert(header.getProcess().Equals(header2.getProcess()));
            Debug.Assert(header.getDocumentType().Equals(header2.getDocumentType()));
            Debug.Assert(header.getInstanceType().Equals(header2.getInstanceType()));
            Debug.Assert(!header.getCreationTimestamp().Equals(header2.getCreationTimestamp()));//both are not created at the exact same time .
            Debug.Assert(!header.getIdentifier().Equals(header2.getIdentifier())); //the identifier will always be unique
		}


		public virtual void shortOfMethod()
		{
			Header header = Header.of(ParticipantIdentifier.of("9908:98764325")
                    , ParticipantIdentifier.of("9908:123456785")
                            , ProcessIdentifier.of("Some:Process"), DocumentTypeIdentifier.of("Some:Document"));

            Debug.Assert(header.Equals(Header.of(ParticipantIdentifier.of("9908:98764325")
                    , ParticipantIdentifier.of("9908:123456785"), ProcessIdentifier.of("Some:Process")
                    , DocumentTypeIdentifier.of("Some:Document"))));
            Debug.Assert(header.Equals(Header.of(ParticipantIdentifier.of("9908:98764325")
                    , ParticipantIdentifier.of("9908:123456785"), ProcessIdentifier.of("Some:Process")
                    , DocumentTypeIdentifier.of("Some:Document"), null, null, DateTime.Now)));
            Debug.Assert(!header.Equals(Header.of(ParticipantIdentifier.of("9908:98764321"), ParticipantIdentifier.of("9908:123456785"), ProcessIdentifier.of("Some:Process"), DocumentTypeIdentifier.of("Some:Document"))));
            Debug.Assert(!header.Equals(Header.of(ParticipantIdentifier.of("9908:98764325"), ParticipantIdentifier.of("9908:123456789"), ProcessIdentifier.of("Some:Process"), DocumentTypeIdentifier.of("Some:Document"))));
            Debug.Assert(!header.Equals(Header.of(ParticipantIdentifier.of("9908:98764325"), ParticipantIdentifier.of("9908:123456785"), ProcessIdentifier.of("Other:Process"), DocumentTypeIdentifier.of("Some:Document"))));
            Debug.Assert(!header.Equals(Header.of(ParticipantIdentifier.of("9908:98764325"), ParticipantIdentifier.of("9908:123456785"), ProcessIdentifier.of("Some:Process"), DocumentTypeIdentifier.of("Other:Document"))));
            Debug.Assert(!header.Equals(Header.of(ParticipantIdentifier.of("9908:98764325"), ParticipantIdentifier.of("9908:123456785"), ProcessIdentifier.of("Some:Process"), DocumentTypeIdentifier.of("Some:Document")).InstanceType(InstanceType.of("Some", "Type", "1.0"))));
            Debug.Assert(header.Equals(Header.of(ParticipantIdentifier.of("9908:98764325"), ParticipantIdentifier.of("9908:123456785"), ProcessIdentifier.of("Some:Process"), DocumentTypeIdentifier.of("Some:Document")).Identifier(InstanceIdentifier.generateUUID())));
            Debug.Assert(header.Equals(Header.of(ParticipantIdentifier.of("9908:98764325"), ParticipantIdentifier.of("9908:123456785"), ProcessIdentifier.of("Some:Process"), DocumentTypeIdentifier.of("Some:Document")).CreationTimestamp(DateTime.Now)));
            Debug.Assert(!header.InstanceType(InstanceType.of("Some", "Type", "1.0")).Equals(Header.of(ParticipantIdentifier.of("9908:98764325"), ParticipantIdentifier.of("9908:123456785"), ProcessIdentifier.of("Some:Process"), DocumentTypeIdentifier.of("Some:Document"))));
            Debug.Assert(header.Identifier(InstanceIdentifier.generateUUID()).Equals(Header.of(ParticipantIdentifier.of("9908:98764325"), ParticipantIdentifier.of("9908:123456785"), ProcessIdentifier.of("Some:Process"), DocumentTypeIdentifier.of("Some:Document"))));
            Debug.Assert(header.CreationTimestamp(DateTime.Now).Equals(Header.of(ParticipantIdentifier.of("9908:98764325"), ParticipantIdentifier.of("9908:123456785"), ProcessIdentifier.of("Some:Process"), DocumentTypeIdentifier.of("Some:Document"))));
            Debug.Assert(header.GetHashCode() != null);
		}
	}
}