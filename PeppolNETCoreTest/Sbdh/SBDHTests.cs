
using System;
using VertSoft.Peppol.Sbdh;

namespace VertSoft.Peppol.Test
{
	public static class SBDHTests
	{
		static public void RunAll()
		{
			SBDHTests.Run_MySBDTest();
			//SBDHTests.Run_PeppolSbdhTest();
			//SBDHTests.Run_SbdhWriterTest();
			//SBDHTests.Run_SbdWriterTest();
			//SBDHTests.Run_SbdhReaderTest();
			SBDHTests.Run_SbdReaderTest();
		}

		static private void Run_PeppolSbdhTest()
		{
			PeppolSbdhTest TestPeppolSbdh = new PeppolSbdhTest();
			TestPeppolSbdh.version100();
			TestPeppolSbdh.version101();
			Console.WriteLine("Passed PeppolSbdhTest");
		}

		static private void Run_SbdhReaderTest()
		{
			SbdhReaderTest TestSbdhReader = new SbdhReaderTest();
			TestSbdhReader.simple();
			// Is OK gives an Exception --> TestSbdhReader.triggerExceptionUsingInputStream();
			// Is OK gives an Exception --> TestSbdhReader.triggerExceptionUsingXMLStreamReader();
			Console.WriteLine("Passed SbdhReaderTest");
		}

		static private void Run_SbdhWriterTest()
		{
			SbdhWriterTest TestSdbhWriter = new SbdhWriterTest();
			TestSdbhWriter.simple();
			TestSdbhWriter.withScheme();
			// Is OK gives an Exception --> TestSdbhWriter.triggerExceptionUsingOutputStream();
			// Is OK gives an Exception --> TestSdbhWriter.triggerExceptionUsingXMLStreamWriter();
			Console.WriteLine("Passed SbdhWriterTest");
		}


		static private void Run_MySBDTest()
		{
			MySBDTests TestSBD = new MySBDTests();
			//Is OK, the file is made : TestSBD.CreateSBDH1FileFromCode();
			//Is OK, the file is made : TestSBD.CreateSBD1FileWithXMLFromCode();
			//Is OK, the file is made : TestSBD.CreateSBD1FileWithTextFromCode();
			//Is OK, the file is made : TestSBD.CreateSBD1FileWithBinaryFromCode();
			//Is OK for now, contents is wrong: TestSBD.ReadSBD1FileWithXML();
			//Is OK, we can read the content : TestSBD.ReadSBD1FileWithText();
			//Is OK, TestSBD.ReadSBD1FileWithBinary();
			Console.WriteLine("Passed MySBDTests");
		}

		static private void Run_SbdReaderTest()
		{
			SbdReaderTest TestSbdReader = new SbdReaderTest();
			TestSbdReader.simple();
			TestSbdReader.simpleBinary();
			//Is OK, gives an exception : TestSbdReader.exceptionOnNonXML();
			//Is OK, gives an exception : TestSbdReader.exceptionOnNotSBD();
			//Is OK, gives an exception : TestSbdReader.exceptionOnNotSBDH();
			Console.WriteLine("Passed SbdReaderTest");
		}

		static private void Run_SbdWriterTest()
		{
			SbdWriterTest TestSbdWriter = new SbdWriterTest();
			//TestSbdWriter.simpleXml();
			TestSbdWriter.simpleBinary();			
			Console.WriteLine("Passed SbdWriterTest");
		}
	}
}
