using AutoRent.DTOs.Car;
using AutoRent.DTOs.Customer;
using AutoRent.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AutoRent.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CarController : ControllerBase
    {
        private readonly ICarService _service;

        public CarController(ICarService service)
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
        public async Task<IActionResult> Create([FromBody] CreateCarDto dto)
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
        public async Task<IActionResult> Edit(string id, [FromBody] CreateCarDto dto)
        {
            var result = await _service.EditAsync(id,dto);
            if (!result) return NotFound();
            return Ok(result);
        }
    }
}
