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
	using PeppolSecurityException = no.difi.vefa.peppol.security.lang.PeppolSecurityException;
	using XmldsigVerifier = no.difi.vefa.peppol.security.xmldsig.XmldsigVerifier;

	/// <summary>
	/// Entry point for most operations pertaining to REM evidence.
	/// 
	/// Provides various services related to production and consumption of REMEvidence,
	/// in addition to holding the JAXBContext, which is costly to create.
	/// 
	/// This class is thread safe, however due to the cost of creating the JAXBContext you should wrap it in a singleton
	/// if you intend to create numerous instances.
	/// 
	/// Created by steinar on 08.11.2015.
	/// </summary>
	public class RemEvidenceService
	{

		public virtual RemEvidenceBuilder createDeliveryNonDeliveryToRecipientBuilder()
		{
			return new RemEvidenceBuilder(EvidenceTypeInstance.DELIVERY_NON_DELIVERY_TO_RECIPIENT);
		}

		public virtual RemEvidenceBuilder createRelayRemMdAcceptanceRejectionBuilder()
		{
			return new RemEvidenceBuilder(EvidenceTypeInstance.RELAY_REM_MD_ACCEPTANCE_REJECTION);
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void verifySignature(SignedRemEvidence signedRemEvidence) throws no.difi.vefa.peppol.security.lang.PeppolSecurityException
		public static void verifySignature(SignedRemEvidence signedRemEvidence)
		{
			XmldsigVerifier.verify(signedRemEvidence.Document);
		}
	}

}