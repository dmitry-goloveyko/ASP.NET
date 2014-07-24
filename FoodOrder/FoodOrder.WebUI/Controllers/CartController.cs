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

		public ViewResult Index(string returnUrl)
		{
			return View(new CartIndexViewModel
			{
				Cart = GetCart(),
				ReturnUrl = returnUrl
			});
		}

		public RedirectToRouteResult AddToCart(int foodId, string returnUrl)
		{
			Food food = repository.Foods
			.FirstOrDefault(f => f.FoodID == foodId);
			if (food != null)
			{
				GetCart().AddItem(food, 1);
			}
			return RedirectToAction("Index", new { returnUrl });
		}

		public RedirectToRouteResult RemoveFromCart(int foodId, string returnUrl)
		{
			Food food = repository.Foods
			.FirstOrDefault(f => f.FoodID == foodId);
			if (food != null)
			{
				GetCart().RemoveLine(food);
			}
			return RedirectToAction("Index", new { returnUrl });
		}

		private Cart GetCart()
		{
			Cart cart = (Cart)Session["Cart"];
			if (cart == null)
			{
				cart = new Cart();
				Session["Cart"] = cart;
			}
			return cart;
		}
    }
}
