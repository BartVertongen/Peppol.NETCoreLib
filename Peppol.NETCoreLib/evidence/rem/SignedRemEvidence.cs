using System;
using System.Collections.Generic;

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
	using Scheme = no.difi.vefa.peppol.common.model.Scheme;
	using ExceptionUtil = no.difi.vefa.peppol.common.util.ExceptionUtil;
	using PeppolRemExtension = no.difi.vefa.peppol.evidence.jaxb.receipt.PeppolRemExtension;
	using AttributedElectronicAddressType = no.difi.vefa.peppol.evidence.jaxb.rem.AttributedElectronicAddressType;
	using EntityDetailsListType = no.difi.vefa.peppol.evidence.jaxb.rem.EntityDetailsListType;
	using EntityDetailsType = no.difi.vefa.peppol.evidence.jaxb.rem.EntityDetailsType;
	using REMEvidenceType = no.difi.vefa.peppol.evidence.jaxb.rem.REMEvidenceType;
	using RemEvidenceException = no.difi.vefa.peppol.evidence.lang.RemEvidenceException;
	using Document = org.w3c.dom.Document;


	/// <summary>
	/// Holds a signed REMEvidence. Internally it is held in two representations; REMEvidenceType and
	/// W3C Document.
	/// <p/>
	/// Please use <seealso cref="RemEvidenceTransformer"/> to transform instances of SignedRemEvidence into other
	/// representations like for instance XML and JAXB
	/// 
	/// @author steinar
	/// Date: 27.11.2015
	/// Time: 11.50
	/// </summary>
	public class SignedRemEvidence
	{

		private readonly JAXBElement<REMEvidenceType> jaxbElement;

		private readonly Document signedRemEvidenceXml;

		public SignedRemEvidence(JAXBElement<REMEvidenceType> jaxbElement, Document signedRemEvidenceXml)
		{
			this.jaxbElement = jaxbElement;
			this.signedRemEvidenceXml = signedRemEvidenceXml;
		}

		/// <summary>
		/// Provides access to the REM evidence in accordance with the XML schema. Thus allowing simple access to various
		/// fields without reverting to XPath expressions in the W3C Document.
		/// </summary>
		public virtual REMEvidenceType RemEvidenceType
		{
			get
			{
				return e();
			}
		}

		public virtual Document Document
		{
			get
			{
				return signedRemEvidenceXml;
			}
		}

		public virtual EvidenceTypeInstance EvidenceType
		{
			get
			{
				return EvidenceTypeInstance.findByLocalName(signedRemEvidenceXml.DocumentElement.LocalName);
			}
		}

		public virtual string EvidenceIdentifier
		{
			get
			{
				return e().EvidenceIdentifier;
			}
		}

		public virtual EventCode EventCode
		{
			get
			{
				return EventCode.valueFor(e().EventCode);
			}
		}

		public virtual EventReason EventReason
		{
			get
			{
				return EventReason.valueForCode(e().EventReasons.EventReason.get(0).Code);
			}
		}

		public virtual DateTime EventTime
		{
			get
			{
				return e().EventTime.toGregorianCalendar().Time;
			}
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public String getEvidenceIssuerPolicyID() throws no.difi.vefa.peppol.evidence.lang.RemEvidenceException
		public virtual string EvidenceIssuerPolicyID
		{
			get
			{
				if (e().EvidenceIssuerPolicyID == null)
				{
					throw new RemEvidenceException("Evidence issuer policy ID is not set");
				}
    
				return e().EvidenceIssuerPolicyID.PolicyID.get(0);
			}
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public String getEvidenceIssuerDetails() throws no.difi.vefa.peppol.evidence.lang.RemEvidenceException
		public virtual string EvidenceIssuerDetails
		{
			get
			{
				return ExceptionUtil.perform(typeof(RemEvidenceException), "There are no Event Issuer Details", () => e().EvidenceIssuerDetails.NamesPostalAddresses.NamePostalAddress.get(0).EntityName.Name.get(0));
			}
		}

		public virtual ParticipantIdentifier SenderIdentifier
		{
			get
			{
				EntityDetailsType senderDetails = e().SenderDetails;
				IList<object> attributedElectronicAddressOrElectronicAddress = senderDetails.AttributedElectronicAddressOrElectronicAddress;
    
				return RemHelper.readElectronicAddressType((AttributedElectronicAddressType) attributedElectronicAddressOrElectronicAddress[0]);
			}
		}


		/// <summary>
		/// Internal convenience method
		/// </summary>
		private REMEvidenceType e()
		{
			return jaxbElement.Value;
		}

		public virtual ParticipantIdentifier RecipientIdentifier
		{
			get
			{
				EntityDetailsListType entityDetailsListType = e().RecipientsDetails;
				EntityDetailsType entityDetailsType = entityDetailsListType.EntityDetails.get(0);
				IList<object> objectList = entityDetailsType.AttributedElectronicAddressOrElectronicAddress;
    
				return RemHelper.readElectronicAddressType((AttributedElectronicAddressType) objectList[0]);
			}
		}

		public virtual DocumentTypeIdentifier DocumentTypeIdentifier
		{
			get
			{
				return DocumentTypeIdentifier.of(e().SenderMessageDetails.MessageSubject, no.difi.vefa.peppol.common.model.Scheme_Fields.NONE);
			}
		}

		public virtual string DocumentTypeInstanceIdentifier
		{
			get
			{
				return e().SenderMessageDetails.UAMessageIdentifier;
			}
		}

		public virtual InstanceIdentifier InstanceIdentifier
		{
			get
			{
				return InstanceIdentifier.of(e().SenderMessageDetails.MessageIdentifierByREMMD);
			}
		}

		public virtual sbyte[] PayloadDigestValue
		{
			get
			{
				return e().SenderMessageDetails.DigestValue;
			}
		}

		public virtual PeppolRemExtension TransmissionEvidence
		{
			get
			{
				return (PeppolRemExtension) e().Extensions.Extension.get(0).Content.get(0);
			}
		}
	}

}