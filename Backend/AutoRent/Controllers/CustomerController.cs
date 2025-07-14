using AutoRent.DTOs.Customer;
using AutoRent.DTOs.Rental;
using AutoRent.Interfaces;
using AutoRent.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AutoRent.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _service;

        public CustomerController(ICustomerService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var rentals = await _service.GetAllAsync();
            return Ok(rentals);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var rental = await _service.GetByIdAsync(id);
            return Ok(rental);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCustomerDto dto)
        {
            try
            {
                var result = await _service.CreateAsync(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _service.DeleteAsync(id);
            if (!result) return NotFound();
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(string id, [FromBody] CreateCustomerDto dto)  
        {
            var result = await _service.EditAsync(id,dto);
            if (!result) return NotFound();
            return Ok(result);
        }

    }
}
