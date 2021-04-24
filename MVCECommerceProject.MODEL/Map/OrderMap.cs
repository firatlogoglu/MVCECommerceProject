using MVCECommerceProject.CORE.Map;
using MVCECommerceProject.MODEL.Entities;

namespace MVCECommerceProject.MODEL.Map
{
    public class OrderMap : CoreMap<Order>
    {
        public OrderMap()
        {
            ToTable("dbo.Orders");

            Property(x => x.CustomerID).HasColumnName("CID").IsOptional();
            Property(x => x.SellerID).HasColumnName("SID").IsOptional();
            HasOptional(x => x.Customer).WithMany(x => x.Customers).HasForeignKey(x => x.CustomerID);
            HasOptional(x => x.Seller).WithMany(x => x.Sellers).HasForeignKey(x => x.SellerID);
            //HasRequired(x => x.Customer).WithMany(x => x.Orders).HasForeignKey(x => x.CustomerID);
            //HasRequired(x => x.Seller).WithMany(x => x.Orders).HasForeignKey(x => x.SellerID);
        }
    }
}