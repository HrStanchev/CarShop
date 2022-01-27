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
    public class ServiceService
    {
        private readonly IServiceRepository _serviceRepository;

        public ServiceService(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public Service Create(Service service)
        {
            var index = _serviceRepository.GetAll().OrderByDescending(x => x.Id).FirstOrDefault()?.Id;
            service.Id = (int)(index != null ? index + 1 : 1);
            return _serviceRepository.Create(service);
        }

        public Service Delete(int id)
        {
            return _serviceRepository.Delete(id);
        }

        public Service GetById(int id)
        {
            return _serviceRepository.GetById(id);
        }

        public IEnumerable<Service> GetAll()
        {
            return _serviceRepository.GetAll();
        }

        public Service Update(Service service)
        {
            return _serviceRepository.Update(service);
        }
    }
}
