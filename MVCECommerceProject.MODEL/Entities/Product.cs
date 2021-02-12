using MVCECommerceProject.CORE.Entity;
using System;
using System.Collections.Generic;

namespace MVCECommerceProject.MODEL.Entities
{
    public class Product : CoreEntity
    {
        public string ProductName { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }
        public string ImagePath { get; set; }
        public Guid SubCategoryID { get; set; }

        //Mapping
        public virtual SubCategory SubCategory { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }
    }
}