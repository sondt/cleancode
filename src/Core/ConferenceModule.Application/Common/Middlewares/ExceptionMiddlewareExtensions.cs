using System.Net;
using ConferenceModule.Application.Common.Exceptions;
using ConferenceModule.Application.Common.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Serilog;

namespace ConferenceModule.Application.Common.Middlewares;

public static class ExceptionMiddlewareExtensions {
    // ReSharper disable once MethodTooLong
    public static void ConfigureExceptionHandler(this IApplicationBuilder app) {
        app.UseExceptionHandler(applicationBuilder => {
            applicationBuilder.Run(async context => {
                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature != null) {
                    var exception = contextFeature.Error;
                    var error = new ErrorDetail {
                        Message = exception.Message,
                        StatusCode = HttpStatusCode.InternalServerError,
                        TraceId = context.TraceIdentifier
                    };
                    error.StatusCode = exception switch {
                        ValidationException => HttpStatusCode.BadRequest,
                        BadRequestException => HttpStatusCode.BadRequest,
                        ArgumentNullException => HttpStatusCode.BadRequest,
                        NotFoundException => HttpStatusCode.NotFound,
                        _ => error.StatusCode
                    };

                    context.Response.ContentType = "application/json; charset=utf-8";
                    context.Response.StatusCode = (int) error.StatusCode;
                    var messageError = error.ToString();
                    // ReSharper disable once TemplateIsNotCompileTimeConstantProblem
                    Log.Error(messageError);
                    await context.Response.WriteAsync(messageError);
                }
            });
        });
    }
}