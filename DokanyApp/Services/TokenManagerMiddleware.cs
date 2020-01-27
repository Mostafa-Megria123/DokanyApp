using Microsoft.AspNetCore.Http;
using System.Net;
using System.Threading.Tasks;

namespace DokanyApp.Services
{
    public class TokenManagerMiddleware : IMiddleware
    {
        private readonly ITokenManager _tokenManager;

        public TokenManagerMiddleware(ITokenManager tokenManager)
            => _tokenManager = tokenManager;

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if (await _tokenManager.IsCurrentActiveTokenAsync())
            {
                // go with the next middleware in case of token not blacklisted
                await next(context);
                return;
            }
            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized; //Blacklisted 401
        }
    }
}
