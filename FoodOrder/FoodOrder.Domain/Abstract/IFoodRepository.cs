using FoodOrder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrder.Domain.Abstract
{
    public interface IFoodRepository
    {
        IQueryable<Food> Foods { get; }
    }
}
