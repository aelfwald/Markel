using System.ComponentModel.DataAnnotations;

namespace Markel.Insurance.Api
{
	/// <summary>
	/// Json class used in UpdateClaim request
	/// </summary>
	public class UpdateClaimJson
	{
		/// <summary>
		/// The claim date time
		/// </summary>
		[Required()]
		public DateTime ClaimDate 
		{
			get; set;
		}

		/// <summary>
		/// The claim lost date
		/// </summary>
		[Required()]
		public DateTime LossDate 
		{
			get; set; 
		}

		/// <summary>
		/// The name of the entity covered by the insurance
		/// </summary>
		[Required()]
		[MaxLength(100)]
		public string? AssuredName
		{
			get; set;
		}

		/// <summary>
		/// The loss incurred by the claimant	
		/// </summary>
		[Required()]
		[RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Incurred loss must be to 2 decimal places.")]
		[Range(0, 9999999999999999.99)]
		public decimal IncurredLoss 
		{
			get; set;
		}

		/// <summary>
		/// Is the claim closed?
		/// </summary>
		[Required()]
		public bool Closed 
		{
			get; set; 
		}

		/// <summary>
		/// The claim type
		/// Supported values are "Theft", "Fire" and "Death".
		/// </summary>
		[Required()]
		[MaxLength(20)]
		public string? ClaimType
		{
			get; set;
		}

	}
}
