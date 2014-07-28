using FoodOrder.Domain.Abstract;
using FoodOrder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodOrder.WebUI.Controllers
{
    public class AdminController : Controller
    {
		private IFoodRepository	 repository;

		public AdminController(IFoodRepository repository)
		{
			this.repository = repository;
		}

        public ViewResult Index()
        {
            return View(repository.Foods);
        }

		public ViewResult Edit(int foodId)
		{
			Food food = repository.Foods
				.FirstOrDefault(f => f.FoodID == foodId);

			return View(food);
		}
    }
}
