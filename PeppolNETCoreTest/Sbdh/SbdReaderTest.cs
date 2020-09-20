
using System.Diagnostics;
using System.IO;
using System.Text;
using VertSoft.Peppol.Common.Model;


namespace VertSoft.Peppol.Sbdh
{
	public class SbdReaderTest
	{       
        //throws Exception
		public virtual void simple()
		{
			FileStream objFileStream = new FileStream("./valid-t10.xml", FileMode.Open);
			MemoryStream objInputDocumentStream = new MemoryStream();
			objFileStream.CopyTo(objInputDocumentStream);
			//arDocument contains the SBDH as an array of Bytes
			byte[] arDocument = objInputDocumentStream.ToArray();

			//SbdWriterTest.header is a static containing a Header object..
			SbdWriter2 objSbdWriter = new SbdWriter2(SbdWriterTest.header);
			objSbdWriter.Write(objInputDocumentStream);

			MemoryStream objOutputStream = new MemoryStream();
			objSbdWriter.BusinessDocument.Save(objOutputStream);
			//Here we read the Stream containing the result of SdbWriter
			SbdReader2 objSbdReader = new SbdReader2(objOutputStream);

			objSbdReader.Read();
			Debug.Assert(objSbdReader.Header.Equals(SbdWriterTest.header));
			Debug.Assert(objSbdReader.ContentType == enContentType.XML);

			byte[] arContent = objSbdReader.ContentStream.ToArray();
			//Check if what we get out the envelope is the same as we put in
			//This is not the right way to check, there can be differences in whitespaces or declarations
			//TODO convert both to XDocument and check after.
			//Debug.Assert(arContent.SequenceEqual(arDocument));
		}


        //@Test(expectedExceptions = SbdhException)  throws Exception
		public void exceptionOnNonXML()
		{
			SbdReader2 objTest = new SbdReader2( new MemoryStream(Encoding.UTF8.GetBytes("{json: true}")) );
		}


        //@Test(expectedExceptions = SbdhException) throws Exception
		public virtual void exceptionOnNotSBD()
		{
			SbdReader2 objTest = new SbdReader2( new MemoryStream(Encoding.UTF8.GetBytes("<StandardBusinessDocument/>")) );
			objTest.Read();
		}


        // @Test(expectedExceptions = SbdhException) throws Exception
		public void exceptionOnNotSBDH()
		{
			string strFormat = "<StandardBusinessDocument xmlns=\"{0}\"><Header></Header></StandardBusinessDocument>";
			string strXml = string.Format(strFormat, Ns.SBDH);
			SbdReader2 objTest = new SbdReader2(new MemoryStream(Encoding.UTF8.GetBytes(strXml)));
			objTest.Read();
		}

        
		public void simpleBinary() //throws Exception
		{
			MemoryStream strmResult = new MemoryStream();
			FileStream asiceFileStream = new FileStream("./iso20022/iso20022-outer.asice", FileMode.Open);
			FileStream sbdhFileStream = new FileStream("./iso20022/sbdh.xml", FileMode.Open);
			Header objHeader = SbdhReader.Read(sbdhFileStream);

			// Create SBD From the SBDH-file with the SBD-writer

			//He writes the header to the result and gives the type of the contents
			SbdWriter2 objSdbWriter = new SbdWriter2(objHeader);
			//REM: The mimetype  can be stored in a ManifestItem
			MemoryStream memstrmContent = new MemoryStream();
			asiceFileStream.CopyTo(memstrmContent);
			objSdbWriter.Write(memstrmContent, enContentType.BINARY, "application/vnd.etsi.asic-e+zip");

			// Parse resulting SBD with 
			MemoryStream strmActual = new MemoryStream();
			objSdbWriter.BusinessDocument.Save(strmResult);
			SbdReader2 objSbdReader = new SbdReader2(strmResult); //pass by ref ?
			objSbdReader.Read();
			Header objActualHeader = objSbdReader.Header;
			Debug.Assert(objActualHeader.Equals(objHeader));

			strmActual = objSbdReader.ContentStream;
			//strmBinaryContent2.CopyTo(strmActual);

			//REM: Verify, we should test equality as XDocuments
			//Debug.Assert(strmActual.Equals(asiceFileStream));
		}
	}
}
 