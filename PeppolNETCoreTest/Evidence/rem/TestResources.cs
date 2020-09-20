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
	using InstanceIdentifier = no.difi.vefa.peppol.common.model.InstanceIdentifier;
	using ParticipantIdentifier = no.difi.vefa.peppol.common.model.ParticipantIdentifier;
	using TransportProtocol = no.difi.vefa.peppol.common.model.TransportProtocol;
	using TransmissionRole = no.difi.vefa.peppol.evidence.jaxb.receipt.TransmissionRole;
	using RemEvidenceException = no.difi.vefa.peppol.evidence.lang.RemEvidenceException;


//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to C#:
//	import static org.testng.Assert.assertNotNull;

	/// <summary>
	/// Created by soc on 06.11.2015.
	/// </summary>
	public class TestResources
	{

		public static readonly DocumentTypeIdentifier DOC_TYPE_ID = DocumentTypeIdentifier.of("urn:oasis:names:specification:ubl:schema:xsd:Tender-2::Tender##" + "urn:www.cenbii.eu:transaction:biitrdm090:ver3.0::2.1");

		public const string DOC_TYPE_INSTANCE_ID = "doc-type-instance-id";

		public static readonly InstanceIdentifier INSTANCE_IDENTIFIER = InstanceIdentifier.generateUUID();

		public static readonly ParticipantIdentifier SENDER_IDENTIFIER = ParticipantIdentifier.of("9908:810017902");

		public static readonly ParticipantIdentifier RECIPIENT_IDENTIFIER = ParticipantIdentifier.of("9908:123456789");

		public const string EVIDENCE_ISSUER_POLICY_ID = "http://ev_policyid.issuer.test/clause15";

		public const string EVIDENCE_ISSUER_NAME = "RemBuilderTest";

		private static KeyStore keyStore;

		private static RemEvidenceService remEvidenceService;

		/// <summary>
		/// Convenient helper method to obtain named Mime message resource from the class path
		/// </summary>
		/// <param name="resourceName">
		/// @return </param>
		/// <exception cref="javax.mail.MessagingException"> </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static javax.mail.internet.MimeMessage getMimeMessageFromResource(String resourceName) throws javax.mail.MessagingException
		public static MimeMessage getMimeMessageFromResource(string resourceName)
		{
			Stream resourceAsStream = typeof(TestResourcesTest).ClassLoader.getResourceAsStream(resourceName);
			assertNotNull(resourceAsStream);

			Properties properties = System.Properties;
			Session session = Session.getDefaultInstance(properties, null);
			return new MimeMessage(session, resourceAsStream);
		}


		public static sbyte[] SampleMdnSmime
		{
			get
			{
				return getMimeMessageFromResourceAsBytes("as2-mdn-smime.txt");
			}
		}

		public static sbyte[] getMimeMessageFromResourceAsBytes(string resourceName)
		{
			MemoryStream baos = new MemoryStream();

			try
			{
				MimeMessage mimeMessage = getMimeMessageFromResource(resourceName);
				mimeMessage.writeTo(baos);

			}
			catch (MessagingException e)
			{
				throw new System.InvalidOperationException(string.Format("Unable to load mime message from resource {0} class path: {1}", resourceName, e.Message), e);
			}
			catch (IOException e)
			{
				throw new System.InvalidOperationException(string.Format("Unable to write contents of mime message to byte array {0}", e.Message), e);
			}

			return baos.toByteArray();
		}

		public static RemEvidenceService RemEvidenceService
		{
			get
			{
				lock (typeof(TestResources))
				{
					if (remEvidenceService == null)
					{
						remEvidenceService = new RemEvidenceService();
					}
            
					return remEvidenceService;
				}
			}
		}

		public static KeyStore Keystore
		{
			get
			{
				lock (typeof(TestResources))
				{
					if (keyStore != null)
					{
						return keyStore;
					}
            
					try
					{
						keyStore = KeyStore.getInstance("JKS");
					}
					catch (KeyStoreException e)
					{
						throw new System.InvalidOperationException("Unable to create KeyStore instance ", e);
					}
					try
					{
						keyStore.load(typeof(TestResources).getResourceAsStream("/keystore-self-signed.jks"), "changeit".ToCharArray());
					}
					catch (Exception e) when (e is IOException || e is NoSuchAlgorithmException || e is CertificateException)
					{
						throw new System.InvalidOperationException("Unable to load data into keystore from 'keystore-self-signed.jks'", e);
					}
            
					return keyStore;
				}
			}
		}

		public static KeyStore.PrivateKeyEntry PrivateKey
		{
			get
			{
				KeyStore localKeyStore = Keystore;
				KeyStore.PrivateKeyEntry privateKeyEntry;
				try
				{
					privateKeyEntry = (KeyStore.PrivateKeyEntry) localKeyStore.getEntry("self-signed", new KeyStore.PasswordProtection("changeit".ToCharArray()));
				}
				catch (Exception e) when (e is NoSuchAlgorithmException || e is UnrecoverableEntryException || e is KeyStoreException)
				{
					throw new System.InvalidOperationException("Unable to load private key entry with alias 'self-signed'", e);
				}
    
				return privateKeyEntry;
			}
		}


		/// <summary>
		/// Creates sample rem evidence.
		/// </summary>
		/// <returns> sample REMEvidence based upon the resources in test/resources of this project. </returns>
		/// <exception cref="RemEvidenceException"> </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static SignedRemEvidence createSampleRemEvidence() throws no.difi.vefa.peppol.evidence.lang.RemEvidenceException
		public static SignedRemEvidence createSampleRemEvidence()
		{
			RemEvidenceBuilder builder = remEvidenceService.createDeliveryNonDeliveryToRecipientBuilder();

			sbyte[] sampleMdnSmime = TestResources.SampleMdnSmime;
			KeyStore.PrivateKeyEntry privateKey = TestResources.PrivateKey;

			builder.eventCode(EventCode.ACCEPTANCE).evidenceIssuerPolicyID(TestResources.EVIDENCE_ISSUER_POLICY_ID).evidenceIssuerDetails(TestResources.EVIDENCE_ISSUER_NAME).senderIdentifier(TestResources.SENDER_IDENTIFIER).recipientIdentifer(TestResources.RECIPIENT_IDENTIFIER).documentTypeId(TestResources.DOC_TYPE_ID).instanceIdentifier(TestResources.INSTANCE_IDENTIFIER).payloadDigest("ThisIsASHA256Digest".GetBytes()).protocolSpecificEvidence(TransmissionRole.C_3, TransportProtocol.AS2, sampleMdnSmime);


			return builder.buildRemEvidenceInstance(privateKey);
		}
	}

}