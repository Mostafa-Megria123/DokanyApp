using AutoMapper;
using DokanyApp.BLL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DokanyApp.BLL
{
    public class ProductService : IProductService
    {
        private IRepository<Product> productRepository;
        private IRepository<ImageProduct> _imageProductRepository;
        private IUnitOfWork uof;
        private readonly IMapper mapper;

        public ProductService(IRepository<Product> productRepository,
            IRepository<ImageProduct> imageProductRepository,
            IUnitOfWork uof,
            IMapper mapper)
        {
            this.productRepository = productRepository;
            _imageProductRepository = imageProductRepository;
            this.uof = uof;
            this.mapper = mapper;
        }

        public async Task<List<ProductDTO>> Get()
        {
            if (productRepository != null)
            {
                var prd = await productRepository.Get();
                var prdDTO = mapper.Map<List<ProductDTO>>(prd);

                return prdDTO;
            }
            return null;
        }

        public async Task<ProductDTO> FindById(int Id)
        {
            if (productRepository != null)
            {
                if (Id < 1) throw new ArgumentException("id must be positive int");
                var prd = await productRepository.GetById(Id);
                var prdDTO = mapper.Map<ProductDTO>(prd);

                return prdDTO;
            }
            return null;
        }

        public async Task Remove(int Id)
        {
            if (productRepository != null)
            {
                if (Id < 1) throw new ArgumentException("id must be positive int");
                var prd = await productRepository.GetById(Id);
                await productRepository.Remove(prd);

                await uof.CommitAsync();
            }
        }

        public async Task<int> Add(Product product , string[] imagesUrl = null)
        {
            if (productRepository != null)
            {
                await productRepository.Add(product);
                if (imagesUrl != null)
                    foreach (var imagePath in imagesUrl)
                    {
                        _imageProductRepository.Add(new ImageProduct { ImagePath = imagePath, ProductId = product.Id });
                    }
                await uof.CommitAsync();
                return product.Id;
            }
            return 0;
        }

        public async Task Update(Product product)
        {
            if (productRepository != null)
            {
                await productRepository.Update(product);
                await uof.CommitAsync();
            }
        }
    }
}

