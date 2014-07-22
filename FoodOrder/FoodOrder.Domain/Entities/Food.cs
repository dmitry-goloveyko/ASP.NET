using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodOrder.Domain.Entities
{
    public class Food
    {
        public int FoodID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime DefaultPreparationTime { get; set; }
        public DateTime RealPreparationTime { get; set; }
    }
}