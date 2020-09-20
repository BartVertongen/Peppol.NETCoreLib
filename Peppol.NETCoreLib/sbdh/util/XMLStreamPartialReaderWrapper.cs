

using System.Xml;

namespace VertSoft.Peppol.Sbdh.Util
{

	public class XMLStreamPartialReaderWrapper //: XmlReader
	{

		//private int eventType = START_DOCUMENT;
 
		private int level = -1;

		public XMLStreamPartialReaderWrapper(XmlReader xmlReader) //: base(xmlReader)
		{
		}


		//ORIGINAL LINE: @Override public int next() throws javax.xml.stream.XMLStreamException
		public /*override*/ int Next()
		{
			return -1;
			// Trigger next event
			/*this.eventType = eventType == START_DOCUMENT ? base.EventType : base.next();

			if (eventType == START_ELEMENT)
			{
				level++;
			}
			else if (eventType == END_ELEMENT)
			{
				level--;

				if (level == -1)
				{
					eventType = END_DOCUMENT;
				}
			}

			return eventType;*/
		}


		//ORIGINAL LINE: @Override public int nextTag() throws javax.xml.stream.XMLStreamException
		public /*override*/ int NextTag()
		{
			int eventType = Next();

			//REPLACE
			/*while ((eventType == XMLStreamConstants.CHARACTERS && WhiteSpace) 
						|| (eventType == XMLStreamConstants.CDATA && WhiteSpace) 
						|| eventType == XMLStreamConstants.SPACE 
						|| eventType == XMLStreamConstants.PROCESSING_INSTRUCTION 
								|| eventType == XMLStreamConstants.COMMENT)
			{
				eventType = Next();
			}

			if (eventType != XMLStreamConstants.START_ELEMENT && eventType != XMLStreamConstants.END_ELEMENT)
			{
				throw new XMLStreamException("expected start or end tag", Location);
			}*/

			return eventType;
		}

		public /*override*/ int EventType
		{
			get
			{
				return -1;
				//return eventType;
			}
		}



		//ORIGINAL LINE: @Override public boolean hasNext() throws javax.xml.stream.XMLStreamException
		public /*override*/ bool hasNext()
		{
			return true;
			//return eventType == END_DOCUMENT ? false : base.hasNext();
		}
	}
}