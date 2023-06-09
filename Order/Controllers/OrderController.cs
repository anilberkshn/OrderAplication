using System;
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

        [HttpGet("GetById")]
        public IActionResult GetById(Guid guid)
        {
            var findOne = _iService.GetById(guid);
            return Ok(findOne);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var getAll = _iService.GetAllAsync();
            return Ok(getAll);
        }

        [HttpDelete("HardDelete")]
        public IActionResult HardDelete(Guid guid)
        {
            var byId = _iService.GetById(guid);
            _iService.Delete(byId.Id);
            return Ok(guid);
        }

        [HttpPut]
        public IActionResult UpdateDeveloper(Guid guid, [FromBody] UpdateDto updateDto)
        {
            var developer = _iService.GetById(guid);
            _iService.Update(guid, updateDto);
            return Ok(developer);
        }


        [HttpPut("SoftDelete")]
        public IActionResult SoftDelete(Guid guid, [FromBody] SoftDeleteDto softDeleteDto)
        {
            var order = _iService.GetById(guid);
            _iService.SoftDelete(order.Id, softDeleteDto);
            return Ok(guid);
        }
    }
}