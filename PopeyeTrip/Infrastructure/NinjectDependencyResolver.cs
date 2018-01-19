using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using System.Web.Mvc;
using PopEyeTrip.Concrete;
using PopEyeTrip.Entities;
using PopEyeTrip.Abstract;

namespace PopEyeTrip.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
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
            kernel.Bind<IMainBoardRepository>().To<EFMainBoardRepository>();
            kernel.Bind<IHashTagRepository>().To<EFHashTagRepository>();
            kernel.Bind<IBannerRepository>().To<EFBannerRepository>();
            kernel.Bind<ILikeRepository>().To<EFLikeRepository>();
        }
    }
}
