
using System;
using System.Diagnostics;
using System.IO;
using VertSoft.Peppol.Common.Model;
using VertSoft.Peppol.Common.Model.Lang;


namespace VertSoft.Peppol.Sbdh
{
	public class SbdhWriterTest
	{
		private Header header = Header.newInstance().Sender(ParticipantIdentifier.of("9908:987654325"))
				.Receiver(ParticipantIdentifier.of("9908:123456785"))
				.Process(ProcessIdentifier.of("urn:www.cenbii.eu:profile:bii04:ver1.0"))
				.DocumentType(DocumentTypeIdentifier
						.of("urn:oasis:names:specification:ubl:schema:xsd:Invoice-2::Invoice"
								+ "##urn:www.cenbii.eu:transaction:biicoretrdm010:ver1.0"
								+ ":#urn:www.peppol.eu:bis:peppol4a:ver1.0::2.0"))
				.InstanceType(InstanceType.of("urn:oasis:names:specification:ubl:schema:xsd:Invoice-2", "Invoice", "2.0"))
				.CreationTimestamp(DateTime.Now).Identifier(InstanceIdentifier.generateUUID());


		//throws Exception
		public virtual void simple()
		{
			MemoryStream byteArrayOutputStream = new MemoryStream();
			SbdhWriter.Write(ref byteArrayOutputStream, header);

			Header actual = SbdhReader.Read(new MemoryStream(byteArrayOutputStream.ToArray()));
			Debug.Assert(actual.Equals(header));
		}


		//throws Exception
		public virtual void withScheme()
		{
			Header expected = header
									.DocumentType(DocumentTypeIdentifier.of("urn:cen.eu:en16931:2017", Scheme.of("busdox-docid-edifact")))
									.Process(ProcessIdentifier.NO_PROCESS);

			MemoryStream byteArrayOutputStream = new MemoryStream();
			SbdhWriter.Write(ref byteArrayOutputStream, expected);

			Header actual = SbdhReader.Read(new MemoryStream(byteArrayOutputStream.ToArray()));
			Debug.Assert(actual.Equals(expected));
		}


		//throws Exception
		public void triggerExceptionUsingXMLStreamWriter()
		{
			//Mock Stream and StreamWriter
			Stream objDummyStream = new MemoryStream();
			StreamWriter objDummyStreamWriter = new StreamWriter(objDummyStream);
			SbdhWriter.Write(objDummyStreamWriter, null);
		}

		// expectedExceptions = SbdhException
		public void triggerExceptionUsingOutputStream()
		{
			//Mock Stream
			MemoryStream objDummyStream = new MemoryStream();
			SbdhWriter.Write(ref objDummyStream, null);
		}
	}
}