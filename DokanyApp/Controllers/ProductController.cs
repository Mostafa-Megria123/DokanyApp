using DokanyApp.BLL;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DokanyApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;
        public ProductController(IProductService productService)
        {
            this.productService = productService ?? throw new ArgumentNullException(nameof(productService));
        }

        [HttpGet("Products")]
        public IActionResult Get()
        {
            var data = productService.Get();
            return Ok(data);
        }
    }
}