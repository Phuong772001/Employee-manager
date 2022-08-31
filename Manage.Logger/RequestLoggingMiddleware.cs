
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;

namespace Manage.Logger
{
    class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        //private readonly ILogger _loggerFactory;
        private readonly ILoggerFactory _loggerFactory;
        public RequestLoggingMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _loggerFactory = loggerFactory;
        }

        public void InvokeAsync(HttpContext context)
        {
            var _logger = _loggerFactory.CreateLogger<RequestLoggingMiddleware>();

            try
            {
                _logger.LogInformation("Performing file logging in Middleware operation");

                // Perform some Database action into Middleware 


                _logger.LogWarning("Performing Middleware Save operation");

                //Save Data


                _logger.LogInformation("Save Comepleted");

                _next(context);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex.Message}");
            }
        }
    }
}
