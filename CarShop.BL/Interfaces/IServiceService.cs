﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarShop.Models.DTO;

namespace CarShop.BL.Interfaces
{
    public interface IServiceService
    {
        Service Create(Service service);
        Service Update(Service service);
        Service Delete(int id);
        Service GetById(int id);
        IEnumerable<Service> GetAll();
    }
}