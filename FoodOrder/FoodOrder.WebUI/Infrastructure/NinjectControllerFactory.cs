using System;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using System.Collections.Generic;
using System.Linq;
using Moq;
using FoodOrder.Domain.Abstract;
using FoodOrder.Domain.Entities;

namespace FoodOrder.WebUI.Infrastructure
{
    public class NinjectControllerFactory: DefaultControllerFactory
    {
        private IKernel ninjectKernel;

        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)ninjectKernel.Get(controllerType);
        }

        private void AddBindings()
        {
            Mock<IFoodRepository> mock = new Mock<IFoodRepository>();
            mock.Setup(m => m.Foods).Returns(new List<Food> {
              new Food { Name = "Pizza", Price = 25 },
              new Food { Name = "Noodle", Price = 179 },
              new Food { Name = "Sushi", Price = 95 }
            }.AsQueryable());

            ninjectKernel.Bind<IFoodRepository>().ToConstant(mock.Object);
        }
    }
}