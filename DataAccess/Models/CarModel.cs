﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    internal class CarModel
    {
        public int Id { get; set; }
        public string Make {  get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public double Price { get; set; }
        
    }
}
