using Microsoft.AspNetCore.Diagnostics;
using System.ComponentModel.DataAnnotations;

namespace Markel.Insurance.ApiAppConfig
{
	/// <summary>
	/// Configures Projects details
	/// </summary>
	public class ConfigureProblemDetailsOptions
	{
		/// <summary>
		/// Configure the problem details middleware to transform any exceptions
		/// into a properly formatted problem details response
		/// </summary>
		/// <param name="options"></param>
		public static void ConfigureProblemDetails(ProblemDetailsOptions options)
		{
			options.CustomizeProblemDetails = Configure;
		}

		/// <summary>
		/// Handler for the CustomizeProblemDetails property of the ProblemDetailsOptions object.
		/// Handles the actual transformation
		/// </summary>
		/// <param name="context"></param>
		private static void Configure(ProblemDetailsContext context)
		{
			IExceptionHandlerFeature? exceptionHandlerPathFeature = context.HttpContext.Features.Get<IExceptionHandlerFeature>();

			switch (exceptionHandlerPathFeature?.Error)
			{
				case ValidationException ex:
					HandleValidationException(context, ex);
					break;
				//case SignAndSendException ex:
				//	HandleSignAndSendException(context, ex);
				//	break;
				default:
					HandleDefaultException(context);
					break;
			}
		}

		/// <summary>
		/// Handle a <see cref="ProviderAuthorisationException"/>
		/// </summary>
		private static void HandleValidationException(ProblemDetailsContext context, ValidationException ex)
		{
			context.HttpContext.Response.StatusCode = 400;
			context.ProblemDetails.Type = "https://httpstatuses.io/401";
			context.ProblemDetails.Title = "Bad request";
			context.ProblemDetails.Status = 400;
			context.ProblemDetails.Detail = ex.Message;
		}

		///// <summary>
		///// Handle a <see cref="SignAndSendException"/>
		///// </summary>
		//private static void HandleSignAndSendException(ProblemDetailsContext context, SignAndSendException ex)
		//{
		//	context.ProblemDetails.Type = "https://httpstatuses.io/500";
		//	context.ProblemDetails.Title = "Internal Server Error";
		//	context.ProblemDetails.Status = 500;
		//	context.ProblemDetails.Detail = ex.PublicMessage;

		//	foreach (KeyValuePair<string, object?> extension in ex.Extensions)
		//	{
		//		context.ProblemDetails.Extensions.Add(extension);
		//	}
		//}

		/// <summary>
		/// Handle any other unhandle exceptions
		/// </summary>
		private static void HandleDefaultException(ProblemDetailsContext context)
		{
			context.ProblemDetails.Type = "https://httpstatuses.io/500";
			context.ProblemDetails.Title = "Internal Server Error";
			context.ProblemDetails.Status = 500;
			context.ProblemDetails.Detail = "An internal server has occured while processing the request";
		}
	}
}
