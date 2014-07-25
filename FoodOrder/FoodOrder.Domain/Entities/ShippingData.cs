using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrder.Domain.Entities
{
	public class ShippingData
	{
		[Required(ErrorMessage="Пожалуйста, введите ваше имя")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Пожалуйста, введите город")]
		public string City { get; set; }

		[Required(ErrorMessage = "Пожалуйста, введите улицу")]
		public string Street { get; set; }

		[Required(ErrorMessage = "Пожалуйста, введите номер дома")]
		public string HouseNumber { get; set; }

		[Required(ErrorMessage = "Пожалуйста, введите номер квартиры")]
		public string ApartmentNumber { get; set; }
	}
}
