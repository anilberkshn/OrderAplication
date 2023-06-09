using System;
using Customer.Model.RequestModels;
using Customer.Model.Response;
using Customer.Services;
using Microsoft.AspNetCore.Mvc;

namespace Customer.Controllers
{
    
    [ApiController]
    [Route("api/customers")]
    public class CustomerController : ControllerBase
    {
        private readonly IService _iService;

        public CustomerController(IService iService)
        {
            _iService = iService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateDto createDto)
        {
            var customer = new global::Customer.Model.Entities.Customer()
            {
                Name = createDto.Name,
                Email = createDto.Email,
                Address = createDto.Address,
               
            };

            _iService.InsertAsync(customer);

            var response = new CreateResponse()
            {
                Id = customer.Id
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
            var customer = _iService.GetById(guid);
            _iService.Update(guid, updateDto);
            return Ok(customer);
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