using AutoMapper;
using DokanyApp.BLL.DTO;
using DokanyApp.BLL.Entities;
using DokanyApp.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DokanyApp.BLL.Services
{
    public class ImagesProductService: IImagesProductService
    {
        private readonly IRepository<ImageProduct> _imageProductRepository;
        private readonly IMapper _mapper;
        public ImagesProductService(IRepository<ImageProduct> imageProductRepository, IMapper mapper)
        {
            _imageProductRepository = imageProductRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ImageProductDto>> GetImages(int productId) 
        {
                if (productId < 1) throw new ArgumentException("id must be positive int");

            var prodImgs = await _imageProductRepository.Get();
            var prodImg = prodImgs.Where(p => p.ProductId == productId);
            return _mapper.Map<IEnumerable<ImageProductDto>>(prodImg);
        }
    }
}
