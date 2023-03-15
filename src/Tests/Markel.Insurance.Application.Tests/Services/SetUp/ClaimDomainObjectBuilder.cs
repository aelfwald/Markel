using Markel.Insurance.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Markel.Insurance.Application
{
	internal class ClaimDomainObjectBuilder
	{

		private int _companyId = 1;
		private string _uniqueClaimReference = "UCR000001";

		internal ClaimDomainObjectBuilder WithCompanyId(int companyId)
		{
			_companyId = companyId;
			return this;
		}

		internal ClaimDomainObjectBuilder WithUniqueClaimReference(string uniqueClaimReference)
		{
			_uniqueClaimReference = uniqueClaimReference;
			return this;
		}

		internal Claim Build()
		{
			return new Claim(
						uniqueClaimReference: _uniqueClaimReference,
						companyId: _companyId,
						claimDateUtc: new DateTime(2023, 02, 23, 13, 0, 0).ToUniversalTime(),
						lossDate: new DateTime(2023, 02, 23, 0, 0, 0),
						assuredName: "George Costanza",
						incurredLoss: 1500.00M,
						closed: false,
						claimType: new ClaimType(id: 1, name: "Theft"));

		}


	}
}
