using Resolver;

namespace DataModel.GenericRepo
{
    internal class Gateway
    {
        public static DbAccess Instance
        {
            get
            {
                return DI.Resolve<DbAccess>(); 
            }
        }
    }
}
