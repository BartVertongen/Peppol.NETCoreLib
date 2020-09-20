using System;


namespace VertSoft.Peppol.Common.Model
{

	[Serializable]
	public class InstanceType
	{
		public static InstanceType of(string standard, string type, string version)
		{
			return new InstanceType(standard, type, version);
		}

		public InstanceType(string standard, string type, string version)
		{
			this.Standard = string.ReferenceEquals(standard, null) ? null : standard.Trim();
			this.Type = string.ReferenceEquals(type, null) ? null : type.Trim();
			this.Version = string.ReferenceEquals(version, null) ? null : version.Trim();
		}

		public virtual string Standard { get; }

		public virtual string Type { get; }

		public virtual string Version { get; }

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

			InstanceType that = (InstanceType) o;

			if (!this.Standard.Equals(that.Standard))
			{
				return false;
			}
			if (!this.Type.Equals(that.Type))
			{
				return false;
			}
			return this.Version.Equals(that.Version);
		}

		public override int GetHashCode()
		{
			int result = this.Standard.GetHashCode();
			result = 31 * result + this.Type.GetHashCode();
			result = 31 * result + this.Version.GetHashCode();
			return result;
		}

		public override string ToString()
		{
			return string.Format("{0}::{1}::{2}", this.Standard, this.Type, this.Version);
		}
	}
}