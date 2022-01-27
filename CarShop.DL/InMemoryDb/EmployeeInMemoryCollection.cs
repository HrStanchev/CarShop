using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarShop.Models.DTO;

namespace CarShop.DL.InMemoryDb
{
    public static class EmployeeInMemoryCollection
    {
        public static List<Employee> EmployeeDb = new List<Employee>()
        {
            new Employee()
            {
                Id = 1,
                Name = "Stavri",
                Competence = Models.Enums.EmployeeCompetence.Engines,
                Salary = 1800
            },
            new Employee()
            {
                Id=2,
                Name = "Joro",
                Competence = Models.Enums.EmployeeCompetence.Brakes,
                Salary = 1600
            },
            new Employee()
            {
                Id = 3,
                Name = "Kiro",
                Competence = Models.Enums.EmployeeCompetence.Gearboxes,
                Salary = 1700
            },
            new Employee()
            {
                Id = 4,
                Name = "Ico",
                Competence = Models.Enums.EmployeeCompetence.Drivetrain,
                Salary = 1500
            }
        };
    }
}
