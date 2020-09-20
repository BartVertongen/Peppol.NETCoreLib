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

namespace no.difi.vefa.peppol.lookup.fetcher
{
	using MetadataFetcher = no.difi.vefa.peppol.lookup.api.MetadataFetcher;
	using Mode = no.difi.vefa.peppol.mode.Mode;

	public abstract class AbstractFetcher : MetadataFetcher
	{
		public abstract FetcherResponse fetch(java.net.URI uri);

		protected internal int timeout = 10000;

		public AbstractFetcher(Mode mode)
		{
			timeout = int.Parse(mode.getString("lookup.fetcher.timeout"));
		}
	}

}