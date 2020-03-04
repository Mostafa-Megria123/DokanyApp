using AutoMapper;
using DokanyApp.BLL.DTO;
using DokanyApp.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DokanyApp.BLL
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> orderRepository;
        private readonly IShippingAddressService _shippingAddressService;
        private readonly ICreditCardService _creditCardService;
        private readonly ICartItemService _cartItemService;
        private readonly IUnitOfWork uof;
        private readonly IMapper mapper;

        public OrderService(IRepository<Order> orderRepository,
            IShippingAddressService shippingAddressService,
            ICreditCardService creditCardService,
            ICartItemService cartItemService,
            IUnitOfWork uof,
            IMapper mapper)
        {
            this.orderRepository = orderRepository;
            _shippingAddressService = shippingAddressService;
            _creditCardService = creditCardService;
            _cartItemService = cartItemService;
            this.uof = uof;
            this.mapper = mapper;
        }

        public async Task<List<OrderDTO>> Get()
        {
            if (orderRepository != null)
            {
                var order = await orderRepository.Get();
                var orderDTO = mapper.Map<List<OrderDTO>>(order);

                return orderDTO;
            }
            return null;
        }

        public async Task<OrderDTO> FindById(int Id)
        {
            if (orderRepository != null)
            {
                if (Id < 1) throw new ArgumentException("id must be positive int");
                var order = await orderRepository.GetById(Id);
                var orderDTO = mapper.Map<OrderDTO>(order);

                return orderDTO;
            }
            return null;
        }

        public async Task Remove(int Id)
        {
            if (orderRepository != null)
            {
                if (Id < 1) throw new ArgumentException("id must be positive int");
                var order = await orderRepository.GetById(Id);
                await orderRepository.Remove(order);

                await uof.CommitAsync();
            }
        }

        public async Task<int> Add(OrderCreationDto order)
        {
            if (orderRepository != null)
            {
                // register shipping address and get it.
                var shippingAddress = await _shippingAddressService.Any(order.ShippingAddressDto);
                if (shippingAddress == null)
                {
                    await _shippingAddressService.Add(order.ShippingAddressDto);
                    shippingAddress = await _shippingAddressService.Any(order.ShippingAddressDto);
                }

                //register creditcard and get it.
                var creditCard = await _creditCardService.Any(order.CreditCardDto);
                if (creditCard == null)
                {
                    await _creditCardService.Add(order.CreditCardDto);
                    creditCard = await _creditCardService.Any(order.CreditCardDto);
                }

                //register cardItem
                var cardItem = await _cartItemService.Any(order.CartItemDTO);
                if (cardItem == null)
                {
                    await _cartItemService.Add(order.CartItemDTO);
                    cardItem = await _cartItemService.Any(order.CartItemDTO);
                }
                //register order
                var newOrder = new Order 
                {
                    CreationDate = order.CreationDate,
                    Description = order.Description,
                    ShippingCost = order.ShippingCost,
                    CustomerId = order.UserId,
                    PaymentMethod = order.PaymentMethodType,
                    Total = order.TotalCost,
                    CartItemIId = cardItem.CartItemId,
                    ShippingId = shippingAddress.Id,
                    CreditCardId = creditCard.Id
                };
                await orderRepository.Add(newOrder);

                await uof.CommitAsync();
                
            }
            return 0;
        }

        public async Task Update(Order order)
        {
            if (orderRepository != null)
            {
                await orderRepository.Update(order);
                await uof.CommitAsync();
            }
        }

        public async Task<List<OrderDTO>> FindByUser(int userId)
        {
            if (orderRepository != null)
            {
                if (userId < 1) throw new ArgumentException("id must be positive int");
                var ordersRepo = await orderRepository.Get();
                var _orders = ordersRepo.Where(o => o.CustomerId == userId);
                var orderDTO = mapper.Map<List<OrderDTO>>(_orders);

                return orderDTO;
            }
            return null;
        }
    }
}

