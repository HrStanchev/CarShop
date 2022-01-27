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
    public class PartInMemoryRepository : IPartRepository
    {
        public PartInMemoryRepository()
        { }

        public Part Create(Part part)
        {
            PartInMemoryCollection.PartDb.Add(part);

            return part;
        }

        public Part Delete(int id)
        {
            var part = PartInMemoryCollection.PartDb.FirstOrDefault(part => part.Id == id);

            PartInMemoryCollection.PartDb.Remove(part);

            return part;
        }

        public IEnumerable<Part> GetAll()
        {
            return PartInMemoryCollection.PartDb;
        }

        public Part GetById(int id)
        {
            return PartInMemoryCollection.PartDb.FirstOrDefault(x => x.Id == id);
        }

        public Part Update(Part part)
        {
            var result = PartInMemoryCollection.PartDb.FirstOrDefault(x => x.Id == part.Id);

            result.Name = part.Name;

            return result;
        }
    }
}
