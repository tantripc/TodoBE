using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoBE.Data
{
    public class OrderDetail
    {
        public Guid ProductID { get; set; }
        public Guid OrderID { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public byte DiscountPrice { get; set; }

        #region Relationship
        public Product Product { get; set; }
        public Order Order { get; set; }
        #endregion
    }
}
