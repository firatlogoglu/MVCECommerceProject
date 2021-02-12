using MVCECommerceProject.CORE.Map;
using MVCECommerceProject.MODEL.Entities;

namespace MVCECommerceProject.MODEL.Map
{
    public class SubCategoryMap : CoreMap<SubCategory>
    {
        public SubCategoryMap()
        {
            ToTable("dbo.SubCategories");

            HasMany(x => x.Products).WithRequired(x => x.SubCategory).HasForeignKey(x => x.SubCategoryID);
        }
    }
}