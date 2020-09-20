
using VertSoft.Peppol.Common.Model;
using VertSoft.Peppol.Publisher.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Xml;
using System.Xml.Serialization;
using VertSoft.Types.Smp.Publishing.Bdxr201605;
using VertSoft.Peppol.Common.Model.Lang;



namespace VertSoft.Peppol.Publisher.Syntax
{
	public class V1Bdxr201605Publisher: SyntaxPublisher
	{

		public override XmlElement of(ServiceGroup serviceGroup, Uri rootUri)
		{
			XmlDocument doc = new XmlDocument();

			ServiceGroupType objServiceGroupType = new ServiceGroupType();
			objServiceGroupType.ParticipantIdentifier = Convert(serviceGroup.ParticipantIdentifier);
			int nCount = serviceGroup.ServiceReferences.Count;
			objServiceGroupType.ServiceMetadataReferenceCollection = new ServiceMetadataReferenceType[nCount];
			nCount = 0;
			foreach (ServiceReference serviceReference in serviceGroup.ServiceReferences)
			{
				objServiceGroupType.ServiceMetadataReferenceCollection[nCount] =
						this.ConvertRef(serviceGroup.ParticipantIdentifier, serviceReference.DocumentTypeIdentifier, rootUri);
				nCount++;
			}
			XmlSerializer objSerializer = new XmlSerializer(typeof(ServiceGroupType));
			MemoryStream objMemStream = new MemoryStream();
			objSerializer.Serialize(objMemStream, objServiceGroupType);

			doc.Load(objMemStream);
			return doc.DocumentElement;
		}


		public override XmlElement of(PublisherServiceMetadata serviceMetadata, bool forSigning)
		{
			ServiceInformationType serviceInformationType = new ServiceInformationType();
			serviceInformationType.ParticipantIdentifier = Convert(serviceMetadata.ParticipantIdentifier);
			serviceInformationType.DocumentIdentifier = Convert(serviceMetadata.DocumentTypeIdentifier);
			List<ProcessType> lstTotalProcesses = new List<ProcessType>();

			foreach (ProcessMetadata processMetadata in serviceMetadata.Processes)
			{				
				List<ProcessType> lstNewProcesses = Convert(processMetadata);
				//Add the list to the existing list?
				lstTotalProcesses.AddRange(lstNewProcesses);			
			}
			serviceInformationType.ProcessList = lstTotalProcesses.ToArray();
			ServiceMetadataType serviceMetadataType = new ServiceMetadataType();
			serviceMetadataType.Item = serviceInformationType;

			XmlDocument doc = new XmlDocument();
			if (forSigning) 
			{
				SignedServiceMetadataType signedServiceMetadataType = new SignedServiceMetadataType();
				signedServiceMetadataType.ServiceMetadata = serviceMetadataType;
				XmlSerializer objSerializer = new XmlSerializer(typeof(SignedServiceMetadataType));
				MemoryStream objMemStream = new MemoryStream();
				objSerializer.Serialize(objMemStream, signedServiceMetadataType);
				
				doc.Load(objMemStream);
				return doc.DocumentElement;
			} 
			else
			{
				XmlSerializer objSerializer = new XmlSerializer(typeof(ServiceMetadataType));
				MemoryStream objMemStream = new MemoryStream();
				objSerializer.Serialize(objMemStream, serviceMetadataType);

				doc.Load(objMemStream);
				return doc.DocumentElement;
			}
		}


		public override XmlSerializer ServiceGroupMarshaller
		{ 
			get { return new XmlSerializer(typeof(ServiceGroupType));  } 
		}

		public override XmlSerializer ServiceMetadataMarshaller
		{
			get { return new XmlSerializer(typeof(ServiceMetadataType)); }
		}

		private ParticipantIdentifierType Convert(ParticipantIdentifier participantIdentifier)
		{
			ParticipantIdentifierType participantIdentifierType = new ParticipantIdentifierType();
			participantIdentifierType.scheme = participantIdentifier.Scheme.Identifier;
			participantIdentifierType.Value = participantIdentifier.Identifier;
			return participantIdentifierType;
		}

		private ProcessIdentifierType Convert(ProcessIdentifier processIdentifier)
		{
			ProcessIdentifierType processIdentifierType = new ProcessIdentifierType();

			processIdentifierType.scheme = processIdentifier.Scheme.Identifier;
			processIdentifierType.Value = processIdentifier.Identifier;
			return processIdentifierType;
		}


		private DocumentIdentifierType Convert(DocumentTypeIdentifier documentTypeIdentifier)
		{
			DocumentIdentifierType documentIdentifierType = new DocumentIdentifierType();

			documentIdentifierType.scheme = documentTypeIdentifier.Scheme.Identifier;
			documentIdentifierType.Value = documentTypeIdentifier.Identifier;
			return documentIdentifierType;
		}


		private List<ProcessType> Convert(ProcessMetadata/*<PublisherEndpoint>*/ processMetadata)
		{
			List<ProcessType> result = new List<ProcessType>();

			foreach (ProcessIdentifier processIdentifier in processMetadata.ProcessIdentifiers)
			{
				ProcessType processType = new ProcessType();
				processType.ProcessIdentifier = Convert(processIdentifier);
				//processType.ServiceEndpointList = new EndpointType[processMetadata.Endpoints.Count];

				List<EndpointType> lstEndpoints = new List<EndpointType>();
				foreach (KeyValuePair<TransportProfile, PublisherEndpoint> endpoint in processMetadata.Endpoints)
				{
					Uri uriAddress = endpoint.Value.Address;
					X509Certificate objCertificate = endpoint.Value.Certificate;
					Period per = endpoint.Value.Period;
					string strDescript = endpoint.Value.Description;
					string strContact = endpoint.Value.TechnicalContact;
					PublisherEndpoint objPublisherEP = new PublisherEndpoint(endpoint.Key
											, uriAddress, objCertificate, per, strDescript, strContact);
					EndpointType objEndPointType = Convert(objPublisherEP);
					lstEndpoints.Add(objEndPointType);
					processType.ServiceEndpointList = lstEndpoints.ToArray();
				}				
				result.Add(processType);
			}
			return result;
		}

		private EndpointType Convert(PublisherEndpoint endpoint)
		{
			EndpointType endpointType = new EndpointType();
			endpointType.transportProfile = endpoint.TransportProfile.Identifier;
			endpointType.RequireBusinessLevelSignature = false;
			//AttributedURIType objUriType = new AttributedURIType();
			//objUriType.Value = endpoint.Address.ToString();
			endpointType.EndpointURI = endpoint.Address.ToString();
			if (endpoint.Period != null)
			{
				endpointType.ServiceActivationDate = endpoint.Period.From;
				endpointType.ServiceExpirationDate = endpoint.Period.To;
			}
			endpointType.Certificate = endpoint.Certificate.GetRawCertData();
			endpointType.ServiceDescription = endpoint.Description;
			endpointType.TechnicalContactUrl = endpoint.TechnicalContact;

			return endpointType;
		}

		private ServiceMetadataReferenceType ConvertRef(ParticipantIdentifier participantIdentifier,
														DocumentTypeIdentifier documentTypeIdentifier, Uri rootURI)
		{
			Uri uri = new Uri(String.Format("%s/services/%s",
					participantIdentifier.UrlEncoded(), documentTypeIdentifier.UrlEncoded()));

			ServiceMetadataReferenceType serviceMetadataReferenceType = new ServiceMetadataReferenceType();
			serviceMetadataReferenceType.href = uri.ToString();
			return serviceMetadataReferenceType;
		}
	}
}