using Markel.Insurance.Application;
using Markel.Insurance.Domain;

namespace Markel.Insurance.Infrastructure
{
	/// <summary>
	/// Defines a query that returns all claim types from the data source
	/// </summary>
	public class GetClaimTypesQuery : IGetClaimTypesQuery
	{
		private readonly DataProvider _dataProvider;

		/// <summary>
		/// Class constructor
		/// </summary>
		/// <param name="dataProvider"></param>
		public GetClaimTypesQuery(DataProvider dataProvider)
		{
			_dataProvider = dataProvider;
		}

		public async Task<IEnumerable<ClaimType>> Run()
		{

			return await Task.FromResult(
						_dataProvider
							.GetClaimTypes());
		}
	}
}
