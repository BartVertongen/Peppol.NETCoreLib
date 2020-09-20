
using System.Collections.Generic;
using VertSoft.Peppol.Common.Lang;
using VertSoft.Peppol.Common.Model;
using VertSoft.Peppol.Icd.Api;
using VertSoft.Peppol.Icd.Model;
using System;
using System.Linq;


namespace VertSoft.Peppol.Icd
{
	/// <summary>
	/// Represents a list of Icd interfaces
	/// </summary>
	public class Icds
	{
        /// <summary>
        /// Add multiple arrays of Icds
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
		public static Icds of(params IIcd[][] values)
		{
			return new Icds(values);
		}

		private Icds(params IIcd[][] values)
		{
            if (values.Length == 0)
                return;
            List<IIcd> Result = new List<IIcd>();
            //Add the first list to start
            Result.AddRange(values[0]);
            for(int i = 1;i< values.Length;i++)
            {
                List<IIcd> NewList = new List<IIcd>(values[i]);
                //Union should eliminate duplicate values
                Result.Union(NewList);
            }
		}


        // throws PeppolParsingException
		public virtual IcdIdentifier Parse(string s)
		{
			return Parse(ParticipantIdentifier.Parse(s));
		}


		public virtual IcdIdentifier Parse(ParticipantIdentifier participantIdentifier)
		{
			try
			{
				string[] parts = participantIdentifier.Identifier.Split(":", 2);
				return IcdIdentifier.Of(FindBySchemeAndCode(participantIdentifier.Scheme, parts[0]), parts[1]);
			}
			catch (System.ArgumentException e)
			{
				throw new PeppolParsingException(e.Message, e);
			}
		}

		public virtual IcdIdentifier Parse(string icd, string identifier)
		{
			try
			{
				return IcdIdentifier.Of(FindByIdentifier(icd), identifier);
			}
			catch (System.ArgumentException e)
			{
				throw new PeppolParsingException(e.Message, e);
			}
		}

		public virtual IIcd FindBySchemeAndCode(Scheme scheme, string code)
		{
            IIcd Result = Values.Find(v => v.Code.Equals(code) && v.Scheme.Equals(scheme));
            if (Result == null)
                throw new ArgumentException(string.Format("Value '{0}::{1}' is not valid ICD.", scheme, code));
            else
                return Result;
		}

		public virtual IIcd FindByIdentifier(string identifier)
		{
            IIcd Result = Values.Find(v => v.Identifier.Equals(identifier));
            if (Result == null)
                throw new ArgumentException(string.Format("Value '{0}' is not valid ICD.", identifier));
            else
                return Result;
		}

		public virtual IIcd FindByCode(string code)
		{
            IIcd Result = Values.Find(v => v.Code.Equals(code));
            if (Result == null)
                throw new ArgumentException(string.Format("Value '{0}' is not valid ICD.", code));
            else
                return Result;
        }

		public List<IIcd> Values { get; set; }
	}
}