using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTransform_TeraData_Sql.Helpers
{
    interface IFileHelper
    {
        string[] ReadFilesFromTeraData();
        string ReadFileContent(string filePath);
        string GetFileName(string filePath);
        void GeneateSQLScriptFile(List<KeyValuePair<string, string>> resSqlScriptStatements, string fileName);
    }
}
