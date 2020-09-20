
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Xml;
using System.Xml.Serialization;
using VertSoft.Peppol.Common.Api;
using VertSoft.Peppol.Common.Model;
using VertSoft.Peppol.Lookup.Model;
using VertSoft.Peppol.Publisher.Model;
using VertSoft.Peppol.Security.Xmldsig;
using VertSoft.Peppol.Types.Smp.AggregateComponents;
using VertSoft.Peppol.Types.Smp.ServiceGroup_2;
using VertSoft.Peppol.Types.Smp.ServiceMetadata_2;
using VertSoft.Peppol.Lookup.Api;
using VertSoft.Peppol.Common.Model.Lang;

namespace VertSoft.Peppol.Lookup.Reader
{
	/// <summary>
	/// MetadataReader for SMP2 BDXR
	/// </summary>
	[Namespace("http://docs.oasis-open.org/bdxr/ns/SMP/2/")]
	public class BdxrReader : IMetadataReader
	{
		static BdxrReader()
		{

		}

		/// <summary>
		/// Parses ServiceGroup SMP2
		/// </summary>
		/// <param name="fetcherResponse"></param>
		/// <returns></returns>
		//throws LookupException
		public virtual List<ServiceReference> ParseServiceGroup(FetcherResponse fetcherResponse)
		{
			try
			{
				XmlSerializer unmarshaller = new XmlSerializer(typeof(ServiceGroupType));
				ServiceGroupType serviceGroup = (ServiceGroupType)unmarshaller.Deserialize(fetcherResponse.InputStream);
				List<ServiceReference> serviceReferences = new List<ServiceReference>();

				foreach (ServiceReferenceType reference in serviceGroup.ServiceReference)
				{
					//string hrefDocumentTypeIdentifier = URLDecoder.decode(reference.Href, "UTF-8").Split("/services/")[1];
					//string[] parts = hrefDocumentTypeIdentifier.Split("::", 2);

					try
					{
						//serviceReferences.Add(ServiceReference.of(DocumentTypeIdentifierWithUri.of(parts[1], Scheme.of(parts[0]), new Uri(reference.Href))));
					}
					catch (System.IndexOutOfRangeException)
					{
						;//LOGGER.warn("Unable to parse '{}'.", hrefDocumentTypeIdentifier);
					}
				}
				return serviceReferences;
			}
			catch (Exception e) //when (e is JAXBException || e is XMLStreamException || e is UnsupportedEncodingException)
			{
				throw new LookupException(e.Message, e);
			}
		}


		/// <summary>
		/// ParsesServiceMetadata SMP2
		/// </summary>
		/// <param name="fetcherResponse"></param>
		/// <returns></returns>
		// throws LookupException, PeppolSecurityException
		public virtual PotentiallySigned<ServiceMetadata, object> ParseServiceMetadata(FetcherResponse fetcherResponse)
		{
			try
			{
				X509Certificate2 signer = null;
				XmlSerializer unmarshaller = new XmlSerializer(typeof(ServiceMetadataType));
				ServiceMetadataType SMDType = (ServiceMetadataType)unmarshaller.Deserialize(fetcherResponse.InputStream);

				if (SMDType == null)
				{
					throw new LookupException("ServiceMetadata element not found.");
				}
				if (SMDType.Signature != null && SMDType.Signature.Length > 0)
				{
					XmlDocument document = new XmlDocument();
					document.Load(fetcherResponse.InputStream);
					//TODO signer = XmldsigVerifier.verify(document);
				}
				List<ProcessMetadata> processMetadatas = new List<ProcessMetadata>();
				foreach (ProcessMetadataType ProcessMetaType in SMDType.ProcessMetadata)
				{
					List<PublisherEndpoint> lstEndpoints = new List<PublisherEndpoint>();
					foreach (EndpointType objEndpointType in ProcessMetaType.Endpoint)
					{
						lstEndpoints.Add(new PublisherEndpoint(TransportProfile.of(
								objEndpointType.TransportProfileID.ToString())
										, new Uri(objEndpointType.AddressURI.ToString())
										, new X509Certificate2(objEndpointType.Certificate[0].ContentBinaryObject.Value)
										, Period.Of(objEndpointType.ActivationDate.Value, objEndpointType.ExpirationDate.Value)
										, objEndpointType.Description.Value, objEndpointType.Contact.Value));
					}
					processMetadatas.Add(ProcessMetadata.of(ProcessIdentifier.of(ProcessMetaType.Process[0].ID.ToString()
															, Scheme.of(ProcessMetaType.Process[0].ID.ToString())), lstEndpoints.ToArray()));
				}
				return Signed<ServiceMetadata, object>.of(
							ServiceMetadata.of(ParticipantIdentifier.Of(SMDType.ParticipantID.Value
									, Scheme.of(SMDType.ParticipantID.schemeName))
									, DocumentTypeIdentifier.of(SMDType.ID.Value
									, Scheme.of(SMDType.ID.schemeName)), processMetadatas), signer);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message, e);
			}
		}
	}
}