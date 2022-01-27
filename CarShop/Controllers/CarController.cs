using AutoMapper;
using CarShop.BL.Interfaces;
using CarShop.Models.DTO;
using CarShop.Models.Requests;
using CarShop.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CarShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;
        private readonly IMapper _mapper;

        public CarController(ICarService carService, IMapper mapper)
        {
            _carService = carService;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _carService.GetAll();

            return Ok(result);
        }
        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            if (id <= 0) return BadRequest();

            var result = _carService.GetById(id);
            if (result == null) return NotFound();

            var response = _mapper.Map<CarResponse>(result);

            return Ok(response);
        }

        [HttpPost("Create")]
        public IActionResult CreateCar([FromBody] CarRequest carRequest)
        {
            if (carRequest == null) return BadRequest();

            var car = _mapper.Map<Car>(carRequest);
            var result = _carService.Create(car);

            return Ok(car);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (id < 0) return BadRequest();

            var result = _carService.Delete(id);

            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpPost("Update")]
        public IActionResult Update([FromBody] CarUpdateRequest carRequest)
        {
            if (carRequest == null) return BadRequest();

            var searchCar = _carService.GetById(carRequest.Id);
            if (searchCar == null) return NotFound(carRequest.Id);

            searchCar.Make = carRequest.Make;
            searchCar.Model = carRequest.Model;
            var result = _carService.Update(searchCar);

            return Ok(result);
        }



    }
}
