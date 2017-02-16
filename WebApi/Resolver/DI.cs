using System.Configuration;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace Resolver
{
    /// <summary>
    /// Simple wrapper for unity resolution.
    /// </summary>
    public class DI
    {
        private static IUnityContainer _container;

        /// <summary>
        /// Public reference to the unity container which will 
        /// allow the ability to register instrances or take 
        /// other actions on the container.
        /// </summary>
        public static IUnityContainer Container
        {
            get
            {
                return _container;
            }
            private set
            {
                _container = value;
            }
        }

        public static void LoadAssembly()
        {
            ComponentLoader.LoadContainer(".\\bin", "DataModel.dll");
            ComponentLoader.LoadContainer(".\\bin", "BusinessServices.dll");
        }

        /// <summary>
        /// Static constructor for DI which will 
        /// initialize the unity container.
        /// </summary>
        static DI()
        {
            var container = new UnityContainer();

            var section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            if (section != null)
            {
                section.Configure(container);
            }
            _container = container;
        }

        /// <summary>
        /// Resolves the type parameter T to an instance of the appropriate type.
        /// </summary>
        /// <typeparam name="T">Type of object to return</typeparam>
        public static T Resolve<T>()
        {
            T ret = default(T);

            if (Container.IsRegistered(typeof(T)))
            {
                ret = Container.Resolve<T>();
            }

            return ret;
        }

        public static void RegisterType<T1, T2>()
        {
            _container.RegisterType(typeof(T1), typeof(T2));
        }
    }
}
