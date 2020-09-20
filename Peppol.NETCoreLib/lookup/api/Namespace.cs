
namespace VertSoft.Peppol.Lookup.Api
{
	//[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
	public class Namespace : System.Attribute
	{
		internal string value;

		public Namespace(string value)
		{
			this.value = value;
		}
	}
}