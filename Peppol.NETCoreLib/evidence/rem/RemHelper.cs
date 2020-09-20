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
	using PeppolRuntimeException = no.difi.vefa.peppol.common.lang.PeppolRuntimeException;
	using ParticipantIdentifier = no.difi.vefa.peppol.common.model.ParticipantIdentifier;
	using Scheme = no.difi.vefa.peppol.common.model.Scheme;
	using ExceptionUtil = no.difi.vefa.peppol.common.util.ExceptionUtil;
	using PeppolRemExtension = no.difi.vefa.peppol.evidence.jaxb.receipt.PeppolRemExtension;
	using AttributedElectronicAddressType = no.difi.vefa.peppol.evidence.jaxb.rem.AttributedElectronicAddressType;
	using EventReasonType = no.difi.vefa.peppol.evidence.jaxb.rem.EventReasonType;
	using ObjectFactory = no.difi.vefa.peppol.evidence.jaxb.rem.ObjectFactory;
	using REMEvidenceType = no.difi.vefa.peppol.evidence.jaxb.rem.REMEvidenceType;
	using RemEvidenceException = no.difi.vefa.peppol.evidence.lang.RemEvidenceException;
	using DomUtils = no.difi.vefa.peppol.security.xmldsig.DomUtils;


	internal class RemHelper
	{

		private static JAXBContext jaxbContext;

		public static readonly ObjectFactory OBJECT_FACTORY = new ObjectFactory();

		private static DatatypeFactory datatypeFactory;

		static RemHelper()
		{
			ExceptionUtil.perform(typeof(PeppolRuntimeException), () =>
			{
			jaxbContext = JAXBContext.newInstance(typeof(REMEvidenceType), typeof(PeppolRemExtension));
			datatypeFactory = DatatypeFactory.newInstance();
			});
		}

		public static AttributedElectronicAddressType createElectronicAddressType(ParticipantIdentifier participant)
		{
			AttributedElectronicAddressType o = new AttributedElectronicAddressType();
			o.Value = participant.Identifier;
			o.Scheme = participant.Scheme.Identifier;

			return o;
		}

		public static ParticipantIdentifier readElectronicAddressType(AttributedElectronicAddressType o)
		{
			return ParticipantIdentifier.of(o.Value, Scheme.of(o.Scheme));
		}

		public static EventReasonType createEventReasonType(EventReason eventReason)
		{
			EventReasonType o = new EventReasonType();
			o.Code = eventReason.Code;
			o.Details = eventReason.Details;

			return o;
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static javax.xml.datatype.XMLGregorianCalendar toXmlGregorianCalendar(java.util.Date date) throws no.difi.vefa.peppol.evidence.lang.RemEvidenceException
		public static XMLGregorianCalendar toXmlGregorianCalendar(DateTime date)
		{
			GregorianCalendar c = new GregorianCalendar();
			c.Time = date;

			XMLGregorianCalendar xmlGregorianCalendar = datatypeFactory.newXMLGregorianCalendar(c);
			xmlGregorianCalendar.Millisecond = DatatypeConstants.FIELD_UNDEFINED;
			return xmlGregorianCalendar;
		}

		public static DateTime fromXmlGregorianCalendar(XMLGregorianCalendar calendar)
		{
			return calendar.toGregorianCalendar().Time;
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static javax.xml.bind.Marshaller getMarshaller() throws javax.xml.bind.JAXBException
		public static Marshaller Marshaller
		{
			get
			{
				return jaxbContext.createMarshaller();
			}
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static javax.xml.bind.Unmarshaller getUnmarshaller() throws javax.xml.bind.JAXBException
		public static Unmarshaller Unmarshaller
		{
			get
			{
				return jaxbContext.createUnmarshaller();
			}
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static javax.xml.parsers.DocumentBuilder getDocumentBuilder() throws no.difi.vefa.peppol.evidence.lang.RemEvidenceException
		public static DocumentBuilder DocumentBuilder
		{
			get
			{
				return ExceptionUtil.perform(typeof(RemEvidenceException), () => DomUtils.newDocumentBuilder());
			}
		}
	}

}