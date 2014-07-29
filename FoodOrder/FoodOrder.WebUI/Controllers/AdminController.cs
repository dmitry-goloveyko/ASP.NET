using FoodOrder.Domain.Abstract;
using FoodOrder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodOrder.WebUI.Controllers
{
	[Authorize]
	public class AdminController : Controller
	{
		private IFoodRepository repository;

		public AdminController(IFoodRepository repository)
		{
			this.repository = repository;
		}

		public ViewResult Index()
		{
			return View(repository.Foods);
		}

		public ViewResult Create()
		{
			return View("Edit", new Food());
		}

		public ViewResult Edit(int foodId)
		{
			Food food = repository.Foods
			  .FirstOrDefault(p => p.FoodID == foodId);
			return View(food);
		}


		[HttpPost]
		public ActionResult Edit(Food food, HttpPostedFileBase image)
		{
			if (ModelState.IsValid)
			{
				if (image != null)
				{
					food.ImageMimeType = image.ContentType;
					food.ImageData = new byte[image.ContentLength];
					image.InputStream.Read(food.ImageData, 0, image.ContentLength);
				}

				repository.SaveFood(food);
				TempData["message"] = string.Format("{0} has been saved", food.Name);
				return RedirectToAction("Index");
			}
			else
			{
				return View(food);
			}
		}
	}
}
