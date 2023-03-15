namespace Markel.Insurance.Application
{
	/// <summary>
	/// Claim dto class
	/// </summary>
	public class ClaimDto
	{
		/// <summary>
		/// The unique claims reference
		/// </summary>
		public string? UniqueClaimReference 
		{ 
			get; set; 
		}

		/// <summary>
		/// Uniquely identifiers the claim's company
		/// </summary>
		public int CompanyId 
		{ 
			get; set; 
		}

		/// <summary>
		/// The claim date 
		/// </summary>
		public DateTime ClaimDate 
		{ 
			get; set; 
		}

		/// <summary>
		/// The claim lost date
		/// </summary>
		public DateTime LossDate 
		{ 
			get; set; 
		}

		/// <summary>
		/// The name of the entity covered by the insurance
		/// </summary>
		public string? AssuredName 
		{ 
			get; set; 
		}

		/// <summary>
		/// The loss incurred by the claimant
		/// </summary>
		public decimal IncurredLoss 
		{ 
			get; set; 
		}

		/// <summary>
		/// Is the claim closed?
		/// </summary>
		public bool Closed 
		{ 
			get; set; 
		}

		/// <summary>
		/// The claim type
		/// </summary>
		public string? ClaimType 
		{ 
			get; set; 
		}

		/// <summary>
		/// Number of days since the claim was submitted.
		/// </summary>
		public double DaysSinceClaim 
		{ 
			get; set; 
		}

	}
}
