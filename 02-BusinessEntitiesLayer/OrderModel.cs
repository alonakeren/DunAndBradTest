using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DunBrad
{
    public class OrderModel
    {
        public int ORD_NUM { get; set; }
        public double ORD_AMOUNT { get; set; }
        public double ADVANCE_AMOUNT { get; set; }
        public System.DateTime ORD_DATE { get; set; }
        public string CUST_CODE { get; set; }
        public string AGENT_CODE { get; set; }
        public string ORD_DESCRIPTION { get; set; }
    }
}
