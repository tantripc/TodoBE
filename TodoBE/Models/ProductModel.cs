using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoBE.Models
{
    public class ProductVM
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public byte DiscountPrice { get; set; }

        public int? CategoryID { get; set; }
    }

    public class ProductModel : ProductVM
    {
        public Guid ProductID { get; set; }
    }
}
