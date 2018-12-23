using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkStation
{
    public class Transaction
    {
        public int ID { get; set; }
        public string ProductName { get; set; }
        public decimal ProducValue { get; set; }
        public string Description { get; set; }
        public string MerchantName { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerAddress { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }

    }


}
