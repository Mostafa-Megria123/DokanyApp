using AutoMapper;
using DokanyApp.BLL;
using DokanyApp.BLL.DTO;
using DokanyApp.LoggingService;
using DokanyApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DokanyApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public OrderController(
            IOrderService orderService,
            ILoggerManager logger,
            IMapper mapper)
        {
            _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var data = await _orderService.Get();
                if (data == null)
                {
                    _logger.LogWarn("Order data not found");
                    return NotFound();
                }
                _logger.LogInfo("Order data retreived");
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError($"error happens while order data retreived: {ex.Message}");
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> FindById(int id)
        {

            if (id <= 0)
                return BadRequest();

            try
            {
                var data = await _orderService.FindById(id);
                if (data == null)
                    return NotFound();

                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError($"error happens while order: {id} , retreived: {ex.Message}");
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemovePrdById(int id)
        {
            if (id <= 0)
            {
                _logger.LogError($"order id is wrong {id}");
                return BadRequest();
            }

            try
            {
                await _orderService.Remove(id);
                _logger.LogInfo($"Order id: {id} is removed");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"error happens while order: {id} , removed: {ex.Message}");
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody]OrderViewModel orderViewModel)
        {
            if (ModelState.IsValid)
            {
                var orderCreationDto = _mapper.Map<OrderCreationDto>(orderViewModel);
                var orderAdded = await _orderService.Add(orderCreationDto);

                if (orderAdded)
                {
                    _logger.LogInfo("new order added");
                    return Ok();
                }
                else
                    return StatusCode(500);
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrder([FromBody]OrderDTO order)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _orderService.Update(order);
                    _logger.LogInfo("Order Was Updated Successfully");
                    return Ok();
                }
                catch (Exception ex)
                {
                    if (ex.GetType().FullName == "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        return NotFound();
                    }
                    _logger.LogError($"error happens while order: {order.Id} updated: {ex.Message}");
                    return BadRequest();
                }
            }
            return BadRequest();
        }

    }
}
