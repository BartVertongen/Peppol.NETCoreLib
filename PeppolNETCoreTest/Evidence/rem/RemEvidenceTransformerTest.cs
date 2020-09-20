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
	using PeppolSecurityException = no.difi.vefa.peppol.security.lang.PeppolSecurityException;
	using XmldsigVerifier = no.difi.vefa.peppol.security.xmldsig.XmldsigVerifier;

	/// <summary>
	/// Created by steinar on 08.11.2015.
	/// </summary>
	public class RemEvidenceTransformerTest
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void buildStreamAndParseRemEvidence() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void buildStreamAndParseRemEvidence()
		{

			// Obtains instance of the service which is the entry point to the Rem package
			TestResources.RemEvidenceService;

			// Creates the sample REMEvidenceType
			SignedRemEvidence signedRemEvidence = TestResources.createSampleRemEvidence();

			// Creates the transformer
			RemEvidenceTransformer remEvidenceTransformer = new RemEvidenceTransformer();

			// where to place the transformed output
			MemoryStream baos = new MemoryStream();

			// performs the actual transformation into XML representation
			remEvidenceTransformer.toFormattedXml(signedRemEvidence, baos);

			Console.WriteLine(baos.ToString());

			// Attempts to parse the XML transformed REMEvidence, signature verification should fail
			// as the XML is formatted
			SignedRemEvidence remEvidence = remEvidenceTransformer.parse(new MemoryStream(baos.toByteArray()));

			assertNotNull(remEvidence);

			try
			{
				XmldsigVerifier.verify(remEvidence.Document);
				fail("Tthe formatted xml should not constitute a valid signature");
			}
			catch (PeppolSecurityException)
			{
				// This is expected
			}
		}

		/// <summary>
		/// Creates sample REM Evidence, transforms it into XML representation and
		/// parses it back into a Java object again.
		/// </summary>
		/// <exception cref="Exception"> </exception>
        //ORIGINAL LINE: @Test public void verifyRoundTrip() throws Exception
		public virtual void verifyRoundTrip()
		{
			// Obtains instance of the service which is the entry point to the Rem package
			TestResources.RemEvidenceService;

			// Creates the sample REMEvidenceType
			SignedRemEvidence signedRemEvidence = TestResources.createSampleRemEvidence();

			// Transforms evidence to XML representation
			RemEvidenceTransformer remEvidenceTransformer = new RemEvidenceTransformer();
			MemoryStream baos = new MemoryStream();
			remEvidenceTransformer.FormattedOutput = false;
			remEvidenceTransformer.toUnformattedXml(signedRemEvidence, baos);

			// Transforms back again....
			SignedRemEvidence remEvidence = remEvidenceTransformer.parse(new MemoryStream(baos.toByteArray()));

			// Signature should still verify
			RemEvidenceService.verifySignature(remEvidence);
		}
	}
}