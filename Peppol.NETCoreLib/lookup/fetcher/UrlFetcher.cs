using System;

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
	using FetcherResponse = no.difi.vefa.peppol.lookup.api.FetcherResponse;
	using LookupException = no.difi.vefa.peppol.lookup.api.LookupException;
	using Mode = no.difi.vefa.peppol.mode.Mode;


	public class UrlFetcher : AbstractFetcher
	{

		public UrlFetcher(Mode mode) : base(mode)
		{
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: @Override public no.difi.vefa.peppol.lookup.api.FetcherResponse fetch(URI uri) throws no.difi.vefa.peppol.lookup.api.LookupException, java.io.FileNotFoundException
		public virtual FetcherResponse fetch(URI uri)
		{
			try
			{
				HttpURLConnection urlConnection = (HttpURLConnection) uri.toURL().openConnection();
				urlConnection.ConnectTimeout = timeout;
				urlConnection.ReadTimeout = timeout;

				if (urlConnection.ResponseCode != 200)
				{
					throw new LookupException(string.Format("Received code '{0}' from SMP.", urlConnection.ResponseCode));
				}

				return new FetcherResponse(new BufferedInputStream(urlConnection.InputStream), urlConnection.getHeaderField("X-SMP-Namespace"));
			}
			catch (FileNotFoundException)
			{
				throw new FileNotFoundException(uri.ToString());
			}
			catch (Exception e) when (e is SocketTimeoutException || e is SocketException)
			{
				throw new LookupException(string.Format("Unable to fetch '{0}'", uri), e);
			}
			catch (IOException e)
			{
				throw new LookupException(e.Message, e);
			}
		}
	}

}