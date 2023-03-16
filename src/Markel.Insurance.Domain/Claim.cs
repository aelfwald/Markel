namespace Markel.Insurance.Domain
{
	/// <summary>
	/// Claim domain class
	/// </summary>
	public  class Claim
	{
		/// <summary>
		/// Class constructor
		/// </summary>
		public Claim(
			string uniqueClaimReference, 
			int companyId, 
			DateTime claimDateUtc, 
			DateTime lossDate, 
			string assuredName, 
			decimal incurredLoss,
			bool closed, 
			ClaimType claimType)
		{
			UniqueClaimReference = uniqueClaimReference;
			CompanyId = companyId;
			ClaimDate = claimDateUtc;
			LossDate = lossDate;
			AssuredName = assuredName;
			IncurredLoss = incurredLoss;
			Closed = closed;
			ClaimType = claimType;
		}

		/// <summary>
		/// The unique claim reference
		/// </summary>
		public string UniqueClaimReference 
		{
			get; set;
		}

		/// <summary>
		/// Uniquely identifies the claim's company
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
		/// The loss date
		/// </summary>
		public DateTime LossDate 
		{
			get; set;
		}

		/// <summary>
		/// The name of the entity covered by the insurance
		/// </summary>
		public string AssuredName
		{
			get; set;
		}

		/// <summary>
		/// The loss incurred
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
		public ClaimType ClaimType 
		{
			get; set; 
		}

		/// <summary>
		/// Number of days since the claim was submitted
		/// </summary>
		public double DaysSinceClaim(IDateTimeProvider dateTimeProvider)
		{ 
			return Math.Floor(Math.Max(0, (dateTimeProvider.GetDateTime() - this.ClaimDate).TotalDays));
		}

	}
}
