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
    public class PartService
    {
        private readonly IPartRepository _partRepository;

        public PartService(IPartRepository partRepository)
        {
            _partRepository = partRepository;
        }

        public Part Create(Part part)
        {
            var index = _partRepository.GetAll().OrderByDescending(x => x.Id).FirstOrDefault()?.Id;
            part.Id = (int)(index != null ? index + 1 : 1);
            return _partRepository.Create(part);
        }

        public Part Delete(int id)
        {
            return _partRepository.Delete(id);
        }

        public Part GetById(int id)
        {
            return _partRepository.GetById(id);
        }

        public IEnumerable<Part> GetAll()
        {
            return _partRepository.GetAll();
        }

        public Part Update(Part part)
        {
            return _partRepository.Update(part);
        }
    }
}
