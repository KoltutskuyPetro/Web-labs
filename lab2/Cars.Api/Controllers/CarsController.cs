using AutoMapper;
using Cars.Api.Repositories;
using Microsoft.AspNetCore.Mvc;
using Cars.Api.Models.DTO;
using Cars.Api.Models.Domain;

namespace Cars.Api.Controllers
{
    [Route("api/[controller]")]
    public class CarsController : Controller
    {
        private readonly ICarRepository carRepository;
        private readonly IMapper mapper;

        public CarsController(ICarRepository carRepository, IMapper mapper)
        {
            this.carRepository = carRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var carsDomain = await carRepository.GetAllAsync();

            return Ok(mapper.Map<List<CarDto>>(carsDomain));
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var carDomain = await carRepository.GetByIdAsync(id);

            if (carDomain == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<CarDto>(carDomain));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddCarRequestDto addCarRequestDto)
        {
            var carDomainModel = mapper.Map<Car>(addCarRequestDto);

            carDomainModel = await carRepository.CreateAsync(carDomainModel);

            var carDto = mapper.Map<CarDto>(carDomainModel);

            return CreatedAtAction(nameof(GetById), new { id = carDto.Id }, carDto);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateCarRequestDto updateCarRequestDto)
        {
            var carDomainModel = mapper.Map<Car>(updateCarRequestDto);

            carDomainModel = await carRepository.UpdateAsync(id, carDomainModel);

            if (carDomainModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<CarDto>(carDomainModel));
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var carDomainModel = await carRepository.DeleteAsync(id);

            if (carDomainModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<CarDto>(carDomainModel));
        }
    }
}

