using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entityes
{
    public class CoffeeDbModel
    {
        public int Id { get; set; }
        public string Sort { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public double WaterAmount { get; set; }
        public string Expectation { get; set; }
    }
}
