using DokanyApp.BLL;
using DokanyApp.LoggingService;
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
            logger.LogInfo("Here is info message from the Eslaaaam.");
            logger.LogDebug("Here is debug message from the Megria.");
            logger.LogError("Here is debug message from the Dola.");

            try
            {
                var data = await categoryService.Get();
                if (data == null)
                {
                    return NotFound();
                }
                return Ok(data);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> FindById(int id)
        {
            logger.LogInfo("Here is info message from the Eslaaaam.");
            logger.LogError("Here is debug message from the Dola.");

#pragma warning disable CS0472 // The result of the expression is always the same since a value of this type is never equal to 'null'
            if (id == null)
#pragma warning restore CS0472 // The result of the expression is always the same since a value of this type is never equal to 'null'
            {
                return BadRequest();
            }

            try
            {
                var data = await categoryService.FindById(id);

                if (data == null)
                {
                    return NotFound();
                }
                return Ok(data);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        public async Task<IActionResult> RemovePrdById(int id)
        {
#pragma warning disable CS0472 // The result of the expression is always the same since a value of this type is never equal to 'null'
            if (id == null)
#pragma warning restore CS0472 // The result of the expression is always the same since a value of this type is never equal to 'null'
            {
                return BadRequest();
            }

            try
            {
                await categoryService.Remove(id);
                return Ok("Category number " + id + " Removed Successfully");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("AddCategory")]
        public async Task<IActionResult> CreateCategory([FromBody]Category category)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await categoryService.Add(category);
                    return Ok("Category Was Added Successfully");
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("UpdateCategory")]
        public async Task<IActionResult> UpdateCatgory([FromBody]Category category)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await categoryService.Update(category);
                    return Ok("Category Was Updated Successfully");
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
