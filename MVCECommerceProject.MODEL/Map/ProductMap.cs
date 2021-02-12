using MVCECommerceProject.CORE.Map;
using MVCECommerceProject.MODEL.Entities;

namespace MVCECommerceProject.MODEL.Map
{
    public class ProductMap : CoreMap<Product>
    {
        public ProductMap()
        {
            ToTable("dbo.Products");
        }
    }
}