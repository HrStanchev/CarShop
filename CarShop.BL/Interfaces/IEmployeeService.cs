﻿using CarShop.Models.DTO;
using System.Collections.Generic;

namespace CarShop.BL.Interfaces
{
    public interface IEmployeeService
    {
        Employee Create(Employee employee);
        Employee Update(Employee employee);
        Employee Delete(int id);
        Employee GetById(int id);
        IEnumerable<Employee> GetAll();
    }
}
