using Markel.Insurance.Domain;

namespace Markel.Insurance.Infrastructure
{
	/// <summary>
	/// Provides the current date time
	/// </summary>
	public class DateTimeProvider : IDateTimeProvider
	{
		public DateTime GetDateTime()
		{
			return DateTime.Now;
		}
	}
}
