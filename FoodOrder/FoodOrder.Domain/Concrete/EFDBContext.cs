using FoodOrder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrder.Domain.Concrete
{
    public class EFDBContext: DbContext
    {
        public DbSet<Food> Foods { get; set; }
    }
}
