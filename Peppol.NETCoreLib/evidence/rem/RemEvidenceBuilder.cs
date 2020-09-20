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
	using TransmissionRole = no.difi.vefa.peppol.evidence.jaxb.receipt.TransmissionRole;
	using REMEvidenceType = no.difi.vefa.peppol.evidence.jaxb.rem.REMEvidenceType;
	using RemEvidenceException = no.difi.vefa.peppol.evidence.lang.RemEvidenceException;
	using PeppolSecurityException = no.difi.vefa.peppol.security.lang.PeppolSecurityException;
	using Document = org.w3c.dom.Document;


	/// <summary>
	/// Builds instances of SignedRemEvidence based upon the properties supplied.
	/// <p/>
	/// See unit tests for details on how to use it.
	/// <p/>
	/// Created by steinar on 08.11.2015.
	/// Edited by sanderf to fix issues #4, #5, #11
	/// </summary>
	public class RemEvidenceBuilder
	{

		private Evidence evidence;

//JAVA TO C# CONVERTER WARNING: 'final' parameters are ignored unless the option to convert to C# 7.2 'in' parameters is selected:
//ORIGINAL LINE: protected RemEvidenceBuilder(final EvidenceTypeInstance evidenceTypeInstance)
		protected internal RemEvidenceBuilder(EvidenceTypeInstance evidenceTypeInstance)
		{
			evidence = Evidence.newInstance().type(evidenceTypeInstance).evidenceIdentifier(InstanceIdentifier.generateUUID()).timestamp(DateTime.Now);
		}

		public virtual RemEvidenceBuilder eventCode(EventCode eventCode)
		{
			evidence = evidence.eventCode(eventCode);
			return this;
		}

		/// <summary>
		/// Spec says that multiple event reasons may be added in theory, however the details for each
		/// concrete instance indicates a cardinality of 0..1
		/// </summary>
		public virtual RemEvidenceBuilder eventReason(EventReason eventReason)
		{
			evidence = evidence.eventReason(eventReason);
			return this;
		}

		public virtual RemEvidenceBuilder eventTime(DateTime date)
		{
			evidence = evidence.timestamp(date);
			return this;
		}

		public virtual RemEvidenceBuilder evidenceIssuerPolicyID(string evidencePolicyID)
		{
			evidence = evidence.issuerPolicy(evidencePolicyID);
			return this;
		}

		public virtual RemEvidenceBuilder evidenceIssuerDetails(string evidenceIssuerDetails)
		{
			evidence = evidence.issuer(evidenceIssuerDetails);
			return this;
		}

		public virtual RemEvidenceBuilder senderIdentifier(ParticipantIdentifier senderIdentifier)
		{
			evidence = evidence.sender(senderIdentifier);
			return this;
		}

		public virtual RemEvidenceBuilder recipientIdentifer(ParticipantIdentifier recipientIdentifier)
		{
			evidence = evidence.receiver(recipientIdentifier);
			return this;
		}

		public virtual RemEvidenceBuilder documentTypeId(DocumentTypeIdentifier documentTypeId)
		{
			evidence = evidence.documentTypeIdentifier(documentTypeId);
			return this;
		}

		public virtual RemEvidenceBuilder documentTypeInstanceIdentifier(string documentTypeInstanceId)
		{
			evidence = evidence.documentIdentifier(InstanceIdentifier.of(documentTypeInstanceId));
			return this;
		}

		/// <summary>
		/// The value of <code>//DocumentIdentification/InstanceIdentifier</code> from the SBDH.
		/// </summary>
		/// <param name="instanceIdentifier"> the unique identification of the SBDH in accordance with UN/CEFACT TS SBDH </param>
		/// <returns> reference to the builder </returns>
		public virtual RemEvidenceBuilder instanceIdentifier(InstanceIdentifier instanceIdentifier)
		{
			evidence = evidence.messageIdentifier(instanceIdentifier);
			return this;
		}

		public virtual RemEvidenceBuilder payloadDigest(sbyte[] payloadDigest)
		{
			evidence = evidence.digest(Digest.of(DigestMethod.SHA256, payloadDigest));
			return this;
		}

		public virtual RemEvidenceBuilder protocolSpecificEvidence(TransmissionRole transmissionRole, TransportProtocol transportProtocol, sbyte[] protocolSpecificBytes)
		{
			evidence = evidence.transmissionRole(transmissionRole).transportProtocol(transportProtocol).originalReceipt(Receipt.of(protocolSpecificBytes));
			return this;
		}

		public virtual Evidence Evidence
		{
			get
			{
				return evidence;
			}
		}

		/// <summary>
		/// Builds an instance of SignedRemEvidence based upon the previously supplied parameters.
		/// </summary>
		/// <param name="privateKeyEntry"> the private key and certificate to be used for the XMLDsig signature </param>
		/// <returns> a signed RemEvidence represented as an instance of SignedRemEvidence </returns>
		/// <exception cref="RemEvidenceException"> when the properties provided are not correct or missing </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public SignedRemEvidence buildRemEvidenceInstance(java.security.KeyStore.PrivateKeyEntry privateKeyEntry) throws no.difi.vefa.peppol.evidence.lang.RemEvidenceException
		public virtual SignedRemEvidence buildRemEvidenceInstance(KeyStore.PrivateKeyEntry privateKeyEntry)
		{
			try
			{
				// Signs the REMEvidenceType instance
				Document signedRemDocument = SignedEvidenceWriter.write(privateKeyEntry, this.evidence);

				// Transforms the REMEvidenceType DOM Document instance it's JAXB representation.
				JAXBElement<REMEvidenceType> remEvidenceTypeJAXBElement = RemEvidenceTransformer.toJaxb(signedRemDocument);

				return new SignedRemEvidence(remEvidenceTypeJAXBElement, signedRemDocument);
			}
			catch (PeppolSecurityException e)
			{
				throw new RemEvidenceException(e.Message, e);
			}
		}
	}

}