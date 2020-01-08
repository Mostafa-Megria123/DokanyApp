using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DokanyApp.com.dokany.Services;
using DokanyApp.Models;
using JwtAuthentication.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace JwtAuthentication.Controllers
{
    [Route("api/[controller]")]
    //[ApiController]
    public class AuthenticationController : ControllerBase
    {
        public static string resultedToken;
        private readonly DokanyContext _context;
        private readonly ITokenManager _tokenManager;

        public AuthenticationController(DokanyContext context,
            ITokenManager tokenManager)
        {
            _context = context;
            _tokenManager = tokenManager;
        }

        [HttpGet]
        public string Get(string username, string password, string userType)
        {
            return (username == "Mostafa" && password == "Mm_123456" && userType == "Customer")
                ? AuthenticationConfig.GenertateJsonWebToken(username, password, userType)
                : "Please enter a valid parameters";
        }

        [HttpPost("OnlyCustomer")]
        //[Authorize(Roles = "Customer")]
        [Authorize(Roles = "Trader")]
        public string Post()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            IEnumerable<Claim> claim = identity.Claims;
            var username = claim.Where(U => U.Type == "Username").Select(U => U.Value).SingleOrDefault();
            var password = claim.Where(P => P.Type == "Password").Select(U => U.Value).SingleOrDefault();

            return "Hey " + username + " is here and Ur password is " + password + " :D";
        }

        [HttpGet("Registeration")]
        public async Task UserRegisterationAsync(string firstName, string lastName, string email, string mobileNumber, string userType)
        {
            if (userType.Equals("customer", StringComparison.InvariantCultureIgnoreCase))
            {
                //var customerId = _context.Customer.Select(c => c.CustomerId).LastOrDefault() + 1;
                _context.User.Add(new User()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    MobileNumber = mobileNumber,
                    UserStatus = DokanyApp.com.dokany.Models.UserStatusENU.NewUser,
                    UserType = DokanyApp.com.dokany.Models.UserType.Customer
                });
            }
            else if (userType.Equals("trader", StringComparison.InvariantCultureIgnoreCase))
            {
                //var traderId = _context.User.Select(c => c.TraderId).LastOrDefault() + 1;
                _context.User.Add(new DokanyApp.Models.User()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    MobileNumber = mobileNumber,
                    UserStatus = DokanyApp.com.dokany.Models.UserStatusENU.NewUser,
                    UserType = DokanyApp.com.dokany.Models.UserType.Trader

                });
            }
            await _context.SaveChangesAsync();
        }

        [HttpGet("Login")]
        public string Login(string _username, string _password, string userType)
        {
            if (userType.Equals("customer", StringComparison.InvariantCultureIgnoreCase))
            {
                var username = _context.User.Where(c => c.UserName == _username).FirstOrDefault().ToString();
                var password = _context.User.FirstOrDefault(m => m.MobileNumber == _password).MobileNumber;

                if (username == _username && password == _password)
                {
                    resultedToken = AuthenticationConfig.GenertateJsonWebToken(username, password, userType);
                    //return "Hey" + username + "how are you sweety";
                }
            }
            else if (userType.Equals("trader", StringComparison.InvariantCultureIgnoreCase))
            {
                var username = _context.User.FirstOrDefault(u => u.UserName == _username).UserName;
                var password = _context.User.FirstOrDefault(t => t.MobileNumber == _password).MobileNumber;

                if (username == _username && password == _password)
                {
                    resultedToken = AuthenticationConfig.GenertateJsonWebToken(username, password, userType);
                    //return "Hey" + username + "how are you sweety";
                }
            }
            return resultedToken;
        }

        [HttpPost("LogOut")]
        public async Task<IActionResult> Invalidate()
        {
            await _tokenManager.DeactivateCurrrentTokenAsync();

            return NoContent();
        }
    }
}