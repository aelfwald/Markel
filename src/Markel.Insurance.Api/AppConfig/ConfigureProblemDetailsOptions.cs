using Markel.Insurance.Application;
using Microsoft.AspNetCore.Diagnostics;

namespace Markel.Insurance.ApiAppConfig
{
	/// <summary>
	/// Configures problem details
	/// </summary>
	public class ConfigureProblemDetailsOptions
	{
		/// <summary>
		/// Configure the problem details middleware to transform any exceptions
		/// into a properly formatted problem details response
		/// </summary>
		public static void ConfigureProblemDetails(ProblemDetailsOptions options)
		{
			options.CustomizeProblemDetails = Configure;
		}

		private static void Configure(ProblemDetailsContext context)
		{
			IExceptionHandlerFeature? exceptionHandlerPathFeature = context.HttpContext.Features.Get<IExceptionHandlerFeature>();

			switch (exceptionHandlerPathFeature?.Error)
			{
				case ValidationException ex:
					HandleValidationException(context, ex);
					break;
				case NotFoundException ex:
					HandleNotFoundException(context, ex);
					break;
				default:
					HandleDefaultException(context);
					break;
			}
		}

		private static void HandleValidationException(ProblemDetailsContext context, ValidationException ex)
		{
			context.HttpContext.Response.StatusCode = 400;
			context.ProblemDetails.Type = "https://httpstatuses.io/400";
			context.ProblemDetails.Title = "Bad Request";
			context.ProblemDetails.Status = 400;
			context.ProblemDetails.Detail = ex.Message;
		}

		private static void HandleNotFoundException(ProblemDetailsContext context, NotFoundException ex)
		{
			context.HttpContext.Response.StatusCode = 404;
			context.ProblemDetails.Type = "https://httpstatuses.io/404";
			context.ProblemDetails.Title = "Not Found";
			context.ProblemDetails.Status = 404;
			context.ProblemDetails.Detail = ex.Message;
		}

		private static void HandleDefaultException(ProblemDetailsContext context)
		{
			context.ProblemDetails.Type = "https://httpstatuses.io/500";
			context.ProblemDetails.Title = "Internal Server Error";
			context.ProblemDetails.Status = 500;
			context.ProblemDetails.Detail = "An internal server has occured while processing the request";
		}
	}
}
