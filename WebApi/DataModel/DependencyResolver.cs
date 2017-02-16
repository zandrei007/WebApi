using System.ComponentModel.Composition;
using DataModel.Database;
using DataModel.GenericRepo;
using Resolver.Interfaces;

namespace DataModel
{
    [Export(typeof(IRegisterAssembly))]
    public class DependencyResolver : IRegisterAssembly
    {
        public void SetUp(IRegisterComponent registerComponent)
        {
            registerComponent.RegisterType<TokenAccess, TokenAccess>();
            registerComponent.RegisterType<DbAccess, DbAccess>();
        }
    }
}
