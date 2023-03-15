using Markel.Insurance.Domain;

namespace Markel.Insurance.Infrastructure
{
	public class DataProvider
	{
		private List<Claim>? _claims;
		private List<Company>? _company;
		private List<ClaimType>? _claimTypes;

		internal IEnumerable<Claim> GetClaims()
		{

			_claims ??= new List<Claim>
				{
					new Claim(
						uniqueClaimReference: "UCR000001",
						companyId: 1,
						claimDateUtc: new DateTime(2023, 02, 23, 13 ,0, 0).ToUniversalTime(),
						lossDate: new DateTime(2023, 02, 23, 0 ,0, 0),
						assuredName: "George Costanza",
						incurredLoss: 1500.00M,
						closed: false,
						claimType: new ClaimType(id: 2, name : "Fire")),
					new Claim(
						uniqueClaimReference: "UCR000002",
						companyId: 1,
						claimDateUtc: new DateTime(2023, 02, 23, 15 ,0, 0).ToUniversalTime(),
						lossDate: new DateTime(2022, 01, 01, 0 ,0, 0),
						assuredName: "Newman",
						incurredLoss: 1000.00M,
						closed: true,
						claimType: new ClaimType(id: 1, name : "Theft"))
				};

			return _claims;
		}

		internal IEnumerable<Company> GetCompanies()
		{
			_company ??= new List<Company>
				{
					new Company(
						id: 1,
						name: "Vanderlay Industries",
						address1: "5 Clough Building",
						address2: "Sowerby Bridge",
						address3: "Halifax",
						postcode: "HX6 1NH",
						country: "United Kingdom",
						active: true,
						insuranceEndDate: new DateTime(2023, 12, 31))
				};

			return _company;
		}

		internal IEnumerable<ClaimType> GetClaimTypes()
		{
			_claimTypes ??= new List<ClaimType>
				{
					new ClaimType(
						id: 1,
						name: "Theft"),
					new ClaimType(
						id: 2,
						name: "Fire"),
					new ClaimType(
						id: 3,
						name: "Death"),
				};

			return _claimTypes;
		}

	}
}
