using CarShop.Models.Enums;
using System.Collections.Generic;

namespace CarShop.Models.DTO
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public PaymentType PaymentType { get; set; }
        public int Discount { get; set; }
        public List<Car> Car { get; set; }
    }
}
