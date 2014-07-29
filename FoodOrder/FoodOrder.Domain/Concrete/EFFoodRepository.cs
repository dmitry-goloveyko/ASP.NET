using FoodOrder.Domain.Abstract;
using FoodOrder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrder.Domain.Concrete
{
    public class EFFoodRepository: IFoodRepository
    {
        private EFDBContext context = new EFDBContext();

        public IQueryable<Food> Foods
        {
            get { return context.Foods; }
        }

		public void SaveFood(Food food)
		{
			if (food.FoodID == 0)
			{
				context.Foods.Add(food);
			}
			else
			{
				Food dbEntry = context.Foods.Find(food.FoodID);
				if (dbEntry != null)
				{
					dbEntry.Name = food.Name;
					dbEntry.Description = food.Description;
					dbEntry.Price = food.Price;
					dbEntry.DefaultPreparationTime = food.DefaultPreparationTime;
					dbEntry.ImageData = food.ImageData;
					dbEntry.ImageMimeType = food.ImageMimeType;
				}
			}
			context.SaveChanges();
		}
    }
}
