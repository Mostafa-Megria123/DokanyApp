using DokanyApp.BLL;
using DokanyApp.LoggingService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DokanyApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;
        private readonly ILoggerManager logger;

        public OrderController(IOrderService orderService,
            ILoggerManager logger)
        {
            this.orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
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
                var data = await orderService.Get();
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
                var data = await orderService.FindById(id);

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
                await orderService.Remove(id);
                return Ok("Order number " + id + " Removed Successfully");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("AddProduct")]
        public async Task<IActionResult> CreateProduct([FromBody]Order order)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await orderService.Add(order);
                    return Ok("Product Was Added Successfully");
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct([FromBody]Order order)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await orderService.Update(order);
                    return Ok("Product Was Updated Successfully");
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
