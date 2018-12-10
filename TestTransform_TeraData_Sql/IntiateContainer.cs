using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleInjector;
using TestTransform_TeraData_Sql.Helpers;

namespace TestTransform_TeraData_Sql
{
    public static class IntiateContainer
    {
        /// <summary>
        /// Start the dependency injection container 
        /// </summary>
        /// <param name="container"></param>
        public static void Start(Container container)
        {          
            container.Register<IFileHelper>(() => new FileHelper());
            container.Register<ITransformsHelper>(() => new TransformsHelper(container.GetInstance<FileHelper>()));
        }
    }
}
