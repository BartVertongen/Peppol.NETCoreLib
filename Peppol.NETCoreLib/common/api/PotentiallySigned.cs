

namespace VertSoft.Peppol.Common.Api
{
	public interface PotentiallySigned<T,S>
	{
		T Content {get;}

		PotentiallySigned<T, S> ofSubset(S s);
	}
}