using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Models.Requests
{
    public class CarUpdateRequest
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
    }
}
