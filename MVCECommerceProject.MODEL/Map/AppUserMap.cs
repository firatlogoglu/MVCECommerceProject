using MVCECommerceProject.CORE.Map;
using MVCECommerceProject.MODEL.Entities;

namespace MVCECommerceProject.MODEL.Map
{
    public class AppUserMap : CoreMap<AppUser>
    {
        public AppUserMap()
        {
            ToTable("dbo.Users");
            Property(x => x.Address).IsOptional();
            Property(x => x.BirthDate).HasColumnType("datetime2").IsOptional();
            Property(x => x.Email).HasMaxLength(50).IsOptional();
            //Property(x => x.UserName).HasMaxLength(50).IsRequired();
            Property(x => x.PhoneNumber).IsOptional();
            Property(x => x.Role).IsOptional();
            Property(x => x.Name).HasMaxLength(50).IsRequired();
            Property(x => x.SurName).HasMaxLength(50).IsRequired();
            Property(x => x.ImagePath).IsOptional();
        }
    }
}