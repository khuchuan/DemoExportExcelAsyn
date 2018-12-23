using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Web;
using Excel = Microsoft.Office.Interop.Excel;
namespace Paygate.Utility
{
    public class ExcelHelper
    {



        public DataTable exceldata(string filelocation, string extention)
        {


            var dtPatterns = new DataTable { TableName = "Telco" };
            dtPatterns.Columns.Add(new DataColumn("PhoneNumber"));
            dtPatterns.Columns.Add(new DataColumn("Amount"));
            dtPatterns.Columns.Add(new DataColumn("Type"));
            dtPatterns.Columns.Add(new DataColumn("Description"));

            var excelObject = new ExcelObject(filelocation);
            var tmp = excelObject.ReadData();
            foreach (DataRow dataRow in tmp.Rows)
            {
                var row = dtPatterns.NewRow();
                if (string.IsNullOrEmpty(dataRow[0].ToString())) break;
                row["PhoneNumber"] = dataRow[0];
                row["Amount"] = dataRow[1];
                row["Type"] = "asdfasd";
                row["Description"] = "asdfasdfa2342";
                dtPatterns.Rows.Add(row);
            }
            excelObject.Dispose();

            return dtPatterns;

        }




        public static string WriteData(DataTable dataTable, List<string> header)
        {
            var filename = new SessionUtility().GetValue(SessionUtility.Session_FileName).ToString();
            var filePath = string.Format("{0}{1}",
                                         System.Configuration.ConfigurationManager.AppSettings[
                                             "TEMPLATE.URL"],
                                         filename);
            var excelObject = new ExcelObject(filePath);
            excelObject.Export(dataTable, true, true);
            excelObject.Dispose();
            return filename;
        }


        public DataTable ConvertTo<T>(IList<T> lst)
        {
            //create DataTable Structure
            var tbl = CreateTable<T>();
            var entType = typeof(T);

            var properties = TypeDescriptor.GetProperties(entType);
            //get the list item and add into the list
            foreach (var item in lst)
            {
                var row = tbl.NewRow();
                foreach (PropertyDescriptor prop in properties)
                {
                    row[prop.Name] = prop.GetValue(item);
                }
                tbl.Rows.Add(row);
            }

            return tbl;
        }
        private static DataTable CreateTable<T>()
        {
            //T –> ClassName
            var entType = typeof(T);
            //set the datatable name as class name
            var tbl = new DataTable(entType.Name);
            //get the property list
            var properties = TypeDescriptor.GetProperties(entType);
            foreach (PropertyDescriptor prop in properties)
            {
                //add property as column
                try
                {
                    tbl.Columns.Add(prop.Name, prop.PropertyType);
                }
                catch
                {
                    if (prop.PropertyType.ToString().ToLower().Contains("datetime"))
                    {
                        tbl.Columns.Add(prop.Name, typeof(DateTime));
                        continue;

                    }

                    if (prop.PropertyType.ToString().ToLower().Contains("boolean"))
                    {
                        tbl.Columns.Add(prop.Name, typeof(bool));
                        continue;
                    }
                    if (prop.PropertyType.ToString().ToLower().Contains("int"))
                    {
                        tbl.Columns.Add(prop.Name, typeof(int));
                        continue;
                    }
                }
            }
            return tbl;
        }


        public static void Dowload(string filepath, string filename)
        {
            System.IO.Stream iStream = null;
            byte[] buffer = new Byte[100000];
            int length;
            long dataToRead;
            try
            {
                iStream = new System.IO.FileStream(filepath, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.Read);
                dataToRead = iStream.Length;
                HttpContext.Current.Response.ContentType = "application/force-download";
                HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + filename);
                while (dataToRead > 0)
                {
                    if (HttpContext.Current.Response.IsClientConnected)
                    {
                        length = iStream.Read(buffer, 0, 100000);
                        HttpContext.Current.Response.OutputStream.Write(buffer, 0, length);
                        HttpContext.Current.Response.Flush();
                        buffer = new Byte[100000];
                        dataToRead = dataToRead - length;
                    }
                    else
                    {
                        dataToRead = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write("Error : " + ex.Message);
            }
            finally
            {
                if (iStream != null)
                {
                    iStream.Close();
                }
                HttpContext.Current.Response.Close();
            }

        }
    }
}
