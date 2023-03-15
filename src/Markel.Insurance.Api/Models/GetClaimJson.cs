﻿namespace Markel.Insurance.Api
{
	/// <summary>
	/// Class used for serialising and de-serialising Claim Json
	/// </summary>
	public class GetClaimJson
	{
		/// <summary>
		/// The unique claims reference
		/// </summary>
		public string? UniqueClaimsReference 
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
		/// The claim date time
		/// </summary>
		public DateTime ClaimDateUtc
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
		/// Number of days since the claim was submitted
		/// </summary>
		public double DaysSinceClaim
		{
			get; set;
		}
	}
}