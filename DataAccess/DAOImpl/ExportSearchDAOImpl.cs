using System;
using System.Data;
using System.Data.SqlClient;
using DataAccess.DAO;
using DataAccess.DTO;
using Paygate.Utility;

namespace DataAccess.DAOImpl
{
    public class ExportSearchDAOImpl : IExportSearchDAO
    {
        public int AddRequestExport(ReportExcel requestInfo)
        {
            try
            {
                var parameters = new SqlParameter[6];
                parameters[0] = new SqlParameter("@_SPName", requestInfo.SPName);
                parameters[1] = new SqlParameter("@_Param", requestInfo.Param);
                parameters[2] = new SqlParameter("@_Status", requestInfo.Status);
                parameters[3] = new SqlParameter("@_CreateTime", requestInfo.CreateTime);                
                parameters[4] = new SqlParameter("@_UserName", requestInfo.UserName);
                parameters[5] = new SqlParameter("@_ReturnValue", SqlDbType.Int) { Direction = ParameterDirection.ReturnValue };
                new DBHelpers.DBHelper(Config.ExportExcellConnectionString).ExecuteNonQuerySP("SP_Insert_ReportExcel", parameters);
                return Convert.ToInt32(parameters[5].Value);
            }
            catch (Exception exception)
            {
                NLogLogger.PublishException(exception);
                return -99;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="requestID"></param>
        /// <param name="status"></param>
        /// <param name="urlDownload"></param>
        /// <returns> >0: Update thanh cong; <=0: Update that bai </returns>
        public int UpdateRequestExport(int requestID, short status, string urlDownload)
        {
            try
            {
                var parameters = new SqlParameter[4];
                parameters[0] = new SqlParameter("@_RequestID", requestID);
                parameters[1] = new SqlParameter("@_Status", status);
                parameters[2] = new SqlParameter("@_UrlDownload", urlDownload);  
                parameters[3] = new SqlParameter("@_ReturnValue", SqlDbType.Int) { Direction = ParameterDirection.ReturnValue };
                new DBHelpers.DBHelper(Config.ExportExcellConnectionString).ExecuteNonQuerySP("[SP_tblReportExcel_Update]", parameters);
                return Convert.ToInt32(parameters[3].Value);
            }
            catch (Exception exception)
            {
                NLogLogger.PublishException(exception);
                return -99;
            }
        }



    }
}
