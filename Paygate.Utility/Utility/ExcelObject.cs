using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Data.OleDb;
using System.Text;
using System.Data;

namespace Paygate.Utility
{



    public sealed class ExcelObject : IDisposable
    {

        private const string excelObject = "Provider=Microsoft.{0}.OLEDB.{1};Data Source={2};Extended Properties=\"Excel {3};HDR=YES\"";
        private string _filepath = string.Empty;
        private OleDbConnection _con;

        public delegate void ProgressWork(float percentage);
        private event ProgressWork Reading;
        private event ProgressWork Writeing;
        private event EventHandler ConnectionStringChange;

        public event ProgressWork ReadProgress
        {
            add
            {
                Reading += value;
            }
            remove
            {
                Reading -= value;
            }
        }

        public void OnReadProgress(float percentage)
        {
            if (Reading != null)
                Reading(percentage);
        }


        public event ProgressWork WriteProgress
        {
            add
            {


                Writeing += value;
            }
            remove
            {



                Writeing -= value;
            }
        }

        public void OnWriteProgress(float percentage)
        {
            if (Writeing != null)
                Writeing(percentage);
        }


        public event EventHandler ConnectionStringChanged
        {
            add
            {
                ConnectionStringChange += value;
            }
            remove
            {

                ConnectionStringChange -= value;
            }
        }

        public void OnConnectionStringChanged()
        {
            if (Connection != null && !Connection.ConnectionString.Equals(ConnectionString))
            {
                if (Connection.State == ConnectionState.Open)
                    Connection.Close();
                Connection.Dispose();
                _con = null;

            }
            if (ConnectionStringChange != null)
            {
                ConnectionStringChange(this, new EventArgs());
            }
        }

        public string ConnectionString
        {
            get
            {
                if (!string.IsNullOrEmpty(_filepath))
                {
                    //Check for File Format
                    var fi = new FileInfo(_filepath);
                    if (fi.Extension.Equals(".xls"))
                    {
                        return string.Format(excelObject, "Ace", "12.0", _filepath, "12.0");
                        //  return string.Format(excelObject, "Jet", "4.0", _filepath, "8.0");
                    }
                    if (fi.Extension.Equals(".xlsx"))
                    {
                        return string.Format(excelObject, "Ace", "12.0", _filepath, "12.0");
                    }
                }
                else
                {
                    return string.Empty;
                }
                return string.Empty;
            }
        }

        public OleDbConnection Connection
        {
            get { return _con ?? (_con = new OleDbConnection { ConnectionString = ConnectionString }); }
        }


        public ExcelObject(string path)
        {

            _filepath = path;
            OnConnectionStringChanged();
        }

        public DataTable GetSchema()
        {
            if (Connection.State != ConnectionState.Open) this.Connection.Open();
            var dtSchema = Connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
            return dtSchema;
        }

        public DataTable ReadTable(string tableName)
        {
            return ReadTable(tableName, "");
        }

        public DataTable ReadTable(string tableName, string criteria)
        {

            try
            {
                if (Connection.State != ConnectionState.Open)
                {
                    Connection.Open();
                    OnReadProgress(10);

                }
                var cmdText = "Select * from [{0}]";
                if (!string.IsNullOrEmpty(criteria))
                {
                    cmdText += " Where " + criteria;
                }
                var cmd = new OleDbCommand(string.Format(cmdText, tableName)) { Connection = Connection };
                var adpt = new OleDbDataAdapter(cmd);
                OnReadProgress(30);

                var dataTable = new DataTable();
                OnReadProgress(50);

                adpt.Fill(dataTable, tableName);
                OnReadProgress(100);

                return dataTable;
            }
            catch
            {
                return null;
            }
        }

        public bool DropTable(string tablename)
        {

            try
            {
                if (Connection.State != ConnectionState.Open)
                {
                    Connection.Open();
                    OnWriteProgress(10);

                }
                const string cmdText = "Drop Table [{0}]";
                using (var cmd = new OleDbCommand(string.Format(cmdText, tablename), Connection))
                {
                    OnWriteProgress(30);

                    cmd.ExecuteNonQuery();
                    OnWriteProgress(80);

                }
                Connection.Close();
                OnWriteProgress(100);

                return true;
            }
            catch (Exception ex)
            {
                OnWriteProgress(0);
                return false;
            }
        }

