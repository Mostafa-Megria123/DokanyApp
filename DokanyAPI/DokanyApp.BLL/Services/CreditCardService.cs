using AutoMapper;
using DokanyApp.BLL.DTO;
using DokanyApp.BLL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DokanyApp.BLL.Services
{
    public class CreditCardService : ICreditCardService
    {
        private readonly IRepository<CreditCard> _repository;
        private readonly IUnitOfWork _uof;
        private readonly IMapper _mapper;
        public CreditCardService(IRepository<CreditCard> repository, IUnitOfWork uof, IMapper mapper)
        {
            _mapper = mapper;
            _uof = uof;
            _repository = repository;
        }

        public async Task Add(CreditCardDto creditCardDto)
        {
            var _creditCard = _mapper.Map<CreditCard>(creditCardDto);
            await _repository.Add(_creditCard);

            await _uof.CommitAsync();
        }

        public async Task<CreditCardDto> Any(CreditCardDto creditCard)
        {
            var _creditCards = await Get();
            var _creditCard = _creditCards.FirstOrDefault(c => c.CardName == creditCard.CardName && c.CardNumber == creditCard.CardNumber && c.Month == creditCard.Month && c.Year == creditCard.Year);
         
            if (_creditCard != null)
                return _creditCard;

            return null;
        }

        public async Task<CreditCardDto> FindById(int Id)
        {
            var creditCard = await _repository.GetById(Id);

            return _mapper.Map<CreditCardDto>(creditCard);
        }

        public async Task<List<CreditCardDto>> Get()
        {
            var creditCards = await _repository.Get();

            return _mapper.Map<List<CreditCardDto>>(creditCards);
        }

        public async Task Remove(int Id)
        {
            var creditCard = await _repository.GetById(Id);
            await _repository.Remove(creditCard);

            await _uof.CommitAsync();
        }

        public async Task Update(CreditCardDto creditCardDto)
        {
            var _creditCard = _mapper.Map<CreditCard>(creditCardDto);
            await _repository.Update(_creditCard);
         
            await _uof.CommitAsync();
        }
    }
}
