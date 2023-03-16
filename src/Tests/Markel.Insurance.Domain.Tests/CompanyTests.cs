using FluentAssertions;
using Moq;

namespace Markel.Insurance.Domain.Tests;

public class CompanyTests
{
	public static IEnumerable<object[]> HasActivePolicyTestParams
	{
		get
		{
			yield return new object[] { new DateTime(2023, 03, 14, 0 , 0, 0), true };
			yield return new object[] { new DateTime(2023, 03, 15, 0, 0, 0), true };
			yield return new object[] { new DateTime(2023, 03, 14, 0, 0, 1), true };
			yield return new object[] { new DateTime(2023, 03, 13, 23, 59, 59), false };
			yield return new object[] { new DateTime(2023, 03, 13, 0, 0, 0), false };

		}
	}

	[Theory]
	[MemberData(nameof(HasActivePolicyTestParams))]
	public void Ensure_Has_Active_Policy_Is_Correct( DateTime insuranceEndDate, bool expectedResult)
    {
		//Arrange
		var dateTimeProvider = new Mock<IDateTimeProvider>();
		dateTimeProvider.Setup(m => m.GetDateTime()).Returns(new DateTime(2023, 03, 14, 0 ,0, 0));

		var company = new Company(
						id: 1,
						name: "Vanderlay Industries",
						address1: "5 Clough Building",
						address2: "Sowerby Bridge",
						address3: "Halifax",
						postcode: "HX6 1NH",
						country: "United Kingdom",
						active: true,
						insuranceEndDate: insuranceEndDate);

		//Act
		bool result = company.HasActivePolicy(dateTimeProvider.Object);

		//Assert
		result.Should().Be(expectedResult);

	}
}