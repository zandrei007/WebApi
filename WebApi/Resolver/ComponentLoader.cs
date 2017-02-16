using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Reflection;
using Resolver.Interfaces;

namespace Resolver
{
    public static class ComponentLoader
    {
        public static void LoadContainer(string path, string pattern)
        {
            var dirCat = new DirectoryCatalog(path, pattern);
            //var importDef = BuildImportDefinition();
            try
            {
                using (var aggregateCatalog = new AggregateCatalog())
                {
                    aggregateCatalog.Catalogs.Add(dirCat);

                    using (var componsitionContainer = new CompositionContainer(aggregateCatalog))
                    {
                        //IEnumerable<Export> exports = componsitionContainer.GetExports(importDef);
                        var exp = componsitionContainer.GetExports<IRegisterAssembly>();

                        IEnumerable<IRegisterAssembly> modules =
                            exp.Select(export => export.Value as IRegisterAssembly).Where(m => m != null);

                        var registerComponent = new RegisterComponent(DI.Container);
                        foreach (IRegisterAssembly module in modules)
                        {
                            module.SetUp(registerComponent);
                        }
                    }
                }
            }
            catch (ReflectionTypeLoadException typeLoadException)
            {
                var builder = new StringBuilder();
                foreach (Exception loaderException in typeLoadException.LoaderExceptions)
                {
                    builder.AppendFormat("{0}\n", loaderException.Message);
                }

                throw new TypeLoadException(builder.ToString(), typeLoadException);
            }
        }

        private static ImportDefinition BuildImportDefinition()
        {
            return new ImportDefinition(
                def => true, typeof(IRegisterAssembly).FullName, ImportCardinality.ZeroOrMore, false, false);
        }
    }
}
