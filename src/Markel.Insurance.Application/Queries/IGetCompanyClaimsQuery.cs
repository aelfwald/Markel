namespace Markel.Insurance.Application
{
	/// <summary>
	/// Defines a query that returns a specific claim
	/// </summary>
	public interface IGetCompanyClaimsQuery
	{
		/// <summary>
		/// Runs the query
		/// </summary>
		/// <returns>A <see cref="IEnumerable{T}"> of claim unique references </see> <see cref="string"/>/></returns>
		Task<IEnumerable<string>> Run(int companyId);
	}
}
