using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarShop.Models.DTO;

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
