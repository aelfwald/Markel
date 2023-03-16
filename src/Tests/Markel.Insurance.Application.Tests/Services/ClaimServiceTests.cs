using FluentAssertions;
using Markel.Insurance.Domain;
using Moq;

namespace Markel.Insurance.Application.Tests;

public class ClaimServiceTests
{
    [Fact]
    public void When_requesting_claim_with_invalid_company_id_then_no_claim_is_found()
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
			new Mock<IGetCompaniesQuery>().Object,
			new Mock<IDateTimeProvider>().Object
			);

		Func<Task> test = async () =>
		{
			var result = await cut.GetClaim(2, "UCR000001");
		};

		test.Should().ThrowAsync<NotFoundException>();

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
			new Mock<IGetCompaniesQuery>().Object,
			new Mock<IDateTimeProvider>().Object
			);

		//Act
		var result = await cut.GetClaim(1, uniqueClaimReference);

		//Assert
		result.Should().NotBeNull();
		result!.UniqueClaimReference.Should().Be(uniqueClaimReference);
	}

	[Fact]
	public void When_updating_claim_with_invalid_company_id_then_claim_is_not_found()
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
			ClaimDate = new DateTime(2023, 02, 23, 13, 0, 0),
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
			new Mock<IGetCompaniesQuery>().Object,
			new Mock<IDateTimeProvider>().Object);


		//Act
		Func<Task> test = async () =>
		{
			await cut.Update(claimDto);
		};

		//Assert
		test.Should().ThrowAsync<NotFoundException>();

	}

	[Fact]
	public void When_updating_claim_with_invalid_company_claim_type_then_validation_fails()
	{

		//Arrange
		string uniqueClaimReference = "UCR000001";

		Claim claim = new ClaimDomainObjectBuilder()
						.WithCompanyId(2)
						.WithUniqueClaimReference(uniqueClaimReference).Build();

		var claimDto = new ClaimDto()
		{
			UniqueClaimReference = uniqueClaimReference,
			CompanyId = 1,
			ClaimDate = new DateTime(2023, 02, 23, 13, 0, 0),
			LossDate = new DateTime(2023, 02, 23, 0, 0, 0),
			AssuredName = "George Costanza",
			IncurredLoss = 1500.00M,
			Closed = false,
			ClaimType = "Fire"
		};

		var claimTypes = new List<ClaimType>()
		{
			new ClaimType(1, "Theft")
		};

		var getClaimQuery = new Mock<IGetClaimQuery>();
		getClaimQuery
				.Setup(m => m.Run(uniqueClaimReference))
				.Returns(Task.FromResult<Claim?>(claim));

		var getClaimTypes = new Mock<IGetClaimTypesQuery>();
		getClaimTypes
				.Setup(m => m.Run())
				.Returns(Task.FromResult<IEnumerable<ClaimType>>(claimTypes));


		var cut = new ClaimsService(
			new Mock<IGetCompanyClaimsQuery>().Object,
			getClaimQuery.Object,
			getClaimTypes.Object,
			new Mock<IUpdateClaimCommand>().Object,
			new Mock<IGetCompaniesQuery>().Object,
			new Mock<IDateTimeProvider>().Object);


		//Act
		Func<Task> test = async () =>
		{
			await cut.Update(claimDto);
		};

		//Assert
		test.Should().ThrowAsync<ValidationException>();

	}

	[Fact]
	public async void When_updating_claim_then_claim_is_updated()
	{
		//Arrange
		string uniqueClaimReference = "UCR000001";

		Claim claim = new ClaimDomainObjectBuilder().Build();

		var claimDto = new ClaimDto()
		{
			UniqueClaimReference = uniqueClaimReference,
			CompanyId = 1,
			ClaimDate = new DateTime(2023, 02, 24, 0, 0, 0),
			LossDate = new DateTime(2023, 02, 24, 0, 0, 0),
			AssuredName = "Comos Kramer",
			IncurredLoss = 2000M,
			Closed = true,
			ClaimType = "Fire"
		};

		var claimTypes = new List<ClaimType>()
		{
			new ClaimType(1, "Theft"),
			new ClaimType(2, "Fire"),
		};

		var getClaimQuery = new Mock<IGetClaimQuery>();
		getClaimQuery
				.Setup(m => m.Run(uniqueClaimReference))
				.Returns(Task.FromResult<Claim?>(claim));

		var getClaimTypes = new Mock<IGetClaimTypesQuery>();
		getClaimTypes
				.Setup(m => m.Run())
				.Returns(Task.FromResult<IEnumerable<ClaimType>>(claimTypes));


		var cut = new ClaimsService(
			new Mock<IGetCompanyClaimsQuery>().Object,
			getClaimQuery.Object,
			getClaimTypes.Object,
			new Mock<IUpdateClaimCommand>().Object,
			new Mock<IGetCompaniesQuery>().Object,
			new Mock<IDateTimeProvider>().Object);


		//Act
		await cut.Update(claimDto);

		//Assert
		claim.AssuredName.Should().Be(claimDto.AssuredName);
		claim.ClaimDate.Should().Be(claimDto.ClaimDate);
		claim.ClaimType.Name.Should().Be(claimDto.ClaimType);
		claim.Closed.Should().Be(claimDto.Closed);
		claim.IncurredLoss.Should().Be(claimDto.IncurredLoss);
		claim.LossDate.Should().Be(claimDto.LossDate);

	}

}