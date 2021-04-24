using System;
using System.ComponentModel.DataAnnotations;

namespace MVCECommerceProject.MODEL.CartModel
{
    public class CartItem
    {
        public CartItem()
        {
            Quantity = 1;
        }
        public Guid ID { get; set; }

        [Display(Name = "Ürün Adı")]
        public string Name { get; set; }
        public short Quantity { get; set; }
        public decimal Price { get; set; }

        [Display(Name = "Görsel")]
        public string ImagePath { get; set; }
        public Guid SellerID { get; set; }
        public string SellerName { get; set; }

        public decimal SubTotal
        {
            get
            {
                return Price * Quantity;
            }
        }
    }
}