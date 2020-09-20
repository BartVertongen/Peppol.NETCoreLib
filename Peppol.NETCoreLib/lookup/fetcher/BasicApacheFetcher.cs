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

namespace no.difi.vefa.peppol.lookup.fetcher
{
	using ByteStreams = com.google.common.io.ByteStreams;
	using FetcherResponse = no.difi.vefa.peppol.lookup.api.FetcherResponse;
	using LookupException = no.difi.vefa.peppol.lookup.api.LookupException;
	using Mode = no.difi.vefa.peppol.mode.Mode;
	using RequestConfig = org.apache.http.client.config.RequestConfig;
	using CloseableHttpResponse = org.apache.http.client.methods.CloseableHttpResponse;
	using HttpGet = org.apache.http.client.methods.HttpGet;
	using CloseableHttpClient = org.apache.http.impl.client.CloseableHttpClient;
	using HttpClients = org.apache.http.impl.client.HttpClients;


	public class BasicApacheFetcher : AbstractFetcher
	{

		protected internal RequestConfig requestConfig;

		public BasicApacheFetcher(Mode mode) : base(mode)
		{

			this.requestConfig = RequestConfig.custom().setConnectionRequestTimeout(timeout).setConnectTimeout(timeout).setSocketTimeout(timeout).build();
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: @Override public no.difi.vefa.peppol.lookup.api.FetcherResponse fetch(java.net.URI uri) throws no.difi.vefa.peppol.lookup.api.LookupException, java.io.FileNotFoundException
		public override FetcherResponse fetch(URI uri)
		{
			try
			{
					using (CloseableHttpClient httpClient = createClient())
					{
					HttpGet httpGet = new HttpGet(uri);
        
					using (CloseableHttpResponse response = httpClient.execute(httpGet))
					{
						switch (response.StatusLine.StatusCode)
						{
							case 200:
								return new FetcherResponse(new MemoryStream(ByteStreams.toByteArray(response.Entity.Content)), response.containsHeader("X-SMP-Namespace") ? response.getFirstHeader("X-SMP-Namespace").Value : null);
							case 404:
								throw new FileNotFoundException(uri.ToString());
							default:
								throw new LookupException(string.Format("Received code {0} for lookup. URI: {1}", response.StatusLine.StatusCode, uri));
						}
					}
					}
			}
			catch (Exception e) when (e is SocketTimeoutException || e is SocketException || e is UnknownHostException)
			{
				throw new LookupException(string.Format("Unable to fetch '{0}'", uri), e);
			}
			catch (Exception e) when (e is LookupException || e is FileNotFoundException)
			{
				throw e;
			}
			catch (Exception e)
			{
				throw new LookupException(e.Message, e);
			}
		}

		protected internal virtual CloseableHttpClient createClient()
		{
			return HttpClients.custom().setDefaultRequestConfig(requestConfig).build();
		}
	}

}