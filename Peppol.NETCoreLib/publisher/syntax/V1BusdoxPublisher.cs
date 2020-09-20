
using VertSoft.Peppol.Common.Model;
using VertSoft.Peppol.Publisher.Model;
using VertSoft.Peppol.Publisher.Annotation;
using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.Security.Cryptography.X509Certificates;
using VertSoft.Types.Smp.Identifiers_1.Busdox;
using VertSoft.Types.Smp_1.Addressing;
using VertSoft.Types.Smp.Publishing.Busdox;
using System.IO;
using VertSoft.Peppol.Common.Model.Lang;


namespace VertSoft.Peppol.Publisher.Syntax
{
    [Syntax("busdox")] 
	public class V1BusdoxPublisher : SyntaxPublisher
	{
		public override XmlSerializer ServiceGroupMarshaller
		{
			get { return new XmlSerializer(typeof(ServiceGroupType)); }
		}

		public override XmlSerializer ServiceMetadataMarshaller
		{
			get { return new XmlSerializer(typeof(ServiceMetadataType)); }
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="serviceGroup"></param>
		/// <param name="rootUri"></param>
		/// <returns></returns>
		public override XmlElement of(ServiceGroup serviceGroup, Uri rootUri)
		{
			ServiceGroupType objServiceGroupType = new ServiceGroupType();
			//Convert from model data to xml type data.
			objServiceGroupType.ParticipantIdentifier = Convert(serviceGroup.ParticipantIdentifier);
			int RefCount = serviceGroup.ServiceReferences.Count;
			objServiceGroupType.ServiceMetadataReferenceCollection = new ServiceMetadataReferenceType[RefCount];
			RefCount = 0;
			foreach (ServiceReference serviceReference in serviceGroup.ServiceReferences)
			{
				ServiceMetadataReferenceType objSMRef /*= new ServiceMetadataReferenceType()*/;
				objSMRef = this.ConvertRef(serviceGroup.ParticipantIdentifier
												, serviceReference.DocumentTypeIdentifier, rootUri);
				objServiceGroupType.ServiceMetadataReferenceCollection[RefCount] = objSMRef;
			}
			XmlSerializer objSerializer = new XmlSerializer(typeof(ServiceGroupType));
			MemoryStream strmServiceGroup = new MemoryStream();
			objSerializer.Serialize(strmServiceGroup, objServiceGroupType);
			XmlDocument xmlDoc = new XmlDocument();
			strmServiceGroup.Position = 0;
			xmlDoc.Load(strmServiceGroup);
			return xmlDoc.DocumentElement;
		}


		public override XmlElement of(PublisherServiceMetadata serviceMetadata, bool forSigning = false)
		{
			ServiceInformationType objServiceInformationType = new ServiceInformationType();
			objServiceInformationType.ParticipantIdentifier = Convert(serviceMetadata.ParticipantIdentifier);
			objServiceInformationType.DocumentIdentifier = Convert(serviceMetadata.DocumentTypeIdentifier);
			objServiceInformationType.ProcessList = new ProcessType[serviceMetadata.Processes.Count];
			int intCounter = 0;
			foreach (ProcessMetadata processMetadata in serviceMetadata.Processes)
			{
				List<ProcessType> lstProcessTypes = Convert(processMetadata);
				//Something is wrong here
				//objServiceInformationType.ProcessList[intCounter] = lstProcessTypes.ToArray();
				intCounter++;
			}
				

			ServiceMetadataType objServiceMetadataType = new ServiceMetadataType();
			//REM: The ServiceMetadataType can be a ServiceInformation or a Redirect.
			objServiceMetadataType.Item = objServiceInformationType;

			if (forSigning)
			{
				SignedServiceMetadataType objSignedServiceMetadataType = new SignedServiceMetadataType();
				objSignedServiceMetadataType.ServiceMetadata = objServiceMetadataType;
				return null; // objSignedServiceMetadataType;
			}
			else
			{
				XmlSerializer objSerializer = new XmlSerializer(typeof(ServiceMetadataType));
				MemoryStream strmServiceMetadata = new MemoryStream();
				objSerializer.Serialize(strmServiceMetadata, objServiceMetadataType);
				XmlDocument xmlDoc = new XmlDocument();
				strmServiceMetadata.Position = 0;
				xmlDoc.Load(strmServiceMetadata);
				return xmlDoc.DocumentElement;
			}
		}


		/// <summary>
		/// Converts a ParticipantIdentifier(model) to a type of ParticipantIdentifierType(xml)
		/// </summary>
		/// <param name="participantIdentifier"></param>
		/// <returns></returns>
		private ParticipantIdentifierType Convert(ParticipantIdentifier participantIdentifier)
		{
			ParticipantIdentifierType objParticipantIdentifierType = new ParticipantIdentifierType();

			objParticipantIdentifierType.scheme = participantIdentifier.Scheme.Identifier;
			objParticipantIdentifierType.Value = participantIdentifier.Identifier;
			return objParticipantIdentifierType;
		}


		/// <summary>
		/// Converts a ProcessIdentifier(model) to a ProcessIdentifierType(xml)
		/// </summary>
		/// <param name="processIdentifier"></param>
		/// <returns></returns>
		private ProcessIdentifierType Convert(ProcessIdentifier processIdentifier) 
		{
			ProcessIdentifierType objProcessIdentifierType = new ProcessIdentifierType();
			objProcessIdentifierType.scheme = processIdentifier.Scheme.Identifier;
			objProcessIdentifierType.Value = processIdentifier.Identifier;
			return objProcessIdentifierType;
		}


		private DocumentIdentifierType Convert(DocumentTypeIdentifier documentTypeIdentifier)
		{
			DocumentIdentifierType objDocumentIdentifierType = new DocumentIdentifierType();
			objDocumentIdentifierType.scheme = documentTypeIdentifier.Scheme.Identifier;
			objDocumentIdentifierType.Value = documentTypeIdentifier.Identifier;
			return objDocumentIdentifierType;
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
			AttributedURIType objAttributedURIType = new AttributedURIType();
			objAttributedURIType.Value = endpoint.Address.ToString();

			EndpointReferenceType objEndpointReferenceType = new EndpointReferenceType();
			objEndpointReferenceType.Address = objAttributedURIType;
			objEndpointReferenceType.Metadata = new MetadataType();
			objEndpointReferenceType.ReferenceParameters = new ReferenceParametersType();

			EndpointType objEndpointType = new EndpointType();
			objEndpointType.transportProfile = endpoint.TransportProfile.Identifier;
			objEndpointType.EndpointReference = objEndpointReferenceType;
			objEndpointType.RequireBusinessLevelSignature = false;
			if (endpoint.Period != null)
			{
				objEndpointType.ServiceActivationDate = endpoint.Period.From;
				objEndpointType.ServiceExpirationDate = endpoint.Period.To;
			}
			objEndpointType.Certificate = System.Convert.ToBase64String(endpoint.Certificate.GetRawCertData());
			objEndpointType.ServiceDescription = endpoint.Description;
			objEndpointType.TechnicalContactUrl = endpoint.TechnicalContact;

			return objEndpointType;
		}

		private ServiceMetadataReferenceType ConvertRef(ParticipantIdentifier participantIdentifier,
														DocumentTypeIdentifier documentTypeIdentifier, Uri rootURI)
		{
			Uri uri = new Uri( string.Format("%s/services/%s",
							participantIdentifier.UrlEncoded(), documentTypeIdentifier.UrlEncoded()));

			ServiceMetadataReferenceType serviceMetadataReferenceType = new ServiceMetadataReferenceType();
			serviceMetadataReferenceType.href = uri.ToString();
			return serviceMetadataReferenceType;
		}
	}
}