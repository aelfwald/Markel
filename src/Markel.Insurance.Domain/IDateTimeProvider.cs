namespace Markel.Insurance.Domain
{
	/// <summary>
	/// Defines a date time provider
	/// </summary>
	public interface IDateTimeProvider
	{
		/// <summary>
		/// Get the date time
		/// </summary>
		DateTime GetDateTime();
	}
}
