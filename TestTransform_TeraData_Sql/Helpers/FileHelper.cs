using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTransform_TeraData_Sql.Helpers
{
    public class FileHelper : IFileHelper
    {
        string basePath = Constants.basePath;            
      
        public FileHelper()
        {
                           
        }
        public string[] ReadFilesFromTeraData()
        {
            try
            {               
                var sourcePath = basePath + @"TeraDataFiles\";
                string[] filePaths = Directory.GetFiles(sourcePath, "*.BTQ",
                                         SearchOption.TopDirectoryOnly);
                return filePaths;

            }
            catch (Exception ex)
            {
                Loggger.Error(ex.Message);
                throw ex;
            }
        }
        public string ReadFileContent(string filePath)
        {
            try
            {
                return System.IO.File.ReadAllText(filePath);
               
            }
            catch (Exception ex)
            {
                Loggger.Error(ex.Message);
                throw ex;
            }
        }
        public string GetFileName(string filePath)
        {
            try
            {
               return Path.GetFileNameWithoutExtension(filePath);
            }
            catch (Exception ex)
            {
                Loggger.Error(ex.Message);
                throw ex;
            }
        }
        public void GeneateSQLScriptFile(List<KeyValuePair<string, string>> resSqlScriptStatements, string fileName)
        {
            try
            {
                var destinationPath = basePath + @"SqlFiles\" + fileName + ".txt";
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(destinationPath))
                {
                    foreach (var line in resSqlScriptStatements)
                    {
                        file.WriteLine(line.Value);
                    }
                }
            }
            catch (Exception ex)
            {
                Loggger.Error(ex.Message);
                throw ex;
            }
        }
    }
}
