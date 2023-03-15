using Markel.Insurance.Application;
using Markel.Insurance.Domain;

namespace Markel.Insurance.Infrastructure
{
	/// <summary>
	/// A query that returns all companies
	/// </summary>
	public class GetCompaniesQuery : IGetCompaniesQuery
	{
		private readonly DataProvider _dataProvider;

		public GetCompaniesQuery(DataProvider dataProvider)
		{
			_dataProvider = dataProvider;
		}

		/// <summary>
		/// Runs the query
		/// </summary>
		/// <returns>A <see cref="IEnumerable{T}"> of unique claim references </see> <see cref="string"/>/></returns>
		public async Task<IEnumerable<Company>> Run()
		{
			return await Task.FromResult(
				_dataProvider
					.GetCompanies());
		}

	}
}
