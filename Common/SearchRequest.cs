using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class SearchRequest
    {
        public string SPName { get; set; }
        public string UserName { get; set; }
        public string Params { get; set; }  // La chuoi json cua mot object, tuy tung SP ma se map voi doi tuong cu the
        public int RequestID { get; set; }
    }

    public class Param
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string City { get; set; }
        public int Status { get; set; }
    }
}
