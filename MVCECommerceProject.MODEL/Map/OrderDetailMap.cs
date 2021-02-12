using MVCECommerceProject.CORE.Map;
using MVCECommerceProject.MODEL.Entities;

namespace MVCECommerceProject.MODEL.Map
{
    public class OrderDetailMap : CoreMap<OrderDetail>
    {
        public OrderDetailMap()
        {
            ToTable("dbo.OrderDetails");
            Property(x => x.UnitPrice).IsOptional();
            Property(x => x.Quantity).IsOptional();
        }
    }
}