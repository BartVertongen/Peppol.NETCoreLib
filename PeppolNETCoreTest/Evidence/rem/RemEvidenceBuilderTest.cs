using System;
using System.IO;

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
	using DocumentTypeIdentifier = no.difi.vefa.peppol.common.model.DocumentTypeIdentifier;
	using ParticipantIdentifier = no.difi.vefa.peppol.common.model.ParticipantIdentifier;
	using TransportProtocol = no.difi.vefa.peppol.common.model.TransportProtocol;
	using PeppolRemExtension = no.difi.vefa.peppol.evidence.jaxb.receipt.PeppolRemExtension;
	using TransmissionRole = no.difi.vefa.peppol.evidence.jaxb.receipt.TransmissionRole;
	using ExtensionType = no.difi.vefa.peppol.evidence.jaxb.rem.ExtensionType;
	using ExtensionsListType = no.difi.vefa.peppol.evidence.jaxb.rem.ExtensionsListType;
	using REMEvidenceType = no.difi.vefa.peppol.evidence.jaxb.rem.REMEvidenceType;
	using XmldsigVerifier = no.difi.vefa.peppol.security.xmldsig.XmldsigVerifier;
	using BeforeClass = org.testng.annotations.BeforeClass;


//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to C#:
//	import static org.testng.Assert.*;

	/// <summary>
	/// Ensures that the RemEvidenceBuilder works as expected.
	/// 
	/// @author steinar
	///         Date: 04.11.2015
	///         Time: 21.05
	/// @author Sander Fieten
	///         Date: 06.04.2016
	/// </summary>
	public class RemEvidenceBuilderTest
	{

		protected internal sbyte[] specificReceiptBytes;

		protected internal KeyStore.PrivateKeyEntry privateKeyEntry;

		protected internal RemEvidenceService remEvidenceService;

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @BeforeClass public void setUp()
		public virtual void setUp()
		{
			// Provides sample AS2 MDN to be included as evidence in the REM
			specificReceiptBytes = TestResources.SampleMdnSmime;

			// Grabs our private key and certificate to be used for signing the REM
			privateKeyEntry = TestResources.PrivateKey;

			// Allows us the obtain the JAXBContext, which is needed when creating instances of RemEvidenceBuilder
			// RemEvidenceBuilder instances can only be created by using the factory, but since this is a unit test,
			// we are allowed to go behind the scenes.
			remEvidenceService = new RemEvidenceService();
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void createSampleRemEvidence() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void createSampleRemEvidence()
		{

			RemEvidenceBuilder builder = remEvidenceService.createDeliveryNonDeliveryToRecipientBuilder();
			builder.eventCode(EventCode.ACCEPTANCE).eventTime(DateTime.Now).eventReason(EventReason.OTHER).evidenceIssuerPolicyID(TestResources.EVIDENCE_ISSUER_POLICY_ID).evidenceIssuerDetails(TestResources.EVIDENCE_ISSUER_NAME).senderIdentifier(TestResources.SENDER_IDENTIFIER).recipientIdentifer(TestResources.RECIPIENT_IDENTIFIER).documentTypeId(TestResources.DOC_TYPE_ID).documentTypeInstanceIdentifier(TestResources.DOC_TYPE_INSTANCE_ID).instanceIdentifier(TestResources.INSTANCE_IDENTIFIER).payloadDigest("ThisIsASHA256Digest".GetBytes()).protocolSpecificEvidence(TransmissionRole.C_3, TransportProtocol.AS2, specificReceiptBytes);


			// Signs and builds the REMEvidenceType instance
			SignedRemEvidence signedRemEvidence = builder.buildRemEvidenceInstance(privateKeyEntry);


			// Grabs the REMEvidenceType instance in order to make some assertions.
			REMEvidenceType remEvidenceInstance = signedRemEvidence.RemEvidenceType;

			// Issue #2
			assertNotNull(remEvidenceInstance.Version, "The version attribute was not set!");
			assertEquals(remEvidenceInstance.Version, "2");
			// ------------- Issue #2 --------------


			assertEquals(remEvidenceInstance.EventCode, EventCode.ACCEPTANCE.Value.ToString());

			// Transforms the rem evidence instance into an XML representation suitable for some checks.
			MemoryStream baos = new MemoryStream();
			(new RemEvidenceTransformer()).toFormattedXml(signedRemEvidence, baos);
			string xmlOutput = baos.ToString("UTF-8");

			Console.WriteLine(xmlOutput);

			assertTrue(xmlOutput.Contains(TestResources.DOC_TYPE_ID.Identifier), "Document type id has not been included in the REM XML");
			assertTrue(xmlOutput.Contains(TestResources.INSTANCE_IDENTIFIER.Identifier), "Instance identifier missing");
			assertTrue(xmlOutput.Contains(TestResources.SENDER_IDENTIFIER.Identifier), "Sender identifier missing in generated xml");
			assertTrue(xmlOutput.Contains(TestResources.RECIPIENT_IDENTIFIER.Identifier), "Recipient identifier missing in generated xml");

			// Verifies that the signature was created, note that we omit the opening '<' as we have no idea
			// what the namespace might be.
			// If we were a little more eager we would use XPath to verify the contents :-)

			assertTrue(xmlOutput.Contains("SignatureValue>"));
			assertTrue(xmlOutput.Contains("KeyInfo>"));

			// Verifies the signature using the W3C Document
			XmldsigVerifier.verify(signedRemEvidence.Document);

			assertNotNull(signedRemEvidence.EventCode);
			assertNotNull(signedRemEvidence.EventReason);
			assertNotNull(signedRemEvidence.EventTime);

			// Check the policy id
			assertEquals(signedRemEvidence.EvidenceIssuerPolicyID, TestResources.EVIDENCE_ISSUER_POLICY_ID);

			// Check entity name of evidence issuer (issue #11)
			assertEquals(signedRemEvidence.EvidenceIssuerDetails, TestResources.EVIDENCE_ISSUER_NAME);

			ParticipantIdentifier senderIdentifier = signedRemEvidence.SenderIdentifier;
			assertNotNull(senderIdentifier);

			ParticipantIdentifier receiverIdentifier = signedRemEvidence.RecipientIdentifier;
			assertNotNull(receiverIdentifier);

			DocumentTypeIdentifier documentTypeIdentifier = signedRemEvidence.DocumentTypeIdentifier;
			assertNotNull(documentTypeIdentifier);

			string documentTypeInstanceId = signedRemEvidence.DocumentTypeInstanceIdentifier;
			assertEquals(documentTypeInstanceId, TestResources.DOC_TYPE_INSTANCE_ID);

			sbyte[] digestBytes = signedRemEvidence.PayloadDigestValue;
			assertNotNull(digestBytes);
			assertTrue(digestBytes.Length > 0);
			PeppolRemExtension transmissionEvidence = signedRemEvidence.TransmissionEvidence;
			assertNotNull(transmissionEvidence);

			assertEquals(transmissionEvidence.TransmissionProtocol, TransportProtocol.AS2.Identifier);
			assertEquals(transmissionEvidence.TransmissionRole, TransmissionRole.C_3);


		}


		/// <summary>
		/// Verifies that the PeppolRemExtension is unmarshalled correctly.
		/// </summary>
		/// <exception cref="Exception"> </exception>
        //ORIGINAL LINE: @Test public void testUnmarshal() throws Exception
		public virtual void testUnmarshal()
		{

			RemEvidenceBuilder builder = new RemEvidenceBuilder(EvidenceTypeInstance.DELIVERY_NON_DELIVERY_TO_RECIPIENT);

			builder.eventCode(EventCode.ACCEPTANCE).eventTime(DateTime.Now).eventReason(EventReason.OTHER).evidenceIssuerPolicyID(TestResources.EVIDENCE_ISSUER_POLICY_ID).evidenceIssuerDetails(TestResources.EVIDENCE_ISSUER_NAME).senderIdentifier(TestResources.SENDER_IDENTIFIER).recipientIdentifer(TestResources.RECIPIENT_IDENTIFIER).documentTypeId(TestResources.DOC_TYPE_ID).instanceIdentifier(TestResources.INSTANCE_IDENTIFIER).payloadDigest("ThisIsASHA256Digest".GetBytes()).protocolSpecificEvidence(TransmissionRole.C_3, TransportProtocol.AS2, specificReceiptBytes);


			// Signs and builds the REMEvidenceType instance
			SignedRemEvidence signedRemEvidence = builder.buildRemEvidenceInstance(privateKeyEntry);

			// Grabs the REMEvidenceType instance in order to make some assertions.
			REMEvidenceType remEvidenceInstance = signedRemEvidence.RemEvidenceType;
			assertNotNull(remEvidenceInstance);


			ExtensionType extensionType = signedRemEvidence.RemEvidenceType.Extensions.Extension.get(0);
			object value = extensionType.Content.get(0);

			assertTrue(value is PeppolRemExtension);

			PeppolRemExtension peppolRemExtension = (PeppolRemExtension) value;
			sbyte[] evidenceBytes = peppolRemExtension.OriginalReceipt.get(0).Value;

			assertEquals(evidenceBytes, specificReceiptBytes);
		}

		/// <summary>
		/// Verifies that the PeppolRemExtension is optional.
		/// </summary>
		/// <exception cref="Exception"> </exception>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testExtensionOptional() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void testExtensionOptional()
		{

			RemEvidenceBuilder builder = new RemEvidenceBuilder(EvidenceTypeInstance.DELIVERY_NON_DELIVERY_TO_RECIPIENT);

			builder.eventCode(EventCode.ACCEPTANCE).eventTime(DateTime.Now).eventReason(EventReason.OTHER).evidenceIssuerPolicyID(TestResources.EVIDENCE_ISSUER_POLICY_ID).evidenceIssuerDetails(TestResources.EVIDENCE_ISSUER_NAME).senderIdentifier(TestResources.SENDER_IDENTIFIER).recipientIdentifer(TestResources.RECIPIENT_IDENTIFIER).documentTypeId(TestResources.DOC_TYPE_ID).instanceIdentifier(TestResources.INSTANCE_IDENTIFIER).payloadDigest("ThisIsASHA256Digest".GetBytes());


			// Signs and builds the REMEvidenceType instance
			SignedRemEvidence signedRemEvidence = builder.buildRemEvidenceInstance(privateKeyEntry);

			// Grabs the REMEvidenceType instance in order to make some assertions.
			REMEvidenceType remEvidenceInstance = signedRemEvidence.RemEvidenceType;
			assertNotNull(remEvidenceInstance);

			ExtensionsListType extensions = signedRemEvidence.RemEvidenceType.Extensions;

			assertNull(extensions);
		}

        //ORIGINAL LINE: @Test public void testOptionalDocumentTypeInstanceId() throws Exception
		public virtual void testOptionalDocumentTypeInstanceId()
		{

			RemEvidenceBuilder builder = remEvidenceService.createDeliveryNonDeliveryToRecipientBuilder();
			builder.eventCode(EventCode.ACCEPTANCE).eventTime(DateTime.Now).eventReason(EventReason.OTHER).evidenceIssuerPolicyID(TestResources.EVIDENCE_ISSUER_POLICY_ID).evidenceIssuerDetails(TestResources.EVIDENCE_ISSUER_NAME).senderIdentifier(TestResources.SENDER_IDENTIFIER).recipientIdentifer(TestResources.RECIPIENT_IDENTIFIER).documentTypeId(TestResources.DOC_TYPE_ID).instanceIdentifier(TestResources.INSTANCE_IDENTIFIER).payloadDigest("ThisIsASHA256Digest".GetBytes()).protocolSpecificEvidence(TransmissionRole.C_3, TransportProtocol.AS2, specificReceiptBytes);


			// Signs and builds the REMEvidenceType instance
			SignedRemEvidence signedRemEvidence = builder.buildRemEvidenceInstance(privateKeyEntry);

			assertNull(signedRemEvidence.DocumentTypeInstanceIdentifier);

		}
	}
}