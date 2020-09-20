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
	using Node = org.w3c.dom.Node;

	public class SignedEvidenceReaderTest
	{


		public virtual void simpleConstructor()
		{
			new SignedEvidenceReader();
		}

        //ORIGINAL LINE: @Test(expectedExceptions = RemEvidenceException.class, expectedExceptionsMessageRegExp = "Node of type Document required\\.") 
        //public void exceptionOnNonDocumentType() throws Exception
		public virtual void exceptionOnNonDocumentType()
		{
			SignedEvidenceReader.read(new Node());
		}

        //ORIGINAL LINE: @Test(expectedExceptions = RemEvidenceException.class) public void exceptionOnInputStreamError() throws Exception
		public virtual void exceptionOnInputStreamError()
		{
			SignedEvidenceReader.read(Mockito.mock(typeof(Stream)));
		}
	}
}