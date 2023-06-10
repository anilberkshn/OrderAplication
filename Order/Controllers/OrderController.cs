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
        private readonly IService _iService;

        public OrderController(IService iService)
        {
            _iService = iService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateDto createDto)
        {
            var order = new Order()
            {
                CustomerId = createDto.CustomerId,
                Quantity = createDto.Quantity,
                Price = createDto.Price,
                Status = createDto.Status,
                Address = createDto.Address,
                Product = createDto.Product
            };

            _iService.InsertAsync(order);

            var response = new CreateResponse()
            {
                Id = order.Id
            };
            return Ok(response);
        }

        [HttpGet("GetByIdAsync")]
        public async Task<IActionResult> GetByIdAsync(Guid guid)
        {
            var findOne = await _iService.GetByIdAsync(guid);
            return Ok(findOne);
        }

        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            var getAll =  await _iService.GetAllAsync();
            return Ok(getAll);
        }

        [HttpDelete("HardDelete")]
        public async Task< IActionResult> HardDelete(Guid guid)
        {
            var byId = await _iService.GetByIdAsync(guid);
            _iService.Delete(byId.Id);
            return Ok(guid);
        }

        [HttpPut]
        public IActionResult UpdateDeveloper(Guid guid, [FromBody] UpdateDto updateDto)
        {
            var order = _iService.GetByIdAsync(guid);
            _iService.Update(guid, updateDto);
            return Ok(order);
        }


        [HttpPut("SoftDelete")]
        public async Task<IActionResult>SoftDelete(Guid guid, [FromBody] SoftDeleteDto softDeleteDto)
        {
            var order = await _iService.GetByIdAsync(guid);
            _iService.SoftDelete(order.Id, softDeleteDto);
            return Ok(guid);
        }
    }
}