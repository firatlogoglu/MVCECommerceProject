using MVCECommerceProject.CORE.Map;
using MVCECommerceProject.MODEL.Entities;

namespace MVCECommerceProject.MODEL.Map
{
    public class OrderMap : CoreMap<Order>
    {
        public OrderMap()
        {
            ToTable("dbo.Orders");

            HasRequired(x => x.AppUser).WithMany(x => x.Orders).HasForeignKey(x => x.AppUserID);
        }
    }
}