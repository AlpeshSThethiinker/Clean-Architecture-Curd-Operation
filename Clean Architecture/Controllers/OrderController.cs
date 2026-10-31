using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Application.DTOs;
using Application.DTOs.OrderFolder;
using Microsoft.VisualBasic;
//using 

namespace CleanArchitecture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orders = await _orderService.GetAllAsync();
            return Ok(orders);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var order = await _orderService.GetByIdAsync(id);
            if(order == null)
            {
                return NotFound(new { message = "order display" });
            }
            return Ok(order);

        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOrderDto dto)
        {
            await _orderService.AddAsync(dto);
            return StatusCode(201, new { message = "Order deliverd" });
        }

        //[HttpPut]
        //public async Task<IActionResult> Update([FromBody] UpdateOrderDto dto)
        //{
        //    await _orderService.UpdateAsync(dto);
        //    return Ok(new
        //    {
        //        message = "order updated"
        //    });
        //}


        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _orderService.DeleteAsync(id);
            return Ok(new
            {
                message = "order deleted"
            });
        }
    }
}
