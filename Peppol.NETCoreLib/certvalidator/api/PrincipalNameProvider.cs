namespace no.difi.certvalidator.api
{
	/// <summary>
	/// Used by PrincipalNameValidator to implement validation logic.
	/// </summary>
	public interface PrincipalNameProvider<T>
	{
		bool validate(T value);
	}
}