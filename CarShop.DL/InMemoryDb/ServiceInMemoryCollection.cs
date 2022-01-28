using CarShop.Models.DTO;
using System.Collections.Generic;

namespace CarShop.DL.InMemoryDb
{
    public static class ServiceInMemoryCollection
    {
        public static List<Service> ServiceDb = new List<Service>()
        {
            new Service()
            {
                Id = 1,
                Name = "Engine job",
                Price = 400
            },
            new Service()
            {
                Id=2,
                Name = "Brake job",
                Price = 150
            },
            new Service()
            {
                Id=3,
                Name ="Gearbox job",
                Price = 370
            },
            new Service()
            {
                Id = 4,
                Name = "Drivetrain job",
                Price = 260
            }
        };
    }
}
