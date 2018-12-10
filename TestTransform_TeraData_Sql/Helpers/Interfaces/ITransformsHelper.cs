using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTransform_TeraData_Sql.Helpers
{
    interface ITransformsHelper
    {
        void TransformInitiate();
        void ProcessTeraScriptStatements(string teraScript, string fileName);
    }
}
