namespace Markel.Insurance.Application
{
	/// <summary>
	/// Provides application layer claims services
	/// </summary>
	public interface IClaimsService
	{
		/// <summary>
		/// Retrieves a list of unique claim references
		/// </summary>
		/// <returns>An <see cref="IEnumerable{T}"/> list of type <see cref="string"/></returns>
		Task<IEnumerable<string>> GetClaimsByCompany(int companyId);

		/// <summary>
		/// Retrieves a specific claim
		/// </summary>
		/// <param name="companyId">The company id</param>
		/// <param name="uniqueClaimReference">The unique claim reference</param>
		/// <returns>A <see cref="Claim"/> object</returns>
		Task<ClaimDto?> GetClaim(int companyId, string uniqueClaimReference);

		/// <summary>
		/// Updates a claim
		/// </summary>
		/// <param name="claimDto">The claim update details</param>
		/// <param name="updateClaimDispatcher">update dispatcher</param>
		Task Update(ClaimDto claimDto, UpdateClaimDispatcher updateClaimDispatcher);

	}
}
