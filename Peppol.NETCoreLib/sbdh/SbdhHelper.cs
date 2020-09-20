
using System.Collections.Generic;
using VertSoft.Peppol.Common.Model;
using VertSoft.Peppol.Common.Model.Lang;


namespace VertSoft.Peppol.Sbdh
{
    //REMARK it is all related with XML schemas, we can replace it.
    public class SbdhHelper
    {
		/// <summary>
		/// Creates a Partner from a ParticipantIdentifier
		/// </summary>
		/// <param name="participant"></param>
		/// <returns></returns>
        public static Partner CreatePartner(ParticipantIdentifier participant)
        {
            PartnerIdentification partnerIdentification = new PartnerIdentification();
            partnerIdentification.Authority = participant.Scheme.Identifier;
            partnerIdentification.Value = participant.Identifier;

            Partner partner = new Partner();
            partner.Identifier = partnerIdentification;

            return partner;
        }


        public static Scope[] CreateBusinessScope(List<Scope> scopes)
        {
        	return scopes.ToArray();
        }


		/// <summary>
		/// Creates a Scope from a ProcessIdentifier
		/// </summary>
		/// <param name="processIdentifier"></param>
		/// <returns>Scope</returns>
        public static Scope CreateScope(ProcessIdentifier processIdentifier)
        {
            Scope scope = new Scope();
            scope.Type = "PROCESSID";
            scope.InstanceIdentifier = processIdentifier.Identifier;
            if (processIdentifier.Scheme != ProcessIdentifier.DEFAULT_SCHEME)
                scope.Identifier = processIdentifier.Scheme.Identifier;

            return scope;
        }


		/// <summary>
		/// Creates a Scope from a DocumentTypeIdentifier
		/// </summary>
		/// <param name="documentTypeIdentifier"></param>
		/// <returns>Scope</returns>
        public static Scope CreateScope(DocumentTypeIdentifier documentTypeIdentifier)
        {
            Scope scope = new Scope();
            scope.Type = "DOCUMENTID";
            scope.InstanceIdentifier = documentTypeIdentifier.Identifier;
            if (documentTypeIdentifier.Scheme != DocumentTypeIdentifier.DEFAULT_SCHEME)
                scope.Identifier = documentTypeIdentifier.Scheme.Identifier;

            return scope;
        }

		/// <summary>
		/// Creates a Scope from an ArgumentIdentifier
		/// </summary>
		/// <param name="argumentIdentifier"></param>
		/// <returns></returns>
        public static Scope CreateScope(ArgumentIdentifier argumentIdentifier)
        {
        	Scope scope = new Scope();
            scope.Type = argumentIdentifier.Key;
        	scope.InstanceIdentifier = argumentIdentifier.Identifier;
        
        	return scope;
        }
    }
}