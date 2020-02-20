using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DokanyApp.BLL
{
    public class OrderService : IOrderService
    {
        private IRepository<Order> orderRepository;
        private IUnitOfWork uof;
        private readonly IMapper mapper;

        public OrderService(IRepository<Order> orderRepository,
            IUnitOfWork uof,
            IMapper mapper)
        {
            this.orderRepository = orderRepository;
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

        public async Task<int> Add(Order order)
        {
            if (orderRepository != null)
            {
                await orderRepository.Add(order);
                await uof.CommitAsync();
                return order.OrderId;
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
    }
}

