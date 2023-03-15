using Markel.Insurance.Domain;

namespace Markel.Insurance.Application
{
	/// <summary>
	/// Defines a query that returns a claim from the data source
	/// </summary>
	public interface IGetClaimQuery
	{
		/// <summary>
		/// Runs the query
		/// </summary>
		/// <returns>A <see cref="Claim"/> object</returns>
		Task<Claim?> Run(string claimUcr);
	}
}
