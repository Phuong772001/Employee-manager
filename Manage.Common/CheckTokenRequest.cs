using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Common
{
    public class CheckTokenRequest
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly RequestDelegate _next;
        public CheckTokenRequest(IHttpContextAccessor httpContextAccessor, RequestDelegate next)
        {
            _httpContextAccessor = httpContextAccessor;
            _next = next;
        }
        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                var isExisttoken = _httpContextAccessor.HttpContext.Request.Headers.TryGetValue("Authorization",out var token);
                if (isExisttoken == false)
                {
                    await HandleExceptionAsync(httpContext);
                    return;
                }
                var handler = new JwtSecurityTokenHandler();
                var tokenSecure = handler.CanReadToken(token);
                if (tokenSecure != true)
                {
                    await HandleResponseAsync(httpContext);
                    return;
                }    
                   
                
               await _next(httpContext);
            }
            catch(Exception e)
            {
                await HandleExceptionAsync(httpContext);
            }
        }
        private async Task HandleExceptionAsync(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = 500;
            await context.Response.WriteAsJsonAsync<object>(Response.DataNullResponse());
        }
        private async Task HandleResponseAsync(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = 200;
            await context.Response.WriteAsJsonAsync<object>(Response.AuthHeaderResponse());
           
        }
    }
}
