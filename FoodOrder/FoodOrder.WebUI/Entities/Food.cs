using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodOrder.WebUI.Entities
{
    public class Food
    {
        public int FoodID { get; set; }
        public int Name { get; set; }
        public int Description { get; set; }
        public int Price { get; set; }
        public int DefaultPreparationTime { get; set; }
        public int CurrentPreparationTime { get; set; }
    }
}