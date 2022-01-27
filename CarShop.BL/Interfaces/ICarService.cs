using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarShop.Models.DTO;

namespace CarShop.BL.Interfaces
{
    public interface ICarService
    {
        Car Create(Car car);
        Car Update(Car car);
        Car Delete(int id);
        Car GetById(int id);
        IEnumerable<Car> GetAll();
    }
}
