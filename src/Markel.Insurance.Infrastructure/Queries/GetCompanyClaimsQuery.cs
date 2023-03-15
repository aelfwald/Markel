using Markel.Insurance.Domain;
using Markel.Insurance.Infrastructure;

namespace Markel.Insurance.Application
{
	/// <summary>
	/// Defines a query that returns a specific claim
	/// </summary>
	public class GetCompanyClaimsQuery : IGetCompanyClaimsQuery
	{
		private readonly DataProvider _dataProvider;

		public GetCompanyClaimsQuery(DataProvider dataProvider)
		{
			_dataProvider = dataProvider;
		}

		/// <summary>
		/// Runs the query
		/// </summary>
		/// <returns>A <see cref="IEnumerable{T}"> of unique claim references </see> <see cref="string"/>/></returns>
		public async Task<IEnumerable<string>> Run(int companyId)
		{
			return await Task.FromResult(
				_dataProvider
					.GetClaims()
					.Where( c=> c.CompanyId == companyId)
					.Select( c => c.UniqueClaimReference ));
		}
	}
}
