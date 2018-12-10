using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTransform_TeraData_Sql.Helpers
{
    interface ILogHelper
    {
        void Info(string message);
        void Error(string message);
    }
}
