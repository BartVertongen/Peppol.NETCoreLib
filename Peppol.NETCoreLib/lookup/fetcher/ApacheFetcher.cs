
using System;
using System.Net.Http;
using System.Threading.Tasks;
//using Mode = no.difi.vefa.peppol.mode.Mode;
//using CloseableHttpClient = org.apache.http.impl.client.CloseableHttpClient;
//using HttpClients = org.apache.http.impl.client.HttpClients;
//using PoolingHttpClientConnectionManager = org.apache.http.impl.conn.PoolingHttpClientConnectionManager;


namespace VertSoft.Peppol.Lookup.Fetcher
{
    /// <summary>
    /// An ApacheFetcher looks like a Basic ApacheFetcher with Configuration
    /// </summary>
	public class ApacheFetcher //: BasicApacheFetcher
	{
        static readonly HttpClient client = new HttpClient();
        //private PoolingHttpClientConnectionManager httpClientConnectionManager;

		private ApacheFetcher(/*Mode mode*/) //: base(mode)
		{
            //REM here we can do some configuration.
			//this.httpClientConnectionManager = new PoolingHttpClientConnectionManager();
		}

        public static async Task<HttpResponseMessage> Fetch(Uri uri)
        {
            return await client.GetAsync(uri);
        }
    }
}