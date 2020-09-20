
using VertSoft.Peppol.Common.Model;
using VertSoft.Peppol.Sbdh.Lang;
using System.IO;
using System;
using System.Xml;
using System.Xml.Serialization;
using VertSoft.Peppol.Common.Model.Lang;


namespace VertSoft.Peppol.Sbdh
{
	public class SbdhReader
	{
		/// <summary>
		/// Reads a sbdHeader from a Stream.
		/// Converts A Stream to a Header object.
		/// </summary>
		/// <param name="inputStream">Can be a memoryStream or a FileStream</param>
		/// <returns>Header</returns>
		/// <exception cref="SbdhException"></exception>
		static public Header Read(Stream inputStream)
		{
			try
			{
				//Deserialize SBDH from a stream
				StandardBusinessDocumentHeader objSDBH;
				XmlSerializer serializer = new XmlSerializer(typeof(StandardBusinessDocumentHeader));
				inputStream.Position = 0;
				objSDBH = (StandardBusinessDocumentHeader)serializer.Deserialize(inputStream);
				return SbdhReader.Read(objSDBH);
			}
			catch (Exception e)
			{
				throw new SbdhException("Unable to unmarshal content to SBDH.", e);
			}
		}


		static public Header Read(XmlReader xmlReader) //throws no.difi.vefa.peppol.sbdh.lang.SbdhException
		{
			try
			{
				//Deserialize SBDH from a XmlReader
				//The XmlReader is created using a stream
				StandardBusinessDocumentHeader objSDBH;
				XmlSerializer serializer = new XmlSerializer(typeof(StandardBusinessDocumentHeader));
				objSDBH = (StandardBusinessDocumentHeader)serializer.Deserialize(xmlReader);
				return SbdhReader.Read(objSDBH);
			}
			catch (Exception e)
			{
				throw new SbdhException("Unable to unmarshal content to SBDH.", e);
			}
		}

		/// <summary>
		/// Converts sbdh Object to a Header object
		/// </summary>
		/// <param name="sbdh"></param>
		/// <returns></returns>
		/// <exception cref="SbdhException"></exception>
		static public Header Read(StandardBusinessDocumentHeader sbdh)
		{
			Header header = Header.newInstance();

			// Sender
			if (sbdh.Sender == null)
				throw new SbdhException("Sender is not provided in SBDH");
			if (sbdh.Sender[0].Identifier == null)
				throw new SbdhException("Sender identifier is not provided in SBDH");
			PartnerIdentification SenderIdentifier = sbdh.Sender[0].Identifier;
			header = header.Sender( ParticipantIdentifier.Of(SenderIdentifier.Value, Scheme.of(SenderIdentifier.Authority)) );

			// Receiver
			if (sbdh.Receiver == null)
				throw new SbdhException("Receiver is not provided in SBDH");
			if (sbdh.Receiver[0].Identifier == null)
				throw new SbdhException("Receiver identifier is not provided in SBDH.");			
			PartnerIdentification ReceiverIdentifier = sbdh.Receiver[0].Identifier;
			header = header.Receiver(ParticipantIdentifier.Of(ReceiverIdentifier.Value, Scheme.of(ReceiverIdentifier.Authority)));

			// Prepare...
			DocumentIdentification docIdent = sbdh.DocumentIdentification;
			//Identifier
			if (docIdent == null)
				throw new SbdhException("Document identification is not provided in SBDH.");
			if (docIdent.InstanceIdentifier == null)
				throw new SbdhException("SBDH instance identifier is not provided in SBDH.");
			header = header.Identifier(InstanceIdentifier.of(docIdent.InstanceIdentifier));

			// InstanceType
			if (docIdent.Standard == null)	//Same as Root Namespace for a DocumentType
				throw new SbdhException("Information about standard is not provided in SBDH.");
			if (docIdent.Type == null) //Same as Local Name for a DocumentType
                throw new SbdhException("Information about type is not provided in SBDH.");
			if (docIdent.TypeVersion == null)	//Same as DocumentType Version
				throw new SbdhException("Information about type version is not provided in SBDH.");
			header = header.InstanceType( InstanceType.of(docIdent.Standard, docIdent.Type, docIdent.TypeVersion) );

			// CreationTimestamp
			if (docIdent.CreationDateAndTime == null)
				throw new SbdhException("Element 'CreationDateAndTime' is not set or contains invalid value.");
			header = header.CreationTimestamp(docIdent.CreationDateAndTime);
			
			// Scope
			foreach (Scope scope in sbdh.BusinessScope)
			{
				Scheme scheme;
				string type = scope.Type.Trim();
				switch (type)
				{
					case "DOCUMENTID":
						scheme = scope.Identifier != null ? Scheme.of(scope.Identifier) : DocumentTypeIdentifier.DEFAULT_SCHEME;
						header = header.DocumentType(DocumentTypeIdentifier.of(scope.InstanceIdentifier, scheme));
						break;
					case "PROCESSID":
						scheme = scope.Identifier != null ? Scheme.of(scope.Identifier) : ProcessIdentifier.DEFAULT_SCHEME;
						header = header.Process(ProcessIdentifier.of(scope.InstanceIdentifier, scheme));
						break;
					default:
						header = header.AddArgument(ArgumentIdentifier.of(type, scope.InstanceIdentifier));
						break;
				}
			}
			if (header.getDocumentType() == null)
				throw new SbdhException("Scope containing document identifier is not provided in SBDH.");
			if (header.getProcess() == null)
				throw new SbdhException("Scope containing process identifier is not provided in SBDH.");
			return header;
		}
	}
}