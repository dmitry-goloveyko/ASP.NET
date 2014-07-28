using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace FoodOrder.Domain.Entities
{
    public class Food
    {
		[HiddenInput(DisplayValue = false)]
        public int FoodID { get; set; }

        public string Name { get; set; }

		[DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public decimal Price { get; set; }

        public int DefaultPreparationTime { get; set; }
    }
}