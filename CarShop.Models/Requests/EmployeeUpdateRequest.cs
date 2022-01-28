using CarShop.Models.Enums;

namespace CarShop.Models.Requests
{
    public class EmployeeUpdateRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public EmployeeCompetence Competence { get; set; }
        public double Salary { get; set; }
    }
}
