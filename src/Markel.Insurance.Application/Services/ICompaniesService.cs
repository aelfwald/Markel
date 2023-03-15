namespace Markel.Insurance.Application
{
	/// <summary>
	/// Provides application layer company services
	/// </summary>
	public interface ICompaniesService
	{
		/// <summary>
		/// Gets all companies
		/// </summary>
		/// <returns>An <see cref="IEnumerable{T}"/> list of type <see cref="CompanyDto"/></returns>
		Task<IEnumerable<CompanyDto>> GetAll();
	}
}
