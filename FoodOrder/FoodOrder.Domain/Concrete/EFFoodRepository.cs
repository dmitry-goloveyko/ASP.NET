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
    }
}
