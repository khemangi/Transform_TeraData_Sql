using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTransform_TeraData_Sql.Helpers;
using SimpleInjector;

namespace TestTransform_TeraData_Sql
{
    class Program
    {       
        static void Main(string[] args)
        {
            Initialize();
        }
        /// <summary>
        /// Initialize Application
        /// </summary>
        private static void Initialize()
        {
           
            var container = new Container();
            IntiateContainer.Start(container);
            Loggger.Start();
            Loggger.Info("....Start Application......");
            var _transformHelper = container.GetInstance<ITransformsHelper>();
            _transformHelper.TransformInitiate();
            Loggger.Info("....End Application......");
        }
    }
}
