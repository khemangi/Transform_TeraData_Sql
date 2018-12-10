using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace TestTransform_TeraData_Sql.Helpers
{
    public static class Loggger
    {
        private static log4net.ILog log ;

        public static void Start()
        {
            log4net.Config.BasicConfigurator.Configure();
            log = log4net.LogManager.GetLogger(typeof(Program));
        }
        public static void Info(string message)
        {
            log.Info("#Info....."+ message);
        }
        public static void Error(string message)
        {
            log.Error("#Error....." + message);
        }
    }
}

