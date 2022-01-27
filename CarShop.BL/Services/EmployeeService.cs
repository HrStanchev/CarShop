using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarShop.Models.DTO;
using CarShop.DL.Interfaces;
using CarShop.BL.Interfaces;
using Serilog;

namespace CarShop.BL.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILogger _logger;

        public EmployeeService(IEmployeeRepository employeeRepository, ILogger logger)
        {
            _employeeRepository = employeeRepository;
            _logger = logger;
        }

        public Employee Create(Employee employee)
        {
            var index = _employeeRepository.GetAll().OrderByDescending(x => x.Id).FirstOrDefault()?.Id;
            employee.Id = (int)(index != null ? index + 1 : 1);
            return _employeeRepository.Create(employee);
        }

        public Employee Delete(int id)
        {
            return _employeeRepository.Delete(id);
        }

        public Employee GetById(int id)
        {
            return _employeeRepository.GetById(id);
        }

        public IEnumerable<Employee> GetAll()
        {
            return _employeeRepository.GetAll();
        }

        public Employee Update(Employee employee)
        {
            return _employeeRepository.Update(employee);
        }
    }
}
