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

namespace no.difi.vefa.peppol.sbdh.util
{
	//using ByteStreams = com.google.common.io.ByteStreams;
	using no.difi.vefa.peppol.common.model;
	//using Test = org.testng.annotations.Test;


	public class XMLStreamUtilsTest
	{


        //ORIGINAL LINE: @Test public void simpleCopy() throws Exception
        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void simpleCopy()
		{
			Header header = Header.newInstance().sender(ParticipantIdentifier.of("9908:987654325"))
                    .receiver(ParticipantIdentifier.of("9908:123456785"))
                    .process(ProcessIdentifier.of("urn:www.cenbii.eu:profile:bii04:ver1.0"))
                    .documentType(DocumentTypeIdentifier.of("urn:oasis:names:specification:ubl:schema:xsd:Invoice-2::Invoice" 
                        + "##urn:www.cenbii.eu:transaction:biicoretrdm010:ver1.0" 
                            + ":#urn:www.peppol.eu:bis:peppol4a:ver1.0::2.0"))
                    .instanceType(InstanceType.of("urn:oasis:names:specification:ubl:schema:xsd:Invoice-2", "Invoice", "2.0"))
                    .creationTimestamp(DateTime.Now).identifier(InstanceIdentifier.generateUUID());
            Stream OutputStream = new MemoryStream(); //originally it was a google ByteStream
            using (SbdWriter sbdWriter = SbdWriter.newInstance(OutputStream/*.nullOutputStream()*/, header))
            {
                // I think we should read the xml in the inputStream
                Stream inputStream = new FileStream("/ehf-invoice-no-sbdh.xml", FileMode.Open);
                //Here we should copy the input stream xml in the writer
                inputStream.CopyTo(sbdWriter.xmlWriter());
                //XMLStreamUtils.copy(inputStream, );
			}
		}
	}
}