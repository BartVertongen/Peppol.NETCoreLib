
using System;


namespace VertSoft.Peppol.Publisher.Annotation
{
	/// <summary>
	/// no.difi.vefa.peppol.publisher.syntax.Bdxr201605PublisherSyntax
	/// no.difi.vefa.peppol.publisher.syntax.BusdoxPublisherSyntax
	/// </summary>
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
	public class SyntaxAttribute : Attribute
	{
		internal string[] value;


		/// <summary>
		/// The positional parameter is an array of strings
		/// </summary>
		/// <param name="value"></param>
		public SyntaxAttribute(string value1, string value2)
		{
			this.value = new string [2];
			this.value[0] = value1;
			this.value[1] = value2;
		}

		public SyntaxAttribute(string v)
		{
			this.value = new string[1];
			this.value[0] = v;
		}
	}
}