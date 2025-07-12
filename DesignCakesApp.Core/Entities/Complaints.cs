using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignCakesApp.Core.Entities
{
    public class Complaints
    {
        public int id { get; set; }
        public int customerId { get; set; }
        public int orderId { get; set; }
        public string complaint { get; set; }

        public string @date { get; set; } 
    }
}
