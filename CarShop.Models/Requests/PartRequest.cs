using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Models.Requests
{
    public class PartRequest
    {
        public string Name { get; set; }
        public string PartNumber { get; set; }
        public double Price { get; set; }
    }
}
