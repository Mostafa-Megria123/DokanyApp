using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DokanyApp.BLL.Services
{
    public class TraderService : ITraderService
    {
        private readonly IRepository<User> traderRepository;
        private readonly IUnitOfWork uof;
        public TraderService(IRepository<User> traderRepository,
            IUnitOfWork uof)
        {
            this.traderRepository = traderRepository; //Entities
            this.uof = uof;
        }

        public Task Add(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> FindById(int Id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<User> Get()
        {
            throw new NotImplementedException();
        }

        public Task Remove(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
