using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoBE.Data
{
    public class Order
    {
        public Guid OrderID { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string Receiver { get; set; }
        public string ReceivingAddress { get; set; }
        public string Phone { get; set; }
        public Statuses Status { get; set; }

        #region Relationship
        public ICollection<OrderDetail> OrderDetails { get; set; }
        #endregion

        public Order()
        {
            OrderDetails = new List<OrderDetail>();
        }
    }

    public enum Statuses : int
    {
        New = 0,
        Payment = 1,
        Complete = 2,
        Cancel = -1
    }
}
