using CarShop.Models.DTO;
using System.Collections.Generic;

namespace CarShop.DL.Interfaces
{
    public interface ICarRepository
    {
        Car Create(Car car);
        Car Update(Car car);
        Car Delete(int id);
        Car GetById(int id);
        IEnumerable<Car> GetAll();

    }
}
