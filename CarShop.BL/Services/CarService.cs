using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarShop.Models.DTO;
using CarShop.DL.Interfaces;
using CarShop.BL.Interfaces;

namespace CarShop.BL.Services
{
    public class CarService
    {
        private readonly ICarRepository _carRepository;

        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
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
