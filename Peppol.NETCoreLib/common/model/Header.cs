using System;
using System.Collections.Generic;
using System.Linq;
using VertSoft.Peppol.Common.Model.Lang;

namespace VertSoft.Peppol.Common.Model
{
	[Serializable]
	public class Header
	{
		private ParticipantIdentifier _Sender;
        /// <summary>
		/// Returns the Sender as ParticipantIdentifier
		/// </summary>
		/// <returns></returns>
		/// <remarks>We can not use a Property for it, because of the Fluent api implementation</remarks>
		public ParticipantIdentifier getSender()
        {
            return this._Sender;
        }


        private ParticipantIdentifier _Receiver;
        public ParticipantIdentifier getReceiver()
        {
            return this._Receiver;
        }


        private List<ParticipantIdentifier> _CopyReceiver = new List<ParticipantIdentifier>();
        public List<ParticipantIdentifier> getCopyReceiver()
        {
            return this._CopyReceiver;
        }


        private ProcessIdentifier _Process;
        public ProcessIdentifier getProcess()
        {
            return this._Process;
        }


        private DocumentTypeIdentifier _DocumentType;
        public DocumentTypeIdentifier getDocumentType()
        {
            return this._DocumentType;
        }


        private InstanceIdentifier _Identifier;
        public InstanceIdentifier getIdentifier()
        {
            return this._Identifier;
        }


        private InstanceType _InstanceType;
        public InstanceType getInstanceType()
        {
            return this._InstanceType;
        }


        private DateTime _CreationTimestamp;
        public DateTime getCreationTimestamp()
        {
            return this._CreationTimestamp;
        }

        private Dictionary<string, ArgumentIdentifier> _Arguments = new Dictionary<string, ArgumentIdentifier>();

		public static Header newInstance()
		{
			return new Header();
		}

		public static Header of(ParticipantIdentifier sender, ParticipantIdentifier receiver
                , List<ParticipantIdentifier> cc, ProcessIdentifier process
                , DocumentTypeIdentifier documentType, InstanceIdentifier identifier
                                    , InstanceType instanceType, DateTime creationTimestamp)
		{
			return new Header(sender, receiver, cc, process, documentType, identifier, instanceType, creationTimestamp, null);
		}

		public static Header of(ParticipantIdentifier sender, ParticipantIdentifier receiver
                , ProcessIdentifier process, DocumentTypeIdentifier documentType
                , InstanceIdentifier identifier, InstanceType instanceType, DateTime creationTimestamp)
		{
			return new Header(sender, receiver, new List<ParticipantIdentifier>(), process, documentType, identifier, instanceType, creationTimestamp, null);
		}

		public static Header of(ParticipantIdentifier sender, ParticipantIdentifier receiver, ProcessIdentifier process, DocumentTypeIdentifier documentType)
		{
			return new Header(sender, receiver, new List<ParticipantIdentifier>(), process, documentType, null, null, null, null);
		}

		public Header()
		{
			// No action.
		}

        /// <summary>
        /// Private Constructor: can not be used directly.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="receiver"></param>
        /// <param name="copyReceiver"></param>
        /// <param name="process"></param>
        /// <param name="documentType"></param>
        /// <param name="identifier"></param>
        /// <param name="instanceType"></param>
        /// <param name="creationTimestamp"></param>
        /// <param name="arguments"></param>
		private Header(ParticipantIdentifier sender, ParticipantIdentifier receiver, List<ParticipantIdentifier> copyreceiver
                , ProcessIdentifier process, DocumentTypeIdentifier documentType, InstanceIdentifier identifier
                    , InstanceType instanceType, DateTime? creationTimestamp, Dictionary<string, ArgumentIdentifier> arguments)
		{
			this._Sender = sender;
			this._Receiver = receiver;
			this._CopyReceiver = copyreceiver;
			this._Process = process;
			this._DocumentType = documentType;
            //Next members can be null using the short notation
            this._Identifier = identifier;
			this._InstanceType = instanceType;
			this._CreationTimestamp = creationTimestamp ?? DateTime.Now;
            this._Arguments = arguments ?? this._Arguments;
		}

		public virtual Header Sender(ParticipantIdentifier sender)
		{
            return copy(h => h._Sender = sender);
		}

		public virtual Header Receiver(ParticipantIdentifier receiver)
		{
			return copy(h => h._Receiver = receiver);
		}

		public virtual Header CC(ParticipantIdentifier cc)
		{
			return copy(h => h._CopyReceiver.Add(cc));
		}

		public virtual Header Process(ProcessIdentifier process)
		{
			return copy(h => h._Process = process);
		}

