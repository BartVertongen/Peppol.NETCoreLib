using System;

/*
 * Copyright 2015-2017 Direktoratet for forvaltning og IKT
 *
 * This source code is subject to dual licensing:
 *
 *
 * Licensed under the EUPL, Version 1.1 or – as soon they
 * will be approved by the European Commission - subsequent
 * versions of the EUPL (the "Licence");
 *
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/.
 *
 *
 * See the Licence for the specific language governing
 * permissions and limitations under the Licence.
 */

namespace no.difi.vefa.peppol.evidence.rem
{
	using DigestMethod = no.difi.vefa.peppol.common.code.DigestMethod;
	using no.difi.vefa.peppol.common.model;
	//using TransmissionRole = no.difi.vefa.peppol.evidence.jaxb.receipt.TransmissionRole;


	public class EvidenceTest
	{

		public static readonly Evidence EVIDENCE = Evidence.newInstance().type(EvidenceTypeInstance.DELIVERY_NON_DELIVERY_TO_RECIPIENT).eventCode(EventCode.ACCEPTANCE).eventReason(EventReason.OTHER).issuer("Java Testing").evidenceIdentifier(InstanceIdentifier.generateUUID()).issuerPolicy("Some Policy").timestamp(DateTime.Now).sender(ParticipantIdentifier.of("9908:123456785")).receiver(ParticipantIdentifier.of("9908:987654325")).documentTypeIdentifier(DocumentTypeIdentifier.of("urn:oasis:names:specification:ubl:schema:xsd:Tender-2::Tender" + "##urn:www.cenbii.eu:transaction:biitrdm090:ver3.0" + "::2.1", Scheme_Fields.NONE)).documentIdentifier(InstanceIdentifier.generateUUID()).issuerPolicy("Some Policy").messageIdentifier(InstanceIdentifier.generateUUID()).digest(Digest.of(DigestMethod.SHA256, "VGhpc0lzQVNIQTI1NkRpZ2VzdA==".Bytes)).transportProtocol(TransportProtocol.AS2).transmissionRole(TransmissionRole.C_3).originalReceipt(Receipt.of("text/plain", "Hello World!".Bytes));

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void simpleToString()
		public virtual void simpleToString()
		{
			Assert.assertTrue(EVIDENCE.ToString().Contains("Tender-2"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void allowAddingNullReceipt()
		public virtual void allowAddingNullReceipt()
		{
			Evidence evidence = Evidence.newInstance();
			Assert.assertEquals(evidence.OriginalReceipts.Count, 0);

			evidence = evidence.originalReceipt(null);
			Assert.assertEquals(evidence.OriginalReceipts.Count, 0);

			evidence = evidence.originalReceipt(Receipt.of("Hello World!".GetBytes()));
			Assert.assertEquals(evidence.OriginalReceipts.Count, 1);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void simpleHasPeppolExtensionValues()
		public virtual void simpleHasPeppolExtensionValues()
		{
			Assert.assertFalse(Evidence.newInstance().hasPeppolExtensionValues());

			Assert.assertTrue(Evidence.newInstance().transmissionRole(TransmissionRole.C_2).hasPeppolExtensionValues());

			Assert.assertTrue(Evidence.newInstance().transportProtocol(TransportProtocol.INTERNAL).hasPeppolExtensionValues());

			Assert.assertTrue(Evidence.newInstance().originalReceipt(Receipt.of("Hello World!".GetBytes())).hasPeppolExtensionValues());

			Assert.assertTrue(EVIDENCE.hasPeppolExtensionValues());
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void simpleHashCode()
		public virtual void simpleHashCode()
		{
			Assert.assertNotNull(EVIDENCE.GetHashCode());
			Assert.assertNotNull(EVIDENCE.type(null).GetHashCode());
			Assert.assertNotNull(EVIDENCE.eventCode(null).GetHashCode());
			Assert.assertNotNull(EVIDENCE.eventReason(null).GetHashCode());
			Assert.assertNotNull(EVIDENCE.issuer(null).GetHashCode());
			Assert.assertNotNull(EVIDENCE.evidenceIdentifier(null).GetHashCode());
			Assert.assertNotNull(EVIDENCE.timestamp(null).GetHashCode());
			Assert.assertNotNull(EVIDENCE.sender(null).GetHashCode());
			Assert.assertNotNull(EVIDENCE.receiver(null).GetHashCode());
			Assert.assertNotNull(EVIDENCE.documentTypeIdentifier(null).GetHashCode());
			Assert.assertNotNull(EVIDENCE.documentIdentifier(null).GetHashCode());
			Assert.assertNotNull(EVIDENCE.issuerPolicy(null).GetHashCode());
			Assert.assertNotNull(EVIDENCE.digest(null).GetHashCode());
			Assert.assertNotNull(EVIDENCE.messageIdentifier(null).GetHashCode());
			Assert.assertNotNull(EVIDENCE.transportProtocol(null).GetHashCode());
			Assert.assertNotNull(EVIDENCE.transmissionRole(null).GetHashCode());
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void simpleEquals()
		public virtual void simpleEquals()
		{
			Assert.assertTrue(EVIDENCE.Equals(EVIDENCE));
			Assert.assertFalse(EVIDENCE.Equals(null));
			Assert.assertFalse(EVIDENCE.Equals("Test"));

			Assert.assertFalse(EVIDENCE.Equals(EVIDENCE.type(null)));
			Assert.assertFalse(EVIDENCE.Equals(EVIDENCE.eventCode(null)));
			Assert.assertFalse(EVIDENCE.Equals(EVIDENCE.eventReason(null)));
			Assert.assertFalse(EVIDENCE.Equals(EVIDENCE.issuer(null)));
			Assert.assertFalse(EVIDENCE.Equals(EVIDENCE.evidenceIdentifier(null)));
			Assert.assertFalse(EVIDENCE.Equals(EVIDENCE.timestamp(null)));
			Assert.assertFalse(EVIDENCE.Equals(EVIDENCE.sender(null)));
			Assert.assertFalse(EVIDENCE.Equals(EVIDENCE.receiver(null)));
			Assert.assertFalse(EVIDENCE.Equals(EVIDENCE.documentTypeIdentifier(null)));
			Assert.assertFalse(EVIDENCE.Equals(EVIDENCE.documentIdentifier(null)));
			Assert.assertFalse(EVIDENCE.Equals(EVIDENCE.issuerPolicy(null)));
			Assert.assertFalse(EVIDENCE.Equals(EVIDENCE.digest(null)));
			Assert.assertFalse(EVIDENCE.Equals(EVIDENCE.messageIdentifier(null)));
			Assert.assertFalse(EVIDENCE.Equals(EVIDENCE.transportProtocol(null)));
			Assert.assertFalse(EVIDENCE.Equals(EVIDENCE.transmissionRole(null)));

			Assert.assertFalse(EVIDENCE.type(null).Equals(EVIDENCE));
			Assert.assertFalse(EVIDENCE.eventCode(null).Equals(EVIDENCE));
			Assert.assertFalse(EVIDENCE.eventReason(null).Equals(EVIDENCE));
			Assert.assertFalse(EVIDENCE.issuer(null).Equals(EVIDENCE));
			Assert.assertFalse(EVIDENCE.evidenceIdentifier(null).Equals(EVIDENCE));
			Assert.assertFalse(EVIDENCE.timestamp(null).Equals(EVIDENCE));
			Assert.assertFalse(EVIDENCE.sender(null).Equals(EVIDENCE));
			Assert.assertFalse(EVIDENCE.receiver(null).Equals(EVIDENCE));
			Assert.assertFalse(EVIDENCE.documentTypeIdentifier(null).Equals(EVIDENCE));
			Assert.assertFalse(EVIDENCE.documentIdentifier(null).Equals(EVIDENCE));
			Assert.assertFalse(EVIDENCE.issuerPolicy(null).Equals(EVIDENCE));
			Assert.assertFalse(EVIDENCE.digest(null).Equals(EVIDENCE));
			Assert.assertFalse(EVIDENCE.messageIdentifier(null).Equals(EVIDENCE));
			Assert.assertFalse(EVIDENCE.transportProtocol(null).Equals(EVIDENCE));
			Assert.assertFalse(EVIDENCE.transmissionRole(null).Equals(EVIDENCE));

			Assert.assertTrue(EVIDENCE.type(null).Equals(EVIDENCE.type(null)));
			Assert.assertTrue(EVIDENCE.eventCode(null).Equals(EVIDENCE.eventCode(null)));
			Assert.assertTrue(EVIDENCE.eventReason(null).Equals(EVIDENCE.eventReason(null)));
			Assert.assertTrue(EVIDENCE.issuer(null).Equals(EVIDENCE.issuer(null)));
			Assert.assertTrue(EVIDENCE.evidenceIdentifier(null).Equals(EVIDENCE.evidenceIdentifier(null)));
			Assert.assertTrue(EVIDENCE.timestamp(null).Equals(EVIDENCE.timestamp(null)));
			Assert.assertTrue(EVIDENCE.sender(null).Equals(EVIDENCE.sender(null)));
			Assert.assertTrue(EVIDENCE.receiver(null).Equals(EVIDENCE.receiver(null)));
			Assert.assertTrue(EVIDENCE.documentTypeIdentifier(null).Equals(EVIDENCE.documentTypeIdentifier(null)));
			Assert.assertTrue(EVIDENCE.documentIdentifier(null).Equals(EVIDENCE.documentIdentifier(null)));
			Assert.assertTrue(EVIDENCE.issuerPolicy(null).Equals(EVIDENCE.issuerPolicy(null)));
			Assert.assertTrue(EVIDENCE.digest(null).Equals(EVIDENCE.digest(null)));
			Assert.assertTrue(EVIDENCE.messageIdentifier(null).Equals(EVIDENCE.messageIdentifier(null)));
			Assert.assertTrue(EVIDENCE.transportProtocol(null).Equals(EVIDENCE.transportProtocol(null)));
			Assert.assertTrue(EVIDENCE.transmissionRole(null).Equals(EVIDENCE.transmissionRole(null)));

			Assert.assertFalse(EVIDENCE.Equals(EVIDENCE.type(EvidenceTypeInstance.RELAY_REM_MD_ACCEPTANCE_REJECTION)));
			Assert.assertFalse(EVIDENCE.Equals(EVIDENCE.eventCode(EventCode.REJECTION)));
			Assert.assertFalse(EVIDENCE.Equals(EVIDENCE.eventReason(EventReason.MAILBOX_FULL)));
			Assert.assertFalse(EVIDENCE.Equals(EVIDENCE.issuer("Somebody")));
			Assert.assertFalse(EVIDENCE.Equals(EVIDENCE.evidenceIdentifier(InstanceIdentifier.generateUUID())));
			Assert.assertFalse(EVIDENCE.Equals(EVIDENCE.timestamp(new DateTime(DateTimeHelper.CurrentUnixTimeMillis() + (10 * 1000)))));
			Assert.assertFalse(EVIDENCE.Equals(EVIDENCE.sender(ParticipantIdentifier.of("9908:999999999"))));
			Assert.assertFalse(EVIDENCE.Equals(EVIDENCE.receiver(ParticipantIdentifier.of("9908:111111111"))));
			Assert.assertFalse(EVIDENCE.Equals(EVIDENCE.documentTypeIdentifier(DocumentTypeIdentifier.of("Testing..."))));
			Assert.assertFalse(EVIDENCE.Equals(EVIDENCE.documentIdentifier(InstanceIdentifier.generateUUID())));
			Assert.assertFalse(EVIDENCE.Equals(EVIDENCE.issuerPolicy("Other policy.")));
			Assert.assertFalse(EVIDENCE.Equals(EVIDENCE.digest(Digest.of(DigestMethod.SHA1, "test".GetBytes()))));
			Assert.assertFalse(EVIDENCE.Equals(EVIDENCE.messageIdentifier(InstanceIdentifier.generateUUID())));
			Assert.assertFalse(EVIDENCE.Equals(EVIDENCE.transportProtocol(TransportProtocol.INTERNAL)));
			Assert.assertFalse(EVIDENCE.Equals(EVIDENCE.transmissionRole(TransmissionRole.C_2)));
		}


        //ORIGINAL LINE: @Test public void simpleHeader()
		public virtual void simpleHeader()
		{
			ParticipantIdentifier sender = ParticipantIdentifier.of("9908:999999999");
			ParticipantIdentifier receiver = ParticipantIdentifier.of("9908:111111111");
			DocumentTypeIdentifier documentTypeIdentifier = DocumentTypeIdentifier.of("Testing...");
			InstanceIdentifier documentIdentifier = InstanceIdentifier.generateUUID();

			Evidence evidence = Evidence.newInstance().header(Header.newInstance().sender(sender).receiver(receiver).documentType(documentTypeIdentifier).identifier(documentIdentifier));

			Assert.assertEquals(evidence.Sender, sender);
			Assert.assertEquals(evidence.Receiver, receiver);
			Assert.assertEquals(evidence.DocumentIdentifier, documentIdentifier);
			Assert.assertEquals(evidence.DocumentTypeIdentifier, documentTypeIdentifier);
		}
	}
}