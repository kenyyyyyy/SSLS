using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using SSLS.Domain.Abstract;
using SSLS.Domain.Concrete;

namespace SSLS.WebUI.Infrastructure
{
    public class NinjectDependencyResolver:IDependencyResolver
    {  
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelparam)
        {
            kernel = kernelparam;
            AddBindings();

        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
     
        private void AddBindings()
        {
            kernel.Bind<IBooksRepository>().To<EFBooksRepository>();
            //EmailSettings emailSerttings = new EmailSettings();
            //kernel.Bind<IOrderProcessor>().To<EmailOrderProcessor>().WithConstructorArgument("settings", emailSerttings);
            //kernel.Bind<IOrderProcessor>().To<DatabaseOrderProcessor>();
        }
    }
}