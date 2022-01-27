using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarShop.Models.DTO;

namespace CarShop.DL.InMemoryDb
{
    public static class PartInMemoryCollection
    {
        public static List<Part> PartDb = new List<Part>()
        {
            new Part()
            {
                Id = 1,
                Name = "Piston",
                PartNumber = "A1120306617",
                Price = 331
            },
            new Part()
            {
                Id=2,
                Name = "Clutch",
                PartNumber = "A0212501501",
                Price = 478
            },
            new Part()
            {
                Id=3,
                Name = "Brake caliper",
                PartNumber = "A0034200183",
                Price = 342
            },
            new Part()
            {
                Id=4,
                Name = "Axle shaft",
                PartNumber = "A2113500556",
                Price = 750
            }
        };
    }
}
