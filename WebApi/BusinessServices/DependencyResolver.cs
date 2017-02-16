using BusinessServices.Concrete;
using BusinessServices.Interface;
using System.ComponentModel.Composition;
using Resolver;
using Resolver.Interfaces;

namespace BusinessServices
{
    [Export(typeof(IRegisterAssembly))]
    class DependencyResolver : IRegisterAssembly
    {
        public void SetUp(IRegisterComponent registerComponent)
        {
            registerComponent.RegisterType<IProductServices, ProductServices>();
            registerComponent.RegisterType<IUserServices, UserServices>();
            registerComponent.RegisterType<ITokenServices, TokenServices>();
        }
    }
}
