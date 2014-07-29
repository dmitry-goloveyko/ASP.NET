using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrder.WebUI.Infrastructure.Abstract
{
	public interface IAuthProvider
	{
		bool Authenticate(string name, string password);
	}
}
