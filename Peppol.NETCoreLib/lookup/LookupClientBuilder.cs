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

namespace no.difi.vefa.peppol.lookup
{
	using PeppolLoadingException = no.difi.vefa.peppol.common.lang.PeppolLoadingException;
	using MetadataFetcher = no.difi.vefa.peppol.lookup.api.MetadataFetcher;
	using MetadataLocator = no.difi.vefa.peppol.lookup.api.MetadataLocator;
	using MetadataProvider = no.difi.vefa.peppol.lookup.api.MetadataProvider;
	using MetadataReader = no.difi.vefa.peppol.lookup.api.MetadataReader;
	using Mode = no.difi.vefa.peppol.mode.Mode;
	using CertificateValidator = no.difi.vefa.peppol.security.api.CertificateValidator;
	using EmptyCertificateValidator = no.difi.vefa.peppol.security.util.EmptyCertificateValidator;

	public class LookupClientBuilder
	{

		private Mode mode;

		protected internal MetadataFetcher metadataFetcher;

		protected internal MetadataLocator metadataLocator;

//JAVA TO C# CONVERTER NOTE: Fields cannot have the same name as methods:
		protected internal CertificateValidator certificateValidator_Conflict = EmptyCertificateValidator.INSTANCE;

		protected internal MetadataProvider metadataProvider;

		protected internal MetadataReader metadataReader;

		public static LookupClientBuilder newInstance(Mode mode)
		{
			return new LookupClientBuilder(mode);
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static LookupClientBuilder forMode(no.difi.vefa.peppol.mode.Mode mode) throws no.difi.vefa.peppol.common.lang.PeppolLoadingException
		public static LookupClientBuilder forMode(Mode mode)
		{
			return newInstance(mode).certificateValidator(mode.initiate("security.validator.class", typeof(CertificateValidator)));
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static LookupClientBuilder forMode(String modeIdentifier) throws no.difi.vefa.peppol.common.lang.PeppolLoadingException
		public static LookupClientBuilder forMode(string modeIdentifier)
		{
			return forMode(Mode.of(modeIdentifier));
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static LookupClientBuilder forProduction() throws no.difi.vefa.peppol.common.lang.PeppolLoadingException
		public static LookupClientBuilder forProduction()
		{
			return forMode(Mode.PRODUCTION);
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static LookupClientBuilder forTest() throws no.difi.vefa.peppol.common.lang.PeppolLoadingException
		public static LookupClientBuilder forTest()
		{
			return forMode(Mode.TEST);
		}

		private LookupClientBuilder(Mode mode)
		{
			this.mode = mode;
		}

		public virtual LookupClientBuilder fetcher(MetadataFetcher metadataFetcher)
		{
			this.metadataFetcher = metadataFetcher;
			return this;
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public LookupClientBuilder fetcher(Class metadataFetcher) throws no.difi.vefa.peppol.common.lang.PeppolLoadingException
		public virtual LookupClientBuilder fetcher(System.Type metadataFetcher)
		{
			return fetcher(mode.initiate(metadataFetcher));
		}

		public virtual LookupClientBuilder locator(MetadataLocator metadataLocator)
		{
			this.metadataLocator = metadataLocator;
			return this;
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public LookupClientBuilder locator(Class metadataLocator) throws no.difi.vefa.peppol.common.lang.PeppolLoadingException
		public virtual LookupClientBuilder locator(System.Type metadataLocator)
		{
			return locator(mode.initiate(metadataLocator));
		}

		public virtual LookupClientBuilder provider(MetadataProvider metadataProvider)
		{
			this.metadataProvider = metadataProvider;
			return this;
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public LookupClientBuilder provider(Class metadataProvider) throws no.difi.vefa.peppol.common.lang.PeppolLoadingException
		public virtual LookupClientBuilder provider(System.Type metadataProvider)
		{
			return provider(mode.initiate(metadataProvider));
		}

		public virtual LookupClientBuilder reader(MetadataReader metadataReader)
		{
			this.metadataReader = metadataReader;
			return this;
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public LookupClientBuilder reader(Class metadataReader) throws no.difi.vefa.peppol.common.lang.PeppolLoadingException
		public virtual LookupClientBuilder reader(System.Type metadataReader)
		{
			return reader(mode.initiate(metadataReader));
		}

		public virtual LookupClientBuilder certificateValidator(CertificateValidator certificateValidator)
		{
			this.certificateValidator_Conflict = certificateValidator;
			return this;
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public LookupClient build() throws no.difi.vefa.peppol.common.lang.PeppolLoadingException
		public virtual LookupClient build()
		{
			if (metadataLocator == null)
			{
				locator(mode.initiate("lookup.locator.class", typeof(MetadataLocator)));
			}
			if (metadataProvider == null)
			{
				provider(mode.initiate("lookup.provider.class", typeof(MetadataProvider)));
			}
			if (metadataFetcher == null)
			{
				fetcher(mode.initiate("lookup.fetcher.class", typeof(MetadataFetcher)));
			}
			if (metadataReader == null)
			{
				reader(mode.initiate("lookup.reader.class", typeof(MetadataReader)));
			}

			return new LookupClient(this);
		}
	}

}