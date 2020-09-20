
using System.IO;


namespace VertSoft.Peppol.Lookup.Api
{
    /// <summary>
    /// A FetcherResponse contains a namespace and an inputstream
    /// </summary>
	public class FetcherResponse
	{
		public FetcherResponse(Stream inputStream) : this(inputStream, null)
		{
		}

		public FetcherResponse(Stream inputStream, string @namespace)
		{
			this.InputStream = inputStream;
			this.Namespace = @namespace;
		}

		public Stream InputStream { get; private set; }

		public string Namespace { get; private set; }
	}
}