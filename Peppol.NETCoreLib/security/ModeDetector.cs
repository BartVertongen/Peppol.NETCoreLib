using System.Collections.Generic;

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
	using Config = com.typesafe.config.Config;
	using ConfigFactory = com.typesafe.config.ConfigFactory;
	using Slf4j = lombok.@extern.slf4j.Slf4j;
	using Service = no.difi.vefa.peppol.common.code.Service;
	using PeppolLoadingException = no.difi.vefa.peppol.common.lang.PeppolLoadingException;
	using Mode = no.difi.vefa.peppol.mode.Mode;
	using CertificateValidator = no.difi.vefa.peppol.security.api.CertificateValidator;
	using PeppolSecurityException = no.difi.vefa.peppol.security.lang.PeppolSecurityException;


//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Slf4j public class ModeDetector
	public class ModeDetector
	{

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static no.difi.vefa.peppol.mode.Mode detect(java.security.cert.X509Certificate certificate) throws no.difi.vefa.peppol.common.lang.PeppolLoadingException
		public static Mode detect(X509Certificate certificate)
		{
			return detect(certificate, ConfigFactory.load(), null);
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static no.difi.vefa.peppol.mode.Mode detect(java.security.cert.X509Certificate certificate, com.typesafe.config.Config config, java.util.Map<String, Object> objectStorage) throws no.difi.vefa.peppol.common.lang.PeppolLoadingException
		public static Mode detect(X509Certificate certificate, Config config, IDictionary<string, object> objectStorage)
		{
			foreach (string token in config.getObject("mode").Keys)
			{
				if (!"default".Equals(token))
				{
					try
					{
						Mode mode = Mode.of(config, token);
						mode.initiate("security.validator.class", typeof(CertificateValidator), objectStorage).validate(Service.ALL, certificate);
						return mode;
					}
					catch (PeppolSecurityException e)
					{
						log.info("Detection error ({}): {}", token, e.Message);
					}
				}
			}

			throw new PeppolLoadingException(string.Format("Unable to detect mode for certificate '{0}'.", certificate.SubjectDN.ToString()));
		}
	}

}