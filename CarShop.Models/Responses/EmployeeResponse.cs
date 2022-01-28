using CarShop.Models.Enums;

namespace CarShop.Models.Responses
{
    public class EmployeeResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public EmployeeCompetence Competence { get; set; }
        public double Salary { get; set; }
    }
}
