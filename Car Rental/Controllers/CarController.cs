using CarRental.Dto;
using CarRental.Services.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace Car_Rental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarDTO>>> GetAll()
        {
            var cars = await _carService.GetAllAsync();
            return Ok(cars);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CarDTO>> GetById(int id)
        {
            var car = await _carService.GetByIdAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            return Ok(car);
        }

        [HttpPost]
        public async Task<ActionResult<CarDTO>> Create(CarDTO carDto)
        {
            var createdCar = await _carService.CreateAsync(carDto);
            return CreatedAtAction(nameof(GetById), new { id = createdCar.Id }, createdCar);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CarDTO carDto)
        {
            if (id != carDto.Id)
            {
                return BadRequest();
            }

            var updatedCar = await _carService.UpdateAsync(id, carDto);
            if (updatedCar == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _carService.DeleteAsync(id);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
