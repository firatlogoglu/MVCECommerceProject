using MVCECommerceProject.CORE.Entity;
using System.Data.Entity.ModelConfiguration;

namespace MVCECommerceProject.CORE.Map
{
    public class CoreMap<T> : EntityTypeConfiguration<T> where T : CoreEntity
    {
        public CoreMap()
        {
            Property(x => x.Status).HasColumnName("Status").IsOptional();
            Property(x => x.CreatedDate).HasColumnName("CreatedDate");
        }
    }
}