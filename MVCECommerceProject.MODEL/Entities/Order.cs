using MVCECommerceProject.CORE.Entity;
using System;
using System.Collections.Generic;

namespace MVCECommerceProject.MODEL.Entities
{
    public class Order : CoreEntity
    {
        public Order()
        {
            OrderDetails = new List<OrderDetail>();
        }

        public Guid SellerID { get; set; }
        public Guid CustomerID { get; set; }
        public virtual AppUser Customer { get; set; }
        public virtual AppUser Seller { get; set; }
        public bool Confirmed { get; set; }

        //Mapping
        public virtual List<OrderDetail> OrderDetails { get; set; }
    }
}