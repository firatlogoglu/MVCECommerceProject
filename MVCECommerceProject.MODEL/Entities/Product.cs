using MVCECommerceProject.CORE.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVCECommerceProject.MODEL.Entities
{
    public class Product : CoreEntity
    {
        [Required(ErrorMessage = "Lütfen ürün adını girin"), Display(Name = "Ürün Adı")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Lütfen ürünün birim fiyatını girin"), Display(Name = "Birim Fiyatı")]
        public decimal UnitPrice { get; set; }

        [Required(ErrorMessage = "Lütfen ürünün stoktaki birim miktarını girin"), Display(Name = "Stoktaki Birim Miktarı")]
        public short UnitsInStock { get; set; }

        [Display(Name = "Görsel")]
        public string ImagePath { get; set; }

        //TODO: MARKA EKLENECEK

        public Guid SubCategoryID { get; set; }

        public Guid SellerID { get; set; }
        public virtual AppUser Seller { get; set; }

        //Mapping
        public virtual SubCategory SubCategory { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }
    }
}