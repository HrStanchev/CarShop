﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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