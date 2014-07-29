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

		[Required(ErrorMessage = "Enter a product name")]
        public string Name { get; set; }

		[Required(ErrorMessage = "Enter a description")]
		[DataType(DataType.MultilineText)]
        public string Description { get; set; }

		[Required]
		[Range(0.01, double.MaxValue, ErrorMessage = "Enter positive price")]
        public decimal Price { get; set; }

		[Required(ErrorMessage = "Enter description")]
        public int DefaultPreparationTime { get; set; }

		public byte[] ImageData { get; set; }

		[HiddenInput(DisplayValue = false)]
		public string ImageMimeType { get; set; }
    }
}