using Markel.Insurance.Application;
using Microsoft.AspNetCore.Mvc;

namespace Markel.Insurance.Api.Controllers;

/// <summary>
/// Companies REST controller
/// </summary>
[ApiController]
[Route("v{version:apiVersion}/companies/")]
[ApiVersion("1.0")]
public class CompaniesController : ControllerBase
{
	private readonly ICompaniesService _companiesService;
	private readonly ILogger<CompaniesController> _logger;

    /// <summary>
    /// Class constructor
    /// </summary>
    /// <param name="companiesService"></param>
    /// <param name="logger"></param>
    public CompaniesController(
		ICompaniesService companiesService,
		ILogger<CompaniesController> logger
        )
    {
		_companiesService = companiesService;
		_logger = logger;
    }

    /// <summary>
    /// Get all companies.
    /// </summary>
    /// <returns>Returns a <see cref="IEnumerable{T}"/> list of type <see cref="CompanyJson"/></returns>
    [HttpGet]
    public async Task<IEnumerable<CompanyJson>> GetCompanies()
    {
		_logger.LogTrace("{MethodName} called", nameof(GetCompanies));

		IEnumerable<CompanyDto> dtos = await _companiesService.GetAll();

        return dtos.Select( dto => new CompanyJson()
        {
            Id = dto.Id,
            Active = dto.Active,
            Address1 = dto.Address1,
            Address2 = dto.Address2,
            Address3 = dto.Address3,
            Country = dto.Country,
            HasActivePolicy = dto.HasActivePolicy,
            InsuranceEndDate = dto.InsuranceEndDate,
            Name = dto.Name,
            Postcode = dto.Postcode
        });
    }
}
