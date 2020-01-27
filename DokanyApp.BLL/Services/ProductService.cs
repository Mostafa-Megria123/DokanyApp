using AutoMapper;
using DokanyApp.BLL.DTO;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DokanyApp.BLL.Products
{
    public class ProductService : IProductService
    {
        private IRepository<Product> productRepository;
        private IUnitOfWork uof;
        private readonly IMapper mapper;

        public ProductService(IRepository<Product> productRepository,
            IUnitOfWork uof, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.uof = uof;
            this.mapper = mapper;
        }

        public async Task<ProductDTO> Add(Product product)
        {
            productRepository.Add(product);
            await uof.CommitAsync();
            var prdDto = mapper.Map<ProductDTO>(product);

            return prdDto;
        }

        public ProductDTO FindById(int Id)
        {
            if (Id < 1) throw new ArgumentException("id must be positive int");
            var prd = productRepository.Get().FirstOrDefault(p => p.ProductId == Id);
            var prdDTO = mapper.Map<ProductDTO>(prd);

            return prdDTO;
        }

        public IQueryable<ProductDTO> Get()
        {
            var prd = productRepository.Get().FirstOrDefault(); 
            var prdDTO = mapper.Map<IQueryable<ProductDTO>>(prd);

            // use 'yield return prdDTO;' in case of using IEnumerable as a returned value
            return prdDTO;
        }

        public async Task Remove(int Id)
        {
            if (Id < 1) throw new ArgumentException("id must be positive int");
            var prd = productRepository.Get().FirstOrDefault(p => p.ProductId == Id);
            productRepository.Remove(prd);

            await uof.CommitAsync();
        }

        public async Task Update(Product product)
        {
            productRepository.Modify(product);
            await uof.CommitAsync();
        }
    }
}
