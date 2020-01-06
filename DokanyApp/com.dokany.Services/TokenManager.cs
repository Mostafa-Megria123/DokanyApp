using JwtAuthentication.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DokanyApp.com.dokany.Services
{
    public class TokenManager : ITokenManager
    {
        public IDistributedCache _cache { get; }
        public IHttpContextAccessor _httpContextAccessor { get; }

        public TokenManager(IDistributedCache cache,
                            IHttpContextAccessor httpContextAccessor)
        {
            _cache = cache;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> IsCurrentActiveTokenAsync()
            => await IsActiveAsync(GetCurrentTokenAsync());

        public async Task DeactivateCurrrentTokenAsync()
            => await DeactivateAsync(GetCurrentTokenAsync());

        //  Here the check blacklisted tokens
        public async Task<bool> IsActiveAsync(string token)
            => await _cache.GetStringAsync(GetKey(token)) == null;

        public async Task DeactivateAsync(string token)
            => await _cache.SetStringAsync(GetKey(token),
                " ", new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow =
                    TimeSpan.FromMinutes(5) // Value of Expiration Time
                });

        private string GetCurrentTokenAsync()
        {
            var authorizationHeader = _httpContextAccessor
                .HttpContext.Request.Headers["authorization"].ToArray();

            return authorizationHeader == StringValues.Empty ?
                string.Empty :
                authorizationHeader.Single().Split(" ").Last();
            // As token begins with Bearer+space
        }

        // Change token format to be deactivated soon
        private static string GetKey(string token)
            => $"Token:{token}:Deactivated";
    }
}
