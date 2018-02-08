using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Synkwise.API.Helpers;
using Synkwise.API.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Synkwise.API.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context /* other scoped dependencies */)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                LogException(ex);
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var statusCode = GetStatusCodeByExceptionType(exception.GetType().Name); // 500 if unexpected

            var result = JsonConvert.SerializeObject(
                new
                {
                    ResponseStatus = new ResponseModel
                    {
                        Status = (int)statusCode,
                        Message = exception.InnerException != null ? exception.InnerException.Message : exception.Message
                    }
                });

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;
            return context.Response.WriteAsync(result);
        }

        private static HttpStatusCode GetStatusCodeByExceptionType(string exceptionType)
        {
            var statusCode = HttpStatusCode.InternalServerError;

            var notFoundExceptions = new List<string>
            {
            };

            var badRequestExceptions = new List<string>
            {
                "RegisterBadRequestException",
                "LoginBadRequestException",
                "AccountBadRequestException",
                "ContactBadRequestException",
                "FacilityBadRequestException",
                "ProviderBadRequestException"
            };

            var conflictExceptions = new List<string>
            {
                // some conflict exceptions
            };

            if (notFoundExceptions.Contains(exceptionType))
            {
                statusCode = HttpStatusCode.NotFound;
            }
            else if (badRequestExceptions.Contains(exceptionType))
            {
                statusCode = HttpStatusCode.BadRequest;
            }
            else if (conflictExceptions.Contains(exceptionType))
            {
                statusCode = HttpStatusCode.Conflict;
            }

            return statusCode;
        }

        private static void LogException(Exception ex)
        {
            string errorMessage = string.Empty;
            StringBuilder stringBuilder = new StringBuilder();

            if (ex.InnerException != null)
            {
                stringBuilder.AppendLine(ex.InnerException.Message);
            }
            else
            {
                stringBuilder.AppendLine(ex.Message);
            }

            Logger.Log(stringBuilder.ToString());
        }

    }
}
