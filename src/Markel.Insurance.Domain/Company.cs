namespace Markel.Insurance.Domain;

/// <summary>
/// Company domain class
/// </summary>
public class Company
{
	/// <summary>
	/// Class constructor
	/// </summary>
	public Company(
		int id, 
		string name, 
		string address1, 
		string address2, 
		string address3, 
		string postcode, 
		string country, 
		bool active, 
		DateTime insuranceEndDate)
	{
		Id = id;
		Name = name;
		Address1 = address1;
		Address2 = address2;
		Address3 = address3;
		Postcode = postcode;
		Country = country;
		Active = active;
		InsuranceEndDate = insuranceEndDate;
	}

	/// <summary>
	/// Company unique identifier
	/// </summary>
	public int Id 
	{
		get; set;
	}

	/// <summary>
	/// The company name
	/// </summary>
	public string Name 
	{
		get; set;
	}

	/// <summary>
	/// Company address line 1
	/// </summary>
	public string Address1 
	{
		get; set; 
	}

	/// <summary>
	/// Company address line 2
	/// </summary>
	public string Address2
	{
		get; set;
	}

	/// <summary>
	/// Company address line 3
	/// </summary>
	public string Address3
	{
		get; set; 
	}

	/// <summary>
	/// Company post code
	/// </summary>
	public string Postcode 
	{
		get; set; 
	}

	/// <summary>
	/// Company country
	/// </summary>
	public string Country 
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
	/// Has the company got an active policy?
	/// </summary>
	public bool HasActivePolicy (IDateTimeProvider dateTimeProvider)
	{ 
		return this.InsuranceEndDate >= dateTimeProvider.GetDateTime(); 
	}
}
