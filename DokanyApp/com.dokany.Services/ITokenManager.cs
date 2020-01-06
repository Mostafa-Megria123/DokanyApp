using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DokanyApp.com.dokany.Services
{
    public interface ITokenManager
    {
        Task<bool> IsCurrentActiveTokenAsync();
        Task DeactivateCurrrentTokenAsync();
        Task<bool> IsActiveAsync(string token);
        Task DeactivateAsync(string token);
    } 
}
