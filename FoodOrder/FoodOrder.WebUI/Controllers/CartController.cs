using FoodOrder.Domain.Abstract;
using FoodOrder.Domain.Entities;
using FoodOrder.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodOrder.WebUI.Controllers
{
    public class CartController : Controller
    {
		private IFoodRepository repository;

		public CartController(IFoodRepository repo)
		{
			repository = repo;
		}

		public ViewResult Index(Cart cart, string returnUrl)
		{
			return View(new CartIndexViewModel
			{
				Cart = cart,
				ReturnUrl = returnUrl
			});
		}

		public RedirectToRouteResult AddToCart(Cart cart, int foodId, string returnUrl)
		{
			Food food = repository.Foods
			.FirstOrDefault(f => f.FoodID == foodId);
			if (food != null)
			{
				cart.AddItem(food, 1);
			}
			return RedirectToAction("Index", new { returnUrl });
		}

		public RedirectToRouteResult RemoveFromCart(Cart cart, int foodId, string returnUrl)
		{
			Food food = repository.Foods
			.FirstOrDefault(f => f.FoodID == foodId);
			if (food != null)
			{
				cart.RemoveLine(food);
			}
			return RedirectToAction("Index", new { returnUrl });
		}

		public PartialViewResult Summary(Cart cart)
		{
			return PartialView(cart);
		}
    }
}
