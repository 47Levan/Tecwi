using System;
using System.Collections.Generic;
using System.Web.Mvc;
using BookShop.Models.Repositories;
using Ninject;

namespace BookShop.Infrastructure
{
    public class NinjectResolver :IDependencyResolver
    {
        private IKernel kernel;

        public NinjectResolver(IKernel kernel)
        {
            this.kernel = kernel;
            AddBindings();
        }
        private void AddBindings()
        {
            kernel.Bind<IBook>().To<BooksRepository>();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }


        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
    }
}