using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrder.Domain.Entities
{
	public class Cart
	{
		private List<CartLine> lineCollection = new List<CartLine>();

		public void AddItem(Food food, int quantity)
		{
			CartLine line = lineCollection
			  .Where(p => p.Food.FoodID == food.FoodID)
			  .FirstOrDefault();

			if (line == null)
			{
				lineCollection.Add(new CartLine
				{
					Food = food,
					Quantity = quantity
				});
			}
			else
			{
				line.Quantity += quantity;
			}
		}

		public void RemoveLine(Food food)
		{
			lineCollection.RemoveAll(l => l.Food.FoodID == food.FoodID);
		}

		public decimal ComputeTotalValue()
		{
			return lineCollection.Sum(e => e.Food.Price * e.Quantity);
		}

		public void Clear()
		{
			lineCollection.Clear();
		}

		public IEnumerable<CartLine> Lines
		{
			get { return lineCollection; }
		}
	}

	public class CartLine
	{
		public Food Food { get; set; }
		public int Quantity { get; set; }
	}

}
