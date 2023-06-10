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
    [Route("api/order")]
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
                Status = createDto.Status,
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

        [HttpGet("{id}")] //TODO: Deneme için değiştirildi.
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var findOne = await _orderService.GetByIdAsync(id);
            return Ok(findOne);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            var getAll =  await _orderService.GetAllAsync();
            return Ok(getAll);
        }

        [HttpDelete("HardDelete")]
        public async Task<IActionResult> HardDeleteAsync(Guid guid)
        {
            var byId = await _orderService.GetByIdAsync(guid);
            _orderService.Delete(byId.Id);
            return Ok(guid);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDeveloperAsync(Guid guid, [FromBody] UpdateDto updateDto)
        {
            var order = await _orderService.GetByIdAsync(guid);
            _orderService.Update(guid, updateDto);
            return Ok(order);
        }

        [HttpPut("SoftDelete")]
        public async Task<IActionResult>SoftDeleteAsync(Guid guid, [FromBody] SoftDeleteDto softDeleteDto)
        {
            var order = await _orderService.GetByIdAsync(guid);
            _orderService.SoftDelete(order.Id, softDeleteDto);
            return Ok(guid);
        }
    }
}