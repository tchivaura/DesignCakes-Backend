using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignCakesApp.Core.Entities
{
    public class Orders
    {
        public int id { get; set; }
        public string orderdate { get; set; }
        public int orderproduct { get; set; }
        public int size { get; set; }
        public decimal orderperson { get; set; }
        public string  price { get; set; }
        public string extrainstructions { get; set; }

        public string occasion { get; set; }
        public int customerid { get; set; }
        public string orderstatus { get; set; }
        public string clerk { get; set; }

        public decimal quantity { get; set; }

       
    }
}

