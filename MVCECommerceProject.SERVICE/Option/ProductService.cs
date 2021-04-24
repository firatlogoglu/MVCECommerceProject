using MVCECommerceProject.MODEL.Entities;
using MVCECommerceProject.SERVICE.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MVCECommerceProject.SERVICE.Option
{
    public class ProductService : BaseService<Product>
    {
        /// <summary>
        /// Satıcının tüm ürünlerinin getirilmesi
        /// </summary>
        /// <param name="sid"></param>
        /// <returns></returns>
        public List<Product> FindSellerProducts(Guid sid)
        {
            var v1 = db.Products.Where(x => x.SellerID == sid).Join(
                db.SubCategories,
                subp => subp.SubCategory.ID,
                p => p.ID,
                (pro, subc) => new { pro, subc });

            List<Product> products = new List<Product>();
            foreach (var item in v1)
            {
                Product product = new Product();
                product.ID = item.pro.ID;
                product.ProductName = item.pro.ProductName;
                product.ImagePath = item.pro.ImagePath;
                product.UnitsInStock = item.pro.UnitsInStock;
                product.UnitPrice = item.pro.UnitPrice;
                product.Status = item.pro.Status;
                product.SubCategory = item.subc;
                product.SubCategoryID = item.pro.SubCategory.ID;
                product.SellerID = item.pro.SellerID;
                product.Seller = item.pro.Seller;
                products.Add(product);
            }
            return (products);
        }

        /// <summary>
        /// Satıcının aktif olan tüm ürünlerin getirilmesi
        /// </summary>
        /// <param name="sid"></param>
        /// <returns></returns>
        public List<Product> FindSellerActivedProducts(Guid sid)
        {
            var v1 = db.Products.Where(x => x.SellerID == sid).Join(
                db.SubCategories,
                subp => subp.SubCategory.ID,
                p => p.ID,
                (pro, subc) => new { pro, subc });

            List<Product> products = new List<Product>();
            foreach (var item in v1)
            {
                if (item.pro.Status == CORE.Enums.Status.Active)
                {
                    Product product = new Product();
                    product.ID = item.pro.ID;
                    product.ProductName = item.pro.ProductName;
                    product.ImagePath = item.pro.ImagePath;
                    product.UnitsInStock = item.pro.UnitsInStock;
                    product.UnitPrice = item.pro.UnitPrice;
                    product.Status = item.pro.Status;
                    product.SubCategory = item.subc;
                    product.SubCategoryID = item.pro.SubCategory.ID;
                    product.SellerID = item.pro.SellerID;
                    product.Seller = item.pro.Seller;
                    products.Add(product);
                }
            }
            return (products);
        }

        public List<Product> FindCustomerProducts(Guid cid)
        {
            var v1 = db.Orders.Where(x => x.CustomerID == cid).ToList();
            List<Product> products = new List<Product>();
            foreach (var item in v1)
            {
                foreach (var ord in item.OrderDetails)
                {
                    Product product = new Product();
                    //product = ord.Product;
                    product.ID = ord.ProductID;
                    product.ProductName = ord.Product.ProductName;
                    product.ImagePath = ord.Product.ImagePath;
                    product.UnitPrice = ord.UnitPrice;
                    product.UnitsInStock = ord.Quantity;
                    product.SubCategory = ord.Product.SubCategory;
                    product.Seller = ord.Product.Seller;

                    //TODO: VM yapılacak
                    products.Add(product);
                }
            }
            return (products);
        }

        /// <summary>
        /// Kategorinin bağlı olan aktif ürünlerinin getirilmesi
        /// </summary>
        /// <param name="cateid"></param>
        /// <returns></returns>
        public List<Product> FindCategoryActivedProducts(Guid cateid)
        {
            var v1 = db.Categories.Where(x => x.ID == cateid).ToList();
            List<Product> products = new List<Product>();
            foreach (var item in v1)
            {
                foreach (var ord in item.SubCategories)
                {

                    foreach (var pro in ord.Products)
                    {
                        if (pro.Status == CORE.Enums.Status.Active)
                        {
                            Product product = new Product();
                            product = pro;

                            products.Add(product);
                        }
                    }
                }
            }
            return (products);
        }

        /// <summary>
        ///  Alt kategoriye bağlı olan aktif ürünlerinin getirilmesi
        /// </summary>
        /// <param name="cateid"></param>
        /// <returns></returns>
        public List<Product> FindSubCategoryActivedProducts(Guid cateid)
        {
            var v1 = db.SubCategories.Where(x => x.ID == cateid).ToList();
            List<Product> products = new List<Product>();
            foreach (var item in v1)
            {
                foreach (var pro in item.Products)
                {
                    if (pro.Status == CORE.Enums.Status.Active)
                    {
                        Product product = new Product();
                        product = pro;

                        products.Add(product);
                    }
                }
            }
            return (products);
        }
    }
}