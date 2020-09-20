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
	using MetadataFetcher = no.difi.vefa.peppol.lookup.api.MetadataFetcher;
	using MetadataLocator = no.difi.vefa.peppol.lookup.api.MetadataLocator;
	using MetadataProvider = no.difi.vefa.peppol.lookup.api.MetadataProvider;
	using MetadataReader = no.difi.vefa.peppol.lookup.api.MetadataReader;

	public class LookupClientBuilderTest
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void success() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void success()
		{
			assertNotNull(LookupClientBuilder.forProduction());
			assertNotNull(LookupClientBuilder.forTest());
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testMissingLocator() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void testMissingLocator()
		{
			assertNotNull(LookupClientBuilder.forProduction().locator((MetadataLocator) null).build());
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testMissingProvider() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void testMissingProvider()
		{
			assertNotNull(LookupClientBuilder.forProduction().provider((MetadataProvider) null).build());
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testMissingFetcher() throws Exception
		public virtual void testMissingFetcher()
		{
			assertNotNull(LookupClientBuilder.forProduction().fetcher((MetadataFetcher) null).build());
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testMissingReader() throws Exception
		public virtual void testMissingReader()
		{
			assertNotNull(LookupClientBuilder.forProduction().reader((MetadataReader) null).build());
		}
	}
}