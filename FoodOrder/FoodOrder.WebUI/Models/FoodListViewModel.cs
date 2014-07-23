using FoodOrder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodOrder.WebUI.Models
{
	public class FoodListViewModel
	{
		public IEnumerable<Food> Foods { get; set; }
		public PagingInfo pagingInfo {get; set; }
	}
}