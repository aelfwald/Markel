using Markel.Insurance.Domain;

namespace Markel.Insurance.Application
{
	/// <summary>
	/// Defines a query that returns all companies
	/// </summary>
	public interface IGetCompaniesQuery
	{
		/// <summary>
		/// Runs the query
		/// </summary>
		/// <returns>A <see cref="IEnumerable{T}"> of type <see cref="Company"/>/></returns>
		Task<IEnumerable<Company>> Run();
	}
}
