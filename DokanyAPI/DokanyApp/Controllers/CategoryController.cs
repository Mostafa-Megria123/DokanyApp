using DokanyApp.BLL;
using DokanyApp.LoggingService;
using DokanyApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DokanyApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;
        private readonly ILoggerManager logger;

        public CategoryController(ICategoryService categoryService,
            ILoggerManager logger)
        {
            this.categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var data = await categoryService.Get();
                if (data == null)
                {
                    return NotFound();
                }
                logger.LogInfo("Retreive all categories.");
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError("Error happens for retreive all categories" + ex.Message);
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> FindById(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            try
            {
                var data = await categoryService.FindById(id);
                logger.LogInfo($"Retreive Category for id {id}");
                if (data == null)
                {
                    return NotFound();
                }
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError($"Error happens for retreive category of {id}" + ex.Message);

                return BadRequest();
            }
        }

        [HttpDelete]
        public async Task<IActionResult> RemovePrdById(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            try
            {
                await categoryService.Remove(id);
                logger.LogInfo($"Category of {id} is deleted");
                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError($"Error happens when remove category {id}");
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("AddCategory")]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryViewModel category)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    await categoryService.Add(new Category { CategoryName = category.Name, Description = category.Description , ImagePath = category.ImagePath});
                    logger.LogInfo("New Category Added");
                    return Ok("Category Was Added Successfully");
                }
                catch (Exception ex)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("UpdateCategory")]
        public async Task<IActionResult> UpdateCatgory([FromBody]CategoryViewModel category)
        {
            if (ModelState.IsValid)
            {
                try
                {
                     await categoryService.Update(new Category { Id = category.Id, CategoryName = category.Name, Description = category.Description, ImagePath = category.ImagePath });
                    return Ok();
                }
                catch (Exception ex)
                {
                    if (ex.GetType().FullName == "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        return NotFound();
                    }
                    return BadRequest();
                }
            }
            return BadRequest();
        }
    }
}
