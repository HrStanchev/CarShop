using CarShop.BL.Interfaces;
using CarShop.DL.Interfaces;
using CarShop.Models.DTO;
using Serilog;
using System.Collections.Generic;
using System.Linq;

namespace CarShop.BL.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;
        private readonly ILogger _logger;

        public CarService(ICarRepository carRepository, ILogger logger)
        {
            _carRepository = carRepository;
            _logger = logger;
        }

        public Car Create(Car car)
        {
            var index = _carRepository.GetAll().OrderByDescending(x => x.Id).FirstOrDefault()?.Id;
            car.Id = (int)(index != null ? index + 1 : 1);
            return _carRepository.Create(car);
        }

        public Car Delete(int id)
        {
            return _carRepository.Delete(id);
        }

        public Car GetById(int id)
        {
            return _carRepository.GetById(id);
        }

        public IEnumerable<Car> GetAll()
        {
            return _carRepository.GetAll();
        }

        public Car Update(Car car)
        {
            return _carRepository.Update(car);
        }
    }
}
