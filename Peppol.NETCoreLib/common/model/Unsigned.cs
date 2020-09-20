
using System;
using VertSoft.Peppol.Common.Api;


namespace VertSoft.Peppol.Common.Model
{

	[Serializable]
	public class Unsigned<T> : PotentiallySigned<T, object>
	{

		private readonly T content;

		public static Unsigned<T> of(T content, object signature = null)
		{
			return new Unsigned<T>(content);
		}

		private Unsigned(T content)
		{
			this.content = content;
		}

		public virtual T Content
		{
			get
			{
				return content;
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

            //JAVA TO C# CONVERTER WARNING: Java wildcard generics have no direct equivalent in .NET:
            //ORIGINAL LINE: Unsigned<?> unsigned = (Unsigned<?>) o;
			Unsigned<T> unsigned = (Unsigned<T>) o;

			return content.Equals(unsigned.content);

		}

		public override int GetHashCode()
		{
			return content.GetHashCode();
		}

		public override string ToString()
		{
			return "Unsigned{" +
					"content=" + content +
					'}';
		}

        public PotentiallySigned<T, object> ofSubset(T t)
        {
            return Unsigned<T>.of(t);
        }

        public PotentiallySigned<T, object> ofSubset(object s=null)
        {
            return Signed<T, object>.of(content, s, DateTime.Now);
        }
    }
}