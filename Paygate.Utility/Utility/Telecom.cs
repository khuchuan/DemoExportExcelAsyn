using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Serialization;

namespace Paygate.Utility
{
    public class Telecom
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public int Cate { get; set; }

        public List<Telecom> GetAllTelecom()
        {
            var json = System.Configuration.ConfigurationManager.AppSettings["TELECOM"];
            var telecoms = new JavaScriptSerializer()
                 .Deserialize<IList<Telecom>>(json);
            var list = (from telecom in telecoms
                        let arr = telecom.Code.Split(',')
                        from s in arr
                        select new Telecom { Name = telecom.Name, Code = s, Cate = telecom.Cate }).ToList();


            return list;

        }
        public List<Telecom> GetAllTelecomAfter()
        {
            var json = System.Configuration.ConfigurationManager.AppSettings["TELECOM.AFTER"];
            var telecoms = new JavaScriptSerializer()
                 .Deserialize<IList<Telecom>>(json);
            var list = (from telecom in telecoms
                        let arr = telecom.Code.Split(',')
                        from s in arr
                        select new Telecom { Name = telecom.Name, Code = s, Cate = telecom.Cate }).ToList();


            return list;

        }

        public List<int> GetAllAmount()
        {
            var amount = System.Configuration.ConfigurationManager.AppSettings["TELECOM.AMOUNT"];
            return amount.Split(',').Select(s => Convert.ToInt32(s)).ToList();
        }

        public bool CheckPhoneNumber(string phoneNumber)
        {
            try
            {
                if (string.IsNullOrEmpty(phoneNumber) || phoneNumber.Length < 10 || phoneNumber.Length > 11)
                    return false;

                if (!Config.IsNumber(phoneNumber))
                    return false;

                string headPhone = phoneNumber.Length == 10 ? phoneNumber.Substring(0, 3) : phoneNumber.Substring(0, 4);
                List<Telecom> list = GetAllTelecom();
              
                foreach (Telecom telecom in list)
                {
                    if (telecom.Code == headPhone)
                        return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                NLogLogger.PublishException(ex);
                return false;
            }
        }
    }
}
