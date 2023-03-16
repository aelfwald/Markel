using Markel.Insurance.Domain;


namespace Markel.Insurance.Application
{
	/// <summary>
	/// Provides claims specific services
	/// </summary>
	public class ClaimsService : IClaimsService
	{
		private readonly IGetCompanyClaimsQuery _getCompanyClaimsQuery;
		private readonly IGetClaimQuery _getClaimQuery;
		private readonly IGetClaimTypesQuery _getClaimTypesQuery;
		private readonly IUpdateClaimCommand _updateClaimCommand;
		private readonly IGetCompaniesQuery _getCompaniesQuery;
		private readonly IDateTimeProvider _dateTimeProvider;

		/// <summary>
		/// Class constructor
		/// </summary>
		/// <param name="getCompanyClaimsQuery">A query that returns companys claims</param>
		/// <param name="getClaimQuery">A query that returns a claim</param>
		/// <param name="getClaimTypesQuery">A query that returns all available claim types</param>
		/// <param name="updateClaimCommand">A command that updates a claim</param>
		/// <param name="getCompaniesQuery">The get companies query</param>
		/// <param name="dateTimeProvider">The date time provider</param>
		/// <exception cref="ArgumentNullException"></exception>
		public ClaimsService(
			IGetCompanyClaimsQuery getCompanyClaimsQuery,
			IGetClaimQuery getClaimQuery,  
			IGetClaimTypesQuery getClaimTypesQuery,
			IUpdateClaimCommand updateClaimCommand,
			IGetCompaniesQuery getCompaniesQuery,
			IDateTimeProvider dateTimeProvider)
		{
			_getCompanyClaimsQuery = getCompanyClaimsQuery ?? throw new ArgumentNullException(nameof(getCompanyClaimsQuery));
			_getClaimQuery = getClaimQuery ?? throw new ArgumentNullException(nameof(getCompanyClaimsQuery));
			_getClaimTypesQuery = getClaimTypesQuery ?? throw new ArgumentNullException(nameof(getClaimTypesQuery));
			_updateClaimCommand = updateClaimCommand ?? throw new ArgumentNullException(nameof(updateClaimCommand));
			_getCompaniesQuery = getCompaniesQuery ?? throw new ArgumentNullException(nameof(getCompaniesQuery));
			_dateTimeProvider = dateTimeProvider ?? throw new ArgumentNullException(nameof(dateTimeProvider));
		}

		public async Task<ClaimDto> GetClaim(int companyId, string uniqueClaimReference)
		{

			if (string.IsNullOrEmpty(uniqueClaimReference))
			{
				throw new ArgumentException("Argument not initialised.", nameof(uniqueClaimReference));
			}

			Claim? claim = await _getClaimQuery.Run(uniqueClaimReference);

			if(claim is null || claim.CompanyId != companyId)
			{
				throw new NotFoundException("Claim not found");
			}

			var claimDto = new ClaimDto()
			{
				CompanyId = claim.CompanyId,
				AssuredName = claim.AssuredName,
				ClaimDate = claim.ClaimDate,
				ClaimType = claim.ClaimType.Name,
				Closed = claim.Closed,
				DaysSinceClaim = claim.DaysSinceClaim(_dateTimeProvider),
				IncurredLoss = claim.IncurredLoss,
				LossDate = claim.LossDate,
				UniqueClaimReference = claim.UniqueClaimReference
			};

			return claimDto;

		}

		public async Task<IEnumerable<string>> GetClaimsByCompany(int companyId)
		{

			if(!(await _getCompaniesQuery.Run()).Any( c => c.Id == companyId))
			{
				throw new NotFoundException("Company not found.");
			}

			return await _getCompanyClaimsQuery.Run(companyId);
		}

		public async Task Update(ClaimDto claimDto)
		{

			Claim? claim = await _getClaimQuery.Run(claimDto.UniqueClaimReference!);

			if(claim == null || claim.CompanyId != claimDto.CompanyId)
			{
				throw new NotFoundException("Claim not found");
			}

			IEnumerable<ClaimType> claimTypes = await _getClaimTypesQuery.Run();

			if (!ValidateClaimUpdate(claimDto, claimTypes, out string validationMessage))
			{
				throw new ValidationException(validationMessage);
			}

			claim.AssuredName = claimDto.AssuredName!.Trim();
			claim.ClaimDate = claimDto.ClaimDate;
			claim.Closed = claimDto.Closed;
			claim.IncurredLoss = claimDto.IncurredLoss;
			claim.LossDate = claimDto.LossDate;
			claim.ClaimType = claimTypes.First(c => c.Name.ToLower() == claimDto.ClaimType!.Trim().ToLower());

			await _updateClaimCommand.Run(claim);

		}

		private static bool ValidateClaimUpdate(ClaimDto claimDto, IEnumerable<ClaimType> claimTypes, out string validationMessage)
		{
			validationMessage = "";
			bool isValid = true;
			if (!claimTypes.Any(c => c.Name.ToLower() == claimDto.ClaimType!.Trim().ToLower()))
			{
				validationMessage = "Invalid claim type. Supported values are 'Theft', 'Fire' and 'Death'.";
				isValid = false;
			}

			// Can implement further validation rules required here e.g
			// Prevent updating of closed claims?
			// Prevent future dated claims?
			// etc

			return isValid;
		}

	}
}
