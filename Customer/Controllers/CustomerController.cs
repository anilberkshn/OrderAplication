using System;
using System.Threading.Tasks;
using Core.Model.RequestModel;
using Customer.Model.Entities;
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var findOne = await _customerService.GetByIdAsync(id);
            return Ok(findOne);
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetAllAsync()
        {
            var getAll = await _customerService.GetAllAsync();
            return Ok(getAll);
        } 
        
        [HttpGet("AllWithSkipTake")]
        public async Task<IActionResult> GetAllSkipTakeAsync([FromQuery]GetAllDto getAllDto)
        {
            var getAll = await _customerService.GetAllSkipTakeAsync(getAllDto);
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
           return Ok(await _customerService.Update(id, updateDto));
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