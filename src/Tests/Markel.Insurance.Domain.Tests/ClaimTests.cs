using FluentAssertions;
using Moq;

namespace Markel.Insurance.Domain.Tests;

public class ClaimTests
{
	public static IEnumerable<object[]> NumberOfDaysTestParams
	{
		get
		{
			yield return new object[] { new DateTime(2023, 01, 1), 72 };
			yield return new object[] { new DateTime(2023, 03, 1), 13 };
			yield return new object[] { new DateTime(2023, 04, 1), 0  };
		}
	}

	[Theory]
	[MemberData(nameof(NumberOfDaysTestParams))]
	public void Ensure_Number_Of_Days_Since_Claim_Is_Correct( DateTime claimDate, double numberOfDays )
    {
		//Arrange
		var dateTimeProvider = new Mock<IDateTimeProvider>();
		dateTimeProvider.Setup(m => m.GetDateTime()).Returns(new DateTime(2023, 03, 14));

		var claim = new Claim(
						uniqueClaimReference: "UCR0000001",
						companyId: 1,
						claimDateUtc: claimDate,
						lossDate: new DateTime(2023, 02, 23, 0, 0, 0),
						assuredName: "George Costanza",
						incurredLoss: 1500.00M,
						closed: false,
						claimType: new ClaimType(id: 1, name: "Theft"));

		//Act
		double result = claim.DaysSinceClaim(dateTimeProvider.Object);

		//Assert
		result.Should().Be(numberOfDays);

	}
}