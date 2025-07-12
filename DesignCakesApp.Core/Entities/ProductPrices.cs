using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignCakesApp.Core.Entities
{
    public  class ProductPrices
    {
        public int id { get; set; }
        public int SizeId { get; set; }
        public string Price { get; set; }
        public int ProductId { get; set; }
    }
}
