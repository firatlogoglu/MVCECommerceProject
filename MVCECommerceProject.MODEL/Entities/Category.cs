using MVCECommerceProject.CORE.Entity;
using System.Collections.Generic;

namespace MVCECommerceProject.MODEL.Entities
{
    public class Category : CoreEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        //Mapping
        public virtual List<SubCategory> SubCategories { get; set; }
    }
}