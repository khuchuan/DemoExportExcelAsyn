using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
namespace Paygate.Utility
{
   public class TelecomCard
    {

        public string Name { get; set; }
        public string Code { get; set; }
        public int Cate { get; set; }

        public List<TelecomCard> GetAllTelecomCard()
        {
            var json = System.Configuration.ConfigurationManager.AppSettings["TELECOMCARD"];
            var telecoms = new JavaScriptSerializer()
                 .Deserialize<IList<Telecom>>(json);
            var list = (from telecom in telecoms
                        let arr = telecom.Code.Split(',')
                        from s in arr
                        select new TelecomCard { Name = telecom.Name, Code = s, Cate = telecom.Cate }).ToList();


            return list;

        }


        public List<int> GetAllAmount()
        {
            var amount = System.Configuration.ConfigurationManager.AppSettings["TELECOM.AMOUNT"];
            return amount.Split(',').Select(s => Convert.ToInt32(s)).ToList();
        }
    }
}
