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
	using Signed = no.difi.vefa.peppol.common.model.Signed;
	using RemEvidenceException = no.difi.vefa.peppol.evidence.lang.RemEvidenceException;
	using PeppolSecurityException = no.difi.vefa.peppol.security.lang.PeppolSecurityException;
	using XmldsigVerifier = no.difi.vefa.peppol.security.xmldsig.XmldsigVerifier;
	using Document = org.w3c.dom.Document;
	using Node = org.w3c.dom.Node;
	using SAXException = org.xml.sax.SAXException;


	public class SignedEvidenceReader
	{

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static no.difi.vefa.peppol.common.model.Signed<Evidence> read(java.io.InputStream inputStream) throws no.difi.vefa.peppol.evidence.lang.RemEvidenceException, no.difi.vefa.peppol.security.lang.PeppolSecurityException
		public static Signed<Evidence> read(Stream inputStream)
		{
			try
			{
				return read(RemHelper.DocumentBuilder.parse(inputStream));
			}
			catch (Exception e) when (e is SAXException || e is IOException)
			{
				throw new RemEvidenceException(e.Message, e);
			}
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static no.difi.vefa.peppol.common.model.Signed<Evidence> read(org.w3c.dom.Node node) throws no.difi.vefa.peppol.evidence.lang.RemEvidenceException, no.difi.vefa.peppol.security.lang.PeppolSecurityException
		public static Signed<Evidence> read(Node node)
		{
			if (!(node is Document))
			{
				throw new RemEvidenceException("Node of type Document required.");
			}

			X509Certificate certificate = XmldsigVerifier.verify((Document) node);
			return Signed.of(EvidenceReader.read(node), certificate);
		}
	}

}