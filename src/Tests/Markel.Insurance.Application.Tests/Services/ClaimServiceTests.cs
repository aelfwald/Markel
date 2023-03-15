using Moq;
using FluentAssertions;
using Markel.Insurance.Domain;

namespace Markel.Insurance.Application.Tests;

public class ClaimServiceTests
{
    [Fact]
    public async void When_requesting_claim_with_invalid_company_id_then_no_claim_is_found()
    {
        var getClaimQuery = new Mock<IGetClaimQuery>();
		Claim claim = new ClaimDomainObjectBuilder()
						.WithCompanyId(1)
						.WithUniqueClaimReference("UCR000001").Build();
		getClaimQuery
				.Setup( m => m.Run("UCR000001"))
				.Returns(Task.FromResult<Claim?>(claim));

		var cut = new ClaimsService(
			new Mock<IGetCompanyClaimsQuery>().Object,
			getClaimQuery.Object,
			new Mock<IGetClaimTypesQuery>().Object,
			new Mock<IUpdateClaimCommand>().Object,
			new Mock<IDateTimeProvider>().Object
			);

       var result = await cut.GetClaim(2, "UCR000001");
		result.Should().BeNull();

    }

	[Fact]
	public async void When_requesting_claim_with_valid_company_id_then_claim_is_found()
	{
		//Arrange
		string uniqueClaimReference = "UCR000001";

		var getClaimQuery = new Mock<IGetClaimQuery>();
		Claim claim = new ClaimDomainObjectBuilder()
						.WithCompanyId(1)
						.WithUniqueClaimReference(uniqueClaimReference).Build();
		getClaimQuery
				.Setup(m => m.Run(uniqueClaimReference))
				.Returns(Task.FromResult<Claim?>(claim));

		var cut = new ClaimsService(
			new Mock<IGetCompanyClaimsQuery>().Object,
			getClaimQuery.Object,
			new Mock<IGetClaimTypesQuery>().Object,
			new Mock<IUpdateClaimCommand>().Object,
			new Mock<IDateTimeProvider>().Object
			);

		//Act
		var result = await cut.GetClaim(1, uniqueClaimReference);

		//Assert
		result.Should().NotBeNull();
		result!.UniqueClaimReference.Should().Be(uniqueClaimReference);
	}

	[Fact]
	public async void When_requesting_updaing_claim_with_invalid_company_id_then_claim_is_found()
	{
	
		//Arrange
		string uniqueClaimReference = "UCR000001";

		var getClaimQuery = new Mock<IGetClaimQuery>();
		Claim claim = new ClaimDomainObjectBuilder()
						.WithCompanyId(2)
						.WithUniqueClaimReference(uniqueClaimReference).Build();

		var claimDto = new ClaimDto()
		{
			UniqueClaimReference = uniqueClaimReference,
			CompanyId = 1,
			ClaimDate = new DateTime(2023, 02, 23, 13, 0, 0).ToUniversalTime(),
			LossDate = new DateTime(2023, 02, 23, 0, 0, 0),
			AssuredName = "George Costanza",
			IncurredLoss = 1500.00M,
			Closed = false,
			ClaimType = "Theft"
		};

		getClaimQuery
				.Setup(m => m.Run(uniqueClaimReference))
				.Returns(Task.FromResult<Claim?>(claim));

		var cut = new ClaimsService(
			new Mock<IGetCompanyClaimsQuery>().Object,
			getClaimQuery.Object,
			new Mock<IGetClaimTypesQuery>().Object,
			new Mock<IUpdateClaimCommand>().Object,
			new Mock<IDateTimeProvider>().Object);

		var dispatcher = new UpdateClaimDispatcher();
		var dispatcherMonitor = dispatcher.Monitor();

		//Act
		await cut.Update(claimDto, dispatcher);

		//Assert
		dispatcherMonitor.Should().Raise("ClaimNotFound");

	}

}