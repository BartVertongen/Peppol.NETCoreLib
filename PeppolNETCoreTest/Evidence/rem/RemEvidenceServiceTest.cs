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
	using TransportProtocol = no.difi.vefa.peppol.common.model.TransportProtocol;
	using TransmissionRole = no.difi.vefa.peppol.evidence.jaxb.receipt.TransmissionRole;
	using XmldsigVerifier = no.difi.vefa.peppol.security.xmldsig.XmldsigVerifier;
	//using BeforeClass = org.testng.annotations.BeforeClass;

	/// <summary>
	/// Created by steinar on 08.11.2015.
	/// </summary>
	public class RemEvidenceServiceTest
	{
		protected internal sbyte[] specificReceiptBytes;

		protected internal KeyStore.PrivateKeyEntry privateKeyEntry;

        //ORIGINAL LINE: @BeforeClass public void setUp()
		public virtual void setUp()
		{
			// Provides sample AS2 MDN to be included as evidence in the REM
			specificReceiptBytes = TestResources.SampleMdnSmime;

			// Grabs our private key and certificate to be used for signing the REM
			privateKeyEntry = TestResources.PrivateKey;
		}


        //ORIGINAL LINE: @Test public void testCreateDeliveryNonDeliveryToRecipientBuilder() throws Exception
		public virtual void testCreateDeliveryNonDeliveryToRecipientBuilder()
		{

			RemEvidenceService remEvidenceService = new RemEvidenceService();

			RemEvidenceBuilder builder = remEvidenceService.createDeliveryNonDeliveryToRecipientBuilder();

			sbyte[] sampleMdnSmime = TestResources.SampleMdnSmime;

			builder.eventCode(EventCode.ACCEPTANCE).evidenceIssuerPolicyID(TestResources.EVIDENCE_ISSUER_POLICY_ID).evidenceIssuerDetails(TestResources.EVIDENCE_ISSUER_NAME).senderIdentifier(TestResources.SENDER_IDENTIFIER).recipientIdentifer(TestResources.RECIPIENT_IDENTIFIER).documentTypeId(TestResources.DOC_TYPE_ID).instanceIdentifier(TestResources.INSTANCE_IDENTIFIER).payloadDigest("ThisIsASHA256Digest".GetBytes()).protocolSpecificEvidence(TransmissionRole.C_3, TransportProtocol.AS2, specificReceiptBytes);

			// Signs and builds the REMEvidenceType instance
			SignedRemEvidence signedRemEvidence = builder.buildRemEvidenceInstance(privateKeyEntry);

			assertNotNull(signedRemEvidence);
			assertEquals(signedRemEvidence.EvidenceType, EvidenceTypeInstance.DELIVERY_NON_DELIVERY_TO_RECIPIENT);

			XmldsigVerifier.verify(signedRemEvidence.Document);
		}

        //ORIGINAL LINE: @Test public void testCreateRelayRemMdAcceptanceRejectionBuilder() throws Exception
		public virtual void testCreateRelayRemMdAcceptanceRejectionBuilder()
		{

			RemEvidenceService remEvidenceService = new RemEvidenceService();

			RemEvidenceBuilder builder = remEvidenceService.createRelayRemMdAcceptanceRejectionBuilder();

			sbyte[] sampleMdnSmime = TestResources.SampleMdnSmime;
			KeyStore.PrivateKeyEntry privateKey = TestResources.PrivateKey;

			builder.eventCode(EventCode.ACCEPTANCE).evidenceIssuerPolicyID(TestResources.EVIDENCE_ISSUER_POLICY_ID).evidenceIssuerDetails(TestResources.EVIDENCE_ISSUER_NAME).senderIdentifier(TestResources.SENDER_IDENTIFIER).recipientIdentifer(TestResources.RECIPIENT_IDENTIFIER).documentTypeId(TestResources.DOC_TYPE_ID).instanceIdentifier(TestResources.INSTANCE_IDENTIFIER).payloadDigest("ThisIsASHA256Digest".GetBytes()).protocolSpecificEvidence(TransmissionRole.C_3, TransportProtocol.AS2, "Jabla jabla fake MDN".GetBytes());

			// Signs and builds the REMEvidenceType instance
			SignedRemEvidence signedRemEvidence = builder.buildRemEvidenceInstance(privateKey);

			assertNotNull(signedRemEvidence);
			assertEquals(signedRemEvidence.EvidenceType, EvidenceTypeInstance.RELAY_REM_MD_ACCEPTANCE_REJECTION);

			XmldsigVerifier.verify(signedRemEvidence.Document);
		}
	}
}