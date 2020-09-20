
using VertSoft.Peppol.Common.Model;

namespace VertSoft.Peppol.Common.Api
{

	/// <summary>
	/// Is an Endpoint with only a TransportProfile
	/// </summary>
	public interface ISimpleEndpoint
	{
		TransportProfile TransportProfile { get; /*set;*/ }
	}
}