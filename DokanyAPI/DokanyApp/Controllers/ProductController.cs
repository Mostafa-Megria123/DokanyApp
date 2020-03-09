﻿using DokanyApp.BLL;
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
        private readonly ILoggerManager logger;

        public ProductController(IProductService productService,
            ILoggerManager logger)
        {
            this.productService = productService ?? throw new ArgumentNullException(nameof(productService));
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var data = await productService.Get();
                if (data == null)
                {
                    return NotFound();
                }
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
            {
                return BadRequest();
            }

            try
            {
                var data = await productService.FindById(id);

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
                        CategoryId = product.Category,
                        Description = product.Description,
                        ProductName = product.Name,
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
                        ProductId = product.Id,
                        BrandName = product.BrandName,
                        CategoryId = product.Category,
                        Description = product.Description,
                        ProductName = product.Name,
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
    }
}
