using DokanyApp.BLL;
using DokanyApp.BLL.Interfaces;
using DokanyApp.LoggingService;
using DokanyApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DokanyApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;
        private readonly IImagesProductService imagesProductService;
        private readonly ILoggerManager logger;

        public ProductController(IProductService productService,
            IImagesProductService imagesProductService,
            ILoggerManager logger)
        {
            this.productService = productService ?? throw new ArgumentNullException(nameof(productService));
            this.imagesProductService = imagesProductService ?? throw new ArgumentNullException(nameof(imagesProductService));
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var data = await productService.Get();
                if (data == null)
                    return NotFound();
                logger.LogInfo("Products are retreived.");
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError($"Some error happen for retreiving products {ex.Message}");
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> FindById(int id)
        {
            if (id == null)
                return BadRequest();

            try
            {
                var data = await productService.FindById(id);
                if (data == null)
                    return NotFound();

                logger.LogInfo($"Product {id} is retreived.");

                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError($"Some error happen for retreiving product {id} : {ex.Message}");
                return BadRequest();
            }
        }

        [HttpDelete]
        public async Task<IActionResult> RemovePrdById(int id)
        {
            if (id == null)
            {
                logger.LogError($"Removed product with {id}");
                return BadRequest();
            }

            try
            {
                await productService.Remove(id);
                logger.LogInfo("Product number " + id + " Removed Successfully");
                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError($"Error happened to remove product {ex.Message}");
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("AddProduct")]
        public async Task<IActionResult> CreateProduct([FromBody]ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await productService.Add(new Product
                    {
                        BrandName = product.BrandName,
                        CategoryId = product.CategoryId,
                        Description = product.Description,
                        Name = product.Name,
                        Quantity = product.Quantity,
                        Price = product.Price,
                        ImageUrl = product.ImagePaths[0],
                        CreationDate = DateTime.Now.ToString(),
                        ProductAppreciate = ProductAppreciateENU.Like
                    } , product.ImagePaths);

                    return Ok();
                }
                catch (Exception ex)
                {
                    logger.LogError($"Error happened to add product {ex.Message}");

                    return BadRequest();
                }
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct([FromBody]ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await productService.Update(new Product
                    {
                        Id = product.Id,
                        BrandName = product.BrandName,
                        CategoryId = product.CategoryId,
                        Description = product.Description,
                        Name = product.Name,
                        Quantity = product.Quantity,
                        Price = product.Price,
                        ImageUrl = product.ImagePaths[0],
                        CreationDate = DateTime.Now.ToString(),
                        ProductAppreciate = ProductAppreciateENU.Like
                    });
                    return Ok();
                }
                catch (Exception ex)
                {
                    if (ex.GetType().FullName == "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        return NotFound();
                    }
                    logger.LogError($"Error happened to update product {ex.Message}");

                    return BadRequest();
                }
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("Images")]
        public async Task<IActionResult> GetImages(int productId) 
        {
            if (productId == null)
            {
                return BadRequest();
            }

            try
            {
                var images = await imagesProductService.GetImages(productId);
                if (images == null)
                    return NotFound();
                logger.LogInfo($"Images for projcet {productId} are retreived.");
                return Ok(images);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
    }
}
