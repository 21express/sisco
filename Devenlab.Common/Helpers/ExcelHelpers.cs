using System;
using System.Data;
using System.Data.OleDb;

namespace Devenlab.Common.Helpers
{
    public enum ExcelFormat
    {
        Excel2003,
        Excel2007
    }

    public static class ExcelHelpers
    {


        private static string GetConnectionString(ExcelFormat format, string filename)
        {
            return format == ExcelFormat.Excel2003 ?
                string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=Excel 8.0;", filename) :
                string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 8.0;HDR=YES;\"", filename);
        }

        public static DataSet ReadFile(string filepath)
        {
            var result = new DataSet();
            var connectionstring = GetConnectionString((filepath.Contains("xlsx") ? ExcelFormat.Excel2007 : ExcelFormat.Excel2003), filepath);
            using (var connection = new OleDbConnection(connectionstring))
            {
                try
                {
                    connection.Open();
                    using (var datatable = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null))
                    {
                        if (datatable != null && datatable.Rows.Count == 0)
                            throw new Exception("Excel file doesn't contain sheet");
                    	if (datatable != null)
                    	{
                    		var sheetname = datatable.Rows[0]["TABLE_NAME"].ToString();
                    		using (var adapter = new OleDbDataAdapter(string.Format("select * from [{0}]", sheetname), connection))
                    		{
                    			adapter.Fill(result);
                    		}
                    	}
                    }
                }
                catch (Exception err)
                {
                    throw new Exception("Error On Read File Excel, " + err.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            return result;
        }
    }
}
