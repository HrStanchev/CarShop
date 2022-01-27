using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarShop.Models.Enums;
using CarShop.Models.DTO;

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
