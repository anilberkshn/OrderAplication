using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OrderCase.Model;
using OrderCase.Model.Entities;
using OrderCase.Model.RequestModels;
using OrderCase.Services;

namespace OrderCase.Controllers
{
    
    [ApiController]
    [Route("api/orders")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateDto createDto)
        {
            var order = new OrderModel()
            {
                CustomerId = createDto.CustomerId,
                Quantity = createDto.Quantity,
                Price = createDto.Price,
                Address = createDto.Address,
                Product = createDto.Product
            };

            await _orderService.InsertAsync(order);

            var response = new CreateResponse()
            {
                Id = order.Id
            };
            return Ok(response);
        }

        [HttpGet("GetById")] 
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var findOne = await _orderService.GetByIdAsync(id);
            return Ok(findOne);
        }

        [HttpGet("GetAll")]
        // [Microsoft.AspNetCore.Mvc.HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var getAll =  await _orderService.GetAllAsync();
            return Ok(getAll);
        }

        [HttpDelete("HardDelete")]
        public async Task<IActionResult> HardDeleteAsync(Guid id)
        {
            var byId = await _orderService.GetByIdAsync(id);
            _orderService.Delete(byId.Id);
            return Ok(id);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDeveloperAsync(Guid id, [FromBody] UpdateDto updateDto)
        {
            var order = await _orderService.GetByIdAsync(id);
            _orderService.Update(id, updateDto);
            return Ok(order);
        }

        [HttpPut("SoftDelete")]
        public async Task<IActionResult>SoftDeleteAsync(Guid id, [FromBody] SoftDeleteDto softDeleteDto)
        {
            var order = await _orderService.GetByIdAsync(id);
            _orderService.SoftDelete(order.Id, softDeleteDto);
            return Ok(id);
        }
    }
}