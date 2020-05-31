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
        private readonly IRepository<Order> _orderRepository;
        private readonly IShippingAddressService _shippingAddressService;
        private readonly ICreditCardService _creditCardService;
        private readonly ICartItemService _cartItemService;
        private readonly ITransaction _transaction;
        private readonly IUnitOfWork uof;
        private readonly IMapper mapper;

        public OrderService(IRepository<Order> orderRepository,
            IShippingAddressService shippingAddressService,
            ICreditCardService creditCardService,
            ICartItemService cartItemService,
            ITransaction transaction,
            IUnitOfWork uof,
            IMapper mapper)
        {
            _orderRepository = orderRepository;
            _shippingAddressService = shippingAddressService;
            _creditCardService = creditCardService;
            _cartItemService = cartItemService;
            _transaction = transaction;
            this.uof = uof;
            this.mapper = mapper;
        }

        public async Task<List<OrderDTO>> Get()
        {
            if (_orderRepository != null)
            {
                var order = await _orderRepository.Get();
                var orderDTO = mapper.Map<List<OrderDTO>>(order);

                return orderDTO;
            }
            return null;
        }

        public async Task<OrderDTO> FindById(int Id)
        {
            if (_orderRepository != null)
            {
                if (Id < 1) throw new ArgumentException("id must be positive int");
                var order = await _orderRepository.GetById(Id);
                var orderDTO = mapper.Map<OrderDTO>(order);

                return orderDTO;
            }
            return null;
        }

        public async Task Remove(int Id)
        {
            if (_orderRepository != null)
            {
                if (Id < 1) throw new ArgumentException("id must be positive int");
                var order = await _orderRepository.GetById(Id);
                await _orderRepository.Remove(order);

                await uof.CommitAsync();
            }
        }

        public async Task<bool> Add(OrderCreationDto order)
        {
            if (_orderRepository != null)
            {
                try
                {
                    _transaction.BeginTransaction();
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
                    var cardItems = await _cartItemService.Any(order.CartItemDTO);
                    if (!cardItems.Any())
                    {
                        await _cartItemService.Add(order.CartItemDTO);
                        cardItems = await _cartItemService.Any(order.CartItemDTO);
                    }
                    //register order
                    var newOrder = new Order
                    {
                        CreationDate = DateTime.Now,
                        ShippingDate = DateTime.Now,
                        Description = order.Description,
                        ShippingCost = order.ShippingCost,
                        UserId = order.UserId,
                        PaymentMethod = order.PaymentMethodType,
                        Total = order.TotalCost,
                        CartItemId = cardItems[0].Id,
                        ShippingAddressId = shippingAddress.Id,
                        CreditCardId = creditCard.Id,
                        OrderingStatus = OrderStatusENU.New
                    };
                    await _orderRepository.Add(newOrder);

                    await uof.CommitAsync();

                    _transaction.Commit();
                }
                catch (Exception ex)
                {
                    _transaction.RollBack();

                    return false;
                }

            }
            return true;
        }

        public async Task Update(OrderDTO order)
        {
            if (_orderRepository != null)
            {
                var updatedOrder = mapper.Map<Order>(order);
                await _orderRepository.Update(updatedOrder);
                await uof.CommitAsync();
            }
        }

        public async Task<List<OrderDTO>> FindByUser(int userId)
        {
            if (_orderRepository != null)
            {
                if (userId < 1) throw new ArgumentException("id must be positive int");
                var ordersRepo = await _orderRepository.Get();
                var _orders = ordersRepo.Where(o => o.UserId == userId);
                var orderDTO = mapper.Map<List<OrderDTO>>(_orders);

                return orderDTO;
            }
            return null;
        }

    }
}

