using AutoRent.DTOs.Rental;
using AutoRent.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;

namespace AutoRent.Controllers
{

    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class RentalController : ControllerBase
    {
        private readonly IRentalService _rentalService;

        public RentalController(IRentalService rendalService)
        {
            _rentalService = rendalService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var rentals = await _rentalService.GetAllAsync();
            return Ok(rentals);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var rental = await _rentalService.GetByIdAsync(id);
            return Ok(rental);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateRentalDto dto)
        {
            try
            {
                var result = await _rentalService.CreateAsync(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ReturnRental(string id, [FromBody] ReturnRentalDto dto)
        {
            try
            {
                var result = await _rentalService.ReturnRentalAsync(id, dto);
                if (!result) return NotFound();
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
            var result = await _rentalService.DeleteAsync(id);
            if (!result) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        [Route("{id}/checkOut")]
        public async Task<IActionResult> CheckOut(string id, [FromBody] requestRentalCheckOut dto )
        {
            var result = await _rentalService.CheckOut(id, dto);
            return Ok(result);
        }
    }
}
