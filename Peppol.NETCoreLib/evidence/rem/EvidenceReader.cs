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
	using DigestMethod = no.difi.vefa.peppol.common.code.DigestMethod;
	using PeppolException = no.difi.vefa.peppol.common.lang.PeppolException;
	using no.difi.vefa.peppol.common.model;
	//using OriginalReceiptType = no.difi.vefa.peppol.evidence.jaxb.receipt.OriginalReceiptType;
	//using PeppolRemExtension = no.difi.vefa.peppol.evidence.jaxb.receipt.PeppolRemExtension;
	//using AttributedElectronicAddressType = no.difi.vefa.peppol.evidence.jaxb.rem.AttributedElectronicAddressType;
	//using ExtensionType = no.difi.vefa.peppol.evidence.jaxb.rem.ExtensionType;
	//using REMEvidenceType = no.difi.vefa.peppol.evidence.jaxb.rem.REMEvidenceType;
	using RemEvidenceException = no.difi.vefa.peppol.evidence.lang.RemEvidenceException;
	using Node = org.w3c.dom.Node;
    using javax.xml.transform;

    public class EvidenceReader
	{

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static Evidence read(org.w3c.dom.Node node) throws no.difi.vefa.peppol.evidence.lang.RemEvidenceException
		public static Evidence read(Node node)
		{
			return read(new DOMSource(node));
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static Evidence read(java.io.InputStream inputStream) throws no.difi.vefa.peppol.evidence.lang.RemEvidenceException
		public static Evidence read(Stream inputStream)
		{
			return read(new StreamSource(inputStream));
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private static Evidence read(javax.xml.transform.Source source) throws no.difi.vefa.peppol.evidence.lang.RemEvidenceException
		private static Evidence read(Source source)
		{
			try
			{
				Unmarshaller unmarshaller = RemHelper.Unmarshaller;
				JAXBElement<REMEvidenceType> jaxbRemEvidence = unmarshaller.unmarshal(source, typeof(REMEvidenceType));

				REMEvidenceType remEvidence = jaxbRemEvidence.Value;

				// Version
				if (!"2".Equals(remEvidence.Version))
				{
					throw new RemEvidenceException(string.Format("Version '{0}' not known.", remEvidence.Version));
				}

				Evidence evidence = Evidence.newInstance();

				// Type
				evidence = evidence.type(EvidenceTypeInstance.findByLocalName(jaxbRemEvidence.Name.LocalPart));

				// Event Code
				evidence = evidence.eventCode(EventCode.valueFor(remEvidence.EventCode));

				// Event Reason
				evidence = evidence.eventReason(EventReason.valueForCode(remEvidence.EventReasons.EventReason.get(0).Code));

				// Issuer
				if (remEvidence.EvidenceIssuerDetails != null)
				{
					evidence = evidence.issuer(remEvidence.EvidenceIssuerDetails.NamesPostalAddresses.NamePostalAddress.get(0).EntityName.Name.get(0));
				}

				// Evidence Identifier
				evidence = evidence.evidenceIdentifier(InstanceIdentifier.of(remEvidence.EvidenceIdentifier));

				if (remEvidence.EvidenceIssuerPolicyID != null)
				{
					evidence = evidence.issuerPolicy(remEvidence.EvidenceIssuerPolicyID.PolicyID.get(0));
				}

				// Event Time
				evidence = evidence.timestamp(RemHelper.fromXmlGregorianCalendar(remEvidence.EventTime));

				// Sender
				evidence = evidence.sender(RemHelper.readElectronicAddressType((AttributedElectronicAddressType) remEvidence.SenderDetails.AttributedElectronicAddressOrElectronicAddress.get(0)));

				// Receiver
				evidence = evidence.receiver(RemHelper.readElectronicAddressType((AttributedElectronicAddressType) remEvidence.RecipientsDetails.EntityDetails.get(0).AttributedElectronicAddressOrElectronicAddress.get(0)));

				// Sender Message Details
				evidence = evidence.digest(Digest.of(DigestMethod.fromUri(remEvidence.SenderMessageDetails.DigestMethod.Algorithm), remEvidence.SenderMessageDetails.DigestValue));
				if (remEvidence.SenderMessageDetails.UAMessageIdentifier != null)
				{
					evidence = evidence.documentIdentifier(InstanceIdentifier.of(remEvidence.SenderMessageDetails.UAMessageIdentifier));
				}
				evidence = evidence.messageIdentifier(InstanceIdentifier.of(remEvidence.SenderMessageDetails.MessageIdentifierByREMMD));
				evidence = evidence.documentTypeIdentifier(DocumentTypeIdentifier.of(remEvidence.SenderMessageDetails.MessageSubject, Scheme_Fields.NONE));

				// Extensions
				if (remEvidence.Extensions != null)
				{

					// PEPPOL REM Extension
					foreach (ExtensionType extensionType in remEvidence.Extensions.Extension)
					{
						foreach (object o in extensionType.Content)
						{
							if (o is PeppolRemExtension)
							{
								PeppolRemExtension peppolRemExtension = (PeppolRemExtension) o;

								evidence = evidence.transportProtocol(TransportProtocol.of(peppolRemExtension.TransmissionProtocol));
								evidence = evidence.transmissionRole(peppolRemExtension.TransmissionRole);

								foreach (OriginalReceiptType receiptType in peppolRemExtension.OriginalReceipt)
								{
									evidence = evidence.originalReceipt(Receipt.of(receiptType.Type, receiptType.Value));
								}
							}
						}
					}

				}

				return evidence;
			}
			catch (RemEvidenceException e)
			{
				throw e;
			}
			catch (Exception e)// when (e is JAXBException || e is PeppolException)
			{
				throw new RemEvidenceException("Unable to unmarshal content.", e);
			}
		}
	}
}