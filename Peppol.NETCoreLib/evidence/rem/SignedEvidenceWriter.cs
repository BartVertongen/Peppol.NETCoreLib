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
	using RemEvidenceException = no.difi.vefa.peppol.evidence.lang.RemEvidenceException;
	using PeppolSecurityException = no.difi.vefa.peppol.security.lang.PeppolSecurityException;
	using XmldsigSigner = no.difi.vefa.peppol.security.xmldsig.XmldsigSigner;
	using Document = org.w3c.dom.Document;
	using Node = org.w3c.dom.Node;


	public class SignedEvidenceWriter
	{

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void write(java.io.OutputStream outputStream, java.security.KeyStore.PrivateKeyEntry privateKeyEntry, Evidence evidence) throws no.difi.vefa.peppol.evidence.lang.RemEvidenceException, no.difi.vefa.peppol.security.lang.PeppolSecurityException
		public static void write(Stream outputStream, KeyStore.PrivateKeyEntry privateKeyEntry, Evidence evidence)
		{
			write(privateKeyEntry, evidence, new StreamResult(outputStream));
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static org.w3c.dom.Document write(java.security.KeyStore.PrivateKeyEntry privateKeyEntry, Evidence evidence) throws no.difi.vefa.peppol.evidence.lang.RemEvidenceException, no.difi.vefa.peppol.security.lang.PeppolSecurityException
		public static Document write(KeyStore.PrivateKeyEntry privateKeyEntry, Evidence evidence)
		{
			Document document = RemHelper.DocumentBuilder.newDocument();
			write(document, privateKeyEntry, evidence);
			return document;
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void write(org.w3c.dom.Node node, java.security.KeyStore.PrivateKeyEntry privateKeyEntry, Evidence evidence) throws no.difi.vefa.peppol.evidence.lang.RemEvidenceException, no.difi.vefa.peppol.security.lang.PeppolSecurityException
		public static void write(Node node, KeyStore.PrivateKeyEntry privateKeyEntry, Evidence evidence)
		{
			write(privateKeyEntry, evidence, new DOMResult(node));
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void write(final java.security.KeyStore.PrivateKeyEntry privateKeyEntry, final Evidence evidence, final javax.xml.transform.Result result) throws no.difi.vefa.peppol.evidence.lang.RemEvidenceException, no.difi.vefa.peppol.security.lang.PeppolSecurityException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are ignored unless the option to convert to C# 7.2 'in' parameters is selected:
		public static void write(KeyStore.PrivateKeyEntry privateKeyEntry, Evidence evidence, Result result)
		{
			Document document = RemHelper.DocumentBuilder.newDocument();
			EvidenceWriter.write(document, evidence);

			XmldsigSigner.SHA256().sign(document, privateKeyEntry, result);
		}
	}

}