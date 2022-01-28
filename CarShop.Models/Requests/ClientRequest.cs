using CarShop.Models.DTO;
using CarShop.Models.Enums;
using System.Collections.Generic;

namespace CarShop.Models.Requests
{
    public class ClientRequest
    {
        public string Name { get; set; }
        public PaymentType PaymentType { get; set; }
        public int Discount { get; set; }
        public List<Car> Car { get; set; }

    }
}
