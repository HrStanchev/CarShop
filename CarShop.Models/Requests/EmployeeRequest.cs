using CarShop.Models.Enums;

namespace CarShop.Models.Requests
{
    public class EmployeeRequest
    {
        public string Name { get; set; }
        public EmployeeCompetence Competence { get; set; }
        public double Salary { get; set; }
    }
}
