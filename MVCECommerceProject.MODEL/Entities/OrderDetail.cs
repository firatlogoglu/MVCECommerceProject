using MVCECommerceProject.CORE.Entity;

namespace MVCECommerceProject.MODEL.Entities
{
    public class OrderDetail : CoreEntity
    {
        public Product Product { get; set; }
        public Order Orders { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? Quantity { get; set; }
    }
}