using AutoMapper;
using DokanyApp.BLL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DokanyApp.BLL
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<ImageProduct> _imageProductRepository;
        private readonly IUnitOfWork uof;
        private readonly IMapper mapper;

        public ProductService(IRepository<Product> productRepository,
            IRepository<ImageProduct> imageProductRepository,
            IUnitOfWork uof,
            IMapper mapper)
        {
            this._productRepository = productRepository;
            _imageProductRepository = imageProductRepository;
            this.uof = uof;
            this.mapper = mapper;
        }

        public async Task<List<ProductDTO>> Get()
        {
            if (_productRepository != null)
            {
                var prd = await _productRepository.Get();
                var prdDTO = mapper.Map<List<ProductDTO>>(prd);

                return prdDTO;
            }
            return null;
        }

        public async Task<ProductDTO> FindById(int Id)
        {
            if (_productRepository != null)
            {
                if (Id < 1) throw new ArgumentException("id must be positive int");
                var prd = await _productRepository.GetById(Id);
                var prdDTO = mapper.Map<ProductDTO>(prd);

                return prdDTO;
            }
            return null;
        }

        public async Task Remove(int Id)
        {
            if (_productRepository != null)
            {
                if (Id < 1) throw new ArgumentException("id must be positive int");
                var prd = await _productRepository.GetById(Id);
                await _productRepository.Remove(prd);

                await uof.CommitAsync();
            }
        }

        public async Task<int> Add(Product product , string[] imagesUrl = null)
        {
            if (_productRepository != null)
            {
                await _productRepository.Add(product);
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
            if (_productRepository != null)
            {
                await _productRepository.Update(product);
                await uof.CommitAsync();
            }
        }
    }
}

