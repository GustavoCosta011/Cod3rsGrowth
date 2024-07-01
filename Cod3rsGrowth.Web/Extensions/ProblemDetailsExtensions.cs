using System.Diagnostics;
using Extensions.SerializerSettings;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using FluentValidation;


namespace Cod3rsGrowth.Web
{
    public static class ProblemDetailsExtensions
    {
        public static void UseProblemDetailsExceptionHandler(this IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            app.UseExceptionHandler(builder =>
            {
                builder.Run(async context =>
                {
                    var ManipuladorExceptions = context.Features.Get<IExceptionHandlerFeature>();
                    if (ManipuladorExceptions != null)
                    {
                        var Titulo = "Um ou mais erros encontrados";
                        var exception = ManipuladorExceptions.Error;
                        var problemDetails = new ProblemDetails
                        {
                            Instance = context.Request.HttpContext.Request.Path
                        };
                        if (exception is ValidationException Validação)
                        {
                            problemDetails.Title = Titulo;
                            problemDetails.Status = StatusCodes.Status400BadRequest;
                            problemDetails.Detail = Validação.Demystify().ToString();
                            problemDetails.Extensions["Erros Encontrados"] = Validação.Errors
                            .GroupBy(error => error.PropertyName)
                            .ToDictionary(group => group.Key, group => group.First().ErrorMessage);
                            
                        }
                        else
                        {
                            var logger = loggerFactory.CreateLogger("GlobalExceptionHandler");
                            logger.LogError($"Unexpected error: {ManipuladorExceptions.Error}");
                            problemDetails.Title = Titulo;
                            problemDetails.Status = StatusCodes.Status400BadRequest;
                            problemDetails.Detail = exception.Demystify().ToString();
                            problemDetails.Extensions["Erros Encontrados"] = exception.Message;
                        }
                        context.Response.StatusCode = problemDetails.Status.Value;
                        context.Response.ContentType = "application/problem+json";
                        var json = JsonConvert.SerializeObject(problemDetails, SerializerSettings.JsonSerializerSettings);
                        await context.Response.WriteAsync(json);
                    }
                });
            });
        }

        public static IServiceCollection ConfigureProblemDetailsModelState(this IServiceCollection services)
        {
            return services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Instance = context.HttpContext.Request.Path,
                        Status = StatusCodes.Status400BadRequest,
                        Detail = "Please refer to the errors property for additional details"
                    };

                    return new BadRequestObjectResult(problemDetails)
                    {
                        ContentTypes = { "application/problem+json", "application/problem+xml" }
                    };
                };
            });
        }
    }
}



