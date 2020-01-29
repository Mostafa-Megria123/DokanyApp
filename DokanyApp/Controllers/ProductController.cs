using DokanyApp.BLL;
using DokanyApp.LoggingService;
using Microsoft.AspNetCore.Mvc;
using System;

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

        [HttpGet("Products")]
        public IActionResult Get()
        {
            logger.LogInfo("Here is info message from the Eslaaaam.");
            var data = productService.FindById(1);
            logger.LogDebug("Here is debug message from the Megria.");
            logger.LogError("Here is debug message from the Dola.");

            return Ok(data);
        }
    }
}