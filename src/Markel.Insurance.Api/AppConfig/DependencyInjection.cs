using Markel.Insurance.Application;
using Markel.Insurance.Domain;
using Markel.Insurance.Infrastructure;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Diagnostics.CodeAnalysis;

namespace Markel.Insurance.Api
{
	/// <summary>
	/// Register dependencies against the service container
	/// </summary>
	[ExcludeFromCodeCoverage]
	public static class DependencyInjection
	{
		/// <summary>
		/// Registers services for dependency injection
		/// </summary>
		public static void RegisterServices(this IServiceCollection services)
		{
			services.AddSingleton<ICompaniesService, CompaniesSevice>();
			services.AddSingleton<IClaimsService, ClaimsService>();
			services.AddSingleton<IGetCompaniesQuery, GetCompaniesQuery>();
			services.AddSingleton<IGetCompanyClaimsQuery, GetCompanyClaimsQuery>();
			services.AddSingleton<IGetClaimQuery, GetClaimQuery>();
			services.AddSingleton<IGetClaimTypesQuery, GetClaimTypesQuery>();
			services.AddSingleton<IUpdateClaimCommand, UpdateClaimCommand>();
			services.AddSingleton<DataProvider, DataProvider>();
			services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
			services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerGenOptions>();

		}
	}
}

