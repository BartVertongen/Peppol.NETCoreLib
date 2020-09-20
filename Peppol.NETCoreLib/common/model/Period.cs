
using System;

namespace VertSoft.Peppol.Common.Model.Lang
{
	/// <summary>
	/// 
	/// </summary>
	public interface IPeriod
	{
		DateTime From {get;}

		DateTime To {get;}

        bool isCurrent(DateTime date);


        bool isCurrent();

	}

    public class Period: IPeriod
    {
        public DateTime From { get; }

        public DateTime To { get; }

        private Period(DateTime from, DateTime to)//:base (from, to)
        {
            this.From = from;
            this.To = to;
        }


        public static Period Of(DateTime from, DateTime to)
        {
            return (new Period(from, to));
        }

        public bool isCurrent(DateTime date)
        {
            return (date > From && date < To);
        }

        public bool isCurrent()
        {
            return isCurrent(DateTime.Now);
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
            Period period = (Period)o;
            return From.Equals(period.From) && To.Equals(period.To);
        }

        public override int GetHashCode()
        {
            int intFrom = From.GetHashCode();
            int intTo = To.GetHashCode() << 16;
            int intGlobal = intTo + intFrom;
            return intGlobal;
        }
    }
}