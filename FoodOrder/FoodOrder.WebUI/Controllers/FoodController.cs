using FoodOrder.Domain.Abstract;
using FoodOrder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodOrder.WebUI.Controllers
{
    public class FoodController : Controller
    {
        private IFoodRepository repository;

        public FoodController(IFoodRepository repository)
        {
            this.repository = repository;
        }

        public ViewResult List()
        {
            return View(repository.Foods);
        }

    }
}
