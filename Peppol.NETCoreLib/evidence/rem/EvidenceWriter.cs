using System.IO;
using System.Numerics;

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
	using Receipt = no.difi.vefa.peppol.common.model.Receipt;
	using ExceptionUtil = no.difi.vefa.peppol.common.util.ExceptionUtil;
	using OriginalReceiptType = no.difi.vefa.peppol.evidence.jaxb.receipt.OriginalReceiptType;
	using PeppolRemExtension = no.difi.vefa.peppol.evidence.jaxb.receipt.PeppolRemExtension;
	using no.difi.vefa.peppol.evidence.jaxb.rem;
	using DigestMethodType = no.difi.vefa.peppol.evidence.jaxb.xmldsig.DigestMethodType;
	using RemEvidenceException = no.difi.vefa.peppol.evidence.lang.RemEvidenceException;
	using Node = org.w3c.dom.Node;


	public class EvidenceWriter
	{

		private Evidence evidence;

		private REMEvidenceType remEvidence = new REMEvidenceType();

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void write(java.io.OutputStream outputStream, Evidence evidence) throws no.difi.vefa.peppol.evidence.lang.RemEvidenceException
		public static void write(Stream outputStream, Evidence evidence)
		{
			EvidenceWriter evidenceWriter = new EvidenceWriter(evidence);
			evidenceWriter.prepare();
			evidenceWriter.write(new StreamResult(outputStream));
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void write(org.w3c.dom.Node node, Evidence evidence) throws no.difi.vefa.peppol.evidence.lang.RemEvidenceException
		public static void write(Node node, Evidence evidence)
		{
			EvidenceWriter evidenceWriter = new EvidenceWriter(evidence);
			evidenceWriter.prepare();
			evidenceWriter.write(new DOMResult(node));
		}

		private EvidenceWriter(Evidence evidence)
		{
			this.evidence = evidence;
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private void prepare() throws no.difi.vefa.peppol.evidence.lang.RemEvidenceException
		private void prepare()
		{
			// Version
			remEvidence.Version = "2";

			// Event Code
			remEvidence.EventCode = evidence.EventCode.Value;

			// Event Reason
			if (evidence.EventReason != null)
			{
				remEvidence.EventReasons = new EventReasonsType();
				remEvidence.EventReasons.EventReason.add(RemHelper.createEventReasonType(evidence.EventReason));
			}

			// Issuer
			NamePostalAddressType namePostalAddressType = new NamePostalAddressType();
			namePostalAddressType.EntityName = new EntityNameType();
			namePostalAddressType.EntityName.Name.add(evidence.Issuer);

			remEvidence.EvidenceIssuerDetails = new EntityDetailsType();
			remEvidence.EvidenceIssuerDetails.NamesPostalAddresses = new NamesPostalAddressListType();
			remEvidence.EvidenceIssuerDetails.NamesPostalAddresses.NamePostalAddress.add(namePostalAddressType);

			// Evidence Identifier
			remEvidence.EvidenceIdentifier = evidence.EvidenceIdentifier.Identifier;

			// Issuer Policy
			if (!string.ReferenceEquals(evidence.IssuerPolicy, null))
			{
				remEvidence.EvidenceIssuerPolicyID = new EvidenceIssuerPolicyIDType();
				remEvidence.EvidenceIssuerPolicyID.PolicyID.add(evidence.IssuerPolicy);
			}

			// Event Time
			remEvidence.EventTime = RemHelper.toXmlGregorianCalendar(evidence.Timestamp);

			// Sender
			remEvidence.SenderDetails = new EntityDetailsType();
			remEvidence.SenderDetails.AttributedElectronicAddressOrElectronicAddress.add(RemHelper.createElectronicAddressType(evidence.Sender));

			// Receiver
			remEvidence.RecipientsDetails = new EntityDetailsListType();
			remEvidence.RecipientsDetails.EntityDetails.add(new EntityDetailsType());
			remEvidence.RecipientsDetails.EntityDetails.get(0).AttributedElectronicAddressOrElectronicAddress.add(RemHelper.createElectronicAddressType(evidence.Receiver));
			remEvidence.EvidenceRefersToRecipient = BigInteger.valueOf(1);

			// Sender Message Details
			MessageDetailsType messageDetailsType = new MessageDetailsType();
			messageDetailsType.MessageSubject = evidence.DocumentTypeIdentifier.Identifier;
			if (evidence.DocumentIdentifier != null)
			{
				messageDetailsType.UAMessageIdentifier = evidence.DocumentIdentifier.Identifier;
			}
			messageDetailsType.MessageIdentifierByREMMD = evidence.MessageIdentifier.Identifier;
			DigestMethodType digestMethodType = new DigestMethodType();
			digestMethodType.Algorithm = evidence.Digest.Method.Uri;
			messageDetailsType.DigestMethod = digestMethodType;
			messageDetailsType.DigestValue = evidence.Digest.Value;
			messageDetailsType.IsNotification = false;
			remEvidence.SenderMessageDetails = messageDetailsType;

			// Extensions
			ExtensionsListType extensionsListType = new ExtensionsListType();

			// PEPPOL REM Extension
			if (evidence.hasPeppolExtensionValues())
			{
				PeppolRemExtension peppolRemExtension = new PeppolRemExtension();
				peppolRemExtension.TransmissionProtocol = evidence.TransportProtocol.Identifier;
				peppolRemExtension.TransmissionRole = evidence.TransmissionRole;

				foreach (Receipt receipt in evidence.OriginalReceipts)
				{
					peppolRemExtension.OriginalReceipt.add(convert(receipt));
				}

				ExtensionType extensionType = new ExtensionType();
				extensionType.Content.add(peppolRemExtension);
				extensionsListType.Extension.add(extensionType);
			}

			if (extensionsListType.Extension.size() > 0)
			{
				remEvidence.Extensions = extensionsListType;
			}
		}

		private OriginalReceiptType convert(Receipt receipt)
		{
			OriginalReceiptType originalReceiptType = new OriginalReceiptType();
			originalReceiptType.Type = receipt.Type;
			originalReceiptType.Value = receipt.Value;
			return originalReceiptType;
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private void write(final javax.xml.transform.Result result) throws no.difi.vefa.peppol.evidence.lang.RemEvidenceException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are ignored unless the option to convert to C# 7.2 'in' parameters is selected:
		private void write(Result result)
		{
			ExceptionUtil.perform(typeof(RemEvidenceException), () =>
			{
			Marshaller marshaller = RemHelper.Marshaller;
			marshaller.marshal(evidence.Type.toJAXBElement(remEvidence), result);
			});
		}
	}

}