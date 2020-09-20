
using System;
using System.Collections.Generic;
using System.Web;
using VertSoft.Peppol.Common.Model;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;
using System.Text;
using System.Xml;
using VertSoft.Peppol.Lookup.Api;
using VertSoft.Peppol.Publisher.Model;
using VertSoft.Peppol.Common.Model.Lang;
using VertSoft.Types.Smp.Publishing.Bdxr201407;
using VertSoft.Peppol.Lookup.Model;
using VertSoft.Peppol.Common.Api;


namespace VertSoft.Peppol.Lookup.Reader
{
	[Namespace("http://docs.oasis-open.org/bdxr/ns/SMP/2016/05")]
	public class Bdxr201605Reader : IMetadataReader
	{
		static Bdxr201605Reader()
		{

		}

        /// <summary>
        /// ParsesServiceMetadata SMP1 BDXR
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
                SignedServiceMetadataType SMDType = (SignedServiceMetadataType)unmarshaller.Deserialize(fetcherResponse.InputStream);
                if (SMDType == null)
                {
                    throw new LookupException("ServiceMetadata element not found.");
                }
                if (SMDType.Signature != null && SMDType.Signature.ToString().Length > 0)
                {
                    XmlDocument document = new XmlDocument();
                    document.Load(fetcherResponse.InputStream);
                    //TODO signer = XmldsigVerifier.verify(document);
                }
                ServiceInformationType serviceInformation = (ServiceInformationType) SMDType.ServiceMetadata.Item;
                List<ProcessMetadata> processMetadatas = new List<ProcessMetadata>();
                foreach (ProcessType ProcessType in serviceInformation.ProcessList)
                {
                    List<PublisherEndpoint> Endpoints = new List<PublisherEndpoint>();
                    foreach (EndpointType EndpointType in ProcessType.ServiceEndpointList)
                    {
                        Endpoints.Add(new PublisherEndpoint(TransportProfile.of(EndpointType.transportProfile)
                                        , new Uri(EndpointType.EndpointURI)
                                        , new X509Certificate2(EndpointType.Certificate)
										, Period.Of(EndpointType.ServiceActivationDate, EndpointType.ServiceExpirationDate)
										, EndpointType.ServiceDescription
										, EndpointType.TechnicalContactUrl));
                    }
                    processMetadatas.Add(ProcessMetadata.of(ProcessIdentifier.of(ProcessType.ProcessIdentifier.ToString())
                                                            , Endpoints.ToArray()));
                }
                return Signed<ServiceMetadata, object>.of(
                            ServiceMetadata.of(ParticipantIdentifier.Of(serviceInformation.ParticipantIdentifier.ToString()
                                    , Scheme.of(serviceInformation.ParticipantIdentifier.scheme))
                                    , DocumentTypeIdentifier.of(serviceInformation.DocumentIdentifier.ToString()
                                    , Scheme.of(serviceInformation.DocumentIdentifier.scheme)), processMetadatas), signer);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        /// <summary>
        /// Parses ServiceGroup SMP1 BDXR
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

				foreach (ServiceMetadataReferenceType reference in serviceGroup.ServiceMetadataReferenceCollection)
				{
					string hrefDocumentTypeIdentifier = HttpUtility.UrlDecode(reference.href, Encoding.UTF8).Split("/services/")[1];
					string[] parts = hrefDocumentTypeIdentifier.Split("::", 2);

					try
					{
						serviceReferences.Add(ServiceReference.of(DocumentTypeIdentifierWithUri.of(parts[1]
															, Scheme.of(parts[0]), new Uri(reference.href))));
					}
					catch (System.IndexOutOfRangeException)
					{
                        ;//LOGGER.warn("Unable to parse '{}'.", hrefDocumentTypeIdentifier);
					}
				}
				return serviceReferences;
			}
			catch (Exception e)
			{
				throw new LookupException(e.Message, e);
			}
		}
	}
}