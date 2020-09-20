
using System;
using System.IO;
using System.Diagnostics;
using System.Xml;
using VertSoft.Peppol.Common.Model;
using VertSoft.Peppol.Common.Model.Lang;


namespace VertSoft.Peppol.Sbdh
{
	public class SbdhReaderTest
	{
        //throws Exception
		public virtual void simple()
		{
			Header header = Header.newInstance().Sender(ParticipantIdentifier.of("9908:987654325"))
					.Receiver(ParticipantIdentifier.of("9908:123456785"))
					.Process(ProcessIdentifier.of("urn:www.cenbii.eu:profile:bii04:ver1.0"))
					.DocumentType(DocumentTypeIdentifier
							.of("urn:oasis:names:specification:ubl:schema:xsd:Invoice-2::Invoice" 
									+ "##urn:www.cenbii.eu:transaction:biicoretrdm010:ver1.0" 
									+ ":#urn:www.peppol.eu:bis:peppol4a:ver1.0::2.0"))
					.InstanceType(InstanceType.of("urn:oasis:names:specification:ubl:schema:xsd:Invoice-2", "Invoice", "2.0"))
					.CreationTimestamp(DateTime.Now).Identifier(InstanceIdentifier.generateUUID());

			MemoryStream byteArrayOutputStream = new MemoryStream();
			//The header is written to a Stream
			SbdhWriter.Write(ref byteArrayOutputStream, header);
			//The header is read again from a Stream
			Header parsedHeader = SbdhReader.Read(new MemoryStream(byteArrayOutputStream.ToArray()));

			Debug.Assert(parsedHeader.Equals(header));
		}


		//throws Exception
		public void triggerExceptionUsingInputStream()
		{
			//Mock Stream
			MemoryStream objDummyStream = new MemoryStream();
			SbdhReader.Read(objDummyStream);
		}


		//throws Exception
		public void triggerExceptionUsingXMLStreamReader()
		{
			MemoryStream objDummyStream = new MemoryStream();
			XmlTextReader objDummyReader = new XmlTextReader(objDummyStream);
			SbdhReader.Read(objDummyReader);
		}
	}
}