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
	using Signed = no.difi.vefa.peppol.common.model.Signed<Document, Evidence>;
	using Document = org.w3c.dom.Document;


	public class SignedEvidenceCombinedTest
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void simpleStream() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void simpleStream()
		{
			MemoryStream outputStream = new MemoryStream();

			SignedEvidenceWriter.write(outputStream, TestResources.PrivateKey, EvidenceTest.EVIDENCE);

			Signed<Evidence> evidenceSigned = SignedEvidenceReader.read(new MemoryStream(outputStream.toByteArray()));

			Assert.assertEquals(evidenceSigned.Certificate, TestResources.PrivateKey.Certificate);
			Assert.assertEquals(evidenceSigned.Content, EvidenceTest.EVIDENCE);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void simpleNode() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void simpleNode()
		{
			Document document = SignedEvidenceWriter.write(TestResources.PrivateKey, EvidenceTest.EVIDENCE);

			Signed<Evidence> evidenceSigned = SignedEvidenceReader.read(document);

			Assert.assertEquals(evidenceSigned.Certificate, TestResources.PrivateKey.Certificate);
			Assert.assertEquals(evidenceSigned.Content, EvidenceTest.EVIDENCE);
		}
	}
}