using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarShop.Models.DTO;
using CarShop.DL.InMemoryDb;
using CarShop.DL.Interfaces;

namespace CarShop.DL.Repositories
{
    public class CarInMemoryRepository : ICarRepository
    {
        public CarInMemoryRepository()
        { }

        public Car Create(Car car)
        {
            CarInMemoryCollection.CarDb.Add(car);

            return car;
        }

        public Car Delete(int id)
        {
            var car = CarInMemoryCollection.CarDb.FirstOrDefault(car => car.Id == id);

            CarInMemoryCollection.CarDb.Remove(car);

            return car;
        }

        public IEnumerable<Car> GetAll()
        {
            return CarInMemoryCollection.CarDb;
        }

        public Car GetById(int id)
        {
            return CarInMemoryCollection.CarDb.FirstOrDefault(x => x.Id == id);
        }

        public Car Update(Car car)
        {
            var result = CarInMemoryCollection.CarDb.FirstOrDefault(x => x.Id == car.Id);

            result.Make = car.Make;
            result.Model = car.Model;

            return result;
        }
    }
}
