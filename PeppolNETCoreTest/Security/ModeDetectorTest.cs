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

namespace no.difi.vefa.peppol.security
{
	using Validator = no.difi.certvalidator.Validator;
	using PeppolLoadingException = no.difi.vefa.peppol.common.lang.PeppolLoadingException;

	public class ModeDetectorTest
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void simpleConstructor()
		public virtual void simpleConstructor()
		{
			new ModeDetector();
		}

        //ORIGINAL LINE: @Test(expectedExceptions = PeppolLoadingException.class) public void simpleDetectError() throws Exception
		public virtual void simpleDetectError()
		{
			X509Certificate certificate = Validator.getCertificate(this.GetType().getResourceAsStream("/web-difi.cer"));
			ModeDetector.detect(certificate).getString("security.pki");
		}

        //ORIGINAL LINE: @Test(enabled = false) public void simpleDetectProduction() throws Exception
		public virtual void simpleDetectProduction()
		{
			X509Certificate certificate = Validator.getCertificate(this.GetType().getResourceAsStream("/ap-difi-prod.cer"));
			Assert.assertEquals(ModeDetector.detect(certificate).getString("security.pki"), "/pki/peppol-production.xml");
		}

        //ORIGINAL LINE: @Test public void simpleDetectTest() throws Exception
		public virtual void simpleDetectTest()
		{
			X509Certificate certificate = Validator.getCertificate(this.GetType().getResourceAsStream("/ap-difi-test.cer"));
			Assert.assertEquals(ModeDetector.detect(certificate).getString("security.pki"), "/pki/peppol-test.xml");
		}
	}

}