		public virtual Header DocumentType(DocumentTypeIdentifier documentType)
		{
			return copy(h => h._DocumentType = documentType);
		}

		public virtual Header Identifier(InstanceIdentifier identifier)
		{
			return copy(h => h._Identifier = identifier);
		}

		public virtual Header InstanceType(InstanceType instanceType)
		{
			return copy(h => h._InstanceType = instanceType);
		}

		public virtual Header CreationTimestamp(DateTime creationTimestamp)
		{
			return copy(h => h._CreationTimestamp = creationTimestamp);
		}

		public virtual Header AddArgument(ArgumentIdentifier identifier)
		{
			return copy(h => h._Arguments.Add(identifier.Identifier, identifier));
		}

		public virtual Header AddArguments(List<ArgumentIdentifier> extras)
		{
            
            Header header = new Header(_Sender, _Receiver, this._CopyReceiver
                    , _Process, _DocumentType, _Identifier
                    , _InstanceType, _CreationTimestamp, new Dictionary<string, ArgumentIdentifier>(_Arguments));
            foreach(ArgumentIdentifier ArgId in extras)
            {
                if (header._Arguments.ContainsKey(ArgId.Identifier))
                    header._Arguments[ArgId.Identifier] = ArgId;
                else
                    header._Arguments.Add(ArgId.Identifier, ArgId);
            }
            return header;
		}

		public virtual ArgumentIdentifier getArgument(string key)
		{
			return _Arguments[key];
		}

		public virtual IList<ArgumentIdentifier> Arguments
		{
			get
			{
				return new List<ArgumentIdentifier>(_Arguments.Values);
			}
		}

		public override bool Equals(object o)
		{
			if (this == o)
			{
				return true;
			}
			if (o == null || this.GetType() != o.GetType())
			{
				return false;
			}
			Header that = (Header) o;
            //REM: Identifier and CreationTime are not Compared
            bool bIsCoreEqual = this._Sender.Equals(that._Sender) && this._Receiver.Equals(that._Receiver)
                    && this._Process.Equals(that._Process) && this._DocumentType.Equals(that._DocumentType);
            if (bIsCoreEqual)
            {
                //If the reference are different they still can be equal if none is null
                if (this._InstanceType != that._InstanceType && (this._InstanceType == null || that._InstanceType == null))
                    return false;
                else if ((this._InstanceType != null && that._InstanceType != null) && !this._InstanceType.Equals(that._InstanceType))
                    return false;
                else if (this._Arguments.Count != that._Arguments.Count)
                    return false;
                else if (this._Arguments.SequenceEqual(that._Arguments))
                    return true;
                else
                    return false;
            }
            else
                return false;
		}

		public override int GetHashCode()
		{
            int intSender = _Sender.GetHashCode();
            int intReceiver = _Receiver.GetHashCode() << 4;
            int intProcess = _Process.GetHashCode() << 8;
            int intDocumentType = _DocumentType.GetHashCode() << 12;
            int intIdentifier = (_Identifier != null)?_Identifier.GetHashCode() << 16: 0;
            int intInstanceType = (_InstanceType!=null)?_InstanceType.GetHashCode() << 20 : 0;
            int intCreationTimestamp = _CreationTimestamp.GetHashCode() << 24;
            int intArguments = _Arguments.GetHashCode() << 28;

            int intHashGlobal = intSender + intReceiver + intProcess + intDocumentType + intIdentifier + intInstanceType;
            intHashGlobal += intCreationTimestamp + intArguments;
            return intHashGlobal;
		}

		public override string ToString()
		{
			return "Header{" +
					"sender=" + _Sender +
					", receiver=" + _Receiver +
					", copyReceiver=" + _CopyReceiver +
					", process=" + _Process +
					", documentType=" + _DocumentType +
					", identifier=" + _Identifier +
					", instanceType=" + _InstanceType +
					", creationTimestamp=" + _CreationTimestamp +
					", arguments=" + _Arguments +
					'}';
		}

        /// <summary>
        /// It creates a header copy of the current instance.
        /// After a delegate is used to change one data member.
        /// </summary>
        /// <param name="consumer"></param>
        /// <returns></returns>
        /// <remarks>The consumer is a function that is done with a header</remarks>
        private Header copy(System.Action<Header> consumer)
		{
            List<ParticipantIdentifier> tmpList = new List<ParticipantIdentifier>((IEnumerable<ParticipantIdentifier>)_CopyReceiver);
            Header header = new Header(_Sender, _Receiver, tmpList, _Process, _DocumentType, _Identifier
                    , _InstanceType, _CreationTimestamp, new Dictionary<string, ArgumentIdentifier>(_Arguments));
			consumer(header);
			return header;
		}
	}
}