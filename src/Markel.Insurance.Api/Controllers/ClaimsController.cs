using Markel.Insurance.Application;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Markel.Insurance.Api.Controllers
{
	/// <summary>
	/// Claims REST controller
	/// </summary>
	[Route("v{version:apiVersion}/companies/{companyId}/claims")]
	[ApiController]
	[ApiVersion("1.0")]
	public class ClaimsController : ControllerBase
	{
		private readonly IClaimsService _claimsService;
		private readonly ILogger<CompaniesController> _logger;
			
		/// <summary>
		/// Class constructor
		/// </summary>
		/// <param name="claimsService">The claims service</param>
		/// <param name="logger">The logger</param>
		public ClaimsController(
			IClaimsService claimsService,
			ILogger<CompaniesController> logger)
		{
			_claimsService = claimsService ?? throw new ArgumentNullException(nameof(claimsService));
			_logger = logger;
		}

		/// <summary>
		/// Gets all claims for a company
		/// </summary>
		/// <param name="companyId">The claim company id</param>
		/// <returns>A list of claim unique reference codes</returns>
		[HttpGet]
		public async Task<ActionResult<List<string>>> GetClaimsForCompany(
						[FromRoute][Required] int companyId)
		{
			_logger.LogTrace("{MethodName} called", nameof(GetClaimsForCompany));

			IEnumerable<string> uniqueClaimReferences = await _claimsService.GetClaimsByCompany(companyId);
			return uniqueClaimReferences.ToList();
		}

		/// <summary>
		/// Returns a specific claim
		/// </summary>
		/// <param name="companyId">The claim company id</param>
		/// <param name="uniqueClaimReference">The unique claim reference</param>
		/// <returns>A <see cref="GetClaimJson"/> object</returns>
		[HttpGet()]
		[Route("{uniqueClaimReference}")]
		public async Task<ActionResult<GetClaimJson>> GetClaim(
			[FromRoute][Required] int companyId,
			[FromRoute][Required] string uniqueClaimReference)
		{
			_logger.LogTrace("{MethodName} called", nameof(GetClaim));

			ClaimDto claimDto = await _claimsService.GetClaim(companyId, uniqueClaimReference);

			var getClaimJson = new GetClaimJson()
			{
				CompanyId = claimDto.CompanyId,
				AssuredName = claimDto.AssuredName,
				ClaimDateUtc = claimDto.ClaimDate,
				ClaimType = claimDto.ClaimType,
				Closed = claimDto.Closed,
				IncurredLoss = claimDto.IncurredLoss,
				LossDate = claimDto.LossDate,
				UniqueClaimsReference = claimDto.UniqueClaimReference,
				DaysSinceClaim = claimDto.DaysSinceClaim
			};

			return getClaimJson;
		}

		/// <summary>
		/// Updates a company claim
		/// </summary>
		/// <param name="companyId">The company id</param>
		/// <param name="uniqueClaimReference">The unique claim reference</param>
		/// <param name="claim">The claim update details</param>
		[HttpPatch()]
		[Route("{uniqueClaimReference}")]
		public async Task<ActionResult> UpdateClaim(
			[FromRoute][Required] int companyId,
			[FromRoute][Required] string uniqueClaimReference,
			[FromBody][Required] UpdateClaimJson claim)
		{
			_logger.LogTrace("{MethodName} called", nameof(UpdateClaim));

			var claimDto = new ClaimDto()
			{
				CompanyId = companyId,
				AssuredName = claim.AssuredName,
				ClaimDate = claim.ClaimDateUtc,
				ClaimType = claim.ClaimType,
				Closed = claim.Closed,
				IncurredLoss = claim.IncurredLoss,
				LossDate = claim.LossDate,
				UniqueClaimReference = uniqueClaimReference
			};

			await _claimsService.Update(claimDto);

			return Ok()!;

		}

	}
}
