
using System;
using System.IO;
using DigestMethod = no.difi.vefa.peppol.common.code.DigestMethod;
using no.difi.vefa.peppol.common.model;


namespace no.difi.vefa.peppol.evidence.rem
{
	public class EvidenceCombinedTest
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void simple() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void simple()
		{
			MemoryStream outputStream = new MemoryStream();

			EvidenceWriter.write(outputStream, EvidenceTest.EVIDENCE);

			Evidence newEvidence = EvidenceReader.read(new MemoryStream(outputStream.toByteArray()));

			Assert.assertEquals(newEvidence, EvidenceTest.EVIDENCE);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void noDocumentIdentifier() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void noDocumentIdentifier()
		{
			MemoryStream outputStream = new MemoryStream();

			EvidenceWriter.write(outputStream, EvidenceTest.EVIDENCE.documentIdentifier(null));

			Evidence newEvidence = EvidenceReader.read(new MemoryStream(outputStream.toByteArray()));

			Assert.assertEquals(newEvidence, EvidenceTest.EVIDENCE.documentIdentifier(null));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void noPeppolExtension() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void noPeppolExtension()
		{
			Evidence evidence = Evidence.newInstance().type(EvidenceTypeInstance.DELIVERY_NON_DELIVERY_TO_RECIPIENT).eventCode(EventCode.ACCEPTANCE).eventReason(EventReason.OTHER).issuer("Java Testing").evidenceIdentifier(InstanceIdentifier.generateUUID()).timestamp(DateTime.Now).sender(ParticipantIdentifier.of("9908:123456785")).receiver(ParticipantIdentifier.of("9908:987654325")).documentTypeIdentifier(DocumentTypeIdentifier.of("urn:oasis:names:specification:ubl:schema:xsd:Tender-2::Tender" + "##urn:www.cenbii.eu:transaction:biitrdm090:ver3.0::2.1", Scheme_Fields.NONE)).messageIdentifier(InstanceIdentifier.generateUUID()).digest(Digest.of(DigestMethod.SHA256, "VGhpc0lzQVNIQTI1NkRpZ2VzdA==".GetBytes()));

			Assert.assertFalse(evidence.hasPeppolExtensionValues());

			MemoryStream outputStream = new MemoryStream();

			EvidenceWriter.write(outputStream, evidence);

			Evidence newEvidence = EvidenceReader.read(new MemoryStream(outputStream.toByteArray()));

			Assert.assertEquals(newEvidence, evidence);

			Assert.assertFalse(newEvidence.hasPeppolExtensionValues());
		}
	}
}