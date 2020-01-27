using System.Threading.Tasks;

namespace DokanyApp.Services
{
    public interface ITokenManager
    {
        Task<bool> IsCurrentActiveTokenAsync();
        Task DeactivateCurrrentTokenAsync();
        Task<bool> IsActiveAsync(string token);
        Task DeactivateAsync(string token);
    } 
}
