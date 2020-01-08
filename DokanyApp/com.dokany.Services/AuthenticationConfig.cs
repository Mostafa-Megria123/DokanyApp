using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JwtAuthentication.Shared
{
    public static class AuthenticationConfig
    {
        public static string GenertateJsonWebToken(string username, string password, string userType)
        {
            //HashKey for the word "Welcome To JWT"
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("B70BBD1BBA4157CCE6E3FBEAF6FC02269DCC2E0A45A9FFF4305BCBCA5E8BD5B4"));
            var credintials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>();

            if (userType.Equals("Admin", StringComparison.InvariantCultureIgnoreCase))
            {
                claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Role, "Admin"),
                    new Claim("Username",username),
                    new Claim("Password",password)
                };
            }
            else if (userType.Equals("Customer", StringComparison.InvariantCultureIgnoreCase))
            {
                claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Role, "Customer"),
                    new Claim("Username",username),
                    new Claim("Password",password)
                };

            }
            else if (userType.Equals("Trader", StringComparison.InvariantCultureIgnoreCase))
            {
                claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Role, "Trader"),
                    new Claim("Username",username),
                    new Claim("Password",password)
                };
            }

            var token = new JwtSecurityToken("https://localhost:44325/",
                "https://localhost:44325/",
                claims,
                DateTime.Now,
                expires: DateTime.Now.AddMinutes(10),
                signingCredentials: credintials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        //ConfigureJwtAuthentication
        internal static TokenValidationParameters _TokenValidationParameters;

        public static void ConfigureJwtAuthentication(this IServiceCollection services)
        {
            //HashKey for the word "Welcome To JWT"
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("B70BBD1BBA4157CCE6E3FBEAF6FC02269DCC2E0A45A9FFF4305BCBCA5E8BD5B4"));
            var credintials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            _TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuerSigningKey = true,
                ValidIssuer = "https://localhost:44325/",
                ValidateLifetime = true,
                ValidAudience = "https://localhost:44325/",
                ValidateAudience = true,
                RequireSignedTokens = true,
                IssuerSigningKey = credintials.Key,
                ClockSkew = TimeSpan.FromMinutes(10)
            };

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = _TokenValidationParameters;
#if PROD || UAT
                options.IncludeErrorDetails
#elif DEBUG
                options.RequireHttpsMetadata = false;
#endif
            });
        }
    }
}


