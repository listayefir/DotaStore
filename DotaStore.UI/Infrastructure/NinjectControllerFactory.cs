using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using Moq;
using DotaStore.Domain.Concrete;
using DotaStore.Domain.Abstract;


namespace DotaStore.UI.Infrastructure
{
    public class NinjectControllerFactory:DefaultControllerFactory
    {
        private IKernel _ninjectKernel;

        public NinjectControllerFactory()
        {
            _ninjectKernel = new StandardKernel();
            AddBindings();

        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null
                ? null
                : (IController) _ninjectKernel.Get(controllerType);
        }
        private void AddBindings()
        {
            EFRepository repo = new EFRepository();
            _ninjectKernel.Bind<IRepository>().ToConstant(repo);
        }
    }
}