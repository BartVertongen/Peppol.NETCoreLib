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

	public class EvidenceReaderTest
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void simpleConstructor()
		public virtual void simpleConstructor()
		{
			new EvidenceReader();
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test(expectedExceptions = no.difi.vefa.peppol.evidence.lang.RemEvidenceException.class) public void exceptionOnInputStreamError() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void exceptionOnInputStreamError()
		{
			EvidenceReader.read(new Stream());
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test(expectedExceptions = no.difi.vefa.peppol.evidence.lang.RemEvidenceException.class, expectedExceptionsMessageRegExp = "Version .*") public void exceptionOnInvalidVersion() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void exceptionOnInvalidVersion()
		{
			EvidenceReader.read(this.GetType().getResourceAsStream("/test-version-1.xml"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void readSimpleFile() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void readSimpleFile()
		{
			Evidence evidence = EvidenceReader.read(this.GetType().getResourceAsStream("/sample-signed-formatted-rem.xml"));
			Assert.assertFalse(evidence.hasPeppolExtensionValues());
		}
	}

}