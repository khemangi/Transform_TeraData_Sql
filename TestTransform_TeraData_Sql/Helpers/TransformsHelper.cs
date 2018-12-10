using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTransform_TeraData_Sql.Helpers
{
    public class TransformsHelper:ITransformsHelper
    {      
        private IFileHelper _fileHelper;
        public TransformsHelper(FileHelper fileHelper)
        {           
            _fileHelper = fileHelper;           
        }
        /// <summary>
        /// Transform Initiate 
        /// </summary>
        public void TransformInitiate()
        {
            try
            {
                var filePaths = _fileHelper.ReadFilesFromTeraData();
                foreach (var teraDataFilePath in filePaths)
                {
                    string teraScript = _fileHelper.ReadFileContent(teraDataFilePath);
                    var fileName = _fileHelper.GetFileName(teraDataFilePath);
                    ProcessTeraScriptStatements(teraScript, fileName);
                }
            }
            catch (Exception ex)
            {
                Loggger.Error(ex.Message);
                throw ex;
            }
        }
        /// <summary>
        /// Process TeraScript Statements
        /// </summary>
        /// <param name="teraScriptStatement"></param>
        /// <param name="resSqlScriptStatements"></param>
        public void ProcessTeraScriptStatements(string teraScript, string fileName)
        {
            try
            {

                List<KeyValuePair<string, string>> resSqlScriptStatements = new List<KeyValuePair<string, string>>();
                var teraScriptStatements = teraScript.Split(';');
                foreach (var teraScriptStatement in teraScriptStatements)
                {
                    PrepareToSQLScriptStatement(teraScriptStatement, resSqlScriptStatements);
                }
                _fileHelper.GeneateSQLScriptFile(resSqlScriptStatements, fileName);
            }
            catch (Exception ex)
            {
                Loggger.Error(ex.Message);
                throw ex;
            }
        }
        /// <summary>
        /// Prepare SQL Script Statements
        /// </summary>
        private void PrepareToSQLScriptStatement(string teraScriptStatement, List<KeyValuePair<string, string>> resSqlScriptStatements)
        {
            try
            {
                if (validateStatement(teraScriptStatement))
                {
                    if (validateIsStatement(teraScriptStatement))
                    {
                        MakeSQLScriptStatements("STATEMENT", teraScriptStatement, resSqlScriptStatements);
                    }
                    else if (validateIsComment(teraScriptStatement))
                    {
                        MakeSQLScriptStatements("COMMENT", teraScriptStatement, resSqlScriptStatements);
                    }
                    else if (validateIsTeraDataSpecific(teraScriptStatement))
                    {
                        MakeSQLScriptStatements("TERADATASPECIFIC", teraScriptStatement, resSqlScriptStatements);
                    }

                }
            }
            catch (Exception ex)
            {
                Loggger.Error(ex.Message);
                throw ex;
            }
        }
        /// <summary>
        /// Make SQL Script Statements
        /// </summary>
        /// <param name="resSqlScriptStatements"></param>
        private void MakeSQLScriptStatements(string type, string scriptText, List<KeyValuePair<string, string>> resSqlScriptStatements)
        {
            try
            {
                var keyvaluePair = new KeyValuePair<string, string>(type, scriptText);
                resSqlScriptStatements.Add(keyvaluePair);
            }
            catch (Exception ex)
            {
                Loggger.Error(ex.Message);
                throw ex;
            }
        }
        public static bool validateStatement(string teraScriptStatement)
        {
            return true;
        }
        /// <summary>
        /// validate Statement
        /// </summary>
        /// <param name="statement"></param>
        /// <returns></returns>
        private bool validateIsStatement(string statement)
        {
            try
            {
                var scriptStatementsKeywords = new[] { "CREATE VOLATILE", "INSERT", "UPDATE", "DELETE", "DROP" };
                var firstWord = FirstWord(statement);
                if (scriptStatementsKeywords.Any(x => statement.Contains(x)))
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Loggger.Error(ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// validate IsComment
        /// </summary>
        /// <param name="statement"></param>
        /// <returns></returns>
        private bool validateIsComment(string statement)
        {
            try
            {
                if (statement.StartsWith("/*"))
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                Loggger.Error(ex.Message);
                throw ex;
            }
        }
        /// <summary>
        /// validate IsTeraDataSpecific
        /// </summary>
        /// <param name="statement"></param>
        /// <returns></returns>
        private bool validateIsTeraDataSpecific(string statement)
        {
            try
            {
                var teraDataSpecificKeywords = new[] { ".IF" };
                var firstWord = FirstWord(statement);
                if (teraDataSpecificKeywords.Any(x => x == firstWord))
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Loggger.Error(ex.Message);
                throw ex;
            }
        }
        /// <summary>
        /// Getting FirstWord
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private static string FirstWord(string text)
        {
            try
            {
                return text.IndexOf(" ") > -1
                   ? text.Substring(0, text.IndexOf(" "))
                   : text;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
