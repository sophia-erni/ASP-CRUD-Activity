using ASP_CRUD_Activity.Domain.Contract;
using ASP_CRUD_Activity.Domain.Entities;
using ASP_CRUD_Activity.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ASP_CRUD_Activity.Controllers
{
    [ApiController]
    [Route("api/")]
    public class CarController : ControllerBase
    {
        private readonly IBaseRepository<Car> _carRepository;
        private readonly IMapper _mapper;

        public CarController(IBaseRepository<Car> carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        [HttpGet("cars")]
        public async Task<IActionResult> GetCars()
        {
            var cars = await _carRepository.GetAll();
            var carDtos = _mapper.Map<List<GetCarDto>>(cars);
            return Ok(carDtos);
        }

        [HttpGet("cars/{id}")]
        public async Task<IActionResult> GetCar(Guid id)
        {
            var car = await _carRepository.Get(id);
            if (car == null)
            {
                return NotFound();
            }
            var carDto = _mapper.Map<GetCarDto>(car);
            return Ok(carDto);
        }

        [HttpPost("cars")]
        public async Task<IActionResult> CreateCar([FromBody] CreateCar createCar)
        {
            var car = _mapper.Map<Car>(createCar);
            var createdCar = await _carRepository.Add(car);
            var carDto  = _mapper.Map<GetCarDto>(createdCar);
            return CreatedAtAction(nameof(GetCar), new { id = carDto.Id }, carDto);
        }

        [HttpPut("cars/{id}")]
        public async Task<IActionResult> UpdateCar(Guid id, [FromBody] UpdateCar updateCar)
        {
            var car = await _carRepository.Get(id);
            if (car == null)
            {
                return NotFound();
            }
            _mapper.Map(updateCar, car);
            var updatedCar = await _carRepository.Update(car);
            var carDto = _mapper.Map<GetCarDto>(updatedCar);
            return Ok(carDto);
        }
        [HttpDelete("car/{id}")]
        public async Task<IActionResult> DeleteCar(Guid id)
        {
            var car = await _carRepository.Delete(id);
            if (car == null)
            { return NotFound(); }
            var carDto = _mapper.Map<GetCarDto>(car);
            return Ok(carDto);
        }
        
    }
}
