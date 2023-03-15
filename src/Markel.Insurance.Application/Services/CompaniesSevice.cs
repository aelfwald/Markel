using Markel.Insurance.Domain;

namespace Markel.Insurance.Application
{
	/// <summary>
	/// Provides companies specfic services
	/// </summary>
	public class CompaniesSevice : ICompaniesService
	{
		private readonly IGetCompaniesQuery _getCompaniesQuery;

		/// <summary>
		/// Class constructor
		/// </summary>
		/// <param name="getCompaniesQuery">The get companies query</param>
		public CompaniesSevice(IGetCompaniesQuery getCompaniesQuery)
		{
			_getCompaniesQuery = getCompaniesQuery ?? throw new ArgumentNullException(nameof(getCompaniesQuery));
		}

		public async Task<IEnumerable<CompanyDto>> GetAll()
		{
			IEnumerable<Company> companies = await _getCompaniesQuery.Run();

			var companyDtos = new List<CompanyDto>();

			companies.ToList().ForEach(i =>
				companyDtos.Add(new CompanyDto()
				{
					Active = i.Active,
					Address1 = i.Address1,
					Address2 = i.Address2,
					Address3 = i.Address3,
					Country = i.Country,
					HasActivePolicy = i.HasActivePolicy,
					Id = i.Id,
					InsuranceEndDate = i.InsuranceEndDate,
					Name = i.Name,
					Postcode = i.Postcode
				}));

			return companyDtos;

		}
	}
}
