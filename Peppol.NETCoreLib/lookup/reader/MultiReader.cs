
using System.Collections.Generic;
using System.IO;
using VertSoft.Peppol.Common.Api;
using VertSoft.Peppol.Common.Model;
using VertSoft.Peppol.Lookup.Api;
using System.Xml.Linq;
using System;


namespace VertSoft.Peppol.Lookup.Reader
{ 
	/// <summary>
	/// The MultiReader will try to find out which Reader to use to read SMP data.
	/// </summary>
    public class MultiReader : IMetadataReader
	{
		/// <summary>
		/// A static list with all the possible MetaReader Instances
		/// </summary>
		private static readonly List<IMetadataReader> _sMetaDataReadersList = new List<IMetadataReader>()
				{ new BusdoxReader(), new Bdxr201407Reader(), new Bdxr201605Reader(), new BdxrReader()};


		/// <summary>
		/// Gets all the ServiceReferences from the Stream containing a ServiceGroup
		/// </summary>
		/// <param name="fetcherResponse"></param>
		/// <returns>List of ServiceReferences</returns>
		/// <exception cref="LookupException"></exception>
		public virtual List<ServiceReference> ParseServiceGroup(FetcherResponse fetcherResponse)
		{
			FetcherResponse response = fetcherResponse;


			if (response.Namespace == null)
			{
				response = this.Detect(response);
			}

			foreach (IMetadataReader metadataReader in MultiReader._sMetaDataReadersList)
			{
                object[] Attributes = metadataReader.GetType().GetCustomAttributes(typeof(Namespace), false);
                Namespace NS = (Namespace)Attributes[0];
                if (NS.value.ToLower().Equals(response.Namespace.ToLower()))
				{
					return metadataReader.ParseServiceGroup(response);
				}
			}
			throw new LookupException(string.Format("Unknown namespace: {0}", response.Namespace));
		}


        //ORIGINAL LINE: @Override public PotentiallySigned<ServiceMetadata> parseServiceMetadata(FetcherResponse fetcherResponse) 
        //throws LookupException, PeppolSecurityException
		public virtual PotentiallySigned<ServiceMetadata, object> ParseServiceMetadata(FetcherResponse fetcherResponse)
		{
			FetcherResponse response = fetcherResponse;

			if (response.Namespace == null)
			{
				response = this.Detect(response);
			}

			foreach (IMetadataReader metadataReader in MultiReader._sMetaDataReadersList)
			{
                object[] Attributes = metadataReader.GetType().GetCustomAttributes(typeof(Namespace), false);
                Namespace NS = (Namespace)Attributes[0];
                if (NS.value.ToLower().Equals(response.Namespace.ToLower()))
                {
					return metadataReader.ParseServiceMetadata(response);
				}
			}

			throw new LookupException(string.Format("Unknown namespace: {0}", response.Namespace));
		}

		/// <summary>
		/// Will try to detect the namespace in a FetcherResponse
		/// </summary>
		/// <param name="fetcherResponse"></param>
		/// <returns>a FetcherResponse with the same stream and the namespace filled in.</returns>
		/// <exception cref="LookupException"></exception>
		/// <remarks>The stream should contain XML.</remarks>
		public FetcherResponse Detect(FetcherResponse fetcherResponse)
		{
			try
			{
				string strNamespace;
				MemoryStream ms = new MemoryStream();
				fetcherResponse.InputStream.CopyTo(ms);
				//Convert the Stream to XML
				ms.Position = 0;
				XElement xmlContent = XElement.Load(ms);				
				XNamespace xmlNamespace = xmlContent.GetDefaultNamespace();
				strNamespace = xmlNamespace.NamespaceName;
				if (strNamespace != null)
				{
					return new FetcherResponse(fetcherResponse.InputStream, strNamespace);
				}
				throw new LookupException("Unable to detect namespace.");
			}
			catch (Exception e)
			{
				throw new LookupException(e.Message, e);
			}
		}
	}
}