using AutoMapper;
using DokanyApp.BLL.DTO;
using DokanyApp.BLL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DokanyApp.BLL.Services
{
    public class ShippingAddressService: IShippingAddressService
    {
        private readonly IRepository<ShippingAddress> _shippingAddressRepository;
        private readonly IUnitOfWork _uof;
        private readonly IMapper _mapper;
        public ShippingAddressService(IRepository<ShippingAddress> shippingAddressRepository, IUnitOfWork uof , IMapper mapper)
        {
            _shippingAddressRepository = shippingAddressRepository;
            _uof = uof;
            _mapper = mapper;
        }

        public async Task Add(ShippingAddressDto shippingAddress)
        {
            var _shippingAddress = _mapper.Map<ShippingAddress>(shippingAddress);
            await _shippingAddressRepository.Add(_shippingAddress);

            await _uof.CommitAsync();
        }

        public async Task<ShippingAddressDto> Any(ShippingAddressDto shippingAddress)
        {
            var _shippingAddressse = await Get();
            var _shippingAddress = _shippingAddressse.FirstOrDefault(s => s.FirstName == shippingAddress.FirstName & s.LastName == shippingAddress.LastName 
            && s.City == shippingAddress.City && s.ZipCode == shippingAddress.ZipCode && s.PhoneNumber == shippingAddress.PhoneNumber);

            if (_shippingAddress != null)
                return _shippingAddress;

            return null;
        }

        public async Task<ShippingAddressDto> FindById(int Id)
        {
            var _shippingAddress = await _shippingAddressRepository.GetById(Id);
            return _mapper.Map<ShippingAddressDto>(_shippingAddress);
        }

        public async Task<List<ShippingAddressDto>> Get()
        {
            var _shippingAddresss = await _shippingAddressRepository.Get();
            return _mapper.Map<List<ShippingAddressDto>>(_shippingAddresss);
        }

        public async Task Remove(int Id)
        {
            var _sh = await _shippingAddressRepository.GetById(Id);
            await _shippingAddressRepository.Remove(_sh);

            await _uof.CommitAsync();
        }

        public async Task Update(ShippingAddressDto shippingAddress)
        {
            var _shippingAddress = _mapper.Map<ShippingAddress>(shippingAddress);
            await _shippingAddressRepository.Update(_shippingAddress);

            await _uof.CommitAsync();
        }
    }
}
