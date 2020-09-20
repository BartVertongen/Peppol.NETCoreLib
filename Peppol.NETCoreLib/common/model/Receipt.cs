using System;
using System.Linq;


namespace VertSoft.Peppol.Common.Model
{

	[Serializable]
	public class Receipt
	{
		private readonly string type;

		private readonly byte[] value;

		public static Receipt of(string type, byte[] value)
		{
			return new Receipt(type, value);
		}

		public static Receipt of(byte[] value)
		{
			return of(null, value);
		}

		private Receipt(string type, byte[] value)
		{
			this.type = string.ReferenceEquals(type, null) ? null : type.Trim();
			this.value = value;
		}

		public virtual string Type
		{
			get
			{
				return type;
			}
		}

		public virtual byte[] Value
		{
			get
			{
				return value;
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

			Receipt that = (Receipt)o;

			if (!string.ReferenceEquals(this.type, null) ?!this.type.Equals(that.type) :!string.ReferenceEquals(that.type, null))
			{
				return false;
			}
			return this.value.SequenceEqual(that.value);

		}

		public override int GetHashCode()
		{
			int result = !string.ReferenceEquals(type, null) ? type.GetHashCode() : 0;
			result = 31 * result + value.GetHashCode();
			return result;
		}

		public override string ToString()
		{
			return "Receipt{" +
					"type='" + type + '\'' +
					", value=" + value.ToString() +
					'}';
		}
	}
}