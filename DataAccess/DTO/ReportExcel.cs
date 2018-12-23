using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.DTO
{
    public class ReportExcel
    {
        public int RequestID { get; set; }
        public string SPName { get; set; }
        public string Param { get; set; }
        public short Status { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public string UrlDownload { get; set; }
        public string UserName { get; set; }
    }


}
