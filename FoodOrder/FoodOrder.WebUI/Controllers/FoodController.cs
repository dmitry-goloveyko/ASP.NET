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
    public class FoodController : Controller
    {
        private IFoodRepository repository;
        public int PageSize = 4;

        public FoodController(IFoodRepository repository)
        {
            this.repository = repository;
        }

        public ViewResult List(int page = 1)
        {
			FoodListViewModel model = new FoodListViewModel
			{
				Foods = repository.Foods
				  .OrderBy(p => p.FoodID)
				  .Skip((page - 1) * PageSize)
				  .Take(PageSize),
				pagingInfo = new PagingInfo
				{
					CurrentPage = page,
					ItemsPerPage = PageSize,
					TotalItems = repository.Foods.Count()
				}
			};

            return View(model);
        }

		public FileContentResult GetImage(int foodId)
		{
			Food food = repository.Foods.FirstOrDefault ( f => f.FoodID == foodId);

			if(food != null)
			{
				return File(food.ImageData, food.ImageMimeType);
			}
			else 
			{
				return null;
			}
		}
    }
}
