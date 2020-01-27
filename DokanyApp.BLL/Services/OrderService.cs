using System.Linq;
using System.Threading.Tasks;

namespace DokanyApp.BLL
{

    class OrderService : IOrderService
    {
        private readonly IRepository<Order> orderRepository;
        private readonly IUnitOfWork uof;

        public OrderService(IRepository<Order> orderRepository,
            IUnitOfWork uof)
        {
            this.orderRepository = orderRepository;
            this.uof = uof;
        }

        public IRepository<Order> OrderRepository { get; }

        public Task Add(Order order)
        {
            throw new System.NotImplementedException();
        }

        public Task<Order> FindById(int Id)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<Order> Get()
        {
            throw new System.NotImplementedException();
        }

        public Task Remove(int Id)
        {
            throw new System.NotImplementedException();
        }

        public Task Update(Order order)
        {
            throw new System.NotImplementedException();
        }
    }
}
