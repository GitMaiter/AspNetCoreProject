﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreProject.Models
{
    public class Coffee
    {
        public int Id { get; set; }
        public string Sort { get; set; }
        public DateTime StartDate{ get; set; }
        public DateTime? EndDate{ get; set; }
        public double WaterAmount { get; set; }
        public string Expectation { get; set; }
    }
}
