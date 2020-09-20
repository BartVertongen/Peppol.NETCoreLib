
using System;
using System.IO;
using VertSoft.Peppol.Common.Model;
using VertSoft.Peppol.Common.Model.Lang;


namespace VertSoft.Peppol.Sbdh
{
	public class SbdWriterTest
	{
		//This header is a static because it is used in another test!
		public static readonly Header header = Header.newInstance().Sender(ParticipantIdentifier.of("9908:987654325"))
                .Receiver(ParticipantIdentifier.of("9908:123456785"))
                .Process(ProcessIdentifier.of("urn:www.cenbii.eu:profile:bii04:ver1.0"))
                .DocumentType(DocumentTypeIdentifier.of("urn:oasis:names:specification:ubl:schema:xsd:Invoice-2::Invoice" 
                        + "##urn:www.cenbii.eu:transaction:biicoretrdm010:ver1.0" 
                        + ":#urn:www.peppol.eu:bis:peppol4a:ver1.0::2.0"))
                .InstanceType(InstanceType.of("urn:oasis:names:specification:ubl:schema:xsd:Invoice-2", "Invoice", "2.0"))
                .CreationTimestamp(DateTime.Now).Identifier(InstanceIdentifier.generateUUID());

        //throws Exception
		public void simpleXml()
		{
			FileStream objFileStream = new FileStream("./SBD2Xml.xml", FileMode.CreateNew);
			SbdWriter2 objSbdWriter = new SbdWriter2(header);

			FileStream objFileContentStream = new FileStream("./valid-t10.xml", FileMode.Open);
			MemoryStream objContentStream = new MemoryStream();
			objFileContentStream.CopyTo(objContentStream);
			objSbdWriter.Write(objContentStream);

			objSbdWriter.BusinessDocument.Save(objFileStream);
			objFileStream.Close();
		}

        public void simpleBinary()
        {
			FileStream objFileStream = new FileStream("./SBD2Bin.xml", FileMode.OpenOrCreate);
			//MemoryStream objOutputStream = new MemoryStream();
			//objFileStream.CopyTo(objOutputStream);

			//Load the right header
			FileStream objHeaderFileStream = new FileStream("./iso20022/sbdh.xml", FileMode.Open);
			Header objHeader = SbdhReader.Read(objHeaderFileStream);
			SbdWriter2 objSbdWriter = new SbdWriter2(objHeader);
			FileStream objFileContentStream = new FileStream("./iso20022/iso20022-outer.asice", FileMode.Open);
			MemoryStream objContentStream = new MemoryStream();
			objFileContentStream.CopyTo(objContentStream);
			objSbdWriter.Write(objContentStream, enContentType.BINARY, "application/vnd.etsi.asic-e+zip");

			objSbdWriter.BusinessDocument.Save(objFileStream);
			objFileStream.Close();
		}
	}
}