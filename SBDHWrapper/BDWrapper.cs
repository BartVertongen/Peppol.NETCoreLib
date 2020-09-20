//By Bart Louis Robert Vertongen 2020 March

using System;
using System.IO;
using System.Xml.Linq;
using System.Xml;
using VertSoft.Peppol.Common.Model;


namespace VertSoft.Peppol.Sbdh
{
	/// <summary>
	/// BusinessDocument Wrapper
	/// </summary>
	public class SBDWrapper
	{
		/// <summary>
		/// Filename of the Business Document
		/// </summary>
		public string BDFileName { get; private set; }

		private Header		_SBDHeader = null;
		private XmlReader	_xmlReader = null;
		private BDHelper	_BDHelper = null;
		
		public SBDWrapper(string filename)
		{
			this.BDFileName = filename;
			this._SBDHeader = new Header();
		}

		/// <summary>
		/// Will the Business Document file with the given filename to a Standard Business Document.
		/// </summary>
		/// <exception cref="">Will throw an exception if something goes wrong.</exception>
		public void WrapIt()
		{
			if (this.ValidateFileName())
			{
				//TODO: try it out with other documents 
				//	Creditnote, 
				this.ExtractData();
				this.CreateSBD();
			}			
		}


		/// <summary>
		/// Checks the file name and the content of the file.
		/// </summary>
		/// <returns></returns>
		/// <exception cref="">Will throw an exception if something goes wrong.</exception>
		private bool ValidateFileName()
		{
			if (string.IsNullOrEmpty(this.BDFileName))
			{
				throw new Exception("The given filename is null or empty !");
			}

			//We open the xml Document with a XmlReader, so we can use namespaces and prefixes
			this._xmlReader = XmlReader.Create(this.BDFileName);			
			XDocument xmlBDocument = XDocument.Load(this._xmlReader);
			if (xmlBDocument.Root.Name.LocalName == "StandardBusinessDocument")
			{
				this._xmlReader.Close();
				throw new Exception("This BusinessDocument is already a StandardBusinessDocument!");
			}
			else if (xmlBDocument.Root.Name.LocalName == "StandardBusinessDocumentHeader")
			{
				this._xmlReader.Close();
				throw new Exception("This Xml Document is a StandardBusinessDocumentHeader!");
			}
			this._xmlReader.Close();
			return true;
		}

		/// <summary>
		/// Creates the resulting Standard Business Document.
		/// </summary>
		private void CreateSBD()
		{
			SbdWriter2 objSbdhWriter = new SbdWriter2(this._SBDHeader);
			FileStream objFileStream = new FileStream(this.BDFileName, FileMode.Open);
			MemoryStream memstrmBDoc = new MemoryStream();
			objFileStream.CopyTo(memstrmBDoc);
			memstrmBDoc.Position = 0;
			//Write the Business Document to the Standard Business Document
			objSbdhWriter.Write(memstrmBDoc);
			//Convert XDocument to a File
			string strResultingFileName, strOriginalPath;
			strResultingFileName = Path.GetFileNameWithoutExtension(this.BDFileName);
			strResultingFileName += "_sbd" + Path.GetExtension(this.BDFileName);
			strOriginalPath = Path.GetDirectoryName(this.BDFileName);
			strResultingFileName = Path.Combine(strOriginalPath, strResultingFileName);			 
			objSbdhWriter.BusinessDocument.Save(strResultingFileName);
		}

		/// <summary>
		/// Extracts the needed data to create the SBDHeader.
		/// </summary>
		private void ExtractData()
		{
			//We have to reinitialize the XmlReader because we used it already
			this._xmlReader = XmlReader.Create(this.BDFileName);
			this._BDHelper = new BDHelper(this._xmlReader);

			//CREATIONTIME
			this._SBDHeader = this._SBDHeader.CreationTimestamp(this._BDHelper.GetCreationTime());

			//DOCUMENTTYPE
			this._SBDHeader = this._SBDHeader.DocumentType(this._BDHelper.GetDocumentTypeIdentifier());

			//The ArgumentList contains the BusinessScopes except DOCUMENTID and PROCESSID
			//List<ArgumentIdentifier> objArgumentsList = new List<ArgumentIdentifier>();
			//this._SBDHeader = this._SBDHeader.AddArguments(objArgumentsList);

			//INSTANCEIDENTIFIER
			this._SBDHeader = this._SBDHeader.Identifier(this._BDHelper.GetInstanceIdentifier());

			//INSTANCETYPE
			this._SBDHeader = this._SBDHeader.InstanceType(this._BDHelper.GetInstanceType());

			//PROCESSIDENTIFIER
			this._SBDHeader = this._SBDHeader.Process(this._BDHelper.GetProcessIdentifier());

			//RECEIVER
			this._SBDHeader = this._SBDHeader.Receiver(this._BDHelper.GetReceiver());

			//SENDER
			this._SBDHeader = this._SBDHeader.Sender(this._BDHelper.GetSender());
			this._xmlReader.Close();
		}
	}
}