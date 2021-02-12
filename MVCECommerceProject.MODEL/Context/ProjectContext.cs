using MVCECommerceProject.CORE.Entity;
using MVCECommerceProject.MODEL.Entities;
using MVCECommerceProject.MODEL.Map;
using System;
using System.Data.Entity;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace MVCECommerceProject.MODEL.Context
{
    public class ProjectContext : DbContext
    {
        public ProjectContext()
        {
            Database.Connection.ConnectionString = "server=.;database=NTierProjectDB;uid=sa;pwd=123";
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AppUserMap());
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new SubCategoryMap());
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new OrderMap());
            modelBuilder.Configurations.Add(new OrderDetailMap());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<AppUser> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }

        public override int SaveChanges()
        {
            var modifedEntry = ChangeTracker.Entries().Where(x => x.State == EntityState.Modified || x.State == EntityState.Added);

            string identity = WindowsIdentity.GetCurrent().Name;
            string computerName = Environment.MachineName;
            DateTime dateTime = DateTime.Now;
            int user = 1;
            string ip = "";

            if (HttpContext.Current == null)
            {
                ip = "192.168.1.1";
            }
            else
            {
                ip = HttpContext.Current.Request.UserHostAddress.ToString();
            }

            foreach (var item in modifedEntry)
            {
                CoreEntity entity = item.Entity as CoreEntity;

                if (item != null)
                {
                    if (item.State == EntityState.Added)
                    {
                        entity.CreatedADUsername = identity;
                        entity.CreatedComputerName = computerName;
                        entity.CreatedDate = dateTime;
                        entity.CreatedBy = user;
                        entity.CreatedIP = ip;
                    }
                    else if (item.State == EntityState.Modified)
                    {
                        entity.ModifiedADUsername = identity;
                        entity.ModifiedComputerName = computerName;
                        entity.ModifiedDate = dateTime;
                        entity.ModifiedBy = user;
                        entity.ModifiedIP = ip;
                    }
                }
            }

            return base.SaveChanges();
        }
    }
}