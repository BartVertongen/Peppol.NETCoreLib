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
	using Logger = org.slf4j.Logger;
	using LoggerFactory = org.slf4j.LoggerFactory;
	using Test = org.testng.annotations.Test;

//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to C#:
//	import static org.testng.Assert.*;


	/// <summary>
	/// @author steinar
	///         Date: 05.11.2015
	///         Time: 17.49
	/// </summary>
	public class TestResourcesTest
	{


		public static readonly Logger LOGGER = LoggerFactory.getLogger(typeof(TestResourcesTest));

		/// <summary>
		/// Attempts to retrieve the private key held in our test keystore </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void getPrivateKey()
		public virtual void getPrivateKey()
		{

			KeyStore.PrivateKeyEntry privateKey = TestResources.PrivateKey;
			assertNotNull(privateKey);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void loadMimeMessage() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void loadMimeMessage()
		{

			MimeMessage mimeMessage = TestResources.getMimeMessageFromResource("as2-mdn-smime.txt");
			assertNotNull(mimeMessage);

			MemoryStream baos = new MemoryStream();
			mimeMessage.writeTo(baos);

			LOGGER.debug("Size of baos: " + baos.size());
			LOGGER.debug("Size of mime message:" + mimeMessage.Size);

			Stream rawInputStream = mimeMessage.RawInputStream;
			int counter = 0;
			while (rawInputStream.Read() >= 0)
			{
				counter++;
			}
			LOGGER.debug("Size of raw input stream " + counter);

			// Headers are not part of the MIME message itself, the are however part of the MimeMessage object:
			//
			// MIME-Version: 1.0
			// Content-Type: multipart/signed; protocol="application/pkcs7-signature"; micalg=sha-1;
			// boundary="----=_Part_34_426016548.1445612302735"
			assertEquals(counter, mimeMessage.Size);

			// Should contain the complete content type with parameters
			string contentType = mimeMessage.ContentType;
			assertTrue(contentType.StartsWith("multipart/signed", StringComparison.Ordinal));

			System.Collections.IEnumerator allHeaderLines = mimeMessage.AllHeaderLines;
			while (allHeaderLines.MoveNext())
			{
				string s = (string) allHeaderLines.Current;
				LOGGER.debug(s);
			}
		}
	}

}