using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignCakesApp.Core.Entities
{
    public  class Payments
    {
        public int id { get; set; }
        public string paymenttype { get; set; }
        public string amount { get; set; }
        public string date { get; set; }
        public decimal? orderid { get; set; }
        public string clerk {  get; set; }
        public string? description { get; set; }

        public string? expensedetail  { get; set; }
    }
}
