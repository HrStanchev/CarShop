﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarShop.Models.DTO;
using CarShop.DL.InMemoryDb;
using CarShop.DL.Interfaces;

namespace CarShop.DL.Repositories
{
    public class ServiceInMemoryRepository : IServiceRepository
    {
        public ServiceInMemoryRepository()
        { }

        public Service Create(Service service)
        {
            ServiceInMemoryCollection.ServiceDb.Add(service);

            return service;
        }

        public Service Delete(int id)
        {
            var service = ServiceInMemoryCollection.ServiceDb.FirstOrDefault(service => service.Id == id);

            ServiceInMemoryCollection.ServiceDb.Remove(service);

            return service;
        }

        public IEnumerable<Service> GetAll()
        {
            return ServiceInMemoryCollection.ServiceDb;
        }

        public Service GetById(int id)
        {
            return ServiceInMemoryCollection.ServiceDb.FirstOrDefault(x => x.Id == id);
        }

        public Service Update(Service service)
        {
            var result = ServiceInMemoryCollection.ServiceDb.FirstOrDefault(x => x.Id == service.Id);

            result.Name = service.Name;

            return result;
        }
    }
}
