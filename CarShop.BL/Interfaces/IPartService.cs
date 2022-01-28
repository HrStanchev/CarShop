using CarShop.Models.DTO;
using System.Collections.Generic;

namespace CarShop.BL.Interfaces
{
    public interface IPartService
    {
        Part Create(Part part);
        Part Update(Part part);
        Part Delete(int id);
        Part GetById(int id);
        IEnumerable<Part> GetAll();
    }
}
