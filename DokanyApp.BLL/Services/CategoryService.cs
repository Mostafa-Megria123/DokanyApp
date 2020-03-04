using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DokanyApp.BLL
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> categoryRepository;
        private IUnitOfWork uof;
        private readonly IMapper mapper;

        public CategoryService(IRepository<Category> categoryRepository,
            IUnitOfWork uof,
            IMapper mapper)
        {
            this.categoryRepository = categoryRepository;
            this.uof = uof;
            this.mapper = mapper;
        }

        public async Task<List<CategoryDTO>> Get()
        {
            if (categoryRepository != null)
            {
                var category = await categoryRepository.Get();
                var categoryDTO = mapper.Map<List<CategoryDTO>>(category);

                return categoryDTO;
            }
            return null;
        }

        public async Task<CategoryDTO> FindById(int Id)
        {
            if (categoryRepository != null)
            {
                if (Id < 1) throw new ArgumentException("id must be positive int");
                var category = await categoryRepository.GetById(Id);
                var categoryDTO = mapper.Map<CategoryDTO>(category);

                return categoryDTO;
            }
            return null;
        }

        public async Task Remove(int Id)
        {
            if (categoryRepository != null)
            {
                if (Id < 1) throw new ArgumentException("id must be positive int");
                var category = await categoryRepository.GetById(Id);
                await categoryRepository.Remove(category);

                await uof.CommitAsync();
            }
        }

        public async Task<int> Add(Category category)
        {
            if (categoryRepository != null)
            {
                await categoryRepository.Add(category);
                await uof.CommitAsync();
                return category.CategoryId;
            }
            return 0;
        }

        public async Task Update(Category category)
        {
            if (categoryRepository != null)
            {
                await categoryRepository.Update(category);
                await uof.CommitAsync();
            }
        }
    }
}

