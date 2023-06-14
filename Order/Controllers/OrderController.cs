using System;
using System.Net;
using System.Threading.Tasks;
using Core.Model.ErrorModels;
using Core.Model.RequestModel;
using Microsoft.AspNetCore.Mvc;
using OrderCase.HttpClient;
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
        public OrderController(IOrderService orderService, IOrderHttpClient orderHttpClient)
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
                Product = createDto.Product
            };

            await _orderService.InsertAsync(order);

            var response = new CreateResponse()
            {
                Id = order.Id
            };
            return Ok(response);
        }

        [HttpGet("{id}")] 
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var findOne = await _orderService.GetByIdAsync(id);
            return Ok(findOne);
        }
        
        [HttpGet("http/{id}")] 
        public async Task<IActionResult> GetHttpClient(Guid id)
        {
            var findOne = await _orderService.GetByIdAsync(id);
            return Ok(findOne);
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetAllAsync()
        {
            var getAll =  await _orderService.GetAllAsync();
            return Ok(getAll);
        }
        

        [HttpGet("AllWithSkipTake")]
        public async Task<IActionResult> GetAllSkipTakeAsync([FromQuery]GetAllDto getAllDto)
        {
            var getAll = await _orderService.GetAllSkipTakeAsync(getAllDto);
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
            return Ok( await _orderService.Update(id, updateDto));
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