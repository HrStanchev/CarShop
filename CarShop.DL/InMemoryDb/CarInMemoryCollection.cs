using CarShop.Models.DTO;
using System.Collections.Generic;

namespace CarShop.DL.InMemoryDb
{
    public static class CarInMemoryCollection
    {
        public static List<Car> CarDb = new List<Car>()
        {
            new Car()
            {
                Id = 1,
                Make = "Lada",
                Model = "Niva"
            },
            new Car()
            {
                Id=2,
                Make = "Opel",
                Model = "Vectra"
            },
            new Car()
            {
                Id = 3,
                Make = "Mercedes-Benz",
                Model = "E-Class"
            },
            new Car()
            {
                Id = 4,
                Make = "Honda",
                Model = "Civic"
            }
        };
        
    }
}
