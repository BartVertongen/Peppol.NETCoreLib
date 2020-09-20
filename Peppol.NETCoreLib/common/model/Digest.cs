using System;
using VertSoft.Peppol.Common.Code;


namespace VertSoft.Peppol.Common.Model
{

	public interface IDigest
	{
		DigestMethod Method {get;}

		byte[] Value {get;}

	}

    [Serializable]
    public class Digest : IDigest
    {
        public DigestMethod Method { get; }
        public byte[] Value { get; }

        private Digest(DigestMethod method, byte[] value)
        {
            this.Method = method;
            this.Value = value;
        }

        public static IDigest of(DigestMethod method, byte[] value)
        {
            return new Digest(method, value);
        }

        public override bool Equals(object o)
        {
            if (this == o)  //same reference
            {
                return true;
            }
            if (o == null || this.GetType() != o.GetType())
            {
                return false;
            }

            Digest digest = (Digest)o;

            if (Method != digest.Method)
            {
                return false;
            }
            return Array.Equals(Value, digest.Value);
        }

        public override int GetHashCode()
        {
            int result = Method.GetHashCode();
            result = 31 * result + (Value != null ? Value[0] : 0);
            return result;
        }
    }
}