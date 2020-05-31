using AutoMapper;
using DokanyApp.BLL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DokanyApp.BLL.Services
{
    public class CartItemService : ICartItemService
    {
        private readonly IRepository<CartItem> _repository;
        private readonly IUnitOfWork _uof;
        private readonly IMapper _mapper;
        public CartItemService(IRepository<CartItem> repository, IUnitOfWork uof, IMapper mapper)
        {
            _mapper = mapper;
            _uof = uof;
            _repository = repository;
        }

        public async Task Add(CartItemDTO cartItemDTO)
        {
            var cartItem = _mapper.Map<CartItem>(cartItemDTO);
            await _repository.Add(cartItem);

            await _uof.CommitAsync();
        }

        public async Task<List<CartItemDTO>> Any(CartItemDTO cartItemDTO)
        {
            var cartItems = await _repository.GetByWhere(c => c.Name == cartItemDTO.Name && c.Total == cartItemDTO.Total && c.Quantity == cartItemDTO.Quantity
            && c.UnitCost == cartItemDTO.UnitCost);

            if (cartItems != null)
            {
                var cartItemDto = _mapper.Map<List<CartItemDTO>>(cartItems);
                return cartItemDto;
            }

            return null;
        }

        public async Task<CartItemDTO> FindById(int Id)
        {
            var cartItem = await _repository.GetById(Id);

            return _mapper.Map<CartItemDTO>(cartItem);
        }

        public async Task<List<CartItemDTO>> Get()
        {
            var cartItems = await _repository.Get();

            return _mapper.Map<List<CartItemDTO>>(cartItems);
        }

        public async Task Remove(int Id)
        {
            var cartItem = await _repository.GetById(Id);
            await _repository.Remove(cartItem);

            await _uof.CommitAsync();
        }

        public async Task Update(CartItemDTO cartItemDTO)
        {
            var cartItem = _mapper.Map<CartItem>(cartItemDTO);
            await _repository.Update(cartItem);

            await _uof.CommitAsync();
        }
    }
}
