using System;
using System.Threading.Tasks;
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

        [HttpGet("GetByIdAsync")]
        public async Task<IActionResult> GetByIdAsync(Guid guid)
        {
            var findOne = await _iService.GetByIdAsync(guid);
            return Ok(findOne);
        }

        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            var getAll = await _iService.GetAllAsync();
            return Ok(getAll);
        }

        [HttpDelete("HardDelete")]
        public async Task <IActionResult> HardDelete(Guid guid)
        {
            var byId = await _iService.GetByIdAsync(guid);
            _iService.Delete(byId.Id);
            return Ok(guid);
        }

        [HttpPut]
        public IActionResult Update(Guid guid, [FromBody] UpdateDto updateDto)
        {
            var customer = _iService.GetByIdAsync(guid);
            _iService.Update(guid, updateDto);
            return Ok(customer);
        }


        [HttpPut("SoftDelete")]
        public async Task<IActionResult> SoftDelete(Guid guid, [FromBody] SoftDeleteDto softDeleteDto)
        {
            var order = await _iService.GetByIdAsync(guid);
            _iService.SoftDelete(order.Id, softDeleteDto);
            return Ok(guid);
        }
    }
}