using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.DTO;

namespace DataAccess.DAO
{
   public  interface IExportSearchDAO
    {
        int AddRequestExport(ReportExcel requestInfo);

        int UpdateRequestExport(int requestID, short status, string urlDownload);
    }
}
