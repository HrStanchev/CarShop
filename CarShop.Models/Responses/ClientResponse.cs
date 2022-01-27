using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarShop.Models.Enums;
using CarShop.Models.DTO;

namespace CarShop.Models.Responses
{
    public class ClientResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public PaymentType PaymentType { get; set; }
        public int Discount { get; set; }
        public List<Car> Car { get; set; }
    }
}
