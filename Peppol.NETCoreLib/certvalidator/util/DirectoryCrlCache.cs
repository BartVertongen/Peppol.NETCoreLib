using System;
using System.IO;
using no.difi.certvalidator.api;
using CrlCache = no.difi.certvalidator.api.CrlCache;


namespace no.difi.certvalidator.util
{
	/// <summary>
	/// </summary>
	public class DirectoryCrlCache : CrlCache
	{

		private Path folder;

        //ORIGINAL LINE: public DirectoryCrlCache(java.nio.file.Path folder) throws java.io.IOException
		public DirectoryCrlCache(Path folder)
		{
			this.folder = folder;

			Files.createDirectories(folder);
		}


        //ORIGINAL LINE: @Override public java.security.cert.X509CRL get(String url) throws no.difi.certvalidator.api.CertificateValidationException
		public virtual X509CRL get(string url)
		{
			Path file = folder.resolve(filterUrl(url));

			if (!Files.exists(file))
			{
				return null;
			}

			try
			{
					using (Stream inputStream = Files.newInputStream(file))
					{
					return CrlUtils.load(inputStream);
					}
			}
			catch (Exception e) //when (e is IOException || e is CRLException)
			{
				return null;
			}
		}

		public virtual void set(string url, X509CRL crl)
		{
			Path file = folder.resolve(filterUrl(url));

			try
			{
					using (Stream outputStream = Files.newOutputStream(file))
					{
					CrlUtils.save(outputStream, crl);
					}
			}
			catch (Exception e) //when (e is IOException || e is CRLException)
			{
				// No action.
			}
		}

		private string filterUrl(string s)
		{
			return s.replaceAll("[^a-zA-Z0-9.\\-]", "_");
		}
	}
}