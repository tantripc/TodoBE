using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TodoBE.Data
{
    [Table("OrderDetails")]
    public class OrderDetail
    {
        public Guid ProductID { get; set; }
        public Guid OrderID { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public byte DiscountPrice { get; set; }

        #region Relationship
        [ForeignKey("ProductID")]
        public Product Product { get; set; }
        [ForeignKey("OrderID")]
        public Order Order { get; set; }
        #endregion
    }
}
