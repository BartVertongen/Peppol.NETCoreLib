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
	//using REMEvidenceType = no.difi.vefa.peppol.evidence.jaxb.rem.REMEvidenceType;

	/// <summary>
	/// </summary>
	public class ParseRemTest
	{
		public const string SAMPLE_REM_XML = "sample-rem.xml";

		/// <summary>
		/// Uses JAXB to parse the sample REM evidence provided by Jörg Apitzsch.
		/// </summary>
		/// <exception cref="Exception"> </exception>
        //ORIGINAL LINE: @Test public void parseSampleRem() throws Exception
		public virtual void parseSampleRem()
		{

			Stream sampleRemInputStream = typeof(ParseRemTest).ClassLoader.getResourceAsStream(SAMPLE_REM_XML);
			assertNotNull(sampleRemInputStream, "Unable to locate " + SAMPLE_REM_XML + " in class path");

			JAXBContext jaxbContext = JAXBContext.newInstance(typeof(REMEvidenceType));
			Unmarshaller unmarshaller = jaxbContext.createUnmarshaller();
			JAXBElement unmarshalled = (JAXBElement) unmarshaller.unmarshal(sampleRemInputStream);

			REMEvidenceType value = (REMEvidenceType) unmarshalled.Value;

			assertEquals(value.EventCode, EventCode.DELIVERY.Value);
		}
	}
}