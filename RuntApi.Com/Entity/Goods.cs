using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuntApi.Com.Entity
{
    public class Goods
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool IsSale { get; set; }
        public int Stock { get; set; }
    }
}
