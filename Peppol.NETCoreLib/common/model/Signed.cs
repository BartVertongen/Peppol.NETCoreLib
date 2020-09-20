using System;
using System.Security.Cryptography.X509Certificates;
using VertSoft.Peppol.Common.Api;


namespace VertSoft.Peppol.Common.Model
{

	[Serializable]
	public class Signed<T,S> : PotentiallySigned<T, S>
	{

		private const long serialVersionUID = 4872358438639447851L;

		private readonly T content;

		private readonly S certificate;

		private readonly DateTime? timestamp;

		public static Signed<T,S> of(T content, S certificate, DateTime? timestamp=null)
		{
			return new Signed<T,S>(content, certificate, timestamp);
		}

		/*public static Signed<T,S> of(T content, S certificate)
		{
			return of(content, certificate, null/*DateTime.Now);
		}*/

		private Signed(T content, S certificate, DateTime? timestamp)
		{
			this.content = content;
			this.certificate = certificate;
			this.timestamp = timestamp;
		}

		public virtual T Content
		{
			get
			{
				return content;
			}
		}

		public virtual S Certificate
		{
			get
			{
				return certificate;
			}
		}

		public virtual DateTime? Timestamp
		{
			get
			{
				return timestamp;
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

            //ORIGINAL LINE: Signed<?> signed = (Signed<?>) o;
			Signed<T,S> that = (Signed<T,S>) o;

			if (!this.content.Equals(that.content))
			{
				return false;
			}
			if (!this.certificate.Equals(that.certificate))
			{
				return false;
			}
            if (this.timestamp == that.timestamp)
                return true;
            else if (this.timestamp != null && that.timestamp != null)
                return timestamp.Equals(that.timestamp);
            else return false;
		}

		public override int GetHashCode()
		{
			int result = content.GetHashCode();
			result = 31 * result + certificate.GetHashCode();
			result = 31 * result + (timestamp != null ? timestamp.GetHashCode() : 0);
			return result;
		}

		public override string ToString()
		{
			return "Signed{" +
					"content=" + content +
					", certificate=" + certificate +
					", timestamp=" + timestamp +
					'}';
		}

        //Here we create a new object but signed in the same way as the original
        public virtual Signed<T, S> ofSubset(T t)
        {
            return new Signed<T, S>(t, certificate, timestamp);
        }


        public PotentiallySigned<T, S> ofSubset(S s)
        {
            return new Signed<T, S>(Content, s, timestamp);
        }
    }
}