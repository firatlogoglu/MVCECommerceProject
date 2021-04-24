using MVCECommerceProject.CORE.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVCECommerceProject.MODEL.Entities
{
    public class OrderDetail : CoreEntity
    {
        public Guid ProductID { get; set; }
        public Guid OrderID { get; set; }


        [Required(ErrorMessage = "Lütfen ürünün birim fiyatını girin"), Display(Name = "Birim Fiyatı")]
        public decimal UnitPrice { get; set; }

        [Required(ErrorMessage = "Lütfen miktarı girin"), Display(Name = "Miktar")]
        public short Quantity { get; set; }

        [Required(ErrorMessage = "Lütfen indirim/iskonto oranını girin"), Display(Name = "İndirim/İskonto Oranı")]
        public float Discount { get; set; }

        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }
    }
}