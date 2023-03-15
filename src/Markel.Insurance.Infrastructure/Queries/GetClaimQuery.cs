using Markel.Insurance.Application;
using Markel.Insurance.Domain;

namespace Markel.Insurance.Infrastructure
{
	/// <summary>
	/// Defines a query that returns a claim from the data source
	/// </summary>
	public class GetClaimQuery : IGetClaimQuery
	{
		private readonly DataProvider _dataProvider;

		public GetClaimQuery(DataProvider dataProvider)
		{
			_dataProvider = dataProvider;
		}

		/// <summary>
		/// Runs the query
		/// </summary>
		/// <returns>A <see cref="Claim"/> object</returns>
		public async Task<Claim?> Run(string claimUcr)
		{
			return await Task.FromResult(
						_dataProvider
							.GetClaims()
							.FirstOrDefault(c => c.UniqueClaimReference == claimUcr));
		}
	}
}
