namespace Markel.Insurance.Api
{
	/// <summary>
	/// Class used for serialising and de-serialising Company Json
	/// </summary>
	public class CompanyJson
	{
		/// <summary>
		/// The company unique identifier
		/// </summary>
		public int Id 
		{ 
			get; set; 
		}

		/// <summary>
		/// The company name
		/// </summary>
		public string? Name 
		{ 
			get; set; 
		}

		/// <summary>
		/// The address line 1
		/// </summary>
		public string? Address1 
		{ 
			get; set;
		}

		/// <summary>
		/// The address line 2
		/// </summary>
		public string? Address2 
		{ 
			get; set;
		}

		/// <summary>
		/// The address line 2
		/// </summary>
		public string? Address3 
		{ 
			get; set; 
		}

		/// <summary>
		/// The address postcode
		/// </summary>
		public string? Postcode 
		{ 
			get; set;
		}

		/// <summary>
		/// The address country
		/// </summary>
		public string? Country 
		{ 
			get; set; 
		}

		/// <summary>
		/// Is the company active?
		/// </summary>
		public bool Active 
		{ 
			get; set; 
		}

		/// <summary>
		/// The insurance end date
		/// </summary>
		public DateTime InsuranceEndDate 
		{ 
			get; set; 
		}

		/// <summary>
		/// Has the company got any active claims?
		/// </summary>
		public bool HasActivePolicy 
		{ 
			get; set;
		}
	}
}
