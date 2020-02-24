using DokanyApp.BLL.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DokanyApp.BLL.Interfaces
{
    public interface ICreditCardService
    {
        Task<List<CreditCardDto>> Get();
        Task<CreditCardDto> Any(CreditCardDto creditCard);
        Task<CreditCardDto> FindById(int Id);
        Task Remove(int Id);
        Task Add(CreditCardDto creditCard);
        Task Update(CreditCardDto creditCard);
    }
}
