namespace Markel.Insurance.Application
{
	internal class ClaimDtoBuilder
	{

		internal static ClaimDto Build()
		{
			return new ClaimDto()
			{
				UniqueClaimReference = "UCR000001",
				CompanyId = 1,
				ClaimDate = new DateTime(2023, 02, 23, 13, 0, 0).ToUniversalTime(),
				LossDate = new DateTime(2023, 02, 23, 0, 0, 0),
				AssuredName = "George Costanza",
				IncurredLoss = 1500.00M,
				Closed = false,
				ClaimType = "Theft"
			};
		
		}


	}
}
