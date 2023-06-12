using System;
using System.Threading.Tasks;
using Customer.Model.Entities;
using Customer.Model.RequestModels;
using Customer.Model.Response;
using Customer.Services;
using Microsoft.AspNetCore.Mvc;

namespace Customer.Controllers
{
    
    [ApiController]
    [Route("api/customer")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        public async Task<IActionResult>CreateAsync([FromBody] CreateDto createDto)
        {
            var customer = new Model.Entities.CustomerModel()
            {
                Name = createDto.Name,
                Email = createDto.Email,
                Address = createDto.Address,
            };

           await _customerService.InsertAsync(customer);

            var response = new CreateResponse()
            {
                Id = customer.Id
            };
            return Ok(response);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var findOne = await _customerService.GetByIdAsync(id);
            return Ok(findOne);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            var getAll = await _customerService.GetAllAsync();
            return Ok(getAll);
        }

        [HttpDelete("HardDelete")]
        public async Task <IActionResult> HardDeleteAsync(Guid id)
        {
            var byId = await _customerService.GetByIdAsync(id);
            _customerService.Delete(byId.Id);
            return Ok(id);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] UpdateDto updateDto)
        {
            var customer = await _customerService.GetByIdAsync(id);
            _customerService.Update(id, updateDto);
            return Ok(customer);
        }


        [HttpPut("SoftDelete")]
        public async Task<IActionResult> SoftDeleteAsync(Guid id, [FromBody] SoftDeleteDto softDeleteDto)
        {
            var order = await _customerService.GetByIdAsync(id);
            _customerService.SoftDelete(order.Id, softDeleteDto);
            return Ok(id);
        }
    }
}