        public bool WriteTable(string tableName, Dictionary<string, string> tableDefination)
        {
            try
            {
                using (var cmd = new OleDbCommand(GenerateCreateTable(tableName, tableDefination), this.Connection))
                {

                    if (Connection.State != ConnectionState.Open) Connection.Open();

                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }


        public bool WriteTable(string tableName, Dictionary<string, string> tableDefination, DataTable dataTable)
        {
            try
            {
                using (var cmd = new OleDbCommand(GenerateCreateTable(tableName, tableDefination), this.Connection))
                {

                    if (Connection.State != ConnectionState.Open) Connection.Open();

                    cmd.ExecuteNonQuery();
                    foreach (DataRow dataRow in dataTable.Rows)
                        AddNewRow(dataRow);
                    cmd.Clone();
                    cmd.Dispose();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool AddNewRow(DataRow dr)
        {

            using (var cmd = new OleDbCommand(GenerateInsertStatement(dr), Connection))
            {


                cmd.ExecuteNonQuery();
            }
            return true;
        }

        /// <summary>
        /// Generates Create Table Script
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="tableDefination"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        private static string GenerateCreateTable(string tableName, Dictionary<string, string> tableDefination)
        {

            var sb = new StringBuilder();
            sb.AppendFormat("CREATE TABLE [{0}$](", tableName);
            var firstcol = true;
            foreach (var keyvalue in tableDefination)
            {
                if (!firstcol)
                {
                    sb.Append(",");
                }
                firstcol = false;
                sb.AppendFormat("{0} {1}", keyvalue.Key, keyvalue.Value);
            }

            sb.Append(")");
            return sb.ToString();
        }

        private static string GenerateInsertStatement(DataRow dr)
        {
            var sb = new StringBuilder();
            var firstcol = true;
            sb.AppendFormat("INSERT INTO [{0}](", dr.Table.TableName);


            foreach (DataColumn dc in dr.Table.Columns)
            {
                if (!firstcol)
                {
                    sb.Append(",");
                }
                firstcol = false;

                sb.Append(dc.Caption);
            }

            sb.Append(") VALUES(");
            for (int i = 0; i <= dr.Table.Columns.Count - 1; i++)
            {
                if (!ReferenceEquals(dr.Table.Columns[i].DataType, typeof(int)))
                {
                    sb.Append("'");
                    sb.Append(dr[i].ToString().Replace("'", "''"));
                    sb.Append("'");
                }
                else
                {
                    sb.Append(dr[i].ToString().Replace("'", "''"));
                }
                if (i != dr.Table.Columns.Count - 1)
                {
                    sb.Append(",");
                }
            }

            sb.Append(")");
            return sb.ToString();
        }

        public DataTable ReadData(DataTable table)
        {
            var excelDataAdapter = new OleDbDataAdapter();
            var dataTable = new DataTable();
            if (Connection.State != ConnectionState.Open)
            {
                Connection.Open();
                OnReadProgress(10);

            }
            excelDataAdapter.SelectCommand = new OleDbCommand("SELECT * FROM [Sheet1$]", Connection);
            excelDataAdapter.Fill(dataTable);
            Connection.Dispose();
            Connection.Close();
            return dataTable;
        }


        public DataTable ReadData()
        {
            DataSet ds = new DataSet();

            if (Connection.State != ConnectionState.Open)
            {
                Connection.Open();
                OnReadProgress(10);

            }

            try
            {
                var excelDataAdapter = new OleDbDataAdapter();

                OleDbCommand excelCommand = new OleDbCommand();

                DataTable dtPhone = Connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                foreach (DataRow row in dtPhone.Rows)
                {
                    excelCommand = new OleDbCommand(string.Format("SELECT * FROM [{0}]", row["TABLE_NAME"]), Connection);

                    excelDataAdapter.SelectCommand = excelCommand;
                    var tempDT = new DataTable();
                    excelDataAdapter.Fill(tempDT);
                    tempDT.TableName = row["TABLE_NAME"].ToString();
                    ds.Tables.Add(tempDT);
                }

            }
            catch (Exception)
            {

            }

            Connection.Dispose();
            Connection.Close();

            return ds.Tables.Count > 0 ? ds.Tables[0] : new DataTable();
        }



        public bool Export(DataTable tbl, bool createTable, bool overwriteFile)
        {
            var tableName = tbl.TableName.Replace(" ", "");
            tableName = String.IsNullOrEmpty(tableName) ? "Sheet1" : tableName;
            try
            {
                var infoEn = CultureInfo.GetCultureInfo("en-GB");
                var sql = "";
                if (overwriteFile)
                    if (File.Exists(_filepath))
                        File.Delete(_filepath);

                if (Connection.State != ConnectionState.Open)
                {
                    Connection.Open();
                    OnReadProgress(10);

                }
                OleDbCommand cmdInsert;
                if (createTable || !File.Exists(_filepath))
                {
                    sql = "CREATE TABLE " + tableName + " (";
                    for (int i = 0; i < tbl.Columns.Count; i++)
                    {
                        sql += tbl.Columns[i].ColumnName;
                        if (i + 1 == tbl.Columns.Count) //Here we decide should we close insert command or appebd another create column command
                            sql += " " + GetColumnType(tbl.Columns[i]) + ")"; //Close insert
                        else
                            sql += " " + GetColumnType(tbl.Columns[i]) + ","; //there is more columns to add
                    }
                }
                if (!String.IsNullOrEmpty(sql))
                {
                    cmdInsert = new OleDbCommand(sql, Connection);
                    cmdInsert.ExecuteNonQuery();
                }
                foreach (DataRow row in tbl.Rows)
                {
                    //Dodati parametre na comandu
                    string values = "(";
                    for (int i = 0; i < tbl.Columns.Count; i++)
                    {
                        if (i + 1 == tbl.Columns.Count)
                        {
                            if (tbl.Columns[i].DataType == Type.GetType("System.Decimal") ||
                                 tbl.Columns[i].DataType == Type.GetType("System.Int64") ||
                                 tbl.Columns[i].DataType == Type.GetType("System.Double"))
                                values += String.IsNullOrEmpty(row[i].ToString()) ? "0)" : Convert.ToDecimal(row[i]).ToString("0.00", infoEn) + ")";
                            else
                                values += "'" + System.Security.SecurityElement.Escape(row[i].ToString()) + "')";
                        }
                        else
                        {
                            if (tbl.Columns[i].DataType == Type.GetType("System.Decimal") ||
                                 tbl.Columns[i].DataType == Type.GetType("System.Int64") ||
                                 tbl.Columns[i].DataType == Type.GetType("System.Double"))
                                values += String.IsNullOrEmpty(row[i].ToString()) ? "0," : Convert.ToDecimal(row[i]).ToString("#0.00", infoEn) + ",";
                            else
                                values += "'" + System.Security.SecurityElement.Escape(row[i].ToString()) + "',";
                        }
                    }
                    string sqlInsert = String.Format("Insert into [{0}$] VALUES {1}", tableName, values);
                    cmdInsert = new OleDbCommand(sqlInsert, Connection);

                    cmdInsert.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        private static string GetColumnType(DataColumn dataColumn)
        {
            string t;
            if (dataColumn.DataType == Type.GetType("System.Decimal"))
                t = "decimal";
            else if (dataColumn.DataType == Type.GetType("System.Int64"))
                t = "INT";
            else if (dataColumn.DataType == Type.GetType("System.Double"))
                t = "double";
            else
                t = "VARCHAR(255)";
            return t;
        }

        #region IDisposable Members

        public void Dispose()
        {
            if (_con != null && _con.State == ConnectionState.Open)
                _con.Close();
            if (_con != null)
                _con.Dispose();
            _con = null;
            _filepath = string.Empty;
        }

        #endregion
    }
}
