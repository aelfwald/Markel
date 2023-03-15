using Markel.Insurance.Domain;

namespace Markel.Insurance.Application
{
	/// <summary>
	/// Defines a query that returns claim types
	/// </summary>
	public interface IGetClaimTypesQuery
	{
		/// <summary>
		/// Runs the query
		/// </summary>
		/// <returns>A <see cref="IEnumerable{T}"/> list of type <see cref="ClaimType"/></returns>
		Task<IEnumerable<ClaimType>> Run();
	}
}
