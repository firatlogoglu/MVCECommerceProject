using MVCECommerceProject.CORE.Map;
using MVCECommerceProject.MODEL.Entities;

namespace MVCECommerceProject.MODEL.Map
{
    public class CategoryMap : CoreMap<Category>
    {
        public CategoryMap()
        {
            ToTable("dbo.Categories");

            HasMany(x => x.SubCategories).WithRequired(x => x.Category).HasForeignKey(x => x.CategoryID);
        }
    }
}