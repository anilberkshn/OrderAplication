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
            var customer = new CustomerModel()
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
        public async Task<IActionResult> GetByIdAsync(Guid guid)
        {
            var findOne = await _customerService.GetByIdAsync(guid);
            return Ok(findOne);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            var getAll = await _customerService.GetAllAsync();
            return Ok(getAll);
        }

        [HttpDelete("HardDelete")]
        public async Task <IActionResult> HardDeleteAsync(Guid guid)
        {
            var byId = await _customerService.GetByIdAsync(guid);
            _customerService.Delete(byId.Id);
            return Ok(guid);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(Guid guid, [FromBody] UpdateDto updateDto)
        {
            var customer = await _customerService.GetByIdAsync(guid);
            _customerService.Update(guid, updateDto);
            return Ok(customer);
        }


        [HttpPut("SoftDelete")]
        public async Task<IActionResult> SoftDeleteAsync(Guid guid, [FromBody] SoftDeleteDto softDeleteDto)
        {
            var order = await _customerService.GetByIdAsync(guid);
            _customerService.SoftDelete(order.Id, softDeleteDto);
            return Ok(guid);
        }
    }
}