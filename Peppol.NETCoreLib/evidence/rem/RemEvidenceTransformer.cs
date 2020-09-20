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
	using REMEvidenceType = no.difi.vefa.peppol.evidence.jaxb.rem.REMEvidenceType;
	using RemEvidenceException = no.difi.vefa.peppol.evidence.lang.RemEvidenceException;
	using Document = org.w3c.dom.Document;
	using SAXException = org.xml.sax.SAXException;


	/// <summary>
	/// Transforms SignedRemEvidence back and forth between various representations like for instance
	/// W3C Document and XML.
	/// <p/>
	/// <p/>
	/// The constructor is package protected as you are expected to use the <seealso cref="RemEvidenceService"/>  to
	/// create instances of this class.
	/// <p/>
	/// Created by steinar on 08.11.2015.
	/// </summary>
	public class RemEvidenceTransformer
	{

		private bool formattedOutput = true;

		/// <summary>
		/// Transforms SignedRemEvidence into XML representation suitable for signature verification etc.
		/// I.e. the output is not formatted.
		/// </summary>
		/// <param name="signedRemEvidence"> instance to be formatted. </param>
		/// <param name="outputStream"> </param>
		/// <exception cref="RemEvidenceException"> </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void toUnformattedXml(SignedRemEvidence signedRemEvidence, java.io.OutputStream outputStream) throws no.difi.vefa.peppol.evidence.lang.RemEvidenceException
		public virtual void toUnformattedXml(SignedRemEvidence signedRemEvidence, Stream outputStream)
		{
			format(signedRemEvidence, outputStream, false);
		}

		/// <summary>
		/// Transforms the supplied signed REM Evidence into it's formatted XML representation.
		/// <p/>
		/// NOTE! Do not use this XML representation for signature validation as this will fail.
		/// </summary>
		/// <param name="signedRemEvidence"> </param>
		/// <param name="outputStream"> </param>
		/// <exception cref="RemEvidenceException"> </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void toFormattedXml(SignedRemEvidence signedRemEvidence, java.io.OutputStream outputStream) throws no.difi.vefa.peppol.evidence.lang.RemEvidenceException
		public virtual void toFormattedXml(SignedRemEvidence signedRemEvidence, Stream outputStream)
		{
			format(signedRemEvidence, outputStream, true);
		}

		/// <summary>
		/// Internal convenience method
		/// </summary>
		/// <param name="signedRemEvidence"> rem evidence to transform </param>
		/// <param name="outputStream">      into which the formatted output should be emitted. </param>
		/// <param name="formatted">         indicates whether the output should be formatted (true) or not (false) </param>
		/// <exception cref="RemEvidenceException"> </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: protected void format(SignedRemEvidence signedRemEvidence, java.io.OutputStream outputStream, boolean formatted) throws no.difi.vefa.peppol.evidence.lang.RemEvidenceException
		protected internal virtual void format(SignedRemEvidence signedRemEvidence, Stream outputStream, bool formatted)
		{
			Transformer transformer;
			try
			{
				transformer = TransformerFactory.newInstance().newTransformer();
			}
			catch (TransformerConfigurationException)
			{
				throw new RemEvidenceException("Unable to crate a new transformer");
			}

			if (formatted)
			{
				transformer.setOutputProperty(OutputKeys.INDENT, "yes");
				transformer.setOutputProperty("{http://xml.apache.org/xslt}indent-amount", "4");
			}
			StreamResult result = new StreamResult(outputStream);
			DOMSource source = new DOMSource(signedRemEvidence.Document);
			try
			{
				transformer.transform(source, result);
			}
			catch (TransformerException e)
			{
				throw new RemEvidenceException("Transformation of SignedRemEvidence to XML failed:" + e.Message, e);
			}
		}

		/// <summary>
		/// Parses a REM evidence instance represented as a W3C Document and creates the equivalent JAXB representation.
		/// It is package protected as this is not something that should not be done outside of this package.
		/// </summary>
		/// <param name="signedRemDocument">
		/// @return </param>
		/// <exception cref="RemEvidenceException"> </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: protected static javax.xml.bind.JAXBElement<no.difi.vefa.peppol.evidence.jaxb.rem.REMEvidenceType> toJaxb(org.w3c.dom.Document signedRemDocument) throws no.difi.vefa.peppol.evidence.lang.RemEvidenceException
		protected internal static JAXBElement<REMEvidenceType> toJaxb(Document signedRemDocument)
		{
			try
			{
				Unmarshaller unmarshaller = RemHelper.Unmarshaller;
				return unmarshaller.unmarshal(signedRemDocument, typeof(REMEvidenceType));
			}
			catch (JAXBException)
			{
				throw new RemEvidenceException("Unable to create unmarshaller");
			}
		}


		/// <summary>
		/// Parses the contents of an InputStream, which is expected to supply
		/// a signed REMEvidenceType in XML representation.
		/// <p/>
		/// Step 1: parses xml into W3C Document
		/// Step 2: converts W3C Document into JAXBElement
		/// </summary>
		/// <param name="inputStream"> holding the xml representation of a signed REM evidence. </param>
		/// <returns> SignedRemEvidence </returns>
		/// <exception cref="RemEvidenceException"> </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public SignedRemEvidence parse(java.io.InputStream inputStream) throws no.difi.vefa.peppol.evidence.lang.RemEvidenceException
		public virtual SignedRemEvidence parse(Stream inputStream)
		{

			// 1) Parses XML into W3C Document
			Document parsedDocument;
			try
			{
				DocumentBuilderFactory documentBuilderFactory = DocumentBuilderFactory.newInstance();
				documentBuilderFactory.NamespaceAware = true;
				DocumentBuilder documentBuilder = documentBuilderFactory.newDocumentBuilder();
				parsedDocument = documentBuilder.parse(inputStream);
			}
			catch (ParserConfigurationException e)
			{
				throw new RemEvidenceException("Unable to create DocumentBuilder " + e.Message, e);
			}
			catch (Exception e) when (e is SAXException || e is IOException)
			{
				throw new RemEvidenceException("Unable to parse xml input " + e.Message, e);
			}

			// 2) Parses it into the JAXB representation.
			JAXBElement<REMEvidenceType> remEvidenceTypeJAXBElement = toJaxb(parsedDocument);

			return new SignedRemEvidence(remEvidenceTypeJAXBElement, parsedDocument);
		}

		public virtual bool FormattedOutput
		{
			get
			{
				return formattedOutput;
			}
			set
			{
				this.formattedOutput = value;
			}
		}

	}